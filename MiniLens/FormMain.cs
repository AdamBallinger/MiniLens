using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //TODO: Default settings check
        }

        private void btn_Fullscreen_Click(object sender, EventArgs e)
        {

        }

        private void btn_Area_Click(object sender, EventArgs e)
        {

        }

        private void btn_Window_Click(object sender, EventArgs e)
        {

        }

        private void btn_Opt_Click(object sender, EventArgs e)
        {
            Form form = new FormOptions();
            form.ShowDialog();
        }
    }
}
