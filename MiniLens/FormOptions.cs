using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniLens.Properties;

namespace MiniLens
{
    public partial class FormOptions : Form
    {
        bool inTBHotKey = false;

        // Store which text box is currently selected so we know what textbox to enter the key into.
        TextBox selectedTb = null;

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

        private TextBox SelectedTb
        {
            get { return this.selectedTb; }
            set { this.selectedTb = value; }
        }


        public FormOptions()
        {
            InitializeComponent();
        }

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

            Settings.Default.Save();
            btn_Close_Click(sender, e);
        }

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
                Properties.Settings.Default.FullscreenHotkey = (byte)keyData; // store byte value of the key
                this.selectedTb.Text = keyData.ToString();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void tb_FullHot_Enter(object sender, EventArgs e)
        {
            this.InTBHotKey = true;
            this.SelectedTb = tb_FullHot;
        }

        private void tb_FullHot_Leave(object sender, EventArgs e)
        {
            this.InTBHotKey = false;
        }

        private void tb_AreaHot_Enter(object sender, EventArgs e)
        {
            this.InTBHotKey = true;
            this.SelectedTb = tb_AreaHot;
        }

        private void tb_AreaHot_Leave(object sender, EventArgs e)
        {
            this.InTBHotKey = false;
        }

        private void tb_WinHot_Enter(object sender, EventArgs e)
        {
            this.InTBHotKey = true;
            this.SelectedTb = tb_WinHot;
        }

        private void tb_WinHot_Leave(object sender, EventArgs e)
        {
            this.InTBHotKey = false;
        }

        private void FormOptions_Load(object sender, EventArgs e)
        {
            //Load settings
            tb_Directory.Text = Settings.Default.CaptureDirectory;
            tb_FullHot.Text = ((Keys) Settings.Default.FullscreenHotkey).ToString(); // Convert the stored byte value to a key
            tb_AreaHot.Text = ((Keys)Settings.Default.AreaHotkey).ToString(); // Convert the stored byte value to a key
            tb_WinHot.Text = ((Keys)Settings.Default.WindowHotkey).ToString(); // Convert the stored byte value to a key
            cb_FullScreen.Checked = Settings.Default.FullscreenEnabled;
            cb_Area.Checked = Settings.Default.AreaEnabled;
            cb_Window.Checked = Settings.Default.WindowEnabled;
            cb_Format.SelectedIndex = Settings.Default.CaptureFormat;

            tb_Host.Text = Settings.Default.Hostname;
            tb_Username.Text = Settings.Default.Username;
            tb_Password.Text = Settings.Default.Password;
        }
    }
}
