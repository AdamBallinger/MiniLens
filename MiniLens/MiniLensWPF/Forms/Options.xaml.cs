using System;
using System.Windows;
using System.Windows.Input;
using MiniLens.Properties;
using System.Windows.Forms;
using System.IO;

namespace MiniLensWPF
{
    /// <summary>
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : Window
    {
        #region Fields
        bool inTBHotKey = false;

        // Store which text box is currently selected so we know what textbox to enter the key into.
        System.Windows.Controls.TextBox selectedTb = null;
        #endregion Fields

        #region Properties
        /// <summary>
        /// For checks if the end user is in
        /// a textbox for key input listening.
        /// </summary>
        private bool InTBHotKey
        {
            get { return this.inTBHotKey; }
            set { this.inTBHotKey = value; }
        }

        /// <summary>
        /// The textbox that the end user is
        /// currently active in for key input
        /// listening.
        /// </summary>
        private System.Windows.Controls.TextBox SelectedTb
        {
            get { return this.selectedTb; }
            set { this.selectedTb = value; }
        }
        #endregion Properties

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public Options()
        {
            InitializeComponent();
        }
        #endregion Constructor

        #region Events
        /// <summary>
        /// Loads all the data from settings
        /// and displays it to corresponding
        /// form controls.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Load settings
            tb_Directory.Text = Settings.Default.CaptureDirectory;
            tb_FullHot.Text = ((Keys)Settings.Default.FullscreenHotkey).ToString(); // Convert the stored byte value to a key
            tb_AreaHot.Text = ((Keys)Settings.Default.AreaHotkey).ToString(); // Convert the stored byte value to a key
            tb_WinHot.Text = ((Keys)Settings.Default.WindowHotkey).ToString(); // Convert the stored byte value to a key
            cb_FullScreen.IsChecked = Settings.Default.FullscreenEnabled;
            cb_Area.IsChecked = Settings.Default.AreaEnabled;
            cb_Window.IsChecked = Settings.Default.WindowEnabled;
            cb_Format.SelectedIndex = Settings.Default.CaptureFormat;

            //TODO: Implement these settings.
            //tb_Host.Text = Settings.Default.Hostname;
            //tb_Username.Text = Settings.Default.Username;
            //tb_Password.Text = Settings.Default.Password;

            cb_Minimised.IsChecked = Settings.Default.StartMinimised;
        }

        /// <summary>
        /// Get keyboard input for screenshot
        /// keyboard shortcut settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (this.InTBHotKey)
            {
                // Need to convert wpf key
                byte key = (byte)((Keys)KeyInterop.VirtualKeyFromKey(e.Key));
                Console.WriteLine("WPF Key: " + ((byte)e.Key).ToString() + " Converted VKkey: " + key.ToString());

                if (this.selectedTb == this.tb_FullHot)
                {
                    Settings.Default.FullscreenHotkey = key;
                }
                else if (this.SelectedTb == this.tb_AreaHot)
                {
                    Settings.Default.AreaHotkey = key;
                }
                else if (this.SelectedTb == this.tb_WinHot)
                {
                    Settings.Default.WindowHotkey = key;
                }

                this.selectedTb.Text = e.Key.ToString();
            }
        }

        /// <summary>
        /// Allow the end user to look for
        /// a directory to save images to.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Dir_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbdCaptureDir = new FolderBrowserDialog();
            DialogResult dr = fbdCaptureDir.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                tb_Directory.Text = fbdCaptureDir.SelectedPath;
            }
        }

        /// <summary>
        /// Start listening for keyboard inputs
        /// to change the full screenshot shortcut.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_FullHot_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            this.InTBHotKey = true;
            this.SelectedTb = tb_FullHot;
        }

        /// <summary>
        /// Stop listening for keyboard inputs
        /// to change the full screenshot shortcut.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_FullHot_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            this.InTBHotKey = false;
        }

        /// <summary>
        /// Start listening for keyboard inputs
        /// to change the area screenshot shortcut.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_AreaHot_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            this.InTBHotKey = true;
            this.SelectedTb = tb_AreaHot;
        }

        /// <summary>
        /// Stop listening for keyboard inputs
        /// to change the area screenshot shortcut.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_AreaHot_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            this.InTBHotKey = false;
        }

        /// <summary>
        /// Start listening for keyboard inputs
        /// to change the window screenshot shortcut.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_WinHot_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            this.InTBHotKey = true;
            this.SelectedTb = tb_WinHot;
        }

        /// <summary>
        /// Stop listening for keyboard inputs
        /// to change the window screenshot shortcut.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_WinHot_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            this.InTBHotKey = false;
        }

        /// <summary>
        /// Options save button click event that
        /// saves all the settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(tb_Directory.Text))
            {
                Settings.Default.CaptureDirectory = tb_Directory.Text;
            }

            Settings.Default.FullscreenEnabled = cb_FullScreen.IsChecked ?? false;
            Settings.Default.AreaEnabled = cb_Area.IsChecked ?? false;
            Settings.Default.WindowEnabled = cb_Window.IsChecked ?? false;

            Settings.Default.CaptureFormat = cb_Format.SelectedIndex;

            // TODO: These settings and setup a server
            // Settings.Default.Hostname = tb_Host.Text;
            // Settings.Default.Username = tb_Username.Text;
            // Settings.Default.Password = tb_Password.Text;

            Settings.Default.StartMinimised = cb_Minimised.IsChecked ?? false;

            Settings.Default.Save();
        }

        /// <summary>
        /// Options close button click event that closes
        /// the window without any changes made.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
