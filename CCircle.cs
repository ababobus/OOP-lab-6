
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class CCircle
    {
        private int x;
        private int y;
        static readonly int radius = 30;
        bool Selected = false;

        public CCircle(int x, int y)
        {
            this.x = x;
            this.y = y;
            Selected = true;
        }

        public void Draw(PaintEventArgs e)
        {
            Graphics graphic = e.Graphics;
            graphic.DrawEllipse((Selected ? Form1.PenCircleSelect : Form1.PenCircleNotSelect), this.x - radius, this.y - radius, radius * 2, radius * 2);
        }

        public bool IsClicked(int x, int y)
        {
            if ((this.x - x) * (this.x - x) + (this.y - y) * (this.y - y) <= radius * radius)
                return true;
            else
                return false;
        }
        public void SetSelect(bool select)
        {
            Selected = select;
        }
        public void ChangeSelect()
        {
            Selected = !Selected;
        }
        public bool GetSelect()
        {
            return Selected;
        }
    }
}