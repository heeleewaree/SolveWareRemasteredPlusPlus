using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static SolveWareRemasteredV2.GlobalVars;

namespace SolveWareRemasteredV2
{
    public partial class SOS_GE : Form
    {
        public SOS_GE()
        {
            InitializeComponent();
            ReadFromFile();
            CustomDesign();
            Plot1.MouseWheel += new MouseEventHandler(m_MouseWheel1);
            Plot2.MouseWheel += new MouseEventHandler(m_MouseWheel2);
            Plot3.MouseWheel += new MouseEventHandler(m_MouseWheel3);
            Plot4.MouseWheel += new MouseEventHandler(m_MouseWheel4);
            PaintAll();
        }

        #region Vars
        double A, B, C, F, G, H, P, Q, R, D;
        int scale1 = 40, scale2 = 40, scale3 = 40, scale = 10;
        double accuracy = 0.01;
        int length = 500;
        int OX = 430 / 2, OY = 230 / 2;
        double Tick;
        int MaxTrack;
        double I, J, K, N1, N2, N3;
        double tau1, tau2, sigma, delta, k1, k2;
        double alpha, ksi, beta, gamma, tetta, lyambda;
        double x, y, x1, x2, y1, y2, d;
        double angle, x0, y0;
        String surface;
        #endregion

        #region Custom Design
        private void CustomDesign()
        {
            this.BackColor = abc;
            txtX.ForeColor = tc;
            txtY.ForeColor = tc;
            txtZ.ForeColor = tc;
            txtXY.ForeColor = tc;
            txtYZ.ForeColor = tc;
            txtXZ.ForeColor = tc;
            txtXX.ForeColor = tc;
            txtYY.ForeColor = tc;
            txtZZ.ForeColor = tc;
            txtZero.ForeColor = tc;
            txtTick.ForeColor = tc;
            txtMaxTrack.ForeColor = tc;
            btnApply.ForeColor = tc;
            btnSave.ForeColor = tc;
            txtSurface.ForeColor = tc;
        }
        #endregion

        #region Read From File
        private void ReadFromFile()
        {
            String line;
            int operation = 0;
            try
            {
                StreamReader file = new StreamReader("SOS_GE.cfg");
                line = file.ReadLine();
                while (line != null)
                {
                    if (operation == 0)
                        textA.Text = line;
                    if (operation == 1)
                        textB.Text = line;
                    if (operation == 2)
                        textC.Text = line;
                    if (operation == 3)
                        textF.Text = line;
                    if (operation == 4)
                        textG.Text = line;
                    if (operation == 5)
                        textH.Text = line;
                    if (operation == 6)
                        textP.Text = line;
                    if (operation == 7)
                        textQ.Text = line;
                    if (operation == 8)
                        textR.Text = line;
                    if (operation == 9)
                        textD.Text = line;
                    if (operation == 10)
                        scale1 = Convert.ToInt32(line);
                    if (operation == 11)
                        scale2 = Convert.ToInt32(line);
                    if (operation == 12)
                        scale3 = Convert.ToInt32(line);
                    if (operation == 13)
                        trackBar1.Value = Convert.ToInt32(line);
                    if (operation == 14)
                        trackBar2.Value = Convert.ToInt32(line);
                    if (operation == 15)
                        trackBar3.Value = Convert.ToInt32(line);
                    if (operation == 16)
                        textTick.Text = Convert.ToString(line);
                    if (operation == 17)
                        textMaxtrack.Text = Convert.ToString(line);
                    line = file.ReadLine();
                    operation++;
                }
                file.Close();
                A = Convert.ToDouble(textA.Text);
                B = Convert.ToDouble(textB.Text);
                C = Convert.ToDouble(textC.Text);
                F = Convert.ToDouble(textF.Text) / 2.0;
                G = Convert.ToDouble(textG.Text) / 2.0;
                H = Convert.ToDouble(textH.Text) / 2.0;
                P = Convert.ToDouble(textP.Text) / 2.0;
                Q = Convert.ToDouble(textQ.Text) / 2.0;
                R = Convert.ToDouble(textR.Text) / 2.0;
                D = Convert.ToDouble(textD.Text);
                Tick = Convert.ToDouble(textTick.Text);
                MaxTrack = Convert.ToInt32(textMaxtrack.Text);
                trackBar1.Maximum = MaxTrack;
                trackBar1.Minimum = -MaxTrack;
                trackBar2.Maximum = MaxTrack;
                trackBar2.Minimum = -MaxTrack;
                trackBar3.Maximum = MaxTrack;
                trackBar3.Minimum = -MaxTrack;

                N1 = Tick * trackBar1.Value;
                N2 = Tick * trackBar2.Value;
                N3 = Tick * trackBar3.Value;
                }
                catch
                {
                    return;
                }
                CalculateFunction();
        }
        #endregion

        #region Calculate Function
        private void CalculateFunction()
        {
            try
            {
                A = Convert.ToDouble(textA.Text);
                B = Convert.ToDouble(textB.Text);
                C = Convert.ToDouble(textC.Text);
                F = Convert.ToDouble(textF.Text) / 2.0;
                G = Convert.ToDouble(textG.Text) / 2.0;
                H = Convert.ToDouble(textH.Text) / 2.0;
                P = Convert.ToDouble(textP.Text) / 2.0;
                Q = Convert.ToDouble(textQ.Text) / 2.0;
                R = Convert.ToDouble(textR.Text) / 2.0;
                D = Convert.ToDouble(textD.Text);
            }
            catch
            {
                return;
            }
            if ((A == 0) && (B == 0) && (C == 0) && (F == 0) && (G == 0) && (H == 0))
                return;
            tau1 = A + B + C;
            tau2 = A * B - F * F + A * C - G * G + B * C - H * H;
            sigma = (A * B * C) + (F * G * H) + (F * G * H) - (H * B * H) - (G * G * A) - (C * F * F);
            delta = (A * ((B * C * D) + (G * R * Q) + (Q * R * G) - (Q * Q * C) - (R * R * B) - (D * G * G)));
            delta -= (F * ((F * C * D) + (H * R * Q) + (P * R * G) - (P * C * Q) - (R * R * F) - (D * H * G)));
            delta += (H * ((F * G * D) + (H * Q * Q) + (P * R * B) - (P * G * Q) - (Q * R * F) - (D * H * B)));
            delta -= (P * ((F * G * R) + (H * Q * G) + (P * B * C) - (P * G * G) - (Q * C * F) - (R * B * H)));
            k1 = A * D - P * P + B * D - Q * Q + C * D - R * R;
            k2 = (A * B * D) + (F * Q * P) + (P * F * Q) - (P * P * B) - (Q * Q * A) - (D * F * F);
            k2 += (A * C * D) + (H * R * P) + (P * R * H) - (P * P * C) - (R * R * A) - (D * H * H);
            k2 += (B * C * D) + (G * R * Q) + (Q * G * R) - (Q * Q * C) - (R * R * B) - (D * G * G);

            if (I != 0)
            {
                alpha = (A * J * J) - (2 * F * I * J) + (B * I * I);//
                beta = (A * K * K) + (C * I * I) - (2 * H * I * K);//
                gamma = (2 * I * I * Q) - (2 * F * I * N1) - (2 * I * J * P) + (2 * A * J * N1);//
                tetta = (2 * I * I * R) - (2 * H * I * N1) + (2 * A * K * N1) - (2 * I * K * P);//
                ksi = (2 * G * I * I) - (2 * H * I * J) - (2 * F * I * K) + (2 * A * J * K);//
                lyambda = (D * I * I) + (A * N1 * N1) - (2 * I * N1 * P);//
                ksi = ksi / 2.0;
                gamma = gamma / 2.0;
                tetta = tetta / 2.0;

                angle = Math.Atan((2 * ksi) / (alpha - beta)) / 2;
                if ((alpha * beta - (ksi * ksi)) != 0)
                {
                    x0 = (-gamma * beta - (-tetta * ksi)) / (alpha * beta - (ksi * ksi));
                    y0 = (-tetta * alpha - (-gamma * ksi)) / (alpha * beta - (ksi * ksi));
                }
            }
            else if (J != 0)
            {
                alpha = (B * I * I) - (2 * F * I * J) + (A * J * J);//
                beta = (B * K * K) + (C * J * J) - (2 * J * G * K);//
                gamma = (2 * N2 * I * B) - (2 * F * J * N2) - (2 * I * J * Q) + (2 * P * J * J);//
                tetta = (2 * J * J * R) - (2 * G * J * N2) + (2 * B * K * N2) - (2 * J * K * Q);//
                ksi = (2 * K * I * B) - (2 * F * K * J) - (2 * G * I * J) + (2 * J * J * H);//
                lyambda = (B * N2 * N2) + (D * J * J) - (2 * J * N2 * Q);//
                ksi = ksi / 2.0;
                gamma = gamma / 2.0;
                tetta = tetta / 2.0;

                angle = Math.Atan((2 * ksi) / (alpha - beta)) / 2;
                if ((alpha * beta - (ksi * ksi)) != 0)
                {
                    x0 = (-gamma * beta - (-tetta * ksi)) / (alpha * beta - (ksi * ksi));
                    y0 = (-tetta * alpha - (-gamma * ksi)) / (alpha * beta - (ksi * ksi));
                }
            }
            else if (K != 0)
            {
                alpha = (C * I * I) - (2 * K * H * I) + (A * K * K);//
                beta = (C * J * J) + (B * K * K) - (2 * J * G * K);//
                gamma = (2 * N3 * I * C) - (2 * H * K * N3) - (2 * I * K * R) + (2 * P * K * K);//
                tetta = (2 * K * K * Q) - (2 * G * K * N3) + (2 * C * J * N3) - (2 * J * K * R);//
                ksi = (2 * C * I * J) - (2 * G * K * I) - (2 * H * K * J) + (2 * K * K * F);//
                lyambda = (C * N3 * N3) + (D * K * K) - (2 * K * N3 * R);//
                ksi = ksi / 2.0;
                gamma = gamma / 2.0;
                tetta = tetta / 2.0;

                angle = Math.Atan((2 * ksi) / (alpha - beta)) / 2;
                if ((alpha * beta - (ksi * ksi)) != 0)
                {
                    x0 = (-gamma * beta - (-tetta * ksi)) / (alpha * beta - (ksi * ksi));
                    y0 = (-tetta * alpha - (-gamma * ksi)) / (alpha * beta - (ksi * ksi));
                }
            }
            DetermineSurface();
        }

        #endregion

        #region Determine Surface
        private void DetermineSurface()
        {
            if (sigma != 0)
            {
                if ((tau2 > 0) && (tau1 * sigma > 0))
                {
                    if (delta < 0)
                        surface = "Ellipsoid";
                    else if (delta > 0)
                        surface = "Imaginary Ellipsoid";
                    else if (delta == 0)
                        surface = "Imaginary Cone";
                }
                else if ((tau2 <= 0) || (tau1 * sigma <= 0))
                {
                    if (delta < 0)
                        surface = "Two-Strip Hyperboloid";
                    else if (delta > 0)
                        surface = "Single-sheet hyperboloid";
                    else if (delta == 0)
                        surface = "Cone";
                }
            }
            else if (sigma == 0)
            {
                if (delta < 0)
                    surface = "Elliptical Paraboloid";
                else if (delta > 0)
                    surface = "Hyperbolic parabaloid";
                else if (delta == 0)
                {
                    if (tau2 > 0)
                    {
                        if (tau1 * k2 < 0)
                            surface = "Elliptical Cylinder";
                        else if (tau1 * k2 > 0)
                            surface = "Imaginary Elliptical Cylinder";
                        else if (k2 == 0)
                            surface = "Pair of imaginary intersecting planes";
                    }
                    else if (tau2 < 0)
                    {
                        if (k2 != 0)
                            surface = "Hyperbolic Cylinder";
                        else if (k2 == 0)
                            surface = "Pair of intersecting planes";
                    }
                    else if (tau2 == 0)
                    {
                        if (k2 != 0)
                            surface = "Parabolic Cylinder";
                        else if (k2 == 0)
                        {
                            if (k1 < 0)
                                surface = "Pair of parallel planes";
                            else if (k1 > 0)
                                surface = "Pair of imaginary parallel planes";
                            else if (k1 == 0)
                                surface = "Pair of coincident planes";
                        }
                    }
                }
            }
            txtSurface.Text = surface;
        }
        #endregion

        #region Paint Functions

            #region Paint Function 1
        private void PaintFunction1()
        {
            try
            {
                AccuracyFound(scale1);
                I = 1; J = 0; K = 0;// N = 0;
                CalculateFunction();

                Bitmap btmp = new Bitmap(Plot1.Width, Plot1.Height);
                Plot1.Image = btmp;
                Graphics gr = Graphics.FromImage(Plot1.Image);

                #region Pens
                Plot1.BackColor = pbc;
                Pen MainAxesPen = new Pen(mac);
                SolidBrush NumsPen = new SolidBrush(nc);
                SolidBrush FigurePen = new SolidBrush(pc);
                #endregion

                #region Main Axes
                Point p1 = new Point(OX, 0);
                Point p2 = new Point(OX, Plot1.Height);
                gr.DrawLine(MainAxesPen, p1, p2);
                p1 = new Point(0, OY);
                p2 = new Point(Plot1.Width, OY);
                gr.DrawLine(MainAxesPen, p1, p2);
                #endregion

                #region Drawing 0, X, Y, Z
                String drawString = "0";
                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 11, OY);
                drawString = "Y";
                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, Plot1.Width - 20, OY - 20);
                drawString = "Z";
                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX + 5, 13);
                #endregion

                #region Drawing Nums
                if (scale1 > 10)
                {
                    int j = 1;
                    for (int i = OX; i < Plot1.Width; i += scale1)
                    {
                        //nums
                        drawString = j.ToString();
                        if (j > 9)
                            gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i + scale1 - 7, OY + 5);
                        else
                            gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i + scale1 - 3, OY + 5);
                        j++;
                    }
                    j = -1;
                    for (int i = OX; i > 0; i -= scale1)
                    {
                        //nums
                        drawString = j.ToString();
                        if (j < -9)
                            gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i - scale1 - 10, OY + 5);
                        else
                            gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i - scale1 - 7, OY + 5);
                        j--;
                    }
                    j = 1;
                    for (int i = OY; i > 0; i -= scale1)
                    {
                        //nums
                        drawString = j.ToString();
                        if (j > 9)
                            gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 20, i - scale1 - 9);
                        else
                            gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 16, i - scale1 - 9);
                        j++;
                    }
                    j = -1;
                    for (int i = OY; i < Plot1.Height; i += scale1)
                    {
                        //nums
                        drawString = j.ToString();
                        if (j < -9)
                            gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 24, i + scale1 - 9);
                        else
                            gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 20, i + scale1 - 9);
                        j--;
                    }
                }
                #endregion

                #region Drawing Figure
                if (alpha != 0)
                {
                    y = -length;
                    while (y < length)
                    {
                        d = Math.Pow(2 * ksi * y + 2 * gamma, 2) - (4 * alpha * (beta * y * y + 2 * tetta * y + lyambda));
                        if (d >= 0)
                        {
                            x1 = (-1.0 * (2 * ksi * y + 2 * gamma) + Math.Sqrt(d)) / (2 * alpha);
                            x2 = (-1.0 * (2 * ksi * y + 2 * gamma) - Math.Sqrt(d)) / (2 * alpha);
                            if ((OX + (int)(x1 * scale1) > 0) && (OX + (int)(x1 * scale1) < Plot1.Width) && (OY - (int)(y * scale1) > 0) && (OY - (int)(y * scale1) < Plot1.Height))
                                btmp.SetPixel(OX + (int)(x1 * scale1), OY - (int)(y * scale1), pc);
                            if ((OX + (int)(x2 * scale1) > 0) && (OX + (int)(x2 * scale1) < Plot1.Width) && (OY - (int)(y * scale1) > 0) && (OY - (int)(y * scale1) < Plot1.Height))
                                btmp.SetPixel(OX + (int)(x2 * scale1), OY - (int)(y * scale1), pc);
                        }
                        y += accuracy;
                    }
                }
                else if (beta != 0)
                {
                    x = -length;
                    while (x < length)
                    {
                        d = Math.Pow(2 * ksi * x + 2 * tetta, 2) - (4 * beta * (alpha * x * x + 2 * gamma * x + lyambda));
                        if (d >= 0)
                        {
                            y1 = (-1.0 * (2 * ksi * x + 2 * tetta) + Math.Sqrt(d)) / (2 * beta);
                            y2 = (-1.0 * (2 * ksi * x + 2 * tetta) - Math.Sqrt(d)) / (2 * beta);
                            if ((OX + (int)(x * scale1) > 0) && (OX + (int)(x * scale1) < Plot1.Width) && (OY - (int)(y1 * scale1) > 0) && (OY - (int)(y1 * scale1) < Plot1.Height))
                                btmp.SetPixel(OX + (int)(x * scale1), OY - (int)(y1 * scale1), pc);
                            if ((OX + (int)(x * scale1) > 0) && (OX + (int)(x * scale1) < Plot1.Width) && (OY - (int)(y2 * scale1) > 0) && (OY - (int)(y2 * scale1) < Plot1.Height))
                                btmp.SetPixel(OX + (int)(x * scale1), OY - (int)(y2 * scale1), pc);
                        }
                        x += accuracy;
                    }
                }
                else
                {
                    x = -length;
                    while (x < length)
                    {
                        if (tetta != 0 || ksi != 0)
                        {
                            y1 = (-lyambda - 2 * gamma * x) / (2 * ksi * x + 2 * tetta);
                            if (x < x0)
                            {
                                if ((OX + (int)(x * scale1) > 0) && (OX + (int)(x * scale1) < Plot1.Width) && (OY - (int)(y1 * scale1) > 0) && (OY - (int)(y1 * scale1) < Plot1.Height))
                                    btmp.SetPixel(OX + (int)(x * scale1), OY - (int)(y1 * scale1), pc);
                            }
                            if ((x + accuracy > x0) && (x - accuracy < x0))
                            {
                                x += accuracy * 10;
                            }
                            if (x > x0)
                            {
                                if ((OX + (int)(x * scale1) > 0) && (OX + (int)(x * scale1) < Plot1.Width) && (OY - (int)(y1 * scale1) > 0) && (OY - (int)(y1 * scale1) < Plot1.Height))
                                    btmp.SetPixel(OX + (int)(x * scale1), OY - (int)(y1 * scale1), pc);
                            }
                            x += accuracy;
                        }
                        else
                        {
                            x1 = (-lyambda - 2 * tetta * x) / (2 * ksi * x + 2 * gamma);
                            if (x < y0)
                            {
                                if ((OX + (int)(x1 * scale1) > 0) && (OX + (int)(x1 * scale1) < Plot1.Width) && (OY - (int)(x * scale1) > 0) && (OY - (int)(x * scale1) < Plot1.Height))
                                    btmp.SetPixel(OX + (int)(x1 * scale1), OY - (int)(x * scale1), pc);
                            }
                            if ((x + accuracy > y0) && (x - accuracy < y0))
                            {
                                x += accuracy * 10;
                            }
                            if (x > y0)
                            {
                                if ((OX + (int)(x1 * scale1) > 0) && (OX + (int)(x1 * scale1) < Plot1.Width) && (OY - (int)(x * scale1) > 0) && (OY - (int)(x * scale1) < Plot1.Height))
                                    btmp.SetPixel(OX + (int)(x1 * scale1), OY - (int)(x * scale1), pc);
                            }
                            x += accuracy;
                        }
                    }
                }
                #endregion


                gr.Dispose();
                GC.Collect();
            }
            catch
            {
                return;
            }
        }
        #endregion

            #region Paint Function 2
        private void PaintFunction2()
        {
            try
            {
                AccuracyFound(scale2);
                I = 0; J = 1; K = 0;// N = 0;
                CalculateFunction();

                Bitmap btmp1 = new Bitmap(Plot2.Width, Plot2.Height);
                Plot2.Image = btmp1;
                Graphics gr = Graphics.FromImage(Plot2.Image);

                #region Pens
                Plot2.BackColor = pbc;
                Pen MainAxesPen = new Pen(mac);
                SolidBrush NumsPen = new SolidBrush(nc);
                SolidBrush FigurePen = new SolidBrush(pc);
                #endregion

                #region Main Axes
                Point p1 = new Point(OX, 0);
                Point p2 = new Point(OX, Plot2.Height);
                gr.DrawLine(MainAxesPen, p1, p2);
                p1 = new Point(0, OY);
                p2 = new Point(Plot2.Width, OY);
                gr.DrawLine(MainAxesPen, p1, p2);
                #endregion

                #region Drawing 0, X, Y, Z
                String drawString = "0";
                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 11, OY);
                drawString = "X";
                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, Plot2.Width - 20, OY - 20);
                drawString = "Z";
                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX + 5, 13);
                #endregion

                #region Drawing Nums
                if (scale2 > 10)
                {
                    int j = 1;
                    for (int i = OX; i < Plot2.Width; i += scale2)
                    {
                        //nums
                        drawString = j.ToString();
                        if (j > 9)
                            gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i + scale2 - 7, OY + 5);
                        else
                            gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i + scale2 - 3, OY + 5);
                        j++;
                    }
                    j = -1;
                    for (int i = OX; i > 0; i -= scale2)
                    {
                        //nums
                        drawString = j.ToString();
                        if (j < -9)
                            gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i - scale2 - 10, OY + 5);
                        else
                            gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i - scale2 - 7, OY + 5);
                        j--;
                    }
                    j = 1;
                    for (int i = OY; i > 0; i -= scale2)
                    {
                        //nums
                        drawString = j.ToString();
                        if (j > 9)
                            gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 20, i - scale2 - 9);
                        else
                            gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 16, i - scale2 - 9);
                        j++;
                    }
                    j = -1;
                    for (int i = OY; i < Plot2.Height; i += scale2)
                    {
                        //nums
                        drawString = j.ToString();
                        if (j < -9)
                            gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 24, i + scale2 - 9);
                        else
                            gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 20, i + scale2 - 9);
                        j--;
                    }
                }
                #endregion

                #region Drawing Figure
                if (alpha != 0)
                {
                    y = -length;
                    while (y < length)
                    {
                        d = Math.Pow(2 * ksi * y + 2 * gamma, 2) - (4 * alpha * (beta * y * y + 2 * tetta * y + lyambda));
                        if (d >= 0)
                        {
                            x1 = (-1.0 * (2 * ksi * y + 2 * gamma) + Math.Sqrt(d)) / (2 * alpha);
                            x2 = (-1.0 * (2 * ksi * y + 2 * gamma) - Math.Sqrt(d)) / (2 * alpha);
                            if ((OX + (int)(x1 * scale2) > 0) && (OX + (int)(x1 * scale2) < Plot2.Width) && (OY - (int)(y * scale2) > 0) && (OY - (int)(y * scale2) < Plot2.Height))
                                btmp1.SetPixel(OX + (int)(x1 * scale2), OY - (int)(y * scale2), pc);
                            if ((OX + (int)(x2 * scale2) > 0) && (OX + (int)(x2 * scale2) < Plot2.Width) && (OY - (int)(y * scale2) > 0) && (OY - (int)(y * scale2) < Plot2.Height))
                                btmp1.SetPixel(OX + (int)(x2 * scale2), OY - (int)(y * scale2), pc);
                        }
                        y += accuracy;
                    }
                }
                else if (beta != 0)
                {
                    x = -length;
                    while (x < length)
                    {
                        d = Math.Pow(2 * ksi * x + 2 * tetta, 2) - (4 * beta * (alpha * x * x + 2 * gamma * x + lyambda));
                        if (d >= 0)
                        {
                            y1 = (-1.0 * (2 * ksi * x + 2 * tetta) + Math.Sqrt(d)) / (2 * beta);
                            y2 = (-1.0 * (2 * ksi * x + 2 * tetta) - Math.Sqrt(d)) / (2 * beta);
                            if ((OX + (int)(x * scale2) > 0) && (OX + (int)(x * scale2) < Plot2.Width) && (OY - (int)(y1 * scale2) > 0) && (OY - (int)(y1 * scale2) < Plot2.Height))
                                btmp1.SetPixel(OX + (int)(x * scale2), OY - (int)(y1 * scale2), pc);
                            if ((OX + (int)(x * scale2) > 0) && (OX + (int)(x * scale2) < Plot2.Width) && (OY - (int)(y2 * scale2) > 0) && (OY - (int)(y2 * scale2) < Plot2.Height))
                                btmp1.SetPixel(OX + (int)(x * scale2), OY - (int)(y2 * scale2), pc);
                        }
                        x += accuracy;
                    }
                }
                else
                {
                    x = -length;
                    while (x < length)
                    {
                        if (tetta != 0 || ksi != 0)
                        {
                            y1 = (-lyambda - 2 * gamma * x) / (2 * ksi * x + 2 * tetta);
                            if (x < x0)
                            {
                                if ((OX + (int)(x * scale2) > 0) && (OX + (int)(x * scale2) < Plot2.Width) && (OY - (int)(y1 * scale2) > 0) && (OY - (int)(y1 * scale2) < Plot2.Height))
                                    btmp1.SetPixel(OX + (int)(x * scale2), OY - (int)(y1 * scale2), pc);
                            }
                            if ((x + accuracy > x0) && (x - accuracy < x0))
                            {
                                x += accuracy * 10;
                            }
                            if (x > x0)
                            {
                                if ((OX + (int)(x * scale2) > 0) && (OX + (int)(x * scale2) < Plot2.Width) && (OY - (int)(y1 * scale2) > 0) && (OY - (int)(y1 * scale2) < Plot2.Height))
                                    btmp1.SetPixel(OX + (int)(x * scale2), OY - (int)(y1 * scale2), pc);
                            }
                            x += accuracy;
                        }
                        else
                        {
                            x1 = (-lyambda - 2 * tetta * x) / (2 * ksi * x + 2 * gamma);
                            if (x < y0)
                            {
                                if ((OX + (int)(x1 * scale2) > 0) && (OX + (int)(x1 * scale2) < Plot2.Width) && (OY - (int)(x * scale2) > 0) && (OY - (int)(x * scale2) < Plot2.Height))
                                    btmp1.SetPixel(OX + (int)(x1 * scale2), OY - (int)(x * scale2), pc);
                            }
                            if ((x + accuracy > y0) && (x - accuracy < y0))
                            {
                                x += accuracy * 10;
                            }
                            if (x > y0)
                            {
                                if ((OX + (int)(x1 * scale2) > 0) && (OX + (int)(x1 * scale2) < Plot2.Width) && (OY - (int)(x * scale2) > 0) && (OY - (int)(x * scale2) < Plot2.Height))
                                    btmp1.SetPixel(OX + (int)(x1 * scale2), OY - (int)(x * scale2), pc);
                            }
                            x += accuracy;
                        }
                    }
                }
                #endregion


                gr.Dispose();
                GC.Collect();
            }
            catch
            {
                return;
            }
        }
        #endregion

            #region Paint Function 3
        private void PaintFunction3()
        {
            try
            {
                AccuracyFound(scale3);
                I = 0; J = 0; K = 1;// N = 0;
                CalculateFunction();

                Bitmap btmp2 = new Bitmap(Plot3.Width, Plot3.Height);
                Plot3.Image = btmp2;
                Graphics gr = Graphics.FromImage(Plot3.Image);

                #region Pens
                Plot3.BackColor = pbc;
                Pen MainAxesPen = new Pen(mac);
                SolidBrush NumsPen = new SolidBrush(nc);
                SolidBrush FigurePen = new SolidBrush(pc);
                #endregion

                #region Main Axes
                Point p1 = new Point(OX, 0);
                Point p2 = new Point(OX, Plot3.Height);
                gr.DrawLine(MainAxesPen, p1, p2);
                p1 = new Point(0, OY);
                p2 = new Point(Plot3.Width, OY);
                gr.DrawLine(MainAxesPen, p1, p2);
                #endregion

                #region Drawing 0, X, Y, Z
                String drawString = "0";
                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 11, OY);
                drawString = "X";
                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, Plot3.Width - 20, OY - 20);
                drawString = "Y";
                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX + 5, 13);
                #endregion

                #region Drawing Nums
                if (scale3 > 10)
                {
                    int j = 1;
                    for (int i = OX; i < Plot2.Width; i += scale3)
                    {
                        //nums
                        drawString = j.ToString();
                        if (j > 9)
                            gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i + scale3 - 7, OY + 5);
                        else
                            gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i + scale3 - 3, OY + 5);
                        j++;
                    }
                    j = -1;
                    for (int i = OX; i > 0; i -= scale3)
                    {
                        //nums
                        drawString = j.ToString();
                        if (j < -9)
                            gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i - scale3 - 10, OY + 5);
                        else
                            gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i - scale3 - 7, OY + 5);
                        j--;
                    }
                    j = 1;
                    for (int i = OY; i > 0; i -= scale3)
                    {
                        //nums
                        drawString = j.ToString();
                        if (j > 9)
                            gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 20, i - scale3 - 9);
                        else
                            gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 16, i - scale3 - 9);
                        j++;
                    }
                    j = -1;
                    for (int i = OY; i < Plot2.Height; i += scale3)
                    {
                        //nums
                        drawString = j.ToString();
                        if (j < -9)
                            gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 24, i + scale3 - 9);
                        else
                            gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 20, i + scale3 - 9);
                        j--;
                    }
                }
                #endregion

                #region Drawing Figure
                if (alpha != 0)
                {
                    y = -length;
                    while (y < length)
                    {
                        d = Math.Pow(2 * ksi * y + 2 * gamma, 2) - (4 * alpha * (beta * y * y + 2 * tetta * y + lyambda));
                        if (d >= 0)
                        {
                            x1 = (-1.0 * (2 * ksi * y + 2 * gamma) + Math.Sqrt(d)) / (2 * alpha);
                            x2 = (-1.0 * (2 * ksi * y + 2 * gamma) - Math.Sqrt(d)) / (2 * alpha);
                            if ((OX + (int)(x1 * scale3) > 0) && (OX + (int)(x1 * scale3) < Plot1.Width) && (OY - (int)(y * scale3) > 0) && (OY - (int)(y * scale3) < Plot1.Height))
                                btmp2.SetPixel(OX + (int)(x1 * scale3), OY - (int)(y * scale3), pc);
                            if ((OX + (int)(x2 * scale3) > 0) && (OX + (int)(x2 * scale3) < Plot1.Width) && (OY - (int)(y * scale3) > 0) && (OY - (int)(y * scale3) < Plot1.Height))
                                btmp2.SetPixel(OX + (int)(x2 * scale3), OY - (int)(y * scale3), pc);
                        }
                        y += accuracy;
                    }
                }
                else if (beta != 0)
                {
                    x = -length;
                    while (x < length)
                    {
                        d = Math.Pow(2 * ksi * x + 2 * tetta, 2) - (4 * beta * (alpha * x * x + 2 * gamma * x + lyambda));
                        if (d >= 0)
                        {
                            y1 = (-1.0 * (2 * ksi * x + 2 * tetta) + Math.Sqrt(d)) / (2 * beta);
                            y2 = (-1.0 * (2 * ksi * x + 2 * tetta) - Math.Sqrt(d)) / (2 * beta);
                            if ((OX + (int)(x * scale3) > 0) && (OX + (int)(x * scale3) < Plot1.Width) && (OY - (int)(y1 * scale3) > 0) && (OY - (int)(y1 * scale3) < Plot1.Height))
                                btmp2.SetPixel(OX + (int)(x * scale3), OY - (int)(y1 * scale3), pc);
                            if ((OX + (int)(x * scale3) > 0) && (OX + (int)(x * scale3) < Plot1.Width) && (OY - (int)(y2 * scale3) > 0) && (OY - (int)(y2 * scale3) < Plot1.Height))
                                btmp2.SetPixel(OX + (int)(x * scale3), OY - (int)(y2 * scale3), pc);
                        }
                        x += accuracy;
                    }
                }
                else
                {
                    x = -length;
                    while (x < length)
                    {
                        if (tetta != 0 || ksi != 0)
                        {
                            y1 = (-lyambda - 2 * gamma * x) / (2 * ksi * x + 2 * tetta);
                            if (x < x0)
                            {
                                if ((OX + (int)(x * scale3) > 0) && (OX + (int)(x * scale3) < Plot1.Width) && (OY - (int)(y1 * scale3) > 0) && (OY - (int)(y1 * scale3) < Plot1.Height))
                                    btmp2.SetPixel(OX + (int)(x * scale3), OY - (int)(y1 * scale3), pc);
                            }
                            if ((x + accuracy > x0) && (x - accuracy < x0))
                            {
                                x += accuracy * 10;
                            }
                            if (x > x0)
                            {
                                if ((OX + (int)(x * scale3) > 0) && (OX + (int)(x * scale3) < Plot1.Width) && (OY - (int)(y1 * scale3) > 0) && (OY - (int)(y1 * scale3) < Plot1.Height))
                                    btmp2.SetPixel(OX + (int)(x * scale3), OY - (int)(y1 * scale3), pc);
                            }
                            x += accuracy;
                        }
                        else
                        {
                            x1 = (-lyambda - 2 * tetta * x) / (2 * ksi * x + 2 * gamma);
                            if (x < y0)
                            {
                                if ((OX + (int)(x1 * scale3) > 0) && (OX + (int)(x1 * scale3) < Plot1.Width) && (OY - (int)(x * scale3) > 0) && (OY - (int)(x * scale3) < Plot1.Height))
                                    btmp2.SetPixel(OX + (int)(x1 * scale3), OY - (int)(x * scale3), pc);
                            }
                            if ((x + accuracy > y0) && (x - accuracy < y0))
                            {
                                x += accuracy * 10;
                            }
                            if (x > y0)
                            {
                                if ((OX + (int)(x1 * scale3) > 0) && (OX + (int)(x1 * scale3) < Plot1.Width) && (OY - (int)(x * scale3) > 0) && (OY - (int)(x * scale3) < Plot1.Height))
                                    btmp2.SetPixel(OX + (int)(x1 * scale3), OY - (int)(x * scale3), pc);
                            }
                            x += accuracy;
                        }
                    }
                }
                #endregion


                gr.Dispose();
                GC.Collect();
            }
            catch
            {
                return;
            }
        }
        #endregion

            #region Paint Function 4
        private void PaintFunction4()
        {
            try
            {
                length = 16;
                accuracy = 0.01;

                Bitmap btmp3 = new Bitmap(Plot4.Width, Plot4.Height);
                Plot4.Image = btmp3;
                Graphics gr = Graphics.FromImage(Plot4.Image);

                #region Pens
                Plot4.BackColor = pbc;
                Pen MainAxesPen = new Pen(mac, 2);
                SolidBrush NumsPen = new SolidBrush(nc);
                SolidBrush FigurePen = new SolidBrush(pc);
                #endregion

                int OXX = OX - 30;
                int OYY = OY + 30;

                #region Drawing Figure

                double iks1 = 0.0, iks2 = 0.0;
                double ygr1 = 0.0, ygr2 = 0.0;
                double zet1 = 0.0, zet2 = 0.0;

                #region if A != 0 back
                if (A != 0)
                {
                    // Ax^2 + By^2 + Cz^2 + 2Fxy + 2Gyz + 2Hxz + 2Px + 2Qy + 2Rz + D = 0
                    // Ax^2 + 2Fxy + 2Hxz + 2Px = -(By^2 + Cz^2 + 2Gyz + 2Qy + 2Rz + D)
                    // Ax^2 + x(2Fy + 2Hz + 2P) + (By^2 + Cz^2 + 2Gyz + 2Qy + 2Rz + D) = 0
                    // Disc = (2Fy + 2Hz + 2P)*(2Fy + 2Hz + 2P) - 4*A*(By^2 + Cz^2 + 2Gyz + 2Qy + 2Rz + D)
                    // if Disc >= 0
                    // x1 = (-(2Fy + 2Hz + 2P) + sqrt(Disc))/(2*A)
                    // x2 = (-(2Fy + 2Hz + 2P) - sqrt(Disc))/(2*A)
                    for (double i = -length; i < length; i += accuracy * 10)
                    {
                        for (double j = -length; j < length; j += accuracy * 10)
                        {
                            double Disc = ((2 * F * i + 2 * H * j + 2 * P) * (2 * F * i + 2 * H * j + 2 * P)) - (4 * A * (B * i * i + C * j * j + 2 * G * i * j + 2 * Q * i + 2 * R * j + D));
                            if (Disc >= 0)
                            {
                                iks1 = (-(2 * F * i + 2 * H * j + 2 * P) + Math.Sqrt(Disc)) / (2 * A);
                                iks2 = (-(2 * F * i + 2 * H * j + 2 * P) - Math.Sqrt(Disc)) / (2 * A);
                                Color BackColor = Color.FromArgb(255 - 100, 255 - 100, 255 - 100);
                                if (iks1 < 0)
                                {
                                    if ((OXX + 2 + (int)(i * scale - iks1 * scale / 1.6) > 0) && (OXX + 2 + (int)(i * scale - iks1 * scale / 1.6) < Plot4.Width) && (OYY - 2 - (int)(j * scale - iks1 * scale / 3) > 0) && (OYY - 2 - (int)(j * scale - iks1 * scale / 3) < Plot4.Height))
                                        btmp3.SetPixel(OXX + 2 + (int)(i * scale - iks1 * scale / 1.6), OYY - 2 - (int)(j * scale - iks1 * scale / 3), BackColor);
                                }
                                if (iks2 < 0)
                                {
                                    if ((OXX + 2 + (int)(i * scale - iks2 * scale / 1.6) > 0) && (OXX + 2 + (int)(i * scale - iks2 * scale / 1.6) < Plot4.Width) && (OYY - 2 - (int)(j * scale - iks2 * scale / 3) > 0) && (OYY - 2 - (int)(j * scale - iks2 * scale / 3) < Plot4.Height))
                                        btmp3.SetPixel(OXX + 2 + (int)(i * scale - iks2 * scale / 1.6), OYY - 2 - (int)(j * scale - iks2 * scale / 3), BackColor);
                                }
                                if ((iks1 >= 0) && (i < 0))
                                {
                                    BackColor = pc;
                                    if ((OXX + 2 + (int)(i * scale - iks1 * scale / 1.6) > 0) && (OXX + 2 + (int)(i * scale - iks1 * scale / 1.6) < Plot4.Width) && (OYY - 2 - (int)(j * scale - iks1 * scale / 3) > 0) && (OYY - 2 - (int)(j * scale - iks1 * scale / 3) < Plot4.Height))
                                        btmp3.SetPixel(OXX + 2 + (int)(i * scale - iks1 * scale / 1.6), OYY - 2 - (int)(j * scale - iks1 * scale / 3), BackColor);
                                }
                                if ((iks2 >= 0) && (i < 0))
                                {
                                    BackColor = pc;
                                    if ((OXX + 2 + (int)(i * scale - iks2 * scale / 1.6) > 0) && (OXX + 2 + (int)(i * scale - iks2 * scale / 1.6) < Plot4.Width) && (OYY - 2 - (int)(j * scale - iks2 * scale / 3) > 0) && (OYY - 2 - (int)(j * scale - iks2 * scale / 3) < Plot4.Height))
                                        btmp3.SetPixel(OXX + 2 + (int)(i * scale - iks2 * scale / 1.6), OYY - 2 - (int)(j * scale - iks2 * scale / 3), BackColor);
                                }
                                if (iks1 >= 0)
                                {
                                    BackColor = pc;
                                    if ((OXX + 2 + (int)(i * scale - iks1 * scale / 1.6) > 0) && (OXX + 2 + (int)(i * scale - iks1 * scale / 1.6) < Plot4.Width) && (OYY - 2 - (int)(j * scale - iks1 * scale / 3) > 0) && (OYY - 2 - (int)(j * scale - iks1 * scale / 3) < Plot4.Height))
                                        btmp3.SetPixel(OXX + 2 + (int)(i * scale - iks1 * scale / 1.6), OYY - 2 - (int)(j * scale - iks1 * scale / 3), BackColor);
                                }
                                if (iks2 >= 0)
                                {
                                    BackColor = pc;
                                    if ((OXX + 2 + (int)(i * scale - iks2 * scale / 1.6) > 0) && (OXX + 2 + (int)(i * scale - iks2 * scale / 1.6) < Plot4.Width) && (OYY - 2 - (int)(j * scale - iks2 * scale / 3) > 0) && (OYY - 2 - (int)(j * scale - iks2 * scale / 3) < Plot4.Height))
                                        btmp3.SetPixel(OXX + 2 + (int)(i * scale - iks2 * scale / 1.6), OYY - 2 - (int)(j * scale - iks2 * scale / 3), BackColor);
                                }
                            }
                        }
                    }
                }
                #endregion

                #region if B != 0 back
                else if (B != 0)
                {
                    for (double i = -length; i < length; i += accuracy * 10)
                    {
                        for (double j = -length; j < length; j += accuracy * 10)
                        {
                            // By^2 + 2Fxy + 2Gyz + 2Qy = -(Ax^2 + Cz^2 + 2Hxz + 2Px + 2Rz + D)
                            // By^2 + y(2Fx + 2Gz + 2Q) + (Ax^2 + Cz^2 + 2Hxz + 2Px + 2Rz + D) = 0
                            // Disc = (2Fx + 2Gz + 2Q)*(2Fx + 2Gz + 2Q) - 4*B*(Ax^2 + Cz^2 + 2Hxz + 2Px + 2Rz + D)
                            // if Disc >= 0
                            // y1 = (-(2Fx + 2Gz + 2Q) + sqrt(Disc))/(2*B)
                            // y2 = (-(2Fx + 2Gz + 2Q) - sqrt(Disc))/(2*B)
                            double Disc = ((2 * F * i + 2 * G * j + 2 * Q) * (2 * F * i + 2 * G * j + 2 * Q)) - (4 * B * (A * i * i + C * j * j + 2 * H * i * j + 2 * P * i + 2 * R * j + D));
                            if (Disc >= 0)
                            {
                                ygr1 = (-(2 * F * i + 2 * G * j + 2 * Q) + Math.Sqrt(Disc)) / (2 * B);
                                ygr2 = (-(2 * F * i + 2 * G * j + 2 * Q) - Math.Sqrt(Disc)) / (2 * B);
                                Color BackColor = Color.FromArgb(255 - 100, 255 - 100, 255 - 100);

                                if (ygr1 < 0)
                                {
                                    if ((OXX + 2 + (int)(ygr1 * scale - i * scale / 1.6) > 0) && (OXX + 2 + (int)(ygr1 * scale - i * scale / 1.6) < Plot4.Width) && (OYY - 2 - (int)(j * scale - i * scale / 3) > 0) && (OYY - 2 - (int)(j * scale - i * scale / 3) < Plot4.Height))
                                        btmp3.SetPixel(OXX + 2 + (int)(ygr1 * scale - i * scale / 1.6), OYY - 2 - (int)(j * scale - i * scale / 3), BackColor);
                                }
                                if (ygr2 < 0)
                                {
                                    if ((OXX + 2 + (int)(ygr2 * scale - i * scale / 1.6) > 0) && (OXX + 2 + (int)(ygr2 * scale - i * scale / 1.6) < Plot4.Width) && (OYY - 2 - (int)(j * scale - i * scale / 3) > 0) && (OYY - 2 - (int)(j * scale - i * scale / 3) < Plot4.Height))
                                        btmp3.SetPixel(OXX + 2 + (int)(ygr2 * scale - i * scale / 1.6), OYY - 2 - (int)(j * scale - i * scale / 3), BackColor);
                                }

                                if ((ygr1 >= 0) && (i < 0))
                                {
                                    BackColor = pc;
                                    if ((OXX + 2 + (int)(ygr1 * scale - i * scale / 1.6) > 0) && (OXX + 2 + (int)(ygr1 * scale - i * scale / 1.6) < Plot4.Width) && (OYY - 2 - (int)(j * scale - i * scale / 3) > 0) && (OYY - 2 - (int)(j * scale - i * scale / 3) < Plot4.Height))
                                        btmp3.SetPixel(OXX + 2 + (int)(ygr1 * scale - i * scale / 1.6), OYY - 2 - (int)(j * scale - i * scale / 3), BackColor);
                                }
                                if ((ygr2 >= 0) && (i < 0))
                                {
                                    BackColor = pc;
                                    if ((OXX + 2 + (int)(ygr2 * scale - i * scale / 1.6) > 0) && (OXX + 2 + (int)(ygr2 * scale - i * scale / 1.6) < Plot4.Width) && (OYY - 2 - (int)(j * scale - i * scale / 3) > 0) && (OYY - 2 - (int)(j * scale - i * scale / 3) < Plot4.Height))
                                        btmp3.SetPixel(OXX + 2 + (int)(ygr2 * scale - i * scale / 1.6), OYY - 2 - (int)(j * scale - i * scale / 3), BackColor);
                                }
                                if (ygr1 >= 0)
                                {
                                    BackColor = pc;
                                    if ((OXX + 2 + (int)(ygr1 * scale - i * scale / 1.6) > 0) && (OXX + 2 + (int)(ygr1 * scale - i * scale / 1.6) < Plot4.Width) && (OYY - 2 - (int)(j * scale - i * scale / 3) > 0) && (OYY - 2 - (int)(j * scale - i * scale / 3) < Plot4.Height))
                                        btmp3.SetPixel(OXX + 2 + (int)(ygr1 * scale - i * scale / 1.6), OYY - 2 - (int)(j * scale - i * scale / 3), BackColor);
                                }
                                if (ygr2 >= 0)
                                {
                                    BackColor = pc;
                                    if ((OXX + 2 + (int)(ygr2 * scale - i * scale / 1.6) > 0) && (OXX + 2 + (int)(ygr2 * scale - i * scale / 1.6) < Plot4.Width) && (OYY - 2 - (int)(j * scale - i * scale / 3) > 0) && (OYY - 2 - (int)(j * scale - i * scale / 3) < Plot4.Height))
                                        btmp3.SetPixel(OXX + 2 + (int)(ygr2 * scale - i * scale / 1.6), OYY - 2 - (int)(j * scale - i * scale / 3), BackColor);
                                }
                            }
                        }
                    }
                }
                #endregion

                #region if C != 0 back
                else if (C != 0)
                {
                    for (double i = -length; i < length; i += accuracy * 10)
                    {
                        for (double j = -length; j < length; j += accuracy * 10)
                        {
                            // Cz^2 + 2Gyz + 2Hxz + 2Rz = -(Ax^2 + By^2 + 2Fxy + 2Px + 2Qy + D)
                            // Cx^2 + z(2Gy + 2Hx + 2R) + (Ax^2 + By^2 + 2Fxy + 2Px + 2Qy + D) = 0
                            // Disc = (2Gy + 2Hx + 2R)*(2Gy + 2Hx + 2R) - 4*C*(Ax^2 + By^2 + 2Fxy + 2Px + 2Qy + D)
                            // if Disc >= 0
                            // z1 = (-(2Gy + 2Hx + 2R) + sqrt(Disc))/(2*C)
                            // z2 = (-(2Gy + 2Hx + 2R) - sqrt(Disc))/(2*C)

                            double Disc = ((2 * G * j + 2 * H * i + 2 * R) * (2 * G * j + 2 * H * i + 2 * R)) - (4 * C * (A * i * i + B * j * j + 2 * F * i * j + 2 * P * i + 2 * Q * j + D));
                            if (Disc >= 0)
                            {
                                zet1 = (-(2 * G * j + 2 * H * i + 2 * R) + Math.Sqrt(Disc)) / (2 * C);
                                zet2 = (-(2 * G * j + 2 * H * i + 2 * R) - Math.Sqrt(Disc)) / (2 * C);
                                Color BackColor = Color.FromArgb(255 - 100, 255 - 100, 255 - 100);

                                if (zet1 < 0)
                                {
                                    if ((OXX + 2 + (int)(j * scale - i * scale / 1.6) > 0) && (OXX + 2 + (int)(j * scale - i * scale / 1.6) < Plot4.Width) && (OYY - 2 - (int)(zet1 * scale - i * scale / 3) > 0) && (OYY - 2 - (int)(zet1 * scale - i * scale / 3) < Plot4.Height))
                                        btmp3.SetPixel(OXX + 2 + (int)(j * scale - i * scale / 1.6), OYY - 2 - (int)(zet1 * scale - i * scale / 3), BackColor);
                                }
                                if (zet2 < 0)
                                {
                                    if ((OXX + 2 + (int)(j * scale - i * scale / 1.6) > 0) && (OXX + 2 + (int)(j * scale - i * scale / 1.6) < Plot4.Width) && (OYY - 2 - (int)(zet2 * scale - i * scale / 3) > 0) && (OYY - 2 - (int)(zet2 * scale - i * scale / 3) < Plot4.Height))
                                        btmp3.SetPixel(OXX + 2 + (int)(j * scale - i * scale / 1.6), OYY - 2 - (int)(zet2 * scale - i * scale / 3), BackColor);
                                }
                                if ((zet1 > 0) && (i < 0))
                                {
                                    BackColor = pc;
                                    if ((OXX + 2 + (int)(j * scale - i * scale / 1.6) > 0) && (OXX + 2 + (int)(j * scale - i * scale / 1.6) < Plot4.Width) && (OYY - 2 - (int)(zet1 * scale - i * scale / 3) > 0) && (OYY - 2 - (int)(zet1 * scale - i * scale / 3) < Plot4.Height))
                                        btmp3.SetPixel(OXX + 2 + (int)(j * scale - i * scale / 1.6), OYY - 2 - (int)(zet1 * scale - i * scale / 3), BackColor);
                                }
                                if ((zet2 > 0) && (i < 0))
                                {
                                    BackColor = pc;
                                    if ((OXX + 2 + (int)(j * scale - i * scale / 1.6) > 0) && (OXX + 2 + (int)(j * scale - i * scale / 1.6) < Plot4.Width) && (OYY - 2 - (int)(zet2 * scale - i * scale / 3) > 0) && (OYY - 2 - (int)(zet2 * scale - i * scale / 3) < Plot4.Height))
                                        btmp3.SetPixel(OXX + 2 + (int)(j * scale - i * scale / 1.6), OYY - 2 - (int)(zet2 * scale - i * scale / 3), BackColor);
                                }
                                if (zet1 >= 0)
                                {
                                    BackColor = pc;
                                    if ((OXX + 2 + (int)(j * scale - i * scale / 1.6) > 0) && (OXX + 2 + (int)(j * scale - i * scale / 1.6) < Plot4.Width) && (OYY - 2 - (int)(zet1 * scale - i * scale / 3) > 0) && (OYY - 2 - (int)(zet1 * scale - i * scale / 3) < Plot4.Height))
                                        btmp3.SetPixel(OXX + 2 + (int)(j * scale - i * scale / 1.6), OYY - 2 - (int)(zet1 * scale - i * scale / 3), BackColor);
                                }
                                if (zet2 >= 0)
                                {
                                    BackColor = pc;
                                    if ((OXX + 2 + (int)(j * scale - i * scale / 1.6) > 0) && (OXX + 2 + (int)(j * scale - i * scale / 1.6) < Plot4.Width) && (OYY - 2 - (int)(zet2 * scale - i * scale / 3) > 0) && (OYY - 2 - (int)(zet2 * scale - i * scale / 3) < Plot4.Height))
                                        btmp3.SetPixel(OXX + 2 + (int)(j * scale - i * scale / 1.6), OYY - 2 - (int)(zet2 * scale - i * scale / 3), BackColor);
                                }
                            }
                        }
                    }
                }
                #endregion

                DrawAxes(OXX, OYY, MainAxesPen, gr);

                # region if A != 0 front
                if (A != 0)
                {
                    for (double i = -length; i < length; i += accuracy * 10)
                    {
                        for (double j = -length; j < length; j += accuracy * 10)
                        {
                            // Ax^2 + By^2 + Cz^2 + 2Fxy + 2Gyz + 2Hxz + 2Px + 2Qy + 2Rz + D = 0
                            // Ax^2 + 2Fxy + 2Hxz + 2Px = -(By^2 + Cz^2 + 2Gyz + 2Qy + 2Rz + D)
                            // Ax^2 + x(2Fy + 2Hz + 2P) + (By^2 + Cz^2 + 2Gyz + 2Qy + 2Rz + D) = 0
                            // Disc = (2Fy + 2Hz + 2P)*(2Fy + 2Hz + 2P) - 4*A*(By^2 + Cz^2 + 2Gyz + 2Qy + 2Rz + D)
                            // if Disc >= 0
                            // x1 = (-(2Fy + 2Hz + 2P) + sqrt(Disc))/(2*A)
                            // x2 = (-(2Fy + 2Hz + 2P) - sqrt(Disc))/(2*A)

                            double Disc = ((2 * F * i + 2 * H * j + 2 * P) * (2 * F * i + 2 * H * j + 2 * P)) - (4 * A * (B * i * i + C * j * j + 2 * G * i * j + 2 * Q * i + 2 * R * j + D));
                            if (Disc >= 0)
                            {
                                iks1 = (-(2 * F * i + 2 * H * j + 2 * P) + Math.Sqrt(Disc)) / (2 * A);
                                iks2 = (-(2 * F * i + 2 * H * j + 2 * P) - Math.Sqrt(Disc)) / (2 * A);

                                if ((iks1 >= 0) && (i > 0))
                                {
                                    if ((OXX + 2 + (int)(i * scale - iks1 * scale / 1.6) > 0) && (OXX + 2 + (int)(i * scale - iks1 * scale / 1.6) < Plot4.Width) && (OYY - 2 - (int)(j * scale - iks1 * scale / 3) > 0) && (OYY - 2 - (int)(j * scale - iks1 * scale / 3) < Plot4.Height))
                                        btmp3.SetPixel(OXX + 2 + (int)(i * scale - iks1 * scale / 1.6), OYY - 2 - (int)(j * scale - iks1 * scale / 3), pc);
                                }
                                if ((iks2 >= 0) && (i > 0))
                                {
                                    if ((OXX + 2 + (int)(i * scale - iks2 * scale / 1.6) > 0) && (OXX + 2 + (int)(i * scale - iks2 * scale / 1.6) < Plot4.Width) && (OYY - 2 - (int)(j * scale - iks2 * scale / 3) > 0) && (OYY - 2 - (int)(j * scale - iks2 * scale / 3) < Plot4.Height))
                                        btmp3.SetPixel(OXX + 2 + (int)(i * scale - iks2 * scale / 1.6), OYY - 2 - (int)(j * scale - iks2 * scale / 3), pc);
                                }
                            }
                        }
                    }
                }
                #endregion

                #region if B != 0 front
                else if (B != 0)
                {
                    for (double i = -length; i < length; i += accuracy * 10)
                    {
                        for (double j = -length; j < length; j += accuracy * 10)
                        {
                            // By^2 + 2Fxy + 2Gyz + 2Qy = -(Ax^2 + Cz^2 + 2Hxz + 2Px + 2Rz + D)
                            // By^2 + y(2Fx + 2Gz + 2Q) + (Ax^2 + Cz^2 + 2Hxz + 2Px + 2Rz + D) = 0
                            // Disc = (2Fx + 2Gz + 2Q)*(2Fx + 2Gz + 2Q) - 4*B*(Ax^2 + Cz^2 + 2Hxz + 2Px + 2Rz + D)
                            // if Disc >= 0
                            // y1 = (-(2Fx + 2Gz + 2Q) + sqrt(Disc))/(2*B)
                            // y2 = (-(2Fx + 2Gz + 2Q) - sqrt(Disc))/(2*B)
                            double Disc = ((2 * F * i + 2 * G * j + 2 * Q) * (2 * F * i + 2 * G * j + 2 * Q)) - (4 * B * (A * i * i + C * j * j + 2 * H * i * j + 2 * P * i + 2 * R * j + D));
                            if (Disc >= 0)
                            {
                                ygr1 = (-(2 * F * i + 2 * G * j + 2 * Q) + Math.Sqrt(Disc)) / (2 * B);
                                ygr2 = (-(2 * F * i + 2 * G * j + 2 * Q) - Math.Sqrt(Disc)) / (2 * B);

                                if ((ygr1 >= 0) && (i > 0))
                                {
                                    if ((OXX + 2 + (int)(ygr1 * scale - i * scale / 1.6) > 0) && (OXX + 2 + (int)(ygr1 * scale - i * scale / 1.6) < Plot4.Width) && (OYY - 2 - (int)(j * scale - i * scale / 3) > 0) && (OYY - 2 - (int)(j * scale - i * scale / 3) < Plot4.Height))
                                        btmp3.SetPixel(OXX + 2 + (int)(ygr1 * scale - i * scale / 1.6), OYY - 2 - (int)(j * scale - i * scale / 3), pc);
                                }
                                if ((ygr2 >= 0) && (i > 0))
                                {
                                    if ((OXX + 2 + (int)(ygr2 * scale - i * scale / 1.6) > 0) && (OXX + 2 + (int)(ygr2 * scale - i * scale / 1.6) < Plot4.Width) && (OYY - 2 - (int)(j * scale - i * scale / 3) > 0) && (OYY - 2 - (int)(j * scale - i * scale / 3) < Plot4.Height))
                                        btmp3.SetPixel(OXX + 2 + (int)(ygr2 * scale - i * scale / 1.6), OYY - 2 - (int)(j * scale - i * scale / 3), pc);
                                }
                            }
                        }
                    }
                }
                #endregion

                #region if C != 0 front
                else if (C != 0)
                {
                    for (double i = -length; i < length; i += accuracy * 10)
                    {
                        for (double j = -length; j < length; j += accuracy * 10)
                        {
                            // Cz^2 + 2Gyz + 2Hxz + 2Rz = -(Ax^2 + By^2 + 2Fxy + 2Px + 2Qy + D)
                            // Cx^2 + z(2Gy + 2Hx + 2R) + (Ax^2 + By^2 + 2Fxy + 2Px + 2Qy + D) = 0
                            // Disc = (2Gy + 2Hx + 2R)*(2Gy + 2Hx + 2R) - 4*C*(Ax^2 + By^2 + 2Fxy + 2Px + 2Qy + D)
                            // if Disc >= 0
                            // z1 = (-(2Gy + 2Hx + 2R) + sqrt(Disc))/(2*C)
                            // z2 = (-(2Gy + 2Hx + 2R) - sqrt(Disc))/(2*C)
                            double Disc = ((2 * G * j + 2 * H * i + 2 * R) * (2 * G * j + 2 * H * i + 2 * R)) - (4 * C * (A * i * i + B * j * j + 2 * F * i * j + 2 * P * i + 2 * Q * j + D));
                            if (Disc >= 0)
                            {
                                zet1 = (-(2 * G * j + 2 * H * i + 2 * R) + Math.Sqrt(Disc)) / (2 * C);
                                zet2 = (-(2 * G * j + 2 * H * i + 2 * R) - Math.Sqrt(Disc)) / (2 * C);

                                if ((zet1 >= 0) && (i > 0))
                                {
                                    if ((OXX + 2 + (int)(j * scale - i * scale / 1.6) > 0) && (OXX + 2 + (int)(j * scale - i * scale / 1.6) < Plot4.Width) && (OYY - 2 - (int)(zet1 * scale - i * scale / 3) > 0) && (OYY - 2 - (int)(zet1 * scale - i * scale / 3) < Plot4.Height))
                                        btmp3.SetPixel(OXX + 2 + (int)(j * scale - i * scale / 1.6), OYY - 2 - (int)(zet1 * scale - i * scale / 3), pc);
                                }
                                if ((zet2 >= 0) && (i > 0))
                                {
                                    if ((OXX + 2 + (int)(j * scale - i * scale / 1.6) > 0) && (OXX + 2 + (int)(j * scale - i * scale / 1.6) < Plot4.Width) && (OYY - 2 - (int)(zet2 * scale - i * scale / 3) > 0) && (OYY - 2 - (int)(zet2 * scale - i * scale / 3) < Plot4.Height))
                                        btmp3.SetPixel(OXX + 2 + (int)(j * scale - i * scale / 1.6), OYY - 2 - (int)(zet2 * scale - i * scale / 3), pc);
                                }
                            }
                        }
                    }
                }
                #endregion

                #endregion

                #region Drawing 0, X, Y, Z
                String drawString = "Y";
                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, Plot3.Width - 20, OYY - 20);
                drawString = "Z";
                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OXX + 5, 13);
                drawString = "X";
                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, 25, Plot4.Height - 13);
                #endregion

                gr.Dispose();
                GC.Collect();
            }
            catch
            {
                return;
            }
        }
        #endregion

            #region Paint All
        private void PaintAll()
        {
            PaintFunction1();
            PaintFunction2();
            PaintFunction3();
            PaintFunction4();
        }
        #endregion

        #endregion

        #region Buttons

            #region Button Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter file = new StreamWriter("SOS_GE.cfg");
                file.WriteLine(A);
                file.WriteLine(B);
                file.WriteLine(C);
                file.WriteLine(2 * F);
                file.WriteLine(2 * G);
                file.WriteLine(2 * H);
                file.WriteLine(2 * P);
                file.WriteLine(2 * Q);
                file.WriteLine(2 * R);
                file.WriteLine(D);
                file.WriteLine(scale1);
                file.WriteLine(scale2);
                file.WriteLine(scale3);
                file.WriteLine(trackBar1.Value);
                file.WriteLine(trackBar2.Value);
                file.WriteLine(trackBar3.Value);
                file.WriteLine(Tick);
                file.WriteLine(MaxTrack);
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
            if ((textA.Text == "0") && (textB.Text == "0") && (textC.Text == "0") && (textF.Text == "0") && (textG.Text == "0") && (textH.Text == "0"))
                return;
            try
            {
                A = Convert.ToDouble(textA.Text);
                B = Convert.ToDouble(textB.Text);
                C = Convert.ToDouble(textC.Text);
                F = Convert.ToDouble(textF.Text) / 2.0;
                G = Convert.ToDouble(textG.Text) / 2.0;
                H = Convert.ToDouble(textH.Text) / 2.0;
                P = Convert.ToDouble(textP.Text) / 2.0;
                Q = Convert.ToDouble(textQ.Text) / 2.0;
                R = Convert.ToDouble(textR.Text) / 2.0;
                D = Convert.ToDouble(textD.Text);
                Tick = Convert.ToDouble(textTick.Text);
                MaxTrack = Convert.ToInt32(textMaxtrack.Text);
                trackBar1.Maximum = MaxTrack;
                trackBar1.Minimum = -MaxTrack;
                trackBar2.Maximum = MaxTrack;
                trackBar2.Minimum = -MaxTrack;
                trackBar3.Maximum = MaxTrack;
                trackBar3.Minimum = -MaxTrack;
            }
            catch
            {
                return;
            }
            PaintAll();
        }
        #endregion

        #endregion

        #region Draw Axes
        public void DrawAxes(int OXX, int OYY, Pen MainAxesPen, Graphics gr)
        {
            Point p1 = new Point(OXX, OYY); // z
            Point p2 = new Point(OXX, 0);
            gr.DrawLine(MainAxesPen, p1, p2);
            p1 = new Point(OXX, OYY); // y
            p2 = new Point(this.Width, OYY);
            gr.DrawLine(MainAxesPen, p1, p2);
            p1 = new Point(OXX, OYY); // x
            p2 = new Point(0, Plot4.Height);
            gr.DrawLine(MainAxesPen, p1, p2);
        }
        #endregion

        #region Misc

            #region Resize Form
        private void SOS_GE_Resize(object sender, EventArgs e)
        {
            Plot1.Width = panel1.Width / 2 - 20;
            Plot2.Width = Plot1.Width;
            panel1.Height = this.Height / 2 - 100;
            trackBar1.Location = new Point(panel1.Location.X, panel1.Height + 100);
            trackBar1.Width = Plot1.Width;
            trackBar2.Location = new Point(Plot2.Location.X + 210, panel1.Height + 100);
            trackBar2.Width = Plot2.Width;
            Plot3.Location = new Point(trackBar1.Location.X, trackBar1.Location.Y + 42);
            Plot3.Width = Plot1.Width;
            Plot3.Height = Plot1.Height;
            trackBar3.Location = new Point(panel1.Location.X, panel1.Height + Plot3.Height + 145);
            trackBar3.Width = Plot3.Width;
            Plot4.Location = new Point(trackBar2.Location.X, trackBar2.Location.Y + 42);
            Plot4.Width = Plot1.Width;
            Plot4.Height = Plot1.Height;

            OX = Plot1.Width / 2;
            OY = Plot1.Height / 2;
            PaintAll();
        }
        #endregion

            #region Mouse Wheel
        void m_MouseWheel1(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if ((scale1 == 1) || (scale1 == 7) || (scale1 == 4))
                    scale1 += 3;
                else
                    scale1 += 5;
            }
            else
            {
                if (scale1 > 10)
                    scale1 -= 5;
                else if ((scale1 == 10) || (scale1 == 7) || (scale1 == 4))
                    scale1 -= 3;
                else if (scale1 == 1)
                    return;
            }
            PaintFunction1();
        }
        void m_MouseWheel2(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if ((scale2 == 1) || (scale2 == 7) || (scale2 == 4))
                    scale2 += 3;
                else
                    scale2 += 5;
            }
            else
            {
                if (scale2 > 10)
                    scale2 -= 5;
                else if ((scale2 == 10) || (scale2 == 7) || (scale2 == 4))
                    scale2 -= 3;
                else if (scale2 == 1)
                    return;
            }
            PaintFunction2();
        }
        void m_MouseWheel3(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if ((scale3 == 1) || (scale3 == 7) || (scale3 == 4))
                    scale3 += 3;
                else
                    scale3 += 5;
            }
            else
            {
                if (scale3 > 10)
                    scale3 -= 5;
                else if ((scale3 == 10) || (scale3 == 7) || (scale3 == 4))
                    scale3 -= 3;
                else if (scale3 == 1)
                    return;
            }
            PaintFunction3();
        }
        void m_MouseWheel4(object sender, MouseEventArgs e)
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
            PaintFunction4();
        }
        #endregion

            #region TrackBars

                #region Trackbar 1
        private void trackBar1_Scroll(object sender, EventArgs e)
            {
                N1 = -Tick * trackBar1.Value;
                PaintFunction1();
            }
            #endregion

                #region Trackbar 2
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            N2 = -Tick * trackBar2.Value;
            PaintFunction2();
        }
        #endregion

                #region Trackbar 3
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            N3 = -Tick * trackBar3.Value;
            PaintFunction3();
        }
        #endregion

        #endregion

            #region Key Press
        private void Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == Convert.ToChar(",")) | (e.KeyChar == Convert.ToChar("-")) | e.KeyChar == '\b') return;
            else
                e.Handled = true;
        }
        private void txtMaxTrack_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | e.KeyChar == '\b') return;
            else
                e.Handled = true;
        }
        private void txtTick_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == Convert.ToChar(",")) | e.KeyChar == '\b') return;
            else
                e.Handled = true;
        }
        #endregion

            #region Accuracy Found
        private void AccuracyFound(int scale)
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
