using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;
using WindowsFormsApp1.Shapes;

namespace WinFormsApp1.Shapes
{
    class CTriangle : ShapeParent

    {
        private int width = 60, height = 60;

        private Point[] vertex = new Point[3];
        private void GetVertex()
        {
            Point a = new Point(this.x - this.width / 2, this.y + this.height / 2); //левая нижняя вершна
            this.vertex[0] = a;
            //верх
            Point b = new Point(this.x, this.y - this.height / 2);
            this.vertex[1] = b;
            //правая
            Point c = new Point(this.x + this.width / 2, this.y + this.height / 2);
            this.vertex[2] = c;
        }

        public override ShapeParent DoConstruct()
        {
            return new CTriangle();
        }

        public override void Draw(PaintEventArgs e)
        {
            GetVertex();
            e.Graphics.DrawPolygon((Selected ? Form1.PenCircleSelect : Form1.PenCircleNotSelect), this.vertex);
            e.Graphics.FillPolygon(new SolidBrush(color), this.vertex);
        }

        public override bool InShape(int x, int y)
        {
            bool flag = false;
            GetVertex();

            int a = (this.vertex[0].X - x) * (this.vertex[1].Y - this.vertex[0].Y) - (this.vertex[1].X - this.vertex[0].X) * (this.vertex[0].Y - y);
            int b = (this.vertex[1].X - x) * (this.vertex[2].Y - this.vertex[1].Y) - (this.vertex[2].X - this.vertex[1].X) * (this.vertex[1].Y - y);
            int c = (this.vertex[2].X - x) * (this.vertex[0].Y - this.vertex[2].Y) - (this.vertex[0].X - this.vertex[2].X) * (this.vertex[2].Y - y);

            if ((a >= 0 && b >= 0 && c >= 0) || (a <= 0 && b <= 0 && c <= 0))
                flag = true;
            return flag;
        }

        public override bool Movable(string s, int num, int end)
        {
            if (s == "left")
            {
                return (this.vertex[0].X + num > 0);
            }
            if (s == "right")
            {
                return (this.vertex[2].X + num < end);
            }
            if (s == "up")
            {
                return (this.vertex[1].Y + num > 0);
            }
            if (s == "down")
            {
                return (this.vertex[0].Y + num < end && this.vertex[2].Y + num < end);
            }
            else
            {
                return false;
            }
        }


        public override void MoveX(string s, int num, int end)
        {
            GetVertex();
            if (s == "left" && !Movable(s, num, end))
                this.x = this.width / 2 + 1;
            else if (s == "right" && !Movable(s, num, end))
                this.x = end - this.width / 2 - 3;
            else
                this.x += num;
        }
        public override void MoveY(string s, int num, int end)
        {
            GetVertex();
            if (s == "up" && !Movable(s, num, end))
                this.y = 0 + this.height / 2 + 1;
            else if (s == "down" && !Movable(s, num, end))
                this.y = end - 1 - this.height / 2 - 3;
            else
                this.y += num;
        }
        public override void ChangeSize(int num, int width, int height)
        {
            if (Movable("left", -num, 0) && Movable("up", -num, 0) && Movable("right", num, width) && Movable("down", num, height) && this.width / 2 + num > 0 && this.height / 2 + num > 0)
            {
                this.width += num;
                this.height += num;
            }
        }
    }
}
