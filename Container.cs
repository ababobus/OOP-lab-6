﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;
using WindowsFormsApp1.Shapes;
using WinFormsApp1.Shapes;


namespace WinFormsApp1
{
    class Container
    {
        DoublyLinkedList<ShapeParent> shapes = new DoublyLinkedList<ShapeParent>();


        bool CtrlCheckBoxChecked = false;
        bool OverlayCheckBoxChecked = false;
        private Color shapesColor = Form1.PenCircleNotSelect.Color;

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

        public void SetCtrlCheckBox(bool flag)
        {
            CtrlCheckBoxChecked = flag;
        }
        public void SetOverlayCheckBox(bool flag)
        {
            OverlayCheckBoxChecked = flag;
        }
        public void InShapeContainer(int x, int y, ShapeParent figure)
        {
            if (figure == null) return;
            
            if (CtrlCheckBoxChecked == false) {
                foreach (var i in shapes)
                {
                    i.SetSelect(false);
                }
            }
            bool littleflag = false;
            foreach (var i in shapes)
            {
                if (i.InShape(x, y))
                {
                    i.SetSelect(true);
                    littleflag = true;
                    if (OverlayCheckBoxChecked == false)
                    {
                        break;
                    }
                }
            }
            if (littleflag == false)
            {
                ShapeParent newshape = figure.DoConstruct();

                newshape.SetX(x);
                newshape.SetY(y);
                
                newshape.SetSelect(true);
                shapes.PushBack(newshape);
            }
        }

        public void Move(string s, int num, int end)
        {
            foreach (ShapeParent it in shapes)
            {
                if (it.GetSelect())
                {
                    if (s == "left" || s == "right")
                    {
                        it.MoveX(s, num, end);
                    }
                    if (s == "up" || s == "down")
                    {
                        it.MoveY(s, num, end);
                    }
                }
            }
        }
        //public void MoveX(int num, int start, int end)
        //{
        //    foreach (Shape it in shapes)
        //    {
        //        if (it.GetSelect())
        //            it.MoveX(num, start, end);
        //    }
        //}
        //public void MoveY(int num, int start, int end)
        //{
        //    foreach (Shape it in shapes)
        //    {
        //        if (it.GetSelect())
        //            it.MoveY(num, start, end);
        //    }
    //}
    public void ChangeSizeShapes(int num, int width, int height)
    {
        foreach (ShapeParent it in shapes)
            if (it.GetSelect())
                it.ChangeSize(num, width, height);
    }

    public void DrawShapes(PaintEventArgs e)
        {
            foreach (ShapeParent it in shapes)
                it.Draw(e);
        }
        public void SetShapesColor(Color color) {
            foreach (ShapeParent it in shapes)
            {
                if (it.GetSelect())
                {
                    it.SetColor(color);
                }
            }
        }
    }
}
