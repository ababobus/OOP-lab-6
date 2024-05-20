
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Shapes;

namespace WindowsFormsApp1.Shapes
{
    class CCircle : Shape
    {
        private int x, y;
        private int radius = 30;
        private Color color;
        bool Selected = false;

        public CCircle()
        {
            this.x = 0;
            this.y = 0;
        }
        public CCircle(int x, int y)
        {
            this.x = x;
            this.y = y;
            Selected = true;
            this.color = Color.LightBlue;
        }

        public Shape DoConstruct() { return new CCircle(); }
        public void SetX(int x) { this.x = x; }
        public void SetY(int y) { this.y = y; }
        public void Draw(PaintEventArgs e)
        {
            Brush brush = new SolidBrush(this.color);
            Graphics graphic = e.Graphics;
            graphic.DrawEllipse((Selected ? Form1.PenCircleSelect : Form1.PenCircleNotSelect), this.x - radius, this.y - radius, radius * 2, radius * 2);
            graphic.FillEllipse(brush, this.x - radius, this.y - radius, radius * 2, radius * 2);
        }
        public bool InShape(int x, int y)
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

        public void MoveX(int num, int start, int end)
        {
            if (this.x - this.radius + num < start)
                this.x = start + this.radius;
            else if (this.x + this.radius + num > end)
                this.x = end - 1 - this.radius;
            else
                this.x += num;
        }
        public void MoveY(int num, int start, int end)
        {
            if (this.y - this.radius + num < 0)
                this.y = this.radius;
            else if (this.y + this.radius + num > end)
                this.y = end - 1 - this.radius;
            else
                this.y += num;
        }
        public void ChangeSize(int num, int width, int height)
        {
            if (this.x - this.radius - num > 0 && this.y - this.radius - num > 0 && this.x + this.radius + num < width && this.y + this.radius + num < height && this.radius + num > 0)
                this.radius += num;
        }
        public void SetColor(Color color)
        {
            if (Selected)
            {
                this.color = color;

            }

        }


    }
}