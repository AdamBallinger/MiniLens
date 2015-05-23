namespace MiniLens
{
    partial class FormMain
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
            this.btn_Fullscreen = new System.Windows.Forms.Button();
            this.btn_Area = new System.Windows.Forms.Button();
            this.btn_Window = new System.Windows.Forms.Button();
            this.btn_Opt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Fullscreen
            // 
            this.btn_Fullscreen.Location = new System.Drawing.Point(34, 12);
            this.btn_Fullscreen.Name = "btn_Fullscreen";
            this.btn_Fullscreen.Size = new System.Drawing.Size(146, 24);
            this.btn_Fullscreen.TabIndex = 0;
            this.btn_Fullscreen.Text = "Fullscreen";
            this.btn_Fullscreen.UseVisualStyleBackColor = true;
            this.btn_Fullscreen.Click += new System.EventHandler(this.btn_Fullscreen_Click);
            // 
            // btn_Area
            // 
            this.btn_Area.Location = new System.Drawing.Point(34, 42);
            this.btn_Area.Name = "btn_Area";
            this.btn_Area.Size = new System.Drawing.Size(146, 24);
            this.btn_Area.TabIndex = 1;
            this.btn_Area.Text = "Area";
            this.btn_Area.UseVisualStyleBackColor = true;
            this.btn_Area.Click += new System.EventHandler(this.btn_Area_Click);
            // 
            // btn_Window
            // 
            this.btn_Window.Location = new System.Drawing.Point(34, 72);
            this.btn_Window.Name = "btn_Window";
            this.btn_Window.Size = new System.Drawing.Size(146, 24);
            this.btn_Window.TabIndex = 2;
            this.btn_Window.Text = "Window";
            this.btn_Window.UseVisualStyleBackColor = true;
            this.btn_Window.Click += new System.EventHandler(this.btn_Window_Click);
            // 
            // btn_Opt
            // 
            this.btn_Opt.Location = new System.Drawing.Point(34, 102);
            this.btn_Opt.Name = "btn_Opt";
            this.btn_Opt.Size = new System.Drawing.Size(146, 24);
            this.btn_Opt.TabIndex = 3;
            this.btn_Opt.Text = "Options";
            this.btn_Opt.UseVisualStyleBackColor = true;
            this.btn_Opt.Click += new System.EventHandler(this.btn_Opt_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 139);
            this.Controls.Add(this.btn_Opt);
            this.Controls.Add(this.btn_Window);
            this.Controls.Add(this.btn_Area);
            this.Controls.Add(this.btn_Fullscreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MiniLens";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Fullscreen;
        private System.Windows.Forms.Button btn_Area;
        private System.Windows.Forms.Button btn_Window;
        private System.Windows.Forms.Button btn_Opt;
    }
}

