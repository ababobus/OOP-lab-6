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
    class CSquare : Shape
    {
        private int x, y;
        private int width, height = 30;
        private Color color;
        bool Selected = false;

        public CSquare()
        {
            this.x = 0;
            this.y = 0;
        }
        public CSquare(int x, int y)
        {
            this.x = x;
            this.y = y;
            Selected = true;
        }

        public Shape DoConstruct() { return new CSquare(); }
        public void SetX(int x) { this.x = x; }
        public void SetY(int y) { this.y = y; }
        public void Draw(PaintEventArgs e)
        {
            Graphics graphic = e.Graphics;
            graphic.DrawRectangle((Selected ? Form1.PenCircleSelect : Form1.PenCircleNotSelect), this.x - this.width / 2, this.y - this.height/ 2, this.width, this.height);
        }

        public bool InShape(int x, int y)
        {
            if ((x > this.x - this.width / 2) && (x < this.x + this.width / 2) && (y > this.y - this.height / 2) && (y < this.y + this.height / 2))
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
            if (this.x - this.width / 2 + num < start)
                this.x = start + this.width / 2;
            else if (this.x + this.width / 2 + num > end)
                this.x = end - this.width / 2;
            else
                this.x += num;
        }
        public void MoveY(int num, int start, int end)
        {
            if (this.y - this.height / 2 + num < start)
                this.y = start + this.height / 2;
            else if (this.y + this.height / 2 + num > end)
                this.y = end - this.height / 2;
            else
                this.y += num;
        }
        public void ChangeSize(int num)
        {
            int tmpWidth = this.width + num;
            int tmpHeight = this.height + num;
            if (tmpWidth > 0 && tmpHeight > 0)
            {
                this.width += num;
                this.height += num;
            }
        }
        public void SetColor(Color color)
        {
            if (Selected)
                this.color = color;
        }
    }
}
