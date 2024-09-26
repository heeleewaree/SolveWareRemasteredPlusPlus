using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static SolveWareRemasteredV2.GlobalVars;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SolveWareRemasteredV2
{
    public partial class SOC_CE : Form
    {
        public SOC_CE()
        {
            InitializeComponent();
            ReadFromFile();
            CustomDesign();
            Plot.MouseWheel += new MouseEventHandler(m_MouseWheel);
            Plot.MouseMove += new MouseEventHandler(mouseMove1);
            Plot.MouseDown += new MouseEventHandler(mouseDown1);
            Plot.MouseUp += new MouseEventHandler(mouseUp1);
        }

        #region Vars
        double A, B, F;
        double accuracy = 0.01;
        int length = 500;
        bool checkCP, checkHN, checkG;
        double I1, I2, I3, K;
        String figure;
        bool Ellipse;
        int OX = 865 / 2, OY = 549 / 2;
        int scale = 40;
        double Ox1, Ox2, Oy1, Oy2;
        double y, x1, x2, d;
        bool status = false;
        int CurX, CurY;
        Pen MainAxesPen = new Pen(mac);
        Pen NewAxesPen = new Pen(nac);
        SolidBrush NumsPen = new SolidBrush(nc);
        Pen RotatedAxesPen = new Pen(rac);
        SolidBrush FigurePen = new SolidBrush(pc);
        Pen GridPen = new Pen(gc);
        SolidBrush CrossingPointsPen = new SolidBrush(cpc);
        Point p1, p2;
        Graphics gr;
        Bitmap btmp;
        #endregion

        #region Custom Design
        private void CustomDesign()
        {
            this.BackColor = abc;
            txtX.ForeColor = tc;
            txtY.ForeColor = tc;
            txtPlus.ForeColor = tc;
            txtEquals.ForeColor = tc;
            checkCrossingPoints.ForeColor = tc;
            checkHideNums.ForeColor = tc;
            checkGrid.ForeColor = tc;
            txtFigure.ForeColor = tc;
            txtEllipse.ForeColor = tc;
            Oox.ForeColor = tc;
            Ooy.ForeColor = tc;
            btnApply.ForeColor = tc;
            btnSave.ForeColor = tc;
            checkCrossingPoints.Checked = checkCP;
            checkHideNums.Checked = checkHN;
            checkGrid.Checked = checkG;
        }
        #endregion

        #region Read From File
        private void ReadFromFile()
        {
            String line;
            int operation = 0;
            try
            {
                StreamReader file = new StreamReader("SOC_CE.cfg");
                line = file.ReadLine();
                while (line != null)
                {
                    if (operation == 0)
                        textA.Text = line;
                    if (operation == 1)
                        textB.Text = line;
                    if (operation == 2)
                        textF.Text = line;
                    if (operation == 3)
                    {
                        if (line == "1")
                            checkCP = true;
                        else
                            checkCP = false;
                    }
                    if (operation == 4)
                    {
                        if (line == "1")
                            checkHN = true;
                        else
                            checkHN = false;
                    }
                    if (operation == 5)
                    {
                        if (line == "1")
                            checkG = true;
                        else
                            checkG = false;
                    }
                    if (operation == 6)
                        scale = Convert.ToInt32(line);
                    line = file.ReadLine();
                    operation++;
                }
                file.Close();
                A = Convert.ToDouble(textA.Text);
                B = Convert.ToDouble(textB.Text);
                F = Convert.ToDouble(textF.Text);
                CalculateFunction();
            }
            catch
            {
                return;
            }
        }
        #endregion

        #region Calculate Function
        private void CalculateFunction()
        {
            if ((A < 0) && (B < 0))
            {
                A = -A;
                B = -B;
                F = -F;
            }
            A = 1.0 / A;
            B = 1.0 / B;
            F = -F;
            I1 = A + B;
            I2 = A * B;
            I3 = (A * B * F) + (0 * 0 * 0) + (0 * 0 * 0) - ((0 * 0 * B) + (0 * 0 * A) + (0 * 0 * F));
            K = ((A * F) - (0 * 0)) + ((B * F) - (0 * 0));

            DetermineFigure();
            TextFunction();
        }
        #endregion

        #region Determine Figure
        private void DetermineFigure()
        {
            if (I2 != 0)
            {
                if (I2 > 0)
                {
                    if (I3 < 0)
                    {
                        figure = "Ellipse";
                        Ellipse = true;
                    }
                    else if (I3 == 0)
                    {
                        figure = "Point (a pair of imaginary intersecting lines)";
                        Ellipse = false;
                    }
                    else if (I3 > 0)
                    {
                        figure = "Imaginary ellipse";
                        Ellipse = false;
                    }
                }
                if (I2 < 0)
                {
                    if (I3 == 0)
                    {
                        figure = "A pair of intersecting straight lines";
                        Ellipse = false;
                    }
                    else if (I3 != 0)
                    {
                        figure = "Hyperbola";
                        Ellipse = false;
                    }
                }
            }
            else if (I2 == 0)
            {
                if (I3 != 0)
                {
                    figure = "Parabola";
                    Ellipse = false;
                }
                else if (I3 == 0)
                {
                    if (K < 0)
                    {
                        figure = "A pair of parallel straight lines";
                        Ellipse = false;
                    }
                    else if (K == 0)
                    {
                        figure = "Straight";
                        Ellipse = false;
                    }
                    else if (K > 0)
                    {
                        figure = "A pair of imaginary parallel lines";
                        Ellipse = false;
                    }
                }
            }
            txtFigure.Text = figure;
            EllipsePlane();
        }                
        #endregion

        #region Ellipse Plane
        private void EllipsePlane()
        {
            if (Ellipse)
            {
                txtEllipse.Text = "S = ";
                double g = Math.Sqrt(-F / A) * Math.Sqrt(-F / B);
                if (g != 1)
                    txtEllipse.Text += Convert.ToString(g) + " 𝞹";
                else
                    txtEllipse.Text += " 𝞹";
            }
            else
                txtEllipse.Text = "";
        }
        #endregion

        #region Buttons
        
        #region Button Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter file = new StreamWriter("SOC_CE.cfg");
                file.WriteLine(1.0 / A);
                file.WriteLine(1.0 / B);
                file.WriteLine(-F);
                if (checkCP)
                    file.WriteLine("1");
                else
                    file.WriteLine("0");

                if (checkHN)
                    file.WriteLine("1");
                else
                    file.WriteLine("0");

                if (checkG)
                    file.WriteLine("1");
                else
                    file.WriteLine("0");

                file.WriteLine(scale);
                file.Close();
            }
            catch
            {
                return;
            }

            GC.Collect();
            this.Dispose();
            this.Close();
        }
        #endregion

        #region Button Apply
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                A = Convert.ToDouble(textA.Text);
                B = Convert.ToDouble(textB.Text);

                if ((A == 0) || (B == 0))
                    return;
            }
            catch
            {
                return;
            }
            try
            {
                A = Convert.ToDouble(textA.Text);
                B = Convert.ToDouble(textB.Text);
                F = Convert.ToDouble(textF.Text);
                CalculateFunction();
            }
            catch
            {
                return;
            }
        }
        #endregion

        #region Centering
        private void Plot_DoubleClick(object sender, EventArgs e)
        {
            scale = 40;
            OX = Plot.Width / 2;
            OY = Plot.Height / 2;
            PaintFunction();
        }
        #endregion

        #endregion

        #region Text Function
        private void TextFunction()
        {
            // Crossing w/ a vertical axe
            d = Math.Pow(2 * 0, 2) - (4 * (B + 0.0000000001) * F);
            Oy1 = (-1.0 * (2 * 0) + Math.Sqrt(d)) / (2 * (B + 0.0000000001));
            Oy2 = (-1.0 * (2 * 0) - Math.Sqrt(d)) / (2 * (B + 0.0000000001));
            // Crossing w/ a horizontal axe
            d = Math.Pow(2 * 0, 2) - (4 * (A + 0.0000000001) * F);
            Ox1 = (-1.0 * (2 * 0) + Math.Sqrt(d)) / (2 * (A + 0.0000000001));
            Ox2 = (-1.0 * (2 * 0) - Math.Sqrt(d)) / (2 * (A + 0.0000000001));

            double swap;
            if (Oy1 > Oy2)
            {
                swap = Oy2;
                Oy2 = Oy1;
                Oy1 = swap;
            }
            if (Ox1 > Ox2)
            {
                swap = Ox2;
                Ox2 = Ox1;
                Ox1 = swap;
            }
            if (Ox1 < -500000)
                Ox1 = double.NegativeInfinity;
            if (Ox1 > 500000)
                Ox1 = double.PositiveInfinity;

            if (Ox2 < -500000)
                Ox2 = double.NegativeInfinity;
            if (Ox2 > 500000)
                Ox2 = double.PositiveInfinity;

            if (Oy1 < -500000)
                Oy1 = double.NegativeInfinity;
            if (Oy1 > 500000)
                Oy1 = double.PositiveInfinity;

            if (Oy2 < -500000)
                Oy2 = double.NegativeInfinity;
            if (Oy2 > 500000)
                Oy2 = double.PositiveInfinity;

            Oox.Text = "⋂ Ox(" + Math.Round(Ox1, 3) + "; " + Math.Round(Ox2, 3) + ")    "; // ⋂ OX
            Ooy.Text = "⋂ Oy(" + Math.Round(Oy1, 3) + "; " + Math.Round(Oy2, 3) + ")    "; // ⋂ OY

            PaintFunction();
        }
        #endregion

        #region Paint Function
        private void PaintFunction()
        {
            try
            {
                btmp = new Bitmap(Plot.Width, Plot.Height);
                Plot.Image = btmp;
                gr = Graphics.FromImage(Plot.Image);

                Plot.BackColor = pbc;

                #region Main Axes
                p1 = new Point(OX, 0);
                p2 = new Point(OX, Plot.Height);
                gr.DrawLine(MainAxesPen, p1, p2);
                p1 = new Point(0, OY);
                p2 = new Point(Plot.Width, OY);
                gr.DrawLine(MainAxesPen, p1, p2);
                #endregion

                if (!status)
                {
                    AccuracyFound();

                    #region Drawing 0, X, Y
                    String drawString = "0";
                    gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 11, OY);
                    drawString = "X";
                    gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, Plot.Width - 20, OY - 20);
                    drawString = "Y";
                    gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX + 5, 13);
                    #endregion

                    #region Drawing Nums And Grid
                    int step = 1;
                    if (scale <= 15)
                        step = 5;
                    if (scale <= 5)
                        step = 10;
                    if (scale > 1)
                    {
                        int j = step;
                        for (int i = OX; i < Plot.Width; i += scale * step)
                        {
                            //grid
                            if ((i != OX) && (checkG))
                            {
                                p1 = new Point(i, 0);
                                p2 = new Point(i, OY);
                                gr.DrawLine(GridPen, p1, p2);
                                if (checkHN)
                                    p1 = new Point(i, OY + 0);
                                else
                                    p1 = new Point(i, OY + 20);
                                p2 = new Point(i, Plot.Height);
                                gr.DrawLine(GridPen, p1, p2);
                            }
                            if (!checkHN)
                            {
                                //lines
                                p1 = new Point(i, OY - 4);
                                p2 = new Point(i, OY + 4);
                                gr.DrawLine(MainAxesPen, p1, p2);
                                //nums
                                drawString = j.ToString();
                                if (j > 9)
                                    gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i + scale * step - 7, OY + 5);
                                else
                                    gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i + scale * step - 3, OY + 5);
                                j += step;
                            }
                        }
                        j = -step;
                        for (int i = OX; i > 0; i -= scale * step)
                        {
                            //grid
                            if ((i != OX) && (checkG))
                            {
                                p1 = new Point(i, 0);
                                p2 = new Point(i, OY);
                                gr.DrawLine(GridPen, p1, p2);
                                if (checkHN)
                                    p1 = new Point(i, OY + 0);
                                else
                                    p1 = new Point(i, OY + 20);
                                p2 = new Point(i, Plot.Height);
                                gr.DrawLine(GridPen, p1, p2);
                            }
                            if (!checkHN)
                            {

                                //lines
                                p1 = new Point(i, OY - 4);
                                p2 = new Point(i, OY + 4);
                                gr.DrawLine(MainAxesPen, p1, p2);
                                //nums
                                drawString = j.ToString();
                                if (j < -9)
                                    gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i - scale * step - 10, OY + 5);
                                else
                                    gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i - scale * step - 7, OY + 5);
                                j -= step;
                            }
                        }
                        j = step;
                        for (int i = OY; i > 0; i -= scale * step)
                        {
                            //grid
                            if ((i != OY) && (checkG))
                            {
                                p1 = new Point(0, i);
                                if (checkHN)
                                    p2 = new Point(OX - 0, i);
                                else
                                    p2 = new Point(OX - 20, i);
                                gr.DrawLine(GridPen, p1, p2);

                                p1 = new Point(OX, i);
                                p2 = new Point(Plot.Width, i);
                                gr.DrawLine(GridPen, p1, p2);
                            }
                            if (!checkHN)
                            {
                                //lines
                                p1 = new Point(OX - 4, i);
                                p2 = new Point(OX + 4, i);
                                gr.DrawLine(MainAxesPen, p1, p2);
                                //nums
                                drawString = j.ToString();
                                if (j > 9)
                                    gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 20, i - scale * step - 9);
                                else
                                    gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 16, i - scale * step - 9);
                                j += step;
                            }
                        }
                        j = -step;
                        for (int i = OY; i < Plot.Height; i += scale * step)
                        {
                            //grid
                            if ((i != OY) && (checkG))
                            {
                                p1 = new Point(0, i);
                                if (checkHN)
                                    p2 = new Point(OX - 0, i);
                                else
                                    p2 = new Point(OX - 25, i);
                                gr.DrawLine(GridPen, p1, p2);

                                p1 = new Point(OX, i);
                                p2 = new Point(Plot.Width, i);
                                gr.DrawLine(GridPen, p1, p2);
                            }
                            if (!checkHN)
                            {
                                //lines
                                p1 = new Point(OX - 4, i);
                                p2 = new Point(OX + 4, i);
                                gr.DrawLine(MainAxesPen, p1, p2);
                                //nums
                                drawString = j.ToString();
                                if (j < -9)
                                    gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 24, i + scale * step - 9);
                                else
                                    gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 20, i + scale * step - 9);
                                j -= step;
                            }
                        }
                    }
                    #endregion

                    #region Drawing Figure
                    if ((A != 0) && (B != 0))
                    {
                        y = -length;
                        while (y < length)
                        {
                            d = Math.Pow(2 * 0 * y + 2 * 0, 2) - (4 * A * (B * y * y + 2 * 0 * y + F));
                            if (d >= 0)
                            {
                                x1 = (-1.0 * (2 * 0 * y + 2 * 0) + Math.Sqrt(d)) / (2 * A);
                                x2 = (-1.0 * (2 * 0 * y + 2 * 0) - Math.Sqrt(d)) / (2 * A);
                                if ((OX + (int)(x1 * scale) > 0) && (OX + (int)(x1 * scale) < Plot.Width) && (OY - (int)(y * scale) > 0) && (OY - (int)(y * scale) < Plot.Height))
                                    btmp.SetPixel(OX + (int)(x1 * scale), OY - (int)(y * scale), pc);
                                if ((OX + (int)(x2 * scale) > 0) && (OX + (int)(x2 * scale) < Plot.Width) && (OY - (int)(y * scale) > 0) && (OY - (int)(y * scale) < Plot.Height))
                                    btmp.SetPixel(OX + (int)(x2 * scale), OY - (int)(y * scale), pc);
                            }
                            y += accuracy;
                        }
                    }
                    #endregion

                    #region Drawing Crossing Points

                    if (checkCP)
                    {
                        // points of crossing w/ main axes
                        if ((Ox1 < double.PositiveInfinity) && (Ox1 > double.NegativeInfinity) && (Ox1 != double.NaN))
                            gr.FillEllipse(CrossingPointsPen, new Rectangle(OX + (int)(Ox1 * scale) - 3, OY - 3, 6, 6));
                        if ((Ox2 < double.PositiveInfinity) && (Ox2 > double.NegativeInfinity) && (Ox2 != double.NaN))
                            gr.FillEllipse(CrossingPointsPen, new Rectangle(OX + (int)(Ox2 * scale) - 3, OY - 3, 6, 6));
                        if ((Oy1 < double.PositiveInfinity) && (Oy1 > double.NegativeInfinity) && (Oy1 != double.NaN))
                            gr.FillEllipse(CrossingPointsPen, new Rectangle(OX - 3, OY - (int)(Oy1 * scale) - 3, 6, 6));
                        if ((Oy2 < double.PositiveInfinity) && (Oy2 > double.NegativeInfinity) && (Oy2 != double.NaN))
                            gr.FillEllipse(CrossingPointsPen, new Rectangle(OX - 3, OY - (int)(Oy2 * scale) - 3, 6, 6));
                    }
                    #endregion
                }

                gr.Dispose();
                GC.Collect();
            }
            catch
            {
                return;
            }
        }
        #endregion

        #region Misc

        #region Resize Form
        private void SOC_CE_Resize(object sender, EventArgs e)
        {
            PaintFunction();
        }
        #endregion

        #region KeyPress
        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == Convert.ToChar(",")) | (e.KeyChar == Convert.ToChar("-")) | e.KeyChar == '\b') return;
            else
                e.Handled = true;
        }
        #endregion

        #region CheckBoxes

        #region CheckBox Of Crossing Points
        private void checkCrossingPoints_CheckedChanged(object sender, EventArgs e)
        {
            checkCP = checkCrossingPoints.Checked;
            PaintFunction();
        }
        #endregion

        #region CheckBox Of Hide Numbers
        private void checkHideNums_CheckedChanged(object sender, EventArgs e)
        {
            checkHN = checkHideNums.Checked;
            PaintFunction();
        }
        #endregion

        #region CheckBox Of Grid
        private void checkGrid_CheckedChanged(object sender, EventArgs e)
        {
            checkG = checkGrid.Checked;
            PaintFunction();
        }
        #endregion

        #endregion

        #region Mouse Wheel
        void m_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if ((scale == 1) || (scale == 7) || (scale == 4))
                    scale += 3;
                else
                    scale += 5;
            }
            else
            {
                if (scale > 10)
                    scale -= 5;
                else if ((scale == 10) || (scale == 7) || (scale == 4))
                    scale -= 3;
                else if (scale == 1)
                    return;
            }
            PaintFunction();
        }
        #endregion

        #region Mouse Move
        void mouseMove1(object sender, MouseEventArgs e)
        {
            if (status)
            {
                CurX -= Cursor.Position.X;
                CurY -= Cursor.Position.Y;
                OX -= CurX;
                OY -= CurY;
                CurX = Cursor.Position.X;
                CurY = Cursor.Position.Y;
                PaintFunction();
            }
        }
        void mouseDown1(object sender, MouseEventArgs e)
        {
            status = true;
            CurX = Cursor.Position.X;
            CurY = Cursor.Position.Y;
        }
        void mouseUp1(object sender, MouseEventArgs e)
        {
            status = false;
            PaintFunction();
        }
        #endregion

        #region Accuracy Found
        private void AccuracyFound()
        {
            if (scale > 5)
            {
                accuracy = 0.05;
                length = 500;
            }
            if (scale > 10)
            {
                accuracy = 0.03;
                length = 250;
            }
            if (scale > 20)
            {
                accuracy = 0.01;
                length = 125;
            }
            if (scale > 30)
            {
                accuracy = 0.009;
                length = 72;
            }
            if (scale > 40)
            {
                accuracy = 0.008;
                length = 36;
            }
            if (scale > 50)
            {
                accuracy = 0.007;
                length = 18;
            }
            if (scale > 60)
            {
                accuracy = 0.006;
                length = 9;
            }
        }
        #endregion

        #endregion
    }
}