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

            this.trayIcon.Visible = true;
            this.trayIcon.Icon = Properties.Resources.trayIcon1;
        }

        private void btn_Fullscreen_Click(object sender, EventArgs e)
        {
            Rectangle screenDim = new Rectangle();
            screenDim.X = Convert.ToInt32(SystemParameters.VirtualScreenLeft);
            screenDim.Y = Convert.ToInt32(SystemParameters.VirtualScreenTop);
            screenDim.Width = Convert.ToInt32(SystemParameters.VirtualScreenWidth);
            screenDim.Height = Convert.ToInt32(SystemParameters.VirtualScreenHeight);

            this.TakeScreenShot(screenDim.X, screenDim.Y, screenDim.Width, screenDim.Height);
        }

        private void btn_Area_Click(object sender, EventArgs e)
        {

        }

        private void btn_Directory_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.Default.CaptureDirectory);
        }

        private void btn_Window_Click(object sender, EventArgs e)
        {

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

        // https://msdn.microsoft.com/en-us/library/dd183370(v=vs.85).aspx
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        /// <summary>
        /// Takes a screenshot of a given area
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
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
            string formattedDt = dt.ToString().Replace('/', '-').Replace(':','-');
            
            Console.WriteLine("Saving picture to: " + Settings.Default.CaptureDirectory + "\\" + formattedDt + ".bmp");
            capture.Save(Settings.Default.CaptureDirectory + "\\" + formattedDt + ".bmp");
            
            capture.Dispose();
        }
    }
}
