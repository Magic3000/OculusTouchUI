using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OculusTouchUI.OculusWrapper;

namespace OculusTouchUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Start();
        }

        public void Start()
        {
            OculusWrapper.Start(false);
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
                            _instance.ltYaw.Value = (int)lRot.x;                                //between 0 and 100
                            _instance.ltPitch.Value = (int)lRot.y;
                            _instance.ltRoll.Value = (int)lRot.z;
                            _instance.ltYawLabel.Text = $"Yaw: {(int)lRot.x}";
                            _instance.ltPitchLabel.Text = $"Pitch: {(int)lRot.y}";
                            _instance.ltRollLabel.Text = $"Roll: {(int)lRot.z}";
                            _instance.rtYaw.Value = (int)rRot.x;
                            _instance.rtPitch.Value = (int)rRot.y;
                            _instance.rtRoll.Value = (int)rRot.z;
                            _instance.rtYawLabel.Text = $"Yaw: {(int)rRot.x}";
                            _instance.rtPitchLabel.Text = $"Pitch: {(int)rRot.y}";
                            _instance.rtRollLabel.Text = $"Roll: {(int)rRot.z}";

                            _instance.ltXLabel.Text = $"X: {rPos.x}";                           //required headsed weared (isInHeadset is true) to track what actually launch oculus client
                            _instance.ltYLabel.Text = $"Y: {rPos.y}";
                            _instance.ltZLabel.Text = $"Z: {rPos.z}";
                            _instance.rtXLabel.Text = $"X: {rPos.x}";
                            _instance.rtYLabel.Text = $"Y: {rPos.y}";
                            _instance.rtZLabel.Text = $"Z: {rPos.z}";
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
    }
}
