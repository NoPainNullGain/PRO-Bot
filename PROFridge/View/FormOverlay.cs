using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PROFridge.View
{
    public partial class FormOverlay : Form
    {

        public static Form1 frm1;
        private RECT rect;
        public const string WINDOW_NAME = "PROClient";
        private IntPtr handle = FindWindow(null, WINDOW_NAME);

        private Graphics g;
        Pen pen = new Pen(Color.LimeGreen);

        public struct RECT
        {
            public int left, top, right, bottom;
        }
        

        


        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);


        public FormOverlay()
        {
            InitializeComponent();
            frm1 = new Form1();
        }

        private void FormOverlay_Load(object sender, EventArgs e)
        {
            

            this.BackColor = Color.Wheat;
            this.TransparencyKey = Color.Wheat;
            this.TopMost = true;
            //this.FormBorderStyle = FormBorderStyle.None;

            int initialStyle = GetWindowLong(this.Handle, -20);
            SetWindowLong(this.Handle, -20, initialStyle | 0x80000 | 0x20);

            GetWindowRect(handle, out rect);
            this.Size = new Size(rect.right - rect.left, rect.bottom - rect.top);
            this.Top = rect.top;
            this.Left = rect.left;
        }

        private void FormOverlay_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawRectangle(pen, 100, 100, 200, 200);
        }
    }
}
