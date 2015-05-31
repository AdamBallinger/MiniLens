using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using MiniLens.Properties;

namespace MiniLens
{
    //TODO: Move the logic of this class into a seperate class
    public partial class FormMain : Form
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static NativeMethods.LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        private static IntPtr SetHook(NativeMethods.LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return NativeMethods.SetWindowsHookEx(WH_KEYBOARD_LL, proc, NativeMethods.GetModuleHandle(curModule.ModuleName), 0);
            }
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
                    FullScreenshot();
                }

                if (Settings.Default.AreaHotkey == (Byte)vkCode && Settings.Default.AreaEnabled)
                {
                    Console.WriteLine("Taking area screenshot from Keyboard press.");
                    AreaScreenshot();
                }

                if (Settings.Default.WindowHotkey == (Byte)vkCode && Settings.Default.WindowEnabled)
                {
                    Console.WriteLine("Taking window screenshot from Keyboard press.");
                    WindowScreenshot();
                }
            }
            return NativeMethods.CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        public FormMain()
        {
            _hookID = SetHook(_proc);
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            //TODO: Default settings check
            DirectoryIntegrityCheck();
        }

        private void btn_Fullscreen_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Taking full screenshot from Main Window");
            FullScreenshot();
        }

        private void btn_Area_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Taking area screenshot from Main Window");
            AreaScreenshot();
        }

        private void btn_Window_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Taking window screenshot from Main Window");
            WindowScreenshot();
        }

        private void btn_Directory_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Opening the image directory");
            Process.Start(Settings.Default.CaptureDirectory);
        }

        private void btn_Opt_Click(object sender, EventArgs e)
        {
            Form form = new FormOptions();
            form.ShowDialog();
        }

        private void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            Console.WriteLine("The main window is now visible.");
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Console.WriteLine("The main window is now minimised.");
                trayIcon.ShowBalloonTip(5, "Minimised!", "Double click to reopen.", ToolTipIcon.Info);
                this.Visible = false;
            }
        }

        private void ts_OpenFormMain(object sender, EventArgs e)
        {
            Console.WriteLine("Opening the Main form for MiniLens");
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void ts_FullScreenShot(Object sender, EventArgs e)
        {
            Console.WriteLine("Taking full screenshot from notification icon tool strip.");
            FullScreenshot();
        }

        private void ts_AreaScreenShot(Object sender, EventArgs e)
        {
            Console.WriteLine("Taking area screenshot from notification icon tool strip.");
            AreaScreenshot();
        }

        private void ts_WindowScreenShot(Object sender, EventArgs e)
        {
            Console.WriteLine("Taking window screenshot from notification icon tool strip.");
            WindowScreenshot();
        }

        private void ts_CloseApplication(Object sender, EventArgs e)
        {
            Console.WriteLine("Closing the application from the notification icon tool strip.");
            this.Close();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            NativeMethods.UnhookWindowsHookEx(_hookID);

            // Ensure that the icon is removed from the system tray
            try
            {
                if (trayIcon != null)
                {
                    trayIcon.Visible = false;
                    trayIcon.Icon = null;
                    trayIcon.Dispose();
                    trayIcon = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// This is the primary method to call when taking a full screenshot
        /// </summary>
        private static void FullScreenshot()
        {
            TakeScreenShot(SystemInformation.VirtualScreen);
        }

        /// <summary>
        /// This is the primary method to call when taking an area screenshot
        /// </summary>
        private static void AreaScreenshot()
        {
            // ToDo: Implement Area Screenshot functionality.
            throw new NotImplementedException();
        }

        /// <summary>
        /// This is the primary method to call when taking a window screenshot.
        /// </summary>
        private static void WindowScreenshot()
        {
            // ToDo: Implement Window Screenshot functionality.
            throw new NotImplementedException();
        }

        /// <summary>
        /// Takes a screenshot of a given rectangle.
        /// </summary>
        /// <param name="screenDim">Rectangle of screen capture dimensions</param>
        private static void TakeScreenShot(Rectangle screenDim)
        {
            Bitmap capture = new Bitmap(screenDim.Width, screenDim.Height, PixelFormat.Format32bppArgb);

            using (Graphics screenGraph = Graphics.FromImage(capture))
            {
                screenGraph.CopyFromScreen(
                    screenDim.X,
                    screenDim.Y,
                    0,
                    0,
                    screenDim.Size,
                    CopyPixelOperation.SourceCopy);
            }

            DateTime dt = DateTime.Now;
            string formattedDt = dt.ToString().Replace('/', '-').Replace(':', '-') + "-" + DateTime.Now.Millisecond.ToString();

            string fileLocation = Settings.Default.CaptureDirectory + Path.DirectorySeparatorChar + formattedDt;

            Console.WriteLine("Saving picture to: " + fileLocation);

            DirectoryIntegrityCheck();

            switch (Settings.Default.CaptureFormat)
            {
                case 0:
                    capture.Save(fileLocation + ".bmp", ImageFormat.Bmp);
                    break;
                case 1:
                    capture.Save(fileLocation + ".jpeg", ImageFormat.Jpeg);
                    break;
                case 2:
                    capture.Save(fileLocation + ".png", ImageFormat.Png);
                    break;
                default:
                    capture.Save(fileLocation + ".bmp", ImageFormat.Bmp);
                    break;
            }

            capture.Dispose();
        }

        /// <summary>
        /// Ensure that a folder is setup by checking if it exists and create one if not.
        /// </summary>
        private static void DirectoryIntegrityCheck()
        {
            if (Settings.Default.CaptureDirectory == "null" || !Directory.Exists(Settings.Default.CaptureDirectory))
            {
                Console.WriteLine("Setting default capture directory");
                string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "MiniLens");

                Directory.CreateDirectory(folder);
                Settings.Default.CaptureDirectory = folder;
                Settings.Default.Save();
            }
        }
    }
}
