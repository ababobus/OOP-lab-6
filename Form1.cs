using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static readonly Pen PenCircleSelect = new Pen(Brushes.HotPink);
        public static readonly Pen PenCircleNotSelect = new Pen(Brushes.Black);

        //public static readonly int radius = 30;
        bool IsCtrl = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            PenCircleSelect.Width = 2;
            PenCircleNotSelect.Width = 2;
        }

        List<CCircle> Circles = new List<CCircle>();


        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            foreach (var i in Circles)
                i.Draw(e);
        }
        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            bool CircleClickFlag = false;
            if (IsCtrl == false || CtrlCheckBox.Checked == false)
                foreach (var i in Circles)
                    i.SetSelect(false);

            foreach (var i in Circles)
            {
                if (i.InShape(e.X, e.Y))
                {
                    i.ChangeSelect();
                    CircleClickFlag = true;
                    if (OverlayCheckBox.Checked == false)
                        break;
                }
            }

            if (CircleClickFlag == false)
            {
                if (IsCtrl == false || CtrlCheckBox.Checked == false)
                    foreach (var i in Circles)
                        i.SetSelect(false);
                Circles.Add(new CCircle(e.X, e.Y));
            }
            PictureBox.Invalidate();
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                for (int i = 0; i < Circles.Count(); ++i)
                {
                    if (Circles[i].GetSelect())
                    {
                        Circles.RemoveAt(i--);
                    }
                }
                if (Circles.Count != 0)
                    Circles.Last().SetSelect(true);

                PictureBox.Invalidate();
            }
            else if (e.Control)
            {
                IsCtrl = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                IsCtrl = false;
            }
        }

    }


}