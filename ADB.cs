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

namespace OculusTouchUI
{
    static class Sender
    {
        public static float Hbatlevelf = 0f;
        public static float Rbatlevelf = 0f;
        public static float Lbatlevelf = 0f;
        public static bool fetched = false;
        public static async void Run()
        {
            await questwd();
        }

        public static async Task questwd()
        {
            while (true)
            {
                try
                {
                    int Hbatlevelint = 0;
                    int Rbatlevelint = 0;
                    int Lbatlevelint = 0;

                    ConsoleOutputReceiver Hbat_receiver = new ConsoleOutputReceiver();
                    ADB.client.ExecuteRemoteCommand("dumpsys CompanionService | grep Battery", ADB.device, Hbat_receiver);
                    ConsoleOutputReceiver Rbat_receiver = new ConsoleOutputReceiver();
                    ADB.client.ExecuteRemoteCommand("dumpsys OVRRemoteService | grep Right", ADB.device, Rbat_receiver);
                    ConsoleOutputReceiver Lbat_receiver = new ConsoleOutputReceiver();
                    ADB.client.ExecuteRemoteCommand("dumpsys OVRRemoteService | grep Left", ADB.device, Lbat_receiver); ;

                    var Hbat_match = Regex.Match(Hbat_receiver.ToString(), @"\d+", RegexOptions.RightToLeft);
                    var Rbat_match = Regex.Match(Rbat_receiver.ToString(), @"\d+", RegexOptions.RightToLeft);
                    var Lbat_match = Regex.Match(Lbat_receiver.ToString(), @"\d+", RegexOptions.RightToLeft);

                    Hbatlevelint = int.Parse(Hbat_match.Value);
                    Rbatlevelint = int.Parse(Rbat_match.Value);
                    Lbatlevelint = int.Parse(Lbat_match.Value);
                    Hbatlevelf = Hbatlevelint;
                    Rbatlevelf = Rbatlevelint;
                    Lbatlevelf = Lbatlevelint;
                    fetched = true;

                    if (Hbatlevelf < 15)
                    {
                        //MessageBox.Show("Headset is discharged, disabled or not connected");
                    }
                    if (Rbatlevelf < 15)
                    {
                        //MessageBox.Show("Right controller is discharged, disabled or not connected");
                    }
                    if (Lbatlevelf < 15)
                    {
                        //MessageBox.Show("Left controller is discharged, disabled or not connected");
                    }
                    Thread.Sleep(3000);

                }
                catch (AdbException)
                {
                    Hbatlevelf = Rbatlevelf = Lbatlevelf = 0f;
                    fetched = false;
                    //Form1.currentBattery = "Error: connection to the headset is lost!";
                    Thread.Sleep(3000);
                }
            }


        }
    }
    internal class ADB
    {
        static public AdbClient client;
        static public DeviceData device;
        public static string deviceSerial;
        public static string deviceModel;
        public static string deviceName;
        public static DeviceState deviceState;
        public static bool isMeta;
        public static bool isConnected;

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
                        MessageBox.Show("Can't start adb server, please restart app and try again");
                    }

                }
                catch (WebException)
                {
                    MessageBox.Show("Unable to download ADB from Google servers, try again or download files manually https://developer.android.com/studio/releases/platform-tools, press any key to exit");

                }

            }
            else
            {
                MessageBox.Show("ADB server is already running, no checks are required");
            }

            client = new AdbClient();
            client.Connect("127.0.0.1:62001");
            device = client.GetDevices().FirstOrDefault();
            try
            {

                if (device == null)
                {
                    isConnected = false;
                    //MessageBox.Show("No devices found, please restart app and try again");
                    return;
                }
                if (device.Name != "hollywood" && device.Name != "vr_monterey" && device.Name != "monterey" && device.Name != "seacliff")
                {
                    deviceSerial = device.Serial;
                    deviceModel = device.Model;
                    deviceState = device.State;
                    isMeta = false;
                    isConnected = true;
                    //Form1.currentDevice = $"Not meta-device found: Model: {device.Model} Codename: {device.Name} State: {device.State}";
                    //MessageBox.Show($"Not meta-device found: \nModel: {device.Model}\nCodename: {device.Name} \nState: {device.State}");
                }
                if (device != null)
                {
                    deviceSerial = device.Serial;
                    deviceModel = device.Model;
                    deviceName = device.Name;
                    isMeta = isConnected = true;
                    //Form1.currentDevice = $"Serial or IP: {device.Serial} Model: {device.Model} Codename: {device.Name}";
                    //MessageBox.Show($"Selecting device:\nSerial or IP: {device.Serial}\nModel: {device.Model}\nCodename: {device.Name}");
                }
            }
            catch (AdbException)
            {
                isConnected = false;
                MessageBox.Show("Error: connection to the headset is lost!");
                Thread.Sleep(3000);
            }

            var tasks = new[]
            {
                Task.Factory.StartNew(() => Sender.Run(), TaskCreationOptions.LongRunning),
            };
        }
    }
}
