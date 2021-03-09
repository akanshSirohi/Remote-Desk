using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RemoteDesk
{
    public class Robot
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public static void PressKey(Keys key, bool down)
        {
            const int KEYEVENTF_EXTENDEDKEY = 0x1;
            const int KEYEVENTF_KEYUP = 0x2;
            if (!down)
            {
                keybd_event((byte)key, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
            }
            else
            {
                keybd_event((byte)key, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
            }
        }

        public void evaluateCommand(string cmd)
        {
            if (cmd.Equals("_c_lck_"))
            {
                PressKey(Keys.CapsLock, true);
                PressKey(Keys.CapsLock, false);
            }
            else if (cmd.StartsWith("ASOFT_M:"))
            {
                String d = cmd.Split(':')[1];
                if (d.EndsWith("ASOFT_M"))
                {
                    d = d.Replace("ASOFT_M", "");
                }
                double moveX = Convert.ToDouble(d.Split(';')[0]);
                double moveY = Convert.ToDouble(d.Split(';')[1]);
                moveX = sensitivity(moveX, 5);
                moveY = sensitivity(moveY, 5);
                try
                {
                    double nowX = Cursor.Position.X;
                    double nowY = Cursor.Position.Y;

                    Cursor.Position = new Point((int)Math.Ceiling(nowX + moveX), (int)Math.Ceiling((nowY + moveY)));
                }
                catch (Exception e)
                {
                    Console.WriteLine("ErrorMouse: " + e.ToString());
                }
            }
            else if (cmd.StartsWith("_left_m_"))
            {
                mClick(true);
            }
            else if (cmd.StartsWith("_rght_m_"))
            {
                mClick(false);
            }
            else if (cmd.StartsWith("_bksp_"))
            {
                SendKeys.SendWait("{BKSP}");
            }
            else if (cmd.StartsWith("_rght_"))
            {
                SendKeys.SendWait("{RIGHT}");
            }
            else if (cmd.StartsWith("_left_"))
            {
                SendKeys.SendWait("{LEFT}");
            }
            else if (cmd.StartsWith("_up_"))
            {
                SendKeys.SendWait("{UP}");
            }
            else if (cmd.StartsWith("_dwn_"))
            {
                SendKeys.SendWait("{DOWN}");
            }
            else if (cmd.StartsWith("_f5_"))
            {
                SendKeys.SendWait("{F5}");
            }
            else if (cmd.StartsWith("_enter_"))
            {
                SendKeys.SendWait("{ENTER}");
            }
            else if (cmd.StartsWith("_esc_"))
            {
                SendKeys.SendWait("{ESC}");
            }
            else if (cmd.StartsWith("_stct_cpy_"))
            {
                keyPress(Keys.ControlKey,Keys.C);
            }
            else if (cmd.StartsWith("_stct_pst_"))
            {
                keyPress(Keys.ControlKey,Keys.V);
            }
            else if (cmd.StartsWith("_stct_cut_"))
            {
                keyPress(Keys.ControlKey, Keys.X);
            }
            else if (cmd.StartsWith("_stct_ss_"))
            {
                screenShot();
            }
            else if (cmd.StartsWith("_stct_win_"))
            {
                keyPress(Keys.LWin);
            }
            else
            {
                sendKeys(cmd);
            }
        }
        public double sensitivity(double d, int thrushhold)
        {
            double tmp = Math.Abs(d);
            if (tmp > thrushhold)
            {
                if (d > 0)
                {
                    return d + thrushhold;
                }
                else if (d < 0)
                {
                    return d - thrushhold;
                }
                else
                {
                    return d;
                }
            }
            else
            {
                return d;
            }
        }
        public void mClick(Boolean b)
        {
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            if (b)
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
            }
            else
            {
                mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, X, Y, 0, 0);
            }
        }

        private void sendKeys(String str)
        {
            try
            {
                foreach(char c in str)
                {
                    switch (c)
                    {
                        case '+':
                            keyPress(Keys.Add);
                            break;
                        case '~':
                            keyPress(Keys.ShiftKey,Keys.Oemtilde);
                            break;
                        case '%':
                            keyPress(Keys.ShiftKey,Keys.D5);
                            break;
                        case '^':
                            keyPress(Keys.ShiftKey, Keys.D6);
                            break;
                        case '(':
                            keyPress(Keys.ShiftKey,Keys.D9);
                            break;
                        case ')':
                            keyPress(Keys.ShiftKey, Keys.D0);
                            break;
                        case '{':
                            keyPress(Keys.ShiftKey, Keys.OemOpenBrackets);
                            break;
                        case '}':
                            keyPress(Keys.ShiftKey, Keys.OemCloseBrackets);
                            break;
                        default:
                            SendKeys.SendWait(c.ToString());
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                // Do Nothing!
            }
        }

        private void keyPress(Keys key)
        {
            PressKey(key, true);
            PressKey(key, false);
        }
        private void keyPress(Keys key1, Keys key2)
        {
            PressKey(key1, true);
            PressKey(key2, true);
            PressKey(key2, false);
            PressKey(key1, false);
        }
        private void screenShot()
        {
            PressKey(Keys.LWin, true);
            PressKey(Keys.ShiftKey, true);
            PressKey(Keys.S, true);
            PressKey(Keys.S, false);
            PressKey(Keys.ShiftKey, false);
            PressKey(Keys.LWin, false);
        }
    }
}