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


        public FormOptions()
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            //TODO: Set settings.
            Settings.Default.CaptureDirectory = tb_Directory.Text;
            //Settings.Default.FullscreenHotkey = 
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
                Properties.Settings.Default.FullscreenHotkey = (int)keyData;
                this.tb_FullHot.Text = keyData.ToString();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void tb_AreaHot_Enter(object sender, EventArgs e)
        {
            this.InTBHotKey = true;
        }

        private void tb_AreaHot_Leave(object sender, EventArgs e)
        {
            this.InTBHotKey = false;
        }
    }
}
