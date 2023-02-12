using AdvancedSharpAdbClient.Exceptions;
using AdvancedSharpAdbClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Windows.Forms;
using static OculusTouchUI.OculusWrapper;
using System.Net.Sockets;
using System.Text.RegularExpressions;
/*using VRCOSC.OpenVR;
using VRCOSC.OpenVR.Metadata;
using Valve.VR;
using VRCOSC.OpenVR.Device;*/

namespace OculusTouchUI
{
    /*internal class OVRDispatcher
    {
        private static OVRClient ovrClient;
        public static void Initialize()
        {
            if (ovrClient != null)
                return;
            ovrClient = new OVRClient(new OVRMetadata
            {
                ApplicationType = EVRApplicationType.VRApplication_Background,
                ApplicationManifest = string.Empty,
                ActionManifest = string.Empty
            });
            OVRHelper.OnError += m => Console.WriteLine($"OpenVR Exception: {m}");
            ovrClient.Init();
            //ovrclient.OnShutdown += () => Console.WriteLine($"OpenVR Shutdown");
        }
        public static IEnumerable<Tracker> GetTrackers()
        {
            ovrClient.Update();
            return ovrClient.Trackers.Where(x => x.IsConnected);
        }
    }*/
    internal static class ADB
    {
        static public AdbClient client;
        static public DeviceData device;
        public static string deviceSerial;
        public static string deviceModel;
        public static string deviceName;
        public static DeviceState deviceState;
        public static bool isConnected;
        public static bool wirelessConnection;


        public static string headsetBattery = "N/A";
        public static string rTouchBattery = "N/A";
        public static string lTouchBattery = "N/A";
        public static bool batteryFetched = false;

        public static void StartADB()
        {
            if (!AdbServer.Instance.GetStatus().IsRunning)
            {
                AdbServer server = new AdbServer();
                try
                {
                    bool exists = Directory.Exists("platform-tools"); // ADB Auto donwloader
                    if (!exists)
                    {
                        MessageBox.Show("ADB directory does not exist, creating...\nDowloading ADB");
                        var client = new WebClient();
                        string uri = "https://dl.google.com/android/repository/platform-tools-latest-windows.zip";
                        string filename = "platform-tools-latest-windows.zip";
                        string extractPath = AppDomain.CurrentDomain.BaseDirectory;
                        client.DownloadFile(uri, filename);
                        ZipFile.ExtractToDirectory(filename, extractPath);
                        File.Delete(filename);
                        MessageBox.Show("Download completed");
                    }
                    StartServerResult result = server.StartServer(@"platform-tools\adb.exe", false);
                    if (result != StartServerResult.Started)
                    {
                        MessageBox.Show($"Can't start adb server, please restart app and try again {result}");
                    }

                }
                catch (WebException wExc)
                {
                    MessageBox.Show($"Unable to download ADB from Google servers, try again or download files manually https://developer.android.com/studio/releases/platform-tools, press any key to exit\n{wExc.Message}");
                }
            }
            else
            {
                MessageBox.Show("ADB server is already running, no checks are required");
            }
            client = new AdbClient();
            while (!isConnected)
            {
                client.Connect("127.0.0.1:62001");
                var devices = client.GetDevices();
                if (devices.Count() == 0)
                {
                    var fileName = $"deviceIp.txt";
                    if (File.Exists(fileName))
                    {
                        //192.168.2.102
                        var diviceIp = File.ReadAllText(fileName);
                        if (diviceIp.Split('.').Count() == 4)
                        {
                            client.Connect($"{diviceIp}:5555");
                            devices = client.GetDevices();
                        }
                    }
                    else
                        MessageBox.Show("Please create deviceIp.txt id current program directory with headset local-IP");
                }
                device = devices.First();
                if (device.Model == "Quest_2")
                {
                    try
                    {
                        deviceSerial = device.Serial;
                        deviceModel = device.Model;
                        deviceName = device.Name;
                        deviceState = device.State;
                        if (device.Serial.Contains('.') && device.Serial.Split('.').Count() == 4)
                            wirelessConnection = true;
                        isConnected = true;
                        MessageBox.Show($"Successfully connected via {(wirelessConnection ? "Wi-Fi" : "Usb")} to {deviceModel} ({deviceName}) [{deviceSerial}] state: {deviceState}");
                    }
                    catch (AdbException adbExc)
                    {
                        MessageBox.Show($"Error connecting to headset {adbExc.Message}\nTrying again in 3 seconds...");
                        Thread.Sleep(3000);
                    }
                }
            }

            Thread batteryUpdater = new Thread(() =>
            {
                int Hbatlevelint = 0;
                int Rbatlevelint = 0;
                int Lbatlevelint = 0;
                while (true)
                {
                    try
                    {

                        ConsoleOutputReceiver Hbat_receiver = new ConsoleOutputReceiver();
                        ADB.client.ExecuteRemoteCommand("dumpsys CompanionService | grep Battery", ADB.device, Hbat_receiver);
                        ConsoleOutputReceiver Lbat_receiver = new ConsoleOutputReceiver();
                        ADB.client.ExecuteRemoteCommand("dumpsys OVRRemoteService | grep Left", ADB.device, Lbat_receiver);
                        ConsoleOutputReceiver Rbat_receiver = new ConsoleOutputReceiver();
                        ADB.client.ExecuteRemoteCommand("dumpsys OVRRemoteService | grep Right", ADB.device, Rbat_receiver);

                        var Hbat_match = Regex.Match(Hbat_receiver.ToString(), @"\d+", RegexOptions.RightToLeft);
                        var Lbat_match = Regex.Match(Lbat_receiver.ToString(), @"\d+", RegexOptions.RightToLeft);
                        var Rbat_match = Regex.Match(Rbat_receiver.ToString(), @"\d+", RegexOptions.RightToLeft);

                        try
                        {
                            Hbatlevelint = int.Parse(Hbat_match.Value);
                            Lbatlevelint = int.Parse(Lbat_match.Value);
                            Rbatlevelint = int.Parse(Rbat_match.Value);
                            headsetBattery = Hbatlevelint.ToString() + "%";
                            lTouchBattery = Lbatlevelint.ToString() + "%";
                            rTouchBattery = Rbatlevelint.ToString() + "%";
                        }
                        catch
                        {
                            headsetBattery = Hbat_match.Value;
                            lTouchBattery = Lbat_match.Value;
                            rTouchBattery = Rbat_match.Value;
                        }

                        batteryFetched = true;
                        Thread.Sleep(3000);

                    }
                    catch (AdbException)
                    {
                        headsetBattery = lTouchBattery = rTouchBattery = "N/A";
                        batteryFetched = false;
                        Thread.Sleep(3000);
                    }
                }
            });
            batteryUpdater.IsBackground = true;
            batteryUpdater.Start();
        }
    }
}
