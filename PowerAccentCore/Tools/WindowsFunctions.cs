using System.Drawing;
using System.Runtime.InteropServices;
using Vanara.PInvoke;

namespace PowerAccentCore.Tools
{
    public static class WindowsFunctions
    {
        public static void Insert(char c)
        {
            var inputs = new User32.INPUT[3]
            {
                new User32.INPUT {type = User32.INPUTTYPE.INPUT_KEYBOARD, ki = new User32.KEYBDINPUT {wVk = (ushort) User32.VK.VK_BACK}},
                new User32.INPUT {type = User32.INPUTTYPE.INPUT_KEYBOARD, ki = new User32.KEYBDINPUT {wVk = (ushort) User32.VK.VK_BACK, dwFlags = User32.KEYEVENTF.KEYEVENTF_KEYUP}},
                new User32.INPUT {type = User32.INPUTTYPE.INPUT_KEYBOARD, ki = new User32.KEYBDINPUT {wVk = 0, dwFlags = User32.KEYEVENTF.KEYEVENTF_UNICODE, wScan = c}}
            };
            unsafe
            {
                _ = User32.SendInput((uint)inputs.Length, inputs, sizeof(User32.INPUT));
            }
        }

        public static Point GetCaretPosition()
        {
            User32.GUITHREADINFO guiInfo = new User32.GUITHREADINFO();
            guiInfo.cbSize = (uint)Marshal.SizeOf(guiInfo);
            User32.GetGUIThreadInfo(0, ref guiInfo);
            Point caretPosition = new Point(guiInfo.rcCaret.left, guiInfo.rcCaret.top);
            User32.ClientToScreen(guiInfo.hwndCaret, ref caretPosition);

            if (caretPosition.X == 0)
            {
                Point testPoint;
                User32.GetCaretPos(out testPoint);
                return testPoint;
            }
            
            return caretPosition;
        }

        public static (Point Location, Size Size) GetDisplay(Point location)
        {
            var res = User32.MonitorFromPoint(location, User32.MonitorFlags.MONITOR_DEFAULTTONEAREST);
            User32.MONITORINFO monitorInfo = new User32.MONITORINFO();
            User32.GetMonitorInfo(res, ref monitorInfo);
            return (monitorInfo.rcMonitor.Location, monitorInfo.rcMonitor.Size);
        }
    }
}
