using System;
using System.Runtime.InteropServices;

namespace MiniLens
{
    public static class NativeMethods
    {
        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        // https://msdn.microsoft.com/en-us/library/windows/desktop/ms644990%28v=vs.85%29.aspx
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        // https://msdn.microsoft.com/en-us/library/windows/desktop/ms644993%28v=vs.85%29.aspx
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        // https://msdn.microsoft.com/en-us/library/windows/desktop/ms644974%28v=vs.85%29.aspx
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        // https://msdn.microsoft.com/en-us/library/windows/desktop/ms683199%28v=vs.85%29.aspx
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}