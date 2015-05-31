using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;
using MiniLens.Forms;
using MiniLens.Properties;

namespace MiniLens
{
    public static class Screenshot
    {
        /// <summary>
        /// This is the primary method to call when taking a full screenshot
        /// </summary>
        public static void FullScreenshot()
        {
            TakeScreenShot(SystemInformation.VirtualScreen);
        }

        /// <summary>
        /// This is the primary method to call when taking an area screenshot
        /// </summary>
        public static void AreaScreenshot()
        {
            // ToDo: Implement Area Screenshot functionality.
            CaptureArea ca = new CaptureArea();

            DialogResult dr = ca.ShowDialog();

            if (dr == DialogResult.OK)
            {
                TakeScreenShot(ca.ScreenArea);
            }
        }

        /// <summary>
        /// This is the primary method to call when taking a window screenshot.
        /// </summary>
        public static void WindowScreenshot()
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
        public static void DirectoryIntegrityCheck()
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