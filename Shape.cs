using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Shapes
{
    interface Shape
    {
        Shape DoConstruct();
        public void SetX(int x);
        public void SetY(int y);
        bool InShape(int x, int y);
        void Draw(PaintEventArgs e);
        void SetSelect(bool select); 
        bool GetSelect();
        void ChangeSelect();
        void MoveX(int num, int start, int end);
        void MoveY(int num, int start, int end);
        void ChangeSize(int num);
        void SetColor(Color color);
    }
}
