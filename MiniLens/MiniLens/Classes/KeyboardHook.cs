using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MiniLens.Properties;

namespace MiniLens
{
    public static class KeyboardHook
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static NativeMethods.LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        public static IntPtr HookID {
            get { return _hookID; }
            set { _hookID = value; }
        }

        public static NativeMethods.LowLevelKeyboardProc Proc {
            get { return _proc; }
            set { _proc = value; }
        }

        public static IntPtr SetHook(NativeMethods.LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                Console.WriteLine("Setting hook on: " + curProcess.ProcessName);
                return NativeMethods.SetWindowsHookEx(WH_KEYBOARD_LL, proc, NativeMethods.GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        public static void Unhook()
        {
            NativeMethods.UnhookWindowsHookEx(HookID);
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Console.WriteLine((Keys)vkCode);

                if (Settings.Default.FullscreenHotkey == (Byte)vkCode && Settings.Default.FullscreenEnabled)
                {
                    Console.WriteLine("Taking full screenshot from Keyboard press.");
                    Screenshot.FullScreenshot();
                }

                if (Settings.Default.AreaHotkey == (Byte)vkCode && Settings.Default.AreaEnabled)
                {
                    Console.WriteLine("Taking area screenshot from Keyboard press.");
                    Screenshot.AreaScreenshot();
                }

                if (Settings.Default.WindowHotkey == (Byte)vkCode && Settings.Default.WindowEnabled)
                {
                    Console.WriteLine("Taking window screenshot from Keyboard press.");
                    Screenshot.WindowScreenshot();
                }
            }
            return NativeMethods.CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
    }
}