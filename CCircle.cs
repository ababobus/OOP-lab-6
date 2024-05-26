
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

        public Shape DoConstruct() { 
            return new CCircle(); 
        }
        public void SetX(int x) { 
            this.x = x; 
        }
        public void SetY(int y) { 
            this.y = y; 
        }
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

        public bool Movable(string s, int num, int end)
        {
            if (s == "left")
            {
                //if (this.x - this.radius + num < 0) this.x = this.radius;
                return (this.x - this.radius + num > 0);
            }
            if (s == "right")
            {
                return (this.x + this.radius + num < end); //this.x = end - this.radius - 1;
            }
            if (s == "up")
            {
                return (this.y - this.radius + num > 0); //this.y = this.radius;
            }
            if (s == "down")
            {
                return (this.y + this.radius + num < end); // this.y = end - 1 - this.radius;
            }
            else
            {
                return false;
            }
        }

        public void MoveX(string s, int num, int end)
        {
            if (s == "left" && !Movable(s, num, end)) 
            //if (this.x - this.radius + num < begin)
                this.x = 0 + this.radius;
            else if (s == "right" && !Movable(s, num, end))
                this.x = end - this.radius;
            else
                this.x += num;
        }
        public void MoveY(string s, int num, int end)
        {
            if (s == "up" && !Movable(s, num, end))
                this.y = this.radius;
            else if (s == "down" && !Movable(s, num, end))
                this.y = end - this.radius;
            else
                this.y += num;
        }
        public void ChangeSize(int num, int width, int height)
        {
            if (Movable("left", -num, 0) && Movable("up", -num, 0) && Movable("right", num, width) && Movable("down", num, height) && this.radius + num >0)
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