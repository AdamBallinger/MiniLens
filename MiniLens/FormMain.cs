using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using MiniLens.Properties;
using System.Runtime.InteropServices;
using System.Windows;

namespace MiniLens
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            //TODO: Default settings check
            if (Settings.Default.CaptureDirectory == "null")
            {
                Console.WriteLine("Setting default capture directory to user pictures folder.");
                Settings.Default.CaptureDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                Settings.Default.Save();
            }
        }

        private void btn_Fullscreen_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Taking full screenshot from Main Window");
            this.FullScreenshot();
        }

        private void btn_Area_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Taking area screenshot from Main Window");
            this.AreaScreenshot();
        }

        private void btn_Window_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Taking window screenshot from Main Window");
            this.WindowScreenshot();
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
            this.FullScreenshot();
        }

        private void ts_AreaScreenShot(Object sender, EventArgs e)
        {
            Console.WriteLine("Taking area screenshot from notification icon tool strip.");
            this.AreaScreenshot();
        }

        private void ts_WindowScreenShot(Object sender, EventArgs e)
        {
            Console.WriteLine("Taking window screenshot from notification icon tool strip.");
            this.WindowScreenshot();
        }

        private void ts_CloseApplication(Object sender, EventArgs e)
        {
            Console.WriteLine("Closing the application from the notification icon tool strip.");
            this.Close();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
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
        private void FullScreenshot()
        {
            Rectangle screenDim = new Rectangle();
            screenDim.X = Convert.ToInt32(SystemParameters.VirtualScreenLeft);
            screenDim.Y = Convert.ToInt32(SystemParameters.VirtualScreenTop);
            screenDim.Width = Convert.ToInt32(SystemParameters.VirtualScreenWidth);
            screenDim.Height = Convert.ToInt32(SystemParameters.VirtualScreenHeight);

            this.TakeScreenShot(screenDim.X, screenDim.Y, screenDim.Width, screenDim.Height);
        }

        /// <summary>
        /// This is the primary method to call when taking an area screenshot
        /// </summary>
        private void AreaScreenshot()
        {
            // ToDo: Insert code here.
            throw new NotImplementedException();
        }

        /// <summary>
        /// This is the primary method to call when taking a window screenshot.
        /// </summary>
        private void WindowScreenshot()
        {
            // ToDo: Insert code here.
            throw new NotImplementedException();
        }

        // https://msdn.microsoft.com/en-us/library/dd183370(v=vs.85).aspx
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        /// <summary>
        /// Takes a screenshot of a given area.
        /// </summary>
        /// <param name="x">Left</param>
        /// <param name="y">Top</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        private void TakeScreenShot(int x, int y, int width, int height)
        {
            // ToDo: Need to implement image encoding/compression (png, jpg)

            Bitmap capture = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            using (Graphics gdest = Graphics.FromImage(capture))
            {
                using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
                {
                    IntPtr hSrcDC = gsrc.GetHdc();
                    IntPtr hDC = gdest.GetHdc();
                    BitBlt(hDC, x, y, width, height, hSrcDC, x, y, (int)CopyPixelOperation.SourceCopy);
                    gdest.ReleaseHdc();
                    gsrc.ReleaseHdc();
                }
            }

            DateTime dt = DateTime.Now;
            string formattedDt = dt.ToString().Replace('/', '-').Replace(':', '-');

            Console.WriteLine("Saving picture to: " + Settings.Default.CaptureDirectory + "\\" + formattedDt);

            switch (Settings.Default.CaptureFormat)
            {
                case 0:
                    capture.Save(Settings.Default.CaptureDirectory + "\\" + formattedDt + ".bmp", ImageFormat.Bmp);
                    break;
                case 1:
                    capture.Save(Settings.Default.CaptureDirectory + "\\" + formattedDt + ".jpeg", ImageFormat.Jpeg);
                    break;
                case 2:
                    capture.Save(Settings.Default.CaptureDirectory + "\\" + formattedDt + ".png", ImageFormat.Png);
                    break;
                default:
                    capture.Save(Settings.Default.CaptureDirectory + "\\" + formattedDt + ".bmp", ImageFormat.Bmp);
                    break;
            }

            capture.Dispose();
        }
    }
}
