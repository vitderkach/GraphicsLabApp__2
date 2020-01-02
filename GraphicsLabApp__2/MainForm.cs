using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicsLabApp__2
{
    public partial class MainForm : Form
    {
        private Figure[] figures;
        private PointF mousePoint;
        private ComplexFigure home;
        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            figures = new Figure[5];
            Figure basis = new Figure("Basis", new Rectangle(new PointF(0, 100), 100, 200));
            Figure door = new Figure("Door", new Rectangle(new PointF(20, 200), -80, 60), new Line(new PointF(25, 160), 35, 160));
            Figure window = new Figure("Window", new Rectangle(new PointF(120, 180), -60, 60), new Line(new PointF(150, 180), 150, 120), new Line(new PointF(120, 150), 180, 150));
            Figure penthhouse = new Figure("PenthHouse", new Circle(new PointF(100, 60), 20), new Line(new PointF(80, 60), 120, 60), new Line(new PointF(100, 40), 100, 80));
            Figure roof = new Figure("Roof", new Polygon(new PointF(0, 100), new PointF(100, 0), new PointF(200, 100)));
            pictureBox.Paint += (senderPB, ePB) => PictureBox_Paint(senderPB, ePB);
            pictureBox.MouseClick += PictureBox_MouseClick;
            home = new ComplexFigure("Home", basis, door, window, penthhouse, roof);
            for (int i = 0; i < listBoxShapes.Items.Count; i++)
            {
                listBoxShapes.SetItemCheckState(i, CheckState.Checked);
            }
            listBoxShapes.CheckOnClick = true;
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            mousePoint = new PointF(e.X, e.Y);
            pictureBox.Refresh();
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {

            foreach (var figure in home.Figures)
            {
                foreach (var shape in figure.Shapes)
                {
                    e.Graphics.DrawPolygon(Pens.Black, shape.Points);
                }
            }
            e.Graphics.FillEllipse(new SolidBrush(Color.HotPink), mousePoint.X, mousePoint.Y, 8, 8);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = (string)listBoxShapes.SelectedItem;
            if (listBoxShapes.CheckedItems.Contains(name))
            {
                home.SetFigureState(name, true);
            }
            else
            {
                home.SetFigureState(name, false);
            }

            pictureBox.Refresh();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.A:
                    {

                        home.TranslateComplexFigure(-10, 0);
                        break;
                    }
                case Keys.D:
                    {
                        home.TranslateComplexFigure(10, 0);
                        break;
                    }
                case Keys.W:
                    {
                        home.TranslateComplexFigure(0, -10);
                        break;

                    }
                case Keys.S:
                    {
                        home.TranslateComplexFigure(0, 10);
                        break;
                    }
                case Keys.Q:
                    {
                        home.RotateComlexFigure(-10, mousePoint.X, mousePoint.Y);
                        break;
                    }
                case Keys.E:
                    {
                        home.RotateComlexFigure(10, mousePoint.X, mousePoint.Y);
                        break;
                    }
                case Keys.Z:
                    {
                        home.ScaleComplexFigure(1.1F, 1.1F, mousePoint.X, mousePoint.Y);
                        break;
                    }
                case Keys.C:
                    {
                        home.ScaleComplexFigure(0.9F, 0.9F, mousePoint.X, mousePoint.Y);
                        break;
                    }
                case Keys.R:
                    {
                        home.ScaleComplexFigure(1.1F, 1, mousePoint.X, mousePoint.Y);
                        break;
                    }
                case Keys.T:
                    {
                        home.ScaleComplexFigure(0.9F, 1, mousePoint.X, mousePoint.Y);
                        break;
                    }
                case Keys.F:
                    {
                        home.ScaleComplexFigure(1, 1.1F, mousePoint.X, mousePoint.Y);
                        break;
                    }
                case Keys.G:
                    {
                        home.ScaleComplexFigure(1, 0.9F, mousePoint.X, mousePoint.Y);
                        break;
                    }
                default:
                    {
                        return false;
                    }
            }

            pictureBox.Refresh();
            return true;
        }
    }
}
