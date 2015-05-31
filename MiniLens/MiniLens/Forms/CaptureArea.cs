using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MiniLens.Forms
{
    public partial class CaptureArea : Form
    {
        private Rectangle screenArea = new Rectangle();

        public Rectangle ScreenArea
        {
            get
            {
                return this.screenArea;
            }
            set
            {
                this.screenArea = value;
            }
        }

        public CaptureArea()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void CaptureArea_Paint(object sender, PaintEventArgs e)
        {
            float penLen = 20;
            float penWidth = 10.0f;
            float penbuf = penWidth/2;

            Pen pen = new Pen(Color.FromArgb(255, 255, 0, 0), penWidth);
            
            // Draw corner lines on form
            // (T)op (L)eft (R)ight (B)ottom (H)orizontal (V)ertical
            e.Graphics.DrawLine(pen, 0, penbuf, penLen, penbuf); // TLH
            e.Graphics.DrawLine(pen, penbuf, 0, penbuf, penLen); // TLV
            e.Graphics.DrawLine(pen, this.Width, penbuf, this.Width - penLen, penbuf); // TRH
            e.Graphics.DrawLine(pen, this.Width - penbuf, 0, this.Width - penbuf, penLen); // TRV
            e.Graphics.DrawLine(pen, this.Width, this.Height - penbuf, this.Width - penLen, this.Height - penbuf); // BRH
            e.Graphics.DrawLine(pen, this.Width - penbuf, this.Height, this.Width - penbuf, this.Height - penLen); // BRV
            e.Graphics.DrawLine(pen, 0, this.Height - penbuf, penLen, this.Height - penbuf); // BLH
            e.Graphics.DrawLine(pen, 0, this.Height, penbuf, this.Height - penLen); // BLV
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                                         Color.Red, 10, ButtonBorderStyle.Dashed,
                                         Color.Red, 10, ButtonBorderStyle.Dashed,
                                         Color.Red, 10, ButtonBorderStyle.Dashed,
                                         Color.Red, 10, ButtonBorderStyle.Dashed);
        }

        /// <summary>
        /// Process resize and movement of form without needing a border
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            // https://msdn.microsoft.com/en-us/library/windows/desktop/ms645618%28v=vs.85%29.aspx
            const UInt32 WM_NCHITTEST = 0x0084;
            const UInt32 WM_MOUSEMOVE = 0x0200;

            const UInt32 HTLEFT = 10;
            const UInt32 HTRIGHT = 11;
            const UInt32 HTBOTTOMRIGHT = 17;
            const UInt32 HTBOTTOM = 15;
            const UInt32 HTBOTTOMLEFT = 16;
            const UInt32 HTTOP = 12;
            const UInt32 HTTOPLEFT = 13;
            const UInt32 HTTOPRIGHT = 14;
            const UInt32 HTCAPTION = 2;

            const int RESIZE_HANDLE_SIZE = 10;

            bool handled = false;

            if (m.Msg == WM_NCHITTEST || m.Msg == WM_MOUSEMOVE)
            {
                Size formSize = this.Size;
                Point screenPoint = new Point(m.LParam.ToInt32());
                Point clientPoint = this.PointToClient(screenPoint);
            
                // Collision boxes
                Dictionary<UInt32, Rectangle> boxes = new Dictionary<UInt32, Rectangle>() {
                    {HTBOTTOMLEFT, new Rectangle(0, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
                    {HTBOTTOM, new Rectangle(RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, formSize.Width - 2*RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
                    {HTBOTTOMRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
                    {HTRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, formSize.Height - 2*RESIZE_HANDLE_SIZE)},
                    {HTTOPRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, 0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
                    {HTTOP, new Rectangle(RESIZE_HANDLE_SIZE, 0, formSize.Width - 2*RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
                    {HTTOPLEFT, new Rectangle(0, 0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
                    {HTLEFT, new Rectangle(0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, formSize.Height - 2*RESIZE_HANDLE_SIZE) },
                    {HTCAPTION, new Rectangle(RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, formSize.Width - (2 * RESIZE_HANDLE_SIZE), formSize.Height - (2* RESIZE_HANDLE_SIZE))}
                };
            
                foreach (KeyValuePair<UInt32, Rectangle> hitBox in boxes)
                {
                    // Check for a collision
                    if (hitBox.Value.Contains(clientPoint))
                    {
                        m.Result = (IntPtr)hitBox.Key;
                        handled = true;
                        break;
                    }
                }
            }

            if (!handled)
            {
                base.WndProc(ref m);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            this.screenArea.X = this.Location.X;
            this.screenArea.Y = this.Location.Y;
            this.screenArea.Width = this.Width;
            this.screenArea.Height = this.Height;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
