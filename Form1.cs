using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Shapes;
using WinFormsApp1.Shapes;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private readonly List<ShapeParent> prototypes = new List<ShapeParent>() { new CCircle(), new CSquare(), new CTriangle() };
        ShapeParent shape;
        private WinFormsApp1.Container shapes = new WinFormsApp1.Container();
        public Form1()
        {
            InitializeComponent();
        }

        public static readonly Pen PenCircleSelect = new Pen(Brushes.Yellow);
        public static readonly Pen PenCircleNotSelect = new Pen(Brushes.Black);

        private const int step = 10;

        private void Form1_Load(object sender, EventArgs e)
        {
            PenCircleSelect.Width = 3;
            PenCircleNotSelect.Width = 3;
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            shapes.InShapeContainer(e.X, e.Y, shape);
            PictureBox.Refresh();
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            shapes.DrawShapes(e);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    shapes.RemoveSelections();
                    PictureBox.Invalidate();
                    break;
                case Keys.ControlKey:
                    CtrlCheckBox.Checked = !CtrlCheckBox.Checked;
                    shapes.SetCtrlCheckBox(CtrlCheckBox.Checked);
                    break;
                case Keys.A:
                    //shapes.MoveX(-step, PictureBox.Location.X, PictureBox.Width);
                    shapes.Move("left", -step, PictureBox.Width);
                    PictureBox.Invalidate();
                    break;
                case Keys.D:
                    shapes.Move("right", step, PictureBox.Width);
                    PictureBox.Invalidate();
                    break;
                case Keys.S:
                    shapes.Move("down", step, PictureBox.Height);
                    PictureBox.Invalidate();
                    break;
                case Keys.W:
                    shapes.Move("up", -step, PictureBox.Height);
                    PictureBox.Invalidate();
                    break;
                case Keys.OemOpenBrackets:
                    shapes.ChangeSizeShapes(-step, PictureBox.Width, PictureBox.Height);
                    PictureBox.Invalidate();
                    break;
                case Keys.OemCloseBrackets:
                    shapes.ChangeSizeShapes(step, PictureBox.Width, PictureBox.Height);
                    PictureBox.Invalidate();
                    break;
                case Keys.Escape:
                    Close();
                    break;
            }
        }


        private void CtrlCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            shapes.SetCtrlCheckBox(CtrlCheckBox.Checked);
        }

        private void OverlayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            shapes.SetOverlayCheckBox(OverlayCheckBox.Checked); 
        }

        private void CircleBtn_Click(object sender, EventArgs e)
        {
            shape = prototypes[0];
        }

        private void SquareBtn_Click(object sender, EventArgs e)
        {
            shape = prototypes[1];
        }

        private void TriangleBtn_Click(object sender, EventArgs e)
        {
            shape = prototypes[2];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != DialogResult.Cancel)
            {
                shapes.SetShapesColor(colorDialog1.Color);

                PictureBox.Invalidate();
            }

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            PictureBox.Width = this.ClientSize.Width;
            PictureBox.Height = this.ClientSize.Height - PictureBox.Location.Y;
        }
    }


}