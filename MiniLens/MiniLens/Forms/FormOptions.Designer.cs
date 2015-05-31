namespace MiniLens
{
    partial class FormOptions
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
            this.tb_Directory = new System.Windows.Forms.TextBox();
            this.btn_Dir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_Format = new System.Windows.Forms.ComboBox();
            this.cb_Window = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_WinHot = new System.Windows.Forms.TextBox();
            this.cb_Area = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_AreaHot = new System.Windows.Forms.TextBox();
            this.cb_FullScreen = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_FullHot = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_Username = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_Host = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.fbd_CaptureDir = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_Directory
            // 
            this.tb_Directory.Location = new System.Drawing.Point(101, 31);
            this.tb_Directory.Name = "tb_Directory";
            this.tb_Directory.Size = new System.Drawing.Size(202, 20);
            this.tb_Directory.TabIndex = 0;
            // 
            // btn_Dir
            // 
            this.btn_Dir.Location = new System.Drawing.Point(312, 29);
            this.btn_Dir.Name = "btn_Dir";
            this.btn_Dir.Size = new System.Drawing.Size(29, 23);
            this.btn_Dir.TabIndex = 1;
            this.btn_Dir.Text = "...";
            this.btn_Dir.UseVisualStyleBackColor = true;
            this.btn_Dir.Click += new System.EventHandler(this.btn_Dir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Capture Directory:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cb_Format);
            this.groupBox1.Controls.Add(this.cb_Window);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tb_WinHot);
            this.groupBox1.Controls.Add(this.cb_Area);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_AreaHot);
            this.groupBox1.Controls.Add(this.cb_FullScreen);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_FullHot);
            this.groupBox1.Controls.Add(this.tb_Directory);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_Dir);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 187);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Capture Settings";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Capture Format:";
            // 
            // cb_Format
            // 
            this.cb_Format.FormattingEnabled = true;
            this.cb_Format.Items.AddRange(new object[] {
            "PNG",
            "JPEG",
            "BMP"});
            this.cb_Format.Location = new System.Drawing.Point(101, 148);
            this.cb_Format.Name = "cb_Format";
            this.cb_Format.Size = new System.Drawing.Size(100, 21);
            this.cb_Format.TabIndex = 12;
            // 
            // cb_Window
            // 
            this.cb_Window.AutoSize = true;
            this.cb_Window.Location = new System.Drawing.Point(224, 123);
            this.cb_Window.Name = "cb_Window";
            this.cb_Window.Size = new System.Drawing.Size(71, 17);
            this.cb_Window.TabIndex = 11;
            this.cb_Window.Text = "Enabled?";
            this.cb_Window.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Window Hotkey:";
            // 
            // tb_WinHot
            // 
            this.tb_WinHot.BackColor = System.Drawing.SystemColors.Window;
            this.tb_WinHot.Location = new System.Drawing.Point(101, 121);
            this.tb_WinHot.Name = "tb_WinHot";
            this.tb_WinHot.ReadOnly = true;
            this.tb_WinHot.Size = new System.Drawing.Size(100, 20);
            this.tb_WinHot.TabIndex = 9;
            this.tb_WinHot.Enter += new System.EventHandler(this.tb_WinHot_Enter);
            this.tb_WinHot.Leave += new System.EventHandler(this.tb_WinHot_Leave);
            // 
            // cb_Area
            // 
            this.cb_Area.AutoSize = true;
            this.cb_Area.Location = new System.Drawing.Point(224, 97);
            this.cb_Area.Name = "cb_Area";
            this.cb_Area.Size = new System.Drawing.Size(71, 17);
            this.cb_Area.TabIndex = 8;
            this.cb_Area.Text = "Enabled?";
            this.cb_Area.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Area Hotkey:";
            // 
            // tb_AreaHot
            // 
            this.tb_AreaHot.BackColor = System.Drawing.SystemColors.Window;
            this.tb_AreaHot.Location = new System.Drawing.Point(101, 95);
            this.tb_AreaHot.Name = "tb_AreaHot";
            this.tb_AreaHot.ReadOnly = true;
            this.tb_AreaHot.Size = new System.Drawing.Size(100, 20);
            this.tb_AreaHot.TabIndex = 6;
            this.tb_AreaHot.Enter += new System.EventHandler(this.tb_AreaHot_Enter);
            this.tb_AreaHot.Leave += new System.EventHandler(this.tb_AreaHot_Leave);
            // 
            // cb_FullScreen
            // 
            this.cb_FullScreen.AutoSize = true;
            this.cb_FullScreen.Location = new System.Drawing.Point(224, 71);
            this.cb_FullScreen.Name = "cb_FullScreen";
            this.cb_FullScreen.Size = new System.Drawing.Size(71, 17);
            this.cb_FullScreen.TabIndex = 5;
            this.cb_FullScreen.Text = "Enabled?";
            this.cb_FullScreen.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fullscreen Hotkey:";
            // 
            // tb_FullHot
            // 
            this.tb_FullHot.BackColor = System.Drawing.SystemColors.Window;
            this.tb_FullHot.Location = new System.Drawing.Point(101, 69);
            this.tb_FullHot.Name = "tb_FullHot";
            this.tb_FullHot.ReadOnly = true;
            this.tb_FullHot.Size = new System.Drawing.Size(100, 20);
            this.tb_FullHot.TabIndex = 3;
            this.tb_FullHot.Enter += new System.EventHandler(this.tb_FullHot_Enter);
            this.tb_FullHot.Leave += new System.EventHandler(this.tb_FullHot_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_Password);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tb_Username);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tb_Host);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 205);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(351, 119);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server Settings";
            // 
            // tb_Password
            // 
            this.tb_Password.Location = new System.Drawing.Point(101, 79);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.Size = new System.Drawing.Size(240, 20);
            this.tb_Password.TabIndex = 5;
            this.tb_Password.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Password:";
            // 
            // tb_Username
            // 
            this.tb_Username.Location = new System.Drawing.Point(101, 53);
            this.tb_Username.Name = "tb_Username";
            this.tb_Username.Size = new System.Drawing.Size(240, 20);
            this.tb_Username.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Username:";
            // 
            // tb_Host
            // 
            this.tb_Host.Location = new System.Drawing.Point(101, 27);
            this.tb_Host.Name = "tb_Host";
            this.tb_Host.Size = new System.Drawing.Size(240, 20);
            this.tb_Host.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Hostname:";
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(207, 334);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 5;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(288, 334);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 6;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // FormOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 369);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormOptions";
            this.Load += new System.EventHandler(this.FormOptions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Directory;
        private System.Windows.Forms.Button btn_Dir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_FullHot;
        private System.Windows.Forms.CheckBox cb_Window;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_WinHot;
        private System.Windows.Forms.CheckBox cb_Area;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_AreaHot;
        private System.Windows.Forms.CheckBox cb_FullScreen;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_Username;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_Host;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cb_Format;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.FolderBrowserDialog fbd_CaptureDir;
    }
}