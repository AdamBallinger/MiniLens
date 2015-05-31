using System.Drawing;
using System.Windows.Forms;

namespace MiniLens.Forms
{
    partial class CaptureArea
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaptureArea));
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            resources.ApplyResources(this.btn_Cancel, "btn_Cancel");
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Ok
            // 
            resources.ApplyResources(this.btn_Ok, "btn_Ok");
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // CaptureArea
            // 
            this.AcceptButton = this.btn_Ok;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btn_Cancel;
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.btn_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CaptureArea";
            this.Opacity = 0.7D;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CaptureArea_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Ok;
    }
}