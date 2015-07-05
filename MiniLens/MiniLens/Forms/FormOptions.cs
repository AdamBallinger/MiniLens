using System;
using System.Windows.Forms;
using MiniLens.Properties;

namespace MiniLens
{
    public partial class FormOptions : Form
    {
        #region Fields
        bool inTBHotKey = false;
        TextBox selectedTb = null;
        #endregion Fields

        #region Properties
        /// <summary>
        /// For checks if the end user is in
        /// a textbox for key input listening.
        /// </summary>
        private bool InTBHotKey
        {
            get
            {
                return this.inTBHotKey;
            }
            set
            {
                this.inTBHotKey = value;
            }
        }

        /// <summary>
        /// The textbox that the end user is
        /// currently active in for key input
        /// listening.
        /// </summary>
        private TextBox SelectedTb
        {
            get
            {
                return this.selectedTb;
            }
            set
            {
                this.selectedTb = value;
            }
        }
        #endregion Properties

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public FormOptions()
        {
            InitializeComponent();
        }
        #endregion Constructors

        #region Events
        /// <summary>
        /// Options save button click event that
        /// saves all the settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            //TODO: Set settings.
            Settings.Default.CaptureDirectory = tb_Directory.Text;

            Settings.Default.FullscreenEnabled = cb_FullScreen.Checked;
            Settings.Default.AreaEnabled = cb_Area.Checked;
            Settings.Default.WindowEnabled = cb_Window.Checked;

            Settings.Default.CaptureFormat = cb_Format.SelectedIndex;

            Settings.Default.Hostname = tb_Host.Text;
            Settings.Default.Username = tb_Username.Text;
            Settings.Default.Password = tb_Password.Text;

            Settings.Default.StartMinimised = cb_Minimised.Checked;

            Settings.Default.Save();
            btn_Close_Click(sender, e);
        }

        /// <summary>
        /// Options close button click event that closes
        /// the window without any changes made.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Gets all the keys pressed. This helps
        /// with the limitation of TextBox not
        /// detecting Function keys.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData">The key pressed</param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (this.InTBHotKey)
            {
                Console.WriteLine((byte)keyData);

                if (this.selectedTb == this.tb_FullHot)
                {
                    Settings.Default.FullscreenHotkey = (byte)keyData;
                }
                else if (this.SelectedTb == this.tb_AreaHot)
                {
                    Settings.Default.AreaHotkey = (byte)keyData;
                }
                else if (this.SelectedTb == this.tb_WinHot)
                {
                    Settings.Default.WindowHotkey = (byte)keyData;
                }

                this.selectedTb.Text = keyData.ToString();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Start listening for keyboard inputs
        /// to change the full screenshot shortcut.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_FullHot_Enter(object sender, EventArgs e)
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
        private void tb_FullHot_Leave(object sender, EventArgs e)
        {
            this.InTBHotKey = false;
        }

        /// <summary>
        /// Start listening for keyboard inputs
        /// to change the area screenshot shortcut.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_AreaHot_Enter(object sender, EventArgs e)
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
        private void tb_AreaHot_Leave(object sender, EventArgs e)
        {
            this.InTBHotKey = false;
        }

        /// <summary>
        /// Start listening for keyboard inputs
        /// to change the window screenshot shortcut.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_WinHot_Enter(object sender, EventArgs e)
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
        private void tb_WinHot_Leave(object sender, EventArgs e)
        {
            this.InTBHotKey = false;
        }

        /// <summary>
        /// Loads all the data from settings
        /// and displays it to corresponding
        /// form controls.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormOptions_Load(object sender, EventArgs e)
        {
            //Load settings
            tb_Directory.Text = Settings.Default.CaptureDirectory;
            tb_FullHot.Text = ((Keys)Settings.Default.FullscreenHotkey).ToString(); // Convert the stored byte value to a key
            tb_AreaHot.Text = ((Keys)Settings.Default.AreaHotkey).ToString(); // Convert the stored byte value to a key
            tb_WinHot.Text = ((Keys)Settings.Default.WindowHotkey).ToString(); // Convert the stored byte value to a key
            cb_FullScreen.Checked = Settings.Default.FullscreenEnabled;
            cb_Area.Checked = Settings.Default.AreaEnabled;
            cb_Window.Checked = Settings.Default.WindowEnabled;
            cb_Format.SelectedIndex = Settings.Default.CaptureFormat;

            tb_Host.Text = Settings.Default.Hostname;
            tb_Username.Text = Settings.Default.Username;
            tb_Password.Text = Settings.Default.Password;

            cb_Minimised.Checked = Settings.Default.StartMinimised;
        }

        /// <summary>
        /// Allow the end user to look for
        /// a directory to save images to.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Dir_Click(object sender, EventArgs e)
        {
            DialogResult dr = fbd_CaptureDir.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tb_Directory.Text = fbd_CaptureDir.SelectedPath;
            }
        }
        #endregion Events
    }
}
