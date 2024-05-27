using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Shapes;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace WindowsFormsApp1.Shapes
{
    internal abstract class ShapeParent 
    {

        protected int x, y;
        protected bool Selected = false;
        protected Color color;
        public ShapeParent()
        {
            this.x = 0;
            this.y = 0;
            Selected = true;
        }

        public void SetX(int x)
        {
            this.x = x;
        }
        public void SetY(int y)
        {
            this.y = y;
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
        public void SetColor(Color color)
        {
            if (Selected)
            {
                this.color = color;
            }

        }

        public virtual ShapeParent DoConstruct() { return this; }
        public virtual void Draw(PaintEventArgs e) { return; }
        public virtual bool InShape(int x, int y) { return false; }

        public virtual bool Movable(string s, int num, int end) { return false; }
        public virtual void MoveX(string s, int num, int end) { return; }
        public virtual void MoveY(string s, int num, int end) { return; }
        public virtual void ChangeSize(int num, int width, int height) { return; }
    }
}
