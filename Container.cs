using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Shapes;
using WinFormsApp1.Shapes;


namespace WinFormsApp1
{
    class Container
    {
        DoublyLinkedList<Shape> shapes = new DoublyLinkedList<Shape>();

        bool IsCtrl = false;
        bool CtrlCheckBoxChecked = false;
        bool OverlayCheckBoxChecked = false;

        public void RemoveSelections()
        {
            for (int i = 0; i < shapes.Count; ++i)
            {
                if (shapes.Get(i).GetSelect())
                {
                    shapes.RemoveAt(i--);
                }
            }
            if (shapes.Count != 0)
                shapes.Last().SetSelect(true);
        }

        public void SetCtrl()
        {
            IsCtrl = true;
        }

        public void SetCtrlCheckBox(bool flag)
        {
            CtrlCheckBoxChecked = flag;
        }
        public void SetOverlayCheckBox(bool flag)
        {
            OverlayCheckBoxChecked = flag;
        }
        public void InShapeContainer(int x, int y, Shape figure)
        {
            bool littleflag = false;
            if (IsCtrl==false ||  CtrlCheckBoxChecked==false) {
                foreach (var i in shapes)
                {
                    i.SetSelect(false);
                }
            }
            foreach (var i in shapes)
            {
                i.ChangeSelect();
                littleflag = true;
                if (OverlayCheckBoxChecked == false){
                    break;
                }
            }
            if (littleflag == false)
            {
                if (IsCtrl == false || CtrlCheckBoxChecked == false)
                    foreach (var i in shapes)
                        i.SetSelect(false);
                figure.SetX(x);
                figure.SetY(y);
                shapes.PushBack(figure);
            }
        }


        public void MoveX(int num, int start, int end)
        {
            foreach (Shape it in shapes)
            {
                if (it.GetSelect())
                    it.MoveX(num, start, end);
            }
        }
        public void MoveY(int num, int start, int end)
        {
            foreach (Shape it in shapes)
            {
                if (it.GetSelect())
                    it.MoveY(num, start, end);
            }
        }
        public void ChangeSizeShapes(int num)
        {
            foreach (Shape it in shapes)
                if (it.GetSelect())
                    it.ChangeSize(num);
        }

        public void DrawShapes(PaintEventArgs e)
        {
            foreach (var i in shapes)
                i.Draw(e);
        }
    }
}
