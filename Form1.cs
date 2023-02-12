using AdvancedSharpAdbClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OculusTouchUI.OculusWrapper;

namespace OculusTouchUI
{
    public partial class Form1 : Form
    {
        public static Form1 _instance;
        public Form1()
        {
            InitializeComponent();
            _instance = this;
            Start();
        }

        private void VibratePower_ValueChanged(object sender, System.EventArgs e)
        {
            this.vibratePowerLabel.Text = $"Power: {(Power)vibratePower.Value}";
        }

        private void VibrateStrength_ValueChanged(object sender, System.EventArgs e)
        {
        }

        private void VibrateButton_MouseHover(object sender, System.EventArgs e)
        {
            SetVibration(Device.HMD, Power.Low, 255, 0.05f);
        }

        private static bool isVibrating;
        private void VibrateButton_Click(object sender, EventArgs e)
        {
            isVibrating = !isVibrating;
            if (isVibrating)
            {
                var upd = new Thread(() =>
                {
                    while (isVibrating)
                    {
                        try { this.Invoke(new Action(() => { SetVibration(Device.HMD, (Power)vibratePower.Value, (byte)vibrateStrength.Value, 0); })); }
                        catch { }

                        Thread.Sleep(100);
                    }
                    try
                    { this.Invoke(new Action(() => { SetVibration(Device.HMD, 0, 0, 0); })); }
                    catch { }
                });
                upd.IsBackground = true;
                upd.SetApartmentState(ApartmentState.STA);
                upd.Start();
            }
        }

        private static bool readBattery = true;
        public void Start()
        {
            OculusWrapper.Start(false);
            if (readBattery)
            {
                ADB.StartADB();
            }
            var update = new Thread(() =>
            {
                Thread.Sleep(1000);
                while (true)
                {
                    OculusWrapper.Update();             //to request current state of controllers
                    var lStick = LStick();
                    var rStick = RStick();
                    var lRot = GetLTouchRot();
                    var rRot = GetRTouchRot();
                    var lPos = GetLTouchPos();
                    var rPos = GetRTouchPos();
                    try
                    {
                        _instance.Invoke(new Action(() =>
                        {
                            _instance.LTouchX.Value = (int)lStick.x;                            //between 0 and 255, use OculusWrapper.remap(lStick.x, 0, 255, newMinValue, newMaxValue)
                            _instance.LTouchY.Value = (int)lStick.y;                            //also y axis down is 255 and up is 0, thx oculus
                            _instance.LTouchXLabel.Text = $"LTouch X-Axis: {(int)lStick.x}";
                            _instance.LTouchYLabel.Text = $"LTouch Y-Axis: {(int)lStick.y}";

                            _instance.RTouchX.Value = (int)rStick.x;
                            _instance.RTouchY.Value = (int)rStick.y;
                            _instance.RTouchXLabel.Text = $"RTouch X-Axis: {(int)rStick.x}";
                            _instance.RTouchYLabel.Text = $"RTouch Y-Axis: {(int)rStick.y}";

                            _instance.LTrigger.Value = (int)GetLTrigger();                      //between 0 and 1
                            _instance.LTriggerLabel.Text = $"LTrigger: {(int)GetLTrigger()}";
                            _instance.RTrigger.Value = (int)GetRTrigger();
                            _instance.RTriggerLabel.Text = $"RTrigger: {(int)GetRTrigger()}";

                            string pressedButtons = "Pressed buttons: ";
                            if (GetA())
                                pressedButtons += "A";
                            if (GetB())
                                pressedButtons += "B";
                            if (GetX())
                                pressedButtons += "X";
                            if (GetY())
                                pressedButtons += "Y";
                            if (GetLStick())
                                pressedButtons += "LS";
                            if (GetRStick())
                                pressedButtons += "RS";
                            if (GetLMenu())                 //RMenu a.k.a oculus button isn't trackable for some reason
                                pressedButtons += "LMenu";
                            _instance.pressedLabel.Text = pressedButtons;

                            string touches = "Touches: ";
                            if (GetTouchA())
                                touches += "A";
                            if (GetTouchB())
                                touches += "B";
                            if (GetTouchX())
                                touches += "X";
                            if (GetTouchY())
                                touches += "Y";
                            if (GetTouchLTrigger())
                                touches += "LT";
                            if (GetTouchRTrigger())
                                touches += "RT";
                            if (GetTouchLStick())
                                touches += "LS";
                            if (GetTouchRStick())
                                touches += "RS";
                            if (GetTouchLStickRest())       //little black-circle area under X and Y buttons
                                touches += "LSRest";
                            if (GetTouchRStickRest())       //little black-circle area under A and B buttons
                                touches += "RSRest";




                            _instance.touchesLabel.Text = touches;
                            _instance.isInHeadset.Text = $"Is in Headset: {IsInHeadset()}";

                            _instance.LHand.Value = (int)GetLBump();                            //between 0 and 1
                            _instance.LHandLabel.Text = $"LHand: {(int)GetLBump()}";
                            _instance.RHand.Value = (int)GetRBump();
                            _instance.RHandLabel.Text = $"RHand: {(int)GetRBump()}";

                            int y = (int)getYaw((int)Device.RTouch);
                            int p = (int)getPitch((int)Device.RTouch);
                            int r = (int)getRoll((int)Device.RTouch);
                            _instance.ltYaw.Value = (int)lRot.x;                                //between 0 and 100
                            _instance.ltPitch.Value = (int)lRot.y;
                            _instance.ltRoll.Value = (int)lRot.z;
                            _instance.ltYawLabel.Text = $"Yaw: {(int)lRot.x}";
                            _instance.ltPitchLabel.Text = $"Pitch: {(int)lRot.y}";
                            _instance.ltRollLabel.Text = $"Roll: {(int)lRot.z}";
                            _instance.rtYaw.Value = y;
                            _instance.rtPitch.Value = p;
                            _instance.rtRoll.Value = r;
                            _instance.rtYawLabel.Text = $"Yaw: {y}";
                            _instance.rtPitchLabel.Text = $"Pitch: {p}";
                            _instance.rtRollLabel.Text = $"Roll: {r}";

                            _instance.ltXLabel.Text = $"X: {lPos.x}";                           //required headsed weared (isInHeadset is true) to track what actually launch oculus client
                            _instance.ltYLabel.Text = $"Y: {lPos.y}";
                            _instance.ltZLabel.Text = $"Z: {lPos.z}";
                            _instance.rtXLabel.Text = $"X: {rPos.x}";
                            _instance.rtYLabel.Text = $"Y: {rPos.y}";
                            _instance.rtZLabel.Text = $"Z: {rPos.z}";

                            if (readBattery)
                            {
                                _instance.currentAdbDeviceLbl.Text = $"Device: [{(ADB.wirelessConnection ? "Wi-Fi" : "Usb")}] {ADB.deviceModel} ({ADB.deviceName}) [{ADB.deviceSerial}] state: {ADB.deviceState}";
                                _instance.batteryLbl.Text = $"Battery {(ADB.batteryFetched ? $"HMD: {ADB.headsetBattery} LTouch: {ADB.lTouchBattery} RTouch: {ADB.rTouchBattery}" : "N/A")}";
                            }
                            if (GetRBumpPressed())
                                Reset();
                        }));
                    }
                    catch { }
                    Thread.Sleep(10);
                }
            });
            update.IsBackground = true;
            update.SetApartmentState(ApartmentState.STA);
            update.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*if (readTrackers)
                Valve.VR.OpenVR.Shutdown();*/
        }
    }
}
