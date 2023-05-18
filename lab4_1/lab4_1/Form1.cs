using lab4_1;
using System.Security.Cryptography.X509Certificates;

namespace lab4_1
{
    public partial class frmPaint : Form
    {
        int x, y;
        Boolean isCtrl = false;
        List<CCircle> circles = new List<CCircle>(0);
        public frmPaint()
        {
            InitializeComponent();
        }
        private void pnlPaintBox_MouseClick(object sender, MouseEventArgs e) //Метод ввода нового объекта при нажатии на форму
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < circles.Count; i++)
                {
                    if (circles[i].isEqual(e.X, e.Y))
                    {
                        return;
                    }
                }
                for (int i = 0; i < circles.Count; i++)
                {
                    circles[i].unselect();
                }
                CCircle tmp = new CCircle(e.X, e.Y);
                tmp.select();
                circles.Add(tmp);
            }
            else if (e.Button == MouseButtons.Left && circles.Count > 0)
            {
                if (chckBxCtrl.Checked || isCtrl)
                {
                    //select
                    if (chckBxMode.Checked)
                    {
                        for (int i = 0; i < circles.Count; i++)
                        {
                            if (circles[i].isPossess(e.X, e.Y))
                            {
                                circles[i].select();
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < circles.Count; i++)
                        {
                            if (circles[i].isPossess(e.X, e.Y))
                            {
                                circles[i].select();
                                break;
                            }
                        }
                    }
                }
                else
                {
                    Boolean lastSelected = true;
                    //unselect
                    for (int i = 0; i < circles.Count; i++)
                    {
                        circles[i].unselect();
                    }
                    //select
                    if (chckBxMode.Checked)
                    {
                        for (int i = 0; i < circles.Count; i++)
                        {
                            if (circles[i].isPossess(e.X, e.Y))
                            {
                                circles[i].select();
                                lastSelected = false;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < circles.Count; i++)
                        {
                            if (circles[i].isPossess(e.X, e.Y))
                            {
                                circles[i].select();
                                lastSelected = false;
                                break;
                            }
                        }
                    }
                    if (lastSelected)
                    {
                        circles[circles.Count - 1].select();
                    }
                }
            }
            pnlPaintBox.Invalidate();
        }

        private void frmPaint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                isCtrl = true;
            }
        }

        private void frmPaint_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                isCtrl = false;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                for (int i = 0; i < circles.Count; ++i)
                {
                    if (circles[i].isSelect())
                    {
                        circles.RemoveAt(i--);
                    }
                }
                if (circles.Count > 0)
                {
                    circles[circles.Count - 1].select();
                }
                pnlPaintBox.Invalidate();
            }
        }

        private void pnlPaintBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < circles.Count; i++)
            {
                circles[i].paint(g);
            }
        }

        private void frmPaint_SizeChanged(object sender, EventArgs e)
        {
            pnlPaintBox.Height = this.Height - 150;
            pnlPaintBox.Width = this.Width - 40;
        }
    }
}