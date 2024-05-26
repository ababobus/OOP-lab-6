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

        bool Movable(string s, int num, int end);
        void MoveX(string s, int num, int end);
        void MoveY(string s, int num, int end);
        void ChangeSize(int num, int width, int height);
        void SetColor(Color color);
    }
}
