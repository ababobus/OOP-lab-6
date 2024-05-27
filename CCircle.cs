
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
    class CCircle : ShapeParent
    {
        private int radius = 30;
        public override ShapeParent DoConstruct() { 
            return new CCircle(); 
        }
        
        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawEllipse((Selected ? Form1.PenCircleSelect : Form1.PenCircleNotSelect), this.x - radius, this.y - radius, radius * 2, radius * 2);
            e.Graphics.FillEllipse(new SolidBrush(color), this.x - radius, this.y - radius, radius * 2, radius * 2);
        }
        public override bool InShape(int x, int y)
        {
            if ((this.x - x) * (this.x - x) + (this.y - y) * (this.y - y) <= radius * radius)
                return true;
            else
                return false;
        }

        public override bool Movable(string s, int num, int end)
        {
            if (s == "left")
            {
                return (this.x - this.radius + num > 0);
            }
            if (s == "right")
            {
                return (this.x + this.radius + num < end); 
            }
            if (s == "up")
            {
                return (this.y - this.radius + num > 0); 
            }
            if (s == "down")
            {
                return (this.y + this.radius + num < end);
            }
            else
            {
                return false;
            }
        }

        public override void MoveX(string s, int num, int end)
        {
            if (s == "left" && !Movable(s, num, end)) 
            //if (this.x - this.radius + num < begin)
                this.x = this.radius +1;
            else if (s == "right" && !Movable(s, num, end))
                this.x = end - this.radius -3;
            else
                this.x += num;
        }
        public override void MoveY(string s, int num, int end)
        {
            if (s == "up" && !Movable(s, num, end))
                this.y = this.radius + 1;
            else if (s == "down" && !Movable(s, num, end))
                this.y = end - this.radius - 3;
            else
                this.y += num;
        }
        public override void ChangeSize(int num, int width, int height)
        {
            if (Movable("left", -num, 0) && Movable("up", -num, 0) && Movable("right", num, width) && Movable("down", num, height) && this.radius + num > 0)
                this.radius += num;
        }


    }
}