using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;
using WindowsFormsApp1.Shapes;

namespace WinFormsApp1.Shapes
{
    class CSquare : ShapeParent
    {
        private int width = 60, height = 60;

        public override ShapeParent DoConstruct() { 
            return new CSquare(); 
        }
        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle((Selected ? Form1.PenCircleSelect : Form1.PenCircleNotSelect), this.x - this.width / 2, this.y - this.height/ 2, this.width, this.height);
            e.Graphics.FillRectangle(new SolidBrush(color), this.x - this.width / 2, this.y - this.height / 2, this.width, this.height);
        }

        public override bool InShape(int x, int y)
        {
            if ((x > this.x - this.width / 2) && (x < this.x + this.width / 2) && (y > this.y - this.height / 2) && (y < this.y + this.height / 2))
                return true;
            else
                return false;
        }


        public override bool Movable(string s, int num, int end)
        {
            if (s == "left")
            {
                return (this.x - this.width / 2 + num > 0);
            }
            if (s == "right")
            {
                return (this.x + this.width / 2 + num < end);
            }
            if (s == "up")
            {
                return (this.y - this.height / 2 + num > 0);
            }
            if (s == "down")
            {
                return (this.y + this.height / 2 + num < end);
            }
            else
            {
                return false;
            }
        }

        public override void MoveX(string s, int num, int end)
        {
            if (s == "left" && !Movable(s, num, end))
                this.x = this.width / 2 -1 ;
            else if (s == "right" && !Movable(s, num, end))
                this.x = end - this.width / 2 -3;
            else
                this.x += num;
        }
        public override void MoveY(string s, int num, int end)
        {
            if (s == "up" && !Movable(s, num, end))
                this.y = this.height / 2 + 1;
            else if (s == "down" && !Movable(s, num, end))
                this.y = end - this.height / 2 - 3;
            else
                this.y += num;
        }
        public override  void ChangeSize(int num, int width, int height)
        {
            if (Movable("left", -num, 0) && Movable("up", -num, 0) && Movable("right", num, width) && Movable("down", num, height) && this.width/2 + num > 0 && this.height/2 +num>0)
            {
                this.width += num;
                this.height += num;
            }
        }
    }
}
