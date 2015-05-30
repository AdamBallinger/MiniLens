using System.Security.AccessControl;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btn_Fullscreen = new System.Windows.Forms.Button();
            this.btn_Area = new System.Windows.Forms.Button();
            this.btn_Window = new System.Windows.Forms.Button();
            this.btn_Opt = new System.Windows.Forms.Button();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Directory = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
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
            this.btn_Opt.Location = new System.Drawing.Point(34, 131);
            this.btn_Opt.Name = "btn_Opt";
            this.btn_Opt.Size = new System.Drawing.Size(146, 24);
            this.btn_Opt.TabIndex = 3;
            this.btn_Opt.Text = "Options";
            this.btn_Opt.UseVisualStyleBackColor = true;
            this.btn_Opt.Click += new System.EventHandler(this.btn_Opt_Click);
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Mini Lens";
            this.trayIcon.Visible = true;
            this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(180, 114);
            this.contextMenuStrip1.Text = "MiniLens";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItem5.Text = "MiniLens";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.ts_OpenFormMain);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItem1.Text = "Full Screenshot";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ts_FullScreenShot);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItem2.Text = "Area Screenshot";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.ts_AreaScreenShot);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItem3.Text = "Window Screenshot";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.ts_WindowScreenShot);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItem4.Text = "Close";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.ts_CloseApplication);
            // 
            // btn_Directory
            // 
            this.btn_Directory.Location = new System.Drawing.Point(34, 102);
            this.btn_Directory.Name = "btn_Directory";
            this.btn_Directory.Size = new System.Drawing.Size(146, 23);
            this.btn_Directory.TabIndex = 4;
            this.btn_Directory.Text = "Open Picture Folder";
            this.btn_Directory.UseVisualStyleBackColor = true;
            this.btn_Directory.Click += new System.EventHandler(this.btn_Directory_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 164);
            this.Controls.Add(this.btn_Directory);
            this.Controls.Add(this.btn_Opt);
            this.Controls.Add(this.btn_Window);
            this.Controls.Add(this.btn_Area);
            this.Controls.Add(this.btn_Fullscreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MiniLens";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Fullscreen;
        private System.Windows.Forms.Button btn_Area;
        private System.Windows.Forms.Button btn_Window;
        private System.Windows.Forms.Button btn_Opt;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.Button btn_Directory;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
    }
}

