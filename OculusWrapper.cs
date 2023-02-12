using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OculusTouchUI
{
    public class Vector3
    {
        public override bool Equals(object other)
        {
            if (!(other is Vector3)) return false;

            return Equals((Vector3)other);
        }
        public override int GetHashCode()
        {
            return x.GetHashCode() ^ (y.GetHashCode() << 2) ^ (z.GetHashCode() >> 2);
        }
        public const float kEpsilon = 0.00001F;
        public const float kEpsilonNormalSqrt = 1e-15F;
        public const float PI = (float)Math.PI;
        public const float Deg2Rad = PI * 2F / 360F;
        public const float Rad2Deg = 1F / Deg2Rad;
        public static float Sign(float f) { return f >= 0F ? 1F : -1F; }
        public static float Clamp(float value, float min, float max)
        {
            if (value < min)
                value = min;
            else if (value > max)
                value = max;
            return value;
        }
        public float x = 0;
        public float y = 0;
        public float z = 0;
        public Vector3(float x, float y, float z) { this.x = x; this.y = y; this.z = z; }
        public Vector3(float x, float y) { this.x = x; this.y = y; z = 0F; }
        public void Set(float newX, float newY, float newZ) { x = newX; y = newY; z = newZ; }
        public static Vector3 Scale(Vector3 a, Vector3 b) { return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z); }
        public void Scale(Vector3 scale) { x *= scale.x; y *= scale.y; z *= scale.z; }
        public static Vector3 Cross(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(
                lhs.y * rhs.z - lhs.z * rhs.y,
                lhs.z * rhs.x - lhs.x * rhs.z,
                lhs.x * rhs.y - lhs.y * rhs.x);
        }
        public bool Equals(Vector3 other)
        {
            return x == other.x && y == other.y && z == other.z;
        }
        public static float Dot(Vector3 lhs, Vector3 rhs) { return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z; }
        public static float SqrMagnitude(Vector3 vector) { return vector.x * vector.x + vector.y * vector.y + vector.z * vector.z; }
        public float sqrMagnitude { get { return x * x + y * y + z * z; } }

        public static float Angle(Vector3 from, Vector3 to)
        {
            // sqrt(a) * sqrt(b) = sqrt(a * b) -- valid for real numbers
            float denominator = (float)Math.Sqrt(from.sqrMagnitude * to.sqrMagnitude);
            if (denominator < kEpsilonNormalSqrt)
                return 0F;

            float dot = Clamp(Dot(from, to) / denominator, -1F, 1F);
            return ((float)Math.Acos(dot)) * Rad2Deg;
        }
        public static float SignedAngle(Vector3 from, Vector3 to, Vector3 axis)
        {
            float unsignedAngle = Angle(from, to);

            float cross_x = from.y * to.z - from.z * to.y;
            float cross_y = from.z * to.x - from.x * to.z;
            float cross_z = from.x * to.y - from.y * to.x;
            float sign = Sign(axis.x * cross_x + axis.y * cross_y + axis.z * cross_z);
            return unsignedAngle * sign;
        }
        public static float Distance(Vector3 a, Vector3 b)
        {
            float diff_x = a.x - b.x;
            float diff_y = a.y - b.y;
            float diff_z = a.z - b.z;
            return (float)Math.Sqrt(diff_x * diff_x + diff_y * diff_y + diff_z * diff_z);
        }
        public float magnitude { get { return (float)Math.Sqrt(x * x + y * y + z * z); } }
        public static float Min(float a, float b) { return a < b ? a : b; }
        public static float Max(float a, float b) { return a > b ? a : b; }
        public static Vector3 Min(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(Min(lhs.x, rhs.x), Min(lhs.y, rhs.y), Min(lhs.z, rhs.z));
        }

        public static Vector3 Max(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(Max(lhs.x, rhs.x), Max(lhs.y, rhs.y), Max(lhs.z, rhs.z));
        }
        static readonly Vector3 zeroVector = new Vector3(0F, 0F, 0F);
        static readonly Vector3 oneVector = new Vector3(1F, 1F, 1F);
        static readonly Vector3 upVector = new Vector3(0F, 1F, 0F);
        static readonly Vector3 downVector = new Vector3(0F, -1F, 0F);
        static readonly Vector3 leftVector = new Vector3(-1F, 0F, 0F);
        static readonly Vector3 rightVector = new Vector3(1F, 0F, 0F);
        static readonly Vector3 forwardVector = new Vector3(0F, 0F, 1F);
        static readonly Vector3 backVector = new Vector3(0F, 0F, -1F);
        static readonly Vector3 positiveInfinityVector = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
        static readonly Vector3 negativeInfinityVector = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
        public static Vector3 positiveInfinity { get { return positiveInfinityVector; } }
        public static Vector3 negativeInfinity { get { return negativeInfinityVector; } }
        public static bool operator ==(Vector3 lhs, Vector3 rhs)
        {
            // Returns false in the presence of NaN values.
            float diff_x = lhs.x - rhs.x;
            float diff_y = lhs.y - rhs.y;
            float diff_z = lhs.z - rhs.z;
            float sqrmag = diff_x * diff_x + diff_y * diff_y + diff_z * diff_z;
            return sqrmag < kEpsilon * kEpsilon;
        }
        public static bool operator !=(Vector3 lhs, Vector3 rhs)
        {
            // Returns true in the presence of NaN values.
            return !(lhs == rhs);
        }
        public override string ToString()
        {
            return ToString(null, CultureInfo.InvariantCulture.NumberFormat);
        }
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.InvariantCulture.NumberFormat);
        }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
                format = "F1";
            return $"({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
        }
        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector3 index!");
                }
            }

            set
            {
                switch (index)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    case 2: z = value; break;
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector3 index!");
                }
            }
        }
    }
    public static class OculusWrapper
    {
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern int initOculus();
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern void poll();
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern void resetFacing(int controller);
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern void setTrackingOrigin(int origin);
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern bool isPressed(int button);
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern bool isReleased(int button);
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern bool isDown(int button);
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern bool isTouchPressed(int button);
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern bool isTouchReleased(int button);
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern bool isTouchDown(int button);
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern float getAxis(int axis);
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern void setVibration(int controller, int frequency, byte amplitude, float length);
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern int isWearing();
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern float getPositionX(int controller);
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern float getPositionY(int controller);
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern float getPositionZ(int controller);
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern float getYaw(int controller);
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern float getPitch(int controller);
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern float getRoll(int controller);
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern void sendRawMouseMove(int x, int y, int z);
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern void sendRawMouseButtonDown(int button);
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern void sendRawMouseButtonUp(int button);
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern float reached(int axis, float value);
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern void sendCtrlV();
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern void sendTab();
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern void sendEnter();
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern void sendAltEnter();
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern void sendWin();
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern void sendWinShiftRight();
        [DllImport("auto_oculus_touch.dll", SetLastError = true)]
        public static extern void sendScrollMouse(int scroll);

        private static bool isStarted = false;
        public static bool running
        {
            get
            {
                return isStarted;
            }
        }
        public static void Update()
        {
            if (!isStarted)
                Start(false);
            poll();
        }

        public static void Reset()
        {
            OculusWrapper.resetFacing((int)Device.LTouch);
            OculusWrapper.resetFacing((int)Device.RTouch);
        }

        public static bool firstFail = false;
        public static void Start(bool startUpdate = true)
        {
            if (isStarted)
                return;
            isStarted = true;
            if (OculusWrapper.initOculus() != 1)
            {
                if (!firstFail)
                {
                    firstFail = true;
                    MessageBox.Show("Failed to InitOculus");
                }
                isStarted = false;
            }
            OculusWrapper.poll();
            OculusWrapper.resetFacing((int)Device.LTouch);
            OculusWrapper.resetFacing((int)Device.RTouch);
            OculusWrapper.resetFacing((int)Device.HMD);
            OculusWrapper.setTrackingOrigin((int)TrackingOrigin.OriginFloor);
            if (!startUpdate)
                return;
            var update = new Thread(() =>
            {
                while (true)
                {
                    poll();
                    //code

                    Thread.Sleep(10);
                }
            });
            update.IsBackground = true;
            //update.SetApartmentState(ApartmentState.STA);
            update.Start();
        }

        public enum OculusPress
        {
            A = 0x00000001,
            B = 0x00000002,
            X = 0x00000100,
            Y = 0x00000200,
            RStick = 0x00000004,        //LThumb
            LStick = 0x00000400,        //RThumb
            LMenu = 0x00100000
        }

        public enum OculusTouch
        {
            A = 0x00000001,
            B = 0x00000002,
            RStick = 0x00000004,        //RThumb
            RStickRest = 0x00000008,    //RThumbRest
            RTrigger = 0x00000010,
            X = 0x00000100,
            Y = 0x00000200,
            LStick = 0x00000400,        //LThumb
            LStickRest = 0x00000800,    //LThumbRest
            LTrigger = 0x00001000
        }

        public enum TrackingOrigin
        {
            OriginEye = 0,
            OriginFloor = 1
        }

        public enum Axis
        {
            LTrigger = 0,
            RTrigger = 1,
            LBump = 2,
            RBump = 3,
            LX = 4,
            RX = 5,
            LY = 6,
            RY = 7
        }

        public enum Device
        {
            LTouch = 0,
            RTouch = 1,
            HMD = 2
        }

        public static bool GetTouchA() => isTouchDown((int)OculusTouch.A);
        public static bool GetTouchB() => isTouchDown((int)OculusTouch.B);
        public static bool GetTouchX() => isTouchDown((int)OculusTouch.X);
        public static bool GetTouchY() => isTouchDown((int)OculusTouch.Y);
        public static bool GetTouchLStick() => isTouchDown((int)OculusTouch.LStick);
        public static bool GetTouchRStick() => isTouchDown((int)OculusTouch.RStick);
        public static bool GetTouchLStickRest() => isTouchDown((int)OculusTouch.LStickRest);
        public static bool GetTouchRStickRest() => isTouchDown((int)OculusTouch.RStickRest);
        public static bool GetTouchLTrigger() => isTouchDown((int)OculusTouch.LTrigger);
        public static bool GetTouchRTrigger() => isTouchDown((int)OculusTouch.RTrigger);

        public static bool GetPressed(OculusPress button) => isPressed((int)button);
        public static bool GetReleased(OculusPress button) => isReleased((int)button);
        public static bool GetTouchPressed(OculusTouch button) => isTouchPressed((int)button);
        public static bool GetTouchReleased(OculusTouch button) => isTouchReleased((int)button);
        public static bool GetA() => isDown((int)OculusPress.A);
        public static bool GetB() => isDown((int)OculusPress.B);
        public static bool GetX() => isDown((int)OculusPress.X);
        public static bool GetY() => isDown((int)OculusPress.Y);
        public static bool GetLStick() => isDown((int)OculusPress.LStick);
        public static bool GetRStick() => isDown((int)OculusPress.RStick);
        public static bool GetLMenu() => isDown((int)OculusPress.LMenu);
        public static bool GetLTriggerPressed(float minOffset = 0.5f) => getAxis((int)Axis.LTrigger) >= minOffset;
        public static bool GetRTriggerPressed(float minOffset = 0.5f) => getAxis((int)Axis.RTrigger) >= minOffset;
        public static bool GetLBumpPressed(float minOffset = 0.5f) => getAxis((int)Axis.LBump) >= minOffset;
        public static bool GetRBumpPressed(float minOffset = 0.5f) => getAxis((int)Axis.RBump) >= minOffset;
        public static bool GetLX() => getAxis((int)Axis.LX) >= 0 || getAxis((int)Axis.LX) <= 0;
        public static bool GetLY() => getAxis((int)Axis.LY) >= 0 || getAxis((int)Axis.LY) <= 0;
        public static bool GetRX() => getAxis((int)Axis.RX) >= 0 || getAxis((int)Axis.RX) <= 0;
        public static bool GetRY() => getAxis((int)Axis.RY) >= 0 || getAxis((int)Axis.RY) <= 0;

        public static float axisMinValue = 0.000001f;
        public static float GetLTrigger(bool to255 = true) => to255 ? getAxis((int)Axis.LTrigger) * 255 : getAxis((int)Axis.LTrigger);      //default is 0 to 1
        public static float GetRTrigger(bool to255 = true) => to255 ? getAxis((int)Axis.RTrigger) * 255 : getAxis((int)Axis.RTrigger);      //default is 0 to 1
        public static float GetLBump(bool to255 = true) => to255 ? getAxis((int)Axis.LBump) * 255 : getAxis((int)Axis.LBump);               //default is 0 to 1
        public static float GetRBump(bool to255 = true) => to255 ? getAxis((int)Axis.RBump) * 255 : getAxis((int)Axis.RBump);               //default is 0 to 1

        public static Vector3 LStick(bool to255 = true) => new Vector3(to255 ? 
                                                                    (getAxis((int)Axis.LX) + 1) / 2 * 255 : 
                                                                    getAxis((int)Axis.LX), 
                                                                    to255 ? 
                                                                    (getAxis((int)Axis.LY) + 1) / 2 * 255 : 
                                                                    getAxis((int)Axis.LY));        //default is -1 to 1
        public static Vector3 RStick(bool to255 = true) => new Vector3(to255 ? 
                                                                    (getAxis((int)Axis.RX) + 1) / 2 * 255 : 
                                                                    getAxis((int)Axis.RX),
                                                                    to255 ?
                                                                    (getAxis((int)Axis.RY) + 1) / 2 * 255 :
                                                                    getAxis((int)Axis.RY));        //default is -1 to 1
        internal static float remap(float value, float start1, float stop1, float start2, float stop2) => start2 + (stop2 - start2) * ((value - start1) / (stop1 - start1));

        public static float GetLX(bool from0to100 = false) => from0to100 ? getAxis((int)Axis.LX) * 50 + 50 : getAxis((int)Axis.LX);
        public static float GetLY(bool from0to100 = false) => from0to100 ? getAxis((int)Axis.LY) * 50 + 50 : getAxis((int)Axis.LY);
        public static float GetRX(bool from0to100 = false) => from0to100 ? getAxis((int)Axis.RX) * 50 + 50 : getAxis((int)Axis.RX);
        public static float GetRY(bool from0to100 = false) => from0to100 ? getAxis((int)Axis.RY) * 50 + 50 : getAxis((int)Axis.RY);

        public static bool IsInHeadset() => isWearing() == 1;
        public static float GetLTouchX() => getPositionX((int)Device.LTouch);
        public static float GetLTouchY() => getPositionY((int)Device.LTouch);
        public static float GetLTouchZ() => getPositionZ((int)Device.LTouch);
        public static float GetRTouchX() => getPositionX((int)Device.RTouch);
        public static float GetRTouchY() => getPositionY((int)Device.RTouch);
        public static float GetRTouchZ() => getPositionZ((int)Device.RTouch);
        public static float GetHMDX() => getPositionX((int)Device.HMD);
        public static float GetHMDY() => getPositionY((int)Device.HMD);
        public static float GetHMDZ() => getPositionZ((int)Device.HMD);

        public static Vector3 GetLTouchPos() => new Vector3(GetLTouchX(), GetLTouchY(), GetLTouchZ());
        public static Vector3 GetRTouchPos() => new Vector3(GetRTouchX(), GetRTouchY(), GetRTouchZ());
        public static Vector3 GetHMDPos() => new Vector3(GetHMDX(), GetHMDY(), GetHMDZ());

        public static float GetLTouchYaw() => (getYaw((int)Device.LTouch) + 180) / 3.6f;
        public static float GetLTouchPitch() => (getPitch((int)Device.LTouch) + 90) / 1.8f;
        public static float GetLTouchRoll() => (getRoll((int)Device.LTouch) + 180) / 3.6f;
        public static float GetRTouchYaw() => (getYaw((int)Device.RTouch) + 180) / 3.6f;
        public static float GetRTouchPitch() => (getPitch((int)Device.RTouch) + 90) / 1.8f;
        public static float GetRTouchRoll() => (getRoll((int)Device.RTouch) + 180) / 3.6f;
        public static float GetHMDYaw() => (getYaw((int)Device.HMD) + 180) / 3.6f;
        public static float GetHMDPitch() => (getPitch((int)Device.HMD) + 90) / 1.8f;
        public static float GetHMDRoll() => (getRoll((int)Device.HMD) + 180) / 3.6f;
        public static Vector3 GetLTouchRot() => new Vector3(GetLTouchYaw(), GetLTouchPitch(), GetLTouchRoll());
        public static Vector3 GetRTouchRot() => new Vector3(GetRTouchYaw(), GetRTouchPitch(), GetRTouchRoll());
        public static Vector3 GetHMDRot() => new Vector3(GetHMDYaw(), GetHMDPitch(), GetHMDRoll());

        public enum Power
        {
            Extreme = 1,          //320hz
            High = 2,      //160.7hz
            Medium = 3,          //106hz
            Low = 4            //80hz
        }
        public static void SetVibration(Device controller, Power frequency, byte amplitudeAKAstrength, float lengthInSeconds = 0)
        {
            switch (controller)
            {
                case Device.LTouch:
                    setVibration(0, (int)frequency, amplitudeAKAstrength, lengthInSeconds);
                    break;
                case Device.RTouch:
                    setVibration(1, (int)frequency, amplitudeAKAstrength, lengthInSeconds);
                    break;
                case Device.HMD:
                    setVibration(0, (int)frequency, amplitudeAKAstrength, lengthInSeconds);
                    setVibration(1, (int)frequency, amplitudeAKAstrength, lengthInSeconds);
                    break;
                default:
                    break;
            }
        }
        public static void LRVibrateOff(int frequency = 1, byte amplitude = 0, float length = 0)
        {
            LVibrateOff(frequency, amplitude, length);
            RVibrateOff(frequency, amplitude, length);
        }
        public static void LVibrateOn(int frequency = 1, byte amplitude = 255, float length = 0) => setVibration(0, frequency, amplitude, length);
        public static void LVibrateOff(int frequency = 1, byte amplitude = 0, float length = 0) => setVibration(0, frequency, amplitude, length);
        public static void RVibrateOn(int frequency = 1, byte amplitude = 255, float length = 0) => setVibration(1, frequency, amplitude, length);
        public static void RVibrateOff(int frequency = 1, byte amplitude = 0, float length = 0) => setVibration(1, frequency, amplitude, length);
    }
}
