using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniLens.Properties;

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
