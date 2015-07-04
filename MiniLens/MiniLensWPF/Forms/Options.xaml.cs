using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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

        private bool InTBHotKey
        {
            get { return this.inTBHotKey; }
            set { this.inTBHotKey = value; }
        }

        private System.Windows.Controls.TextBox SelectedTb
        {
            get { return this.selectedTb; }
            set { this.selectedTb = value; }
        }
        #endregion Properties

        #region Constructor
        public Options()
        {
            InitializeComponent();
        }
        #endregion Constructor

        #region Events
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

            //tb_Host.Text = Settings.Default.Hostname;
            //tb_Username.Text = Settings.Default.Username;
            //tb_Password.Text = Settings.Default.Password;

            cb_Minimised.IsChecked = Settings.Default.StartMinimised;
        }

        private void Window_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (this.InTBHotKey)
            {
                // Need to convert wpf key
                byte key = (byte)((Keys)KeyInterop.VirtualKeyFromKey(e.Key));
                Console.WriteLine("WPF Key: " + ((byte)e.Key).ToString() + " Converted key: " + key.ToString());

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

        private void btn_Dir_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fbd_CaptureDir = new FolderBrowserDialog();
            System.Windows.Forms.DialogResult dr = fbd_CaptureDir.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                tb_Directory.Text = fbd_CaptureDir.SelectedPath;
            }
        }

        private void tb_FullHot_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            this.InTBHotKey = true;
            this.SelectedTb = tb_FullHot;
        }

        private void tb_FullHot_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            this.InTBHotKey = false;
        }
        private void tb_AreaHot_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            this.InTBHotKey = true;
            this.SelectedTb = tb_AreaHot;
        }

        private void tb_AreaHot_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            this.InTBHotKey = false;
        }

        private void tb_WinHot_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            this.InTBHotKey = true;
            this.SelectedTb = tb_WinHot;
        }

        private void tb_WinHot_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            this.InTBHotKey = false;
        }

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

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
