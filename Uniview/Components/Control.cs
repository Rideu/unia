
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Net.NetworkInformation;
using System.Threading;
using System.Net;
using System.IO;
using WF = System.Windows.Forms;
using Uniview.Components;

namespace Uniview
{

    public static partial class EControl
    {
        internal static MouseState OMS, NMS;
        internal static KeyboardState OKS, NKS;

        public static float NMW, OMW, WheelVal;

        public static Vector2 MousePos => NMS.Position.ToVector2();

        public static bool LeftButtonPressed => NMS.LeftButton == ButtonState.Pressed;
        public static bool RightButtonPressed => NMS.RightButton == ButtonState.Pressed;
        public static bool PressedDownKey(Keys key) => (OKS.IsKeyUp(key) && NKS.IsKeyDown(key));

        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(int i);
        [DllImport("user32.dll")]
        public static extern short GetKeyState(int i);

        public static void Update(ImageViewer c)
        { 
            Keys[] keybuf = new Keys[256];
            for (int i = 0; i < 256; i++)
            {
                var s = GetAsyncKeyState(i);
                if (s != 0 && i > 2)
                {
                    switch (i)
                    {
                        case 16: keybuf[i] = Keys.LeftShift; break;
                        case 18: keybuf[i] = Keys.LeftAlt; break;
                        default:
                            keybuf[i] = (Keys)i;
                            break;
                    }
                }
            }
            var f = WF.SystemInformation.MouseWheelScrollDelta;

            OKS = NKS;
            NKS = new KeyboardState(keybuf);

            var mp = c.PointToClient(WF.Control.MousePosition);

            OMS = NMS;
            NMS = new MouseState(mp.X, mp.Y, 0,
                (ButtonState)(WF.Control.MouseButtons == WF.MouseButtons.Left ? 1 : 0),
                (ButtonState)(WF.Control.MouseButtons == WF.MouseButtons.Middle ? 1 : 0),
                (ButtonState)(WF.Control.MouseButtons == WF.MouseButtons.Right ? 1 : 0),
                (ButtonState)(WF.Control.MouseButtons == WF.MouseButtons.XButton1 ? 1 : 0),
                (ButtonState)(WF.Control.MouseButtons == WF.MouseButtons.XButton2 ? 1 : 0));

            OMW = NMW;
            NMW = f;
            if (OMW != NMW)
                WheelVal = NMW > 0 ? 60 : NMW < 0 ? -60 : 0;
            else WheelVal = 0; 
        }

        public static bool LeftPressed() => NMS.LeftButton == ButtonState.Pressed;

        public static bool RightPressed() => NMS.RightButton == ButtonState.Pressed;

        public static bool MiddlePressed() => NMS.MiddleButton == ButtonState.Pressed;

        public static bool LeftClick() => (OMS.LeftButton == ButtonState.Pressed && NMS.LeftButton == ButtonState.Released);

        public static bool RightClick() => (OMS.RightButton == ButtonState.Pressed && NMS.RightButton == ButtonState.Released);

        public static bool MidClick() => (OMS.MiddleButton == ButtonState.Pressed && NMS.MiddleButton == ButtonState.Released);

        public static bool PressedKey(Keys key) => (OKS.IsKeyDown(key) && NKS.IsKeyUp(key));

        public static bool AnyKeyPressed() => OKS.GetPressedKeys().Length > 0;

        public static bool IsKeyUp(Keys key) => NKS.IsKeyUp(key);

        public static bool IsKeyDown(Keys key) => NKS.IsKeyDown(key);

        //public static Keys[] GetPressedKeys() => Keyboard.GetState().GetPressedKeys();

        public static void Debug(SpriteBatch batch)
        {
            //string presseds = "";
            //presseds = bindslist.FindAll(p => p.NewState == true).Count + "/" + bindslist.Capacity;

            //batch.DrawString(Game1.font, Mouse.GetState().Position+"", new Vector2(50), Color.White);
        }
    }


}
