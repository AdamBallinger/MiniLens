using System;
using System.Diagnostics;
using System.Windows.Forms;
using MiniLens.Properties;

namespace MiniLens
{
    //TODO: Move the logic of this class into a seperate class
    public partial class FormMain : Form
    {
        #region Constructor
        /// <summary>
        /// Default constructor.
        /// </summary>
        public FormMain()
        {
            KeyboardHook.HookID = KeyboardHook.SetHook(KeyboardHook.Proc);
            InitializeComponent();
        }
        #endregion Constructor

        #region Events
        /// <summary>
        /// Window Load event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            //TODO: Default settings check
            Screenshot.DirectoryIntegrityCheck();

            if (Settings.Default.StartMinimised)
            {
                this.WindowState = FormWindowState.Minimized;
                this.OnResize(EventArgs.Empty);
                //this.MinimiseWindow();
            }
        }

        /// <summary>
        /// Full Screenshot button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Fullscreen_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Taking full screenshot from Main Window");
            Screenshot.FullScreenshot();
        }

        /// <summary>
        /// Area Screenshot button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Area_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Taking area screenshot from Main Window");
            Screenshot.AreaScreenshot();
        }

        /// <summary>
        /// Window Screenshot button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Window_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Taking window screenshot from Main Window");
            Screenshot.WindowScreenshot();
        }

        /// <summary>
        /// Directory button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Directory_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Opening the image directory");
            Process.Start(Settings.Default.CaptureDirectory);
        }

        /// <summary>
        /// Options button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                this.MinimiseWindow();
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
            Screenshot.FullScreenshot();
        }

        private void ts_AreaScreenShot(Object sender, EventArgs e)
        {
            Console.WriteLine("Taking area screenshot from notification icon tool strip.");
            Screenshot.AreaScreenshot();
        }

        private void ts_WindowScreenShot(Object sender, EventArgs e)
        {
            Console.WriteLine("Taking window screenshot from notification icon tool strip.");
            Screenshot.WindowScreenshot();
        }

        private void ts_CloseApplication(Object sender, EventArgs e)
        {
            Console.WriteLine("Closing the application from the notification icon tool strip.");
            this.Close();
        }

        /// <summary>
        /// Window Closing event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            KeyboardHook.Unhook();

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
        #endregion Events

        #region Methods
        private void MinimiseWindow()
        {
            Console.WriteLine("The main window is now minimised.");
            trayIcon.ShowBalloonTip(5, "Minimised!", "Double click to reopen.", ToolTipIcon.Info);
            this.Visible = false;
        }
        #endregion Methods
    }
}
