using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PROFridge.ViewModel.HelperClasses;


namespace PROFridge.View
{
    public partial class FormOverlay : Form
    {


        private RECT rect;
        public const string WINDOW_NAME = "PROClient";
        private IntPtr handle = FindWindow(null, WINDOW_NAME);

        public Singleton singleton = Singleton.Instance;
        public List<Coordinates> XYList;
        public Coordinates coordinates;

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

        }

        private void FormOverlay_Load(object sender, EventArgs e)
        {
            XYList = singleton.XYList;

            float currentXCoord = singleton.XYList.Last().CoordX;
            float currentYCoord = singleton.XYList.Last().CoordY;

            float secondLastXCoord = singleton.XYList.Last().CoordX - 1;
            float secondLastYCoord = singleton.XYList.Last().CoordY - 1;




            this.BackColor = Color.Wheat;
            this.TransparencyKey = Color.Wheat;
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;

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



            var points = new List<PointF>
            {
                new PointF(0, 0),
                new PointF(50, 50),
                new PointF(100, 100),
                new PointF(250, 250)
            };


            for (int i = 0; i < XYList.Count; i++)
            {
                g.DrawLine(pen, singleton.XYList[i].CoordXLast, singleton.XYList[i].CoordYLast, singleton.XYList[i].CoordX, singleton.XYList[i].CoordY);

            }

            g.DrawLine(pen, 100, 100, 200, 200);
            //}
        }
    }
}
