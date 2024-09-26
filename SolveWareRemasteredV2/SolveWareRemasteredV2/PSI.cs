using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static SolveWareRemasteredV2.GlobalVars;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SolveWareRemasteredV2
{
    public partial class PSI : Form
    {
        public PSI()
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
        double A, B, C, F, G, H, P, Q, R, D;
        double I, J, K, N;
        double tau1, tau2, sigma, delta, k1, k2;
        double alpha, ksi, beta, gamma, tetta, lyambda;
        double Invariant3, Invariant2, Invariant1, K105;
        double angle, x0, y0;
        double accuracy = 0.01;
        int length = 500;
        bool checkCP, checkHN, checkG, checkA;
        String figure, result, surface;
        bool Ellipse;
        int OX = 869 / 2, OY = 510 / 2;
        int scale = 40;
        double Ox1, Ox2, Oy1, Oy2;
        double x, y, x1, x2, y1, y2, d;
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
            txtSurface_.ForeColor = tc;
            txtPlane_.ForeColor = tc;
            txtSection_.ForeColor = tc;
            txtX.ForeColor = tc;
            txtY.ForeColor = tc;
            txtZ.ForeColor = tc;
            txtXY.ForeColor = tc;
            txtYZ.ForeColor = tc;
            txtXZ.ForeColor = tc;
            txtXX.ForeColor = tc;
            txtYY.ForeColor = tc;
            txtZZ.ForeColor = tc;
            txtZero1.ForeColor = tc;
            txtZero2.ForeColor = tc;
            txtXXX.ForeColor = tc;
            txtYYY.ForeColor = tc;
            txtZZZ.ForeColor = tc;
            txtSurface.ForeColor = tc;
            txtFigure.ForeColor = tc;
            txtEllipse.ForeColor = tc;
            checkCrossingPoints.ForeColor = tc;
            checkHideNums.ForeColor = tc;
            checkGrid.ForeColor = tc;
            checkAround.ForeColor = tc;
            Oox.ForeColor = tc;
            Ooy.ForeColor = tc;
            Oxy.ForeColor = tc;
            txtAngle.ForeColor = tc;
            btnApply.ForeColor = tc;
            btnSave.ForeColor = tc;
            checkCrossingPoints.Checked = checkCP;
            checkHideNums.Checked = checkHN;
            checkGrid.Checked = checkG;
            checkAround.Checked = checkA;
        }
        #endregion

        #region Read From File
        private void ReadFromFile()
        {
            String line;
            int operation = 0;
            try
            {
                StreamReader file = new StreamReader("PSI.cfg");
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
                        fA.Text = line;
                    if (operation == 11)
                        fB.Text = line;
                    if (operation == 12)
                        fC.Text = line;
                    if (operation == 13)
                        fD.Text = line;
                    if (operation == 14)
                    {
                        if (line == "1")
                            checkCP = true;
                        else
                            checkCP = false;
                    }
                    if (operation == 15)
                    {
                        if (line == "1")
                            checkHN = true;
                        else
                            checkHN = false;
                    }
                    if (operation == 16)
                    {
                        if (line == "1")
                            checkG = true;
                        else
                            checkG = false;
                    }
                    if (operation == 17)
                    {
                        if (line == "1")
                            checkA = true;
                        else
                            checkA = false;
                    }
                    if (operation == 18)
                        scale = Convert.ToInt32(line);
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
                I = Convert.ToDouble(fA.Text);
                J = Convert.ToDouble(fB.Text);
                K = Convert.ToDouble(fC.Text);
                N = Convert.ToDouble(fD.Text);
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
                I = Convert.ToDouble(fA.Text);
                J = Convert.ToDouble(fB.Text);
                K = Convert.ToDouble(fC.Text);
                N = Convert.ToDouble(fD.Text);
            }
            catch
            {
                return;
            }
            if ((A == 0) && (B == 0) && (C == 0) && (F == 0) && (G == 0) && (H == 0))
                return;
            if ((I == 0) && (J == 0) && (K == 0))
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
                gamma = (2 * I * I * Q) - (2 * F * I * N) - (2 * I * J * P) + (2 * A * J * N);//
                tetta = (2 * I * I * R) - (2 * H * I * N) + (2 * A * K * N) - (2 * I * K * P);//
                ksi = (2 * G * I * I) - (2 * H * I * J) - (2 * F * I * K) + (2 * A * J * K);//
                lyambda = (D * I * I) + (A * N * N) - (2 * I * N * P);//
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
                gamma = (2 * N * I * B) - (2 * F * J * N) - (2 * I * J * Q) + (2 * P * J * J);//
                tetta = (2 * J * J * R) - (2 * G * J * N) + (2 * B * K * N) - (2 * J * K * Q);//
                ksi = (2 * K * I * B) - (2 * F * K * J) - (2 * G * I * J) + (2 * J * J * H);//
                lyambda = (B * N * N) + (D * J * J) - (2 * J * N * Q);//
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
                gamma = (2 * N * I * C) - (2 * H * K * N) - (2 * I * K * R) + (2 * P * K * K);//
                tetta = (2 * K * K * Q) - (2 * G * K * N) + (2 * C * J * N) - (2 * J * K * R);//
                ksi = (2 * C * I * J) - (2 * G * K * I) - (2 * H * K * J) + (2 * K * K * F);//
                lyambda = (C * N * N) + (D * K * K) - (2 * K * N * R);//
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
            // around function
            if (checkA)
            {
                for (int u = 10000; u > 1; u--)
                {
                    while ((alpha / u == (int)(alpha / u)) && (beta / u == (int)(beta / u)) && ((2 * ksi) / u == (int)(2 * ksi / u)) && ((2 * gamma) / u == (int)(2 * gamma / u)) && ((2 * tetta) / u == (int)(2 * tetta / u)) && (lyambda / u == (int)(lyambda / u)))
                    {
                        alpha = alpha / u;
                        beta = beta / u;
                        gamma = gamma / u;
                        tetta = tetta / u;
                        ksi = ksi / u;
                        lyambda = lyambda / u;
                    }
                }
            }
            // change signs
            if ((alpha < 0) && (beta < 0))
            {
                alpha = -alpha;
                beta = -beta;
                ksi = -ksi;
                gamma = -gamma;
                tetta = -tetta;
                lyambda = -lyambda;
            }

            //if (Math.Abs(alpha - beta) == 0)
                //angle = 0;

            result = "";
            int i = 0;
            if (alpha != 0)
            {
                if (alpha != 1)
                {
                    if (alpha == -1)
                        result += "-";
                    else
                        result += Convert.ToString(alpha);
                }
                if (I != 0)
                    result += "y^2";
                else if (J != 0)
                    result += "x^2";
                else if (K != 0)
                    result += "x^2";
                i++;
            }
            if (ksi != 0)
            {
                if ((i != 0) && (ksi > 0))
                    result += "+";
                if (2 * ksi != 1)
                {
                    if (2 * ksi == -1)
                        result += "-";
                    else
                        result += Convert.ToString(2 * ksi);
                }
                if (I != 0)
                    result += "yz";
                else if (J != 0)
                    result += "xz";
                else if (K != 0)
                    result += "xy";
                i++;
            }
            if (beta != 0)
            {
                if ((i != 0) && (beta > 0))
                    result += "+";
                if (beta != 1)
                {
                    if (beta == -1)
                        result += "-";
                    else
                    result += Convert.ToString(beta);
                }
                if (I != 0)
                    result += "z^2";
                else if (J != 0)
                    result += "z^2";
                else if (K != 0)
                    result += "y^2";
                i++;
            }
            if (gamma != 0)
            {
                if ((i != 0) && (gamma > 0))
                    result += "+";
                if (2 * gamma != 1)
                {
                    if (2 * gamma == -1)
                        result += "-";
                    else
                        result += Convert.ToString(2 * gamma);
                }
                if (I != 0)
                    result += "y";
                else if (J != 0)
                    result += "x";
                else if (K != 0)
                    result += "x";
                i++;
            }
            if (tetta != 0)
            {
                if ((i != 0) && (tetta > 0))
                    result += "+";
                if (2 * tetta != 1)
                {
                    if (2 * tetta == -1)
                        result += "-";
                    else
                        result += Convert.ToString(2 * tetta);
                }
                if (I != 0)
                    result += "z";
                else if (J != 0)
                    result += "z";
                else if (K != 0)
                    result += "y";
                i++;
            }
            if (lyambda != 0)
            {
                if (lyambda > 0)
                    result += "+";
                result += Convert.ToString(lyambda);
            }
            result += "=0";
            textResult.Text = result;
            Invariant1 = alpha + beta; // Invariant1
            Invariant2 = alpha * beta - (ksi * ksi); // Invariant2
            Invariant3 = (alpha * beta * lyambda) + (ksi * tetta * gamma) + (ksi * tetta * gamma) - ((gamma * gamma * beta) + (tetta * tetta * alpha) + (ksi * ksi * lyambda)); // Invariant3
            K105 = ((alpha * lyambda) - (gamma * gamma)) + ((beta * lyambda) - (tetta * tetta)); // K(B)
            DetermineFigure();
            DetermineSurface();
        }

        #endregion

        #region Determine Figure
        private void DetermineFigure()
        {
            if (Invariant2 != 0)
            {
                if (Invariant2 > 0)
                {
                    if (Invariant3 < 0)
                    {
                        figure = "Ellipse";
                        Ellipse = true;
                    }
                    else if (Invariant3 == 0)
                    {
                        figure = "Point (a pair of imaginary intersecting lines)";
                        Ellipse = false;
                    }
                    else if (Invariant3 > 0)
                    {
                        figure = "Imaginary ellipse";
                        Ellipse = false;
                    }
                }
                if (Invariant2 < 0)
                {
                    if (Invariant3 == 0)
                    {
                        figure = "A pair of intersecting straight lines";
                        Ellipse = false;
                    }
                    else if (Invariant3 != 0)
                    {
                        figure = "Hyperbola";
                        Ellipse = false;
                    }
                }
            }
            else if (Invariant2 == 0)
            {
                if (Invariant3 != 0)
                {
                    figure = "Parabola";
                    Ellipse = false;
                }
                else if (Invariant3 == 0)
                {
                    if (K105 < 0)
                    {
                        figure = "A pair of parallel straight lines";
                        Ellipse = false;
                    }
                    else if (K105 == 0)
                    {
                        figure = "Straight";
                        Ellipse = false;
                    }
                    else if (K105 > 0)
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
                double g = 2.0 / (Math.Sqrt(4 * alpha * beta - (2 * ksi) * (2 * ksi)) / (-(Invariant3 / Invariant2)));
                if (g != 1)
                    txtEllipse.Text += Convert.ToString(g) + " 𝞹";
                else
                    txtEllipse.Text += " 𝞹";
            }
            else
                txtEllipse.Text = "";
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
            TextFunction();
        }
        #endregion

        #region Buttons
         
        #region Button Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter file = new StreamWriter("PSI.cfg");
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
                file.WriteLine(I);
                file.WriteLine(J);
                file.WriteLine(K);
                file.WriteLine(N);

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

                if (checkA)
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
                I = Convert.ToDouble(fA.Text);
                J = Convert.ToDouble(fB.Text);
                K = Convert.ToDouble(fC.Text);
                N = Convert.ToDouble(fD.Text);
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
            d = Math.Pow(2 * tetta, 2) - (4 * (beta + 0.0000000001) * lyambda);
            Oy1 = (-1.0 * (2 * tetta) + Math.Sqrt(d)) / (2 * (beta + 0.0000000001));
            Oy2 = (-1.0 * (2 * tetta) - Math.Sqrt(d)) / (2 * (beta + 0.0000000001));
            // Crossing w/ a horizontal axe
            d = Math.Pow(2 * gamma, 2) - (4 * (alpha + 0.0000000001) * lyambda);
            Ox1 = (-1.0 * (2 * gamma) + Math.Sqrt(d)) / (2 * (alpha + 0.0000000001));
            Ox2 = (-1.0 * (2 * gamma) - Math.Sqrt(d)) / (2 * (alpha + 0.0000000001));

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
            Ooy.Text = "⋂ Oy(" + Math.Round(Oy1, 3) + "; " + Math.Round(Oy2, 3) + ")    "; // ⋂ OX
            Oxy.Text = "O(" + Math.Round(x0, 3) + "; " + Math.Round(y0, 3) + ")    "; // O(x, y)
            txtAngle.Text = "Angle: " + (float)(angle * 180.0 / Math.PI) + "°     "; // Angle

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

                    #region New Axes
                    if (figure != "Parabola")
                    {
                        if (x0 != 0)
                        {
                            p1 = new Point(OX + (int)(x0 * scale), 0);
                            p2 = new Point(OX + (int)(x0 * scale), 100 * OY);
                            gr.DrawLine(NewAxesPen, p1, p2);
                        }
                        if (y0 != 0)
                        {
                            p1 = new Point(0, OY - (int)(y0 * scale));
                            p2 = new Point(100 * OX + (int)(x0 * scale), OY - (int)(y0 * scale));
                            gr.DrawLine(NewAxesPen, p1, p2);
                        }
                    }
                    #endregion

                    #region Drawing 0, X, Y
                    String drawString = "0";
                    gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 11, OY);
                    if (I != 0)
                    {
                        drawString = "Y";
                        gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, Plot.Width - 20, OY - 20);
                        drawString = "Z";
                        gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX + 5, 13);
                    }
                    else if (J != 0)
                    {
                        drawString = "X";
                        gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, Plot.Width - 20, OY - 20);
                        drawString = "Z";
                        gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX + 5, 13);
                    }
                    else if (K != 0)
                    {
                        drawString = "X";
                        gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, Plot.Width - 20, OY - 20);
                        drawString = "Y";
                        gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX + 5, 13);
                    }
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

                    #region Rotated Axes
                    if ((ksi != 0) && (figure != "Parabola"))
                    {
                        double m1, m2, n1, n2;

                        double XY2 = -Plot.Width;
                        double XY1 = 0;
                        m1 = XY1 * Math.Cos(angle) - XY2 * Math.Sin(angle); // rotated x0
                        m2 = XY1 * Math.Sin(angle) + XY2 * Math.Cos(angle); // rotated y0
                        XY2 = Plot.Width;
                        n1 = XY1 * Math.Cos(angle) - XY2 * Math.Sin(angle); // rotated x0
                        n2 = XY1 * Math.Sin(angle) + XY2 * Math.Cos(angle); // rotated y0
                        p1 = new Point(OX + (int)(x0 * scale) + (int)(m1 * scale), OY - (int)(y0 * scale) - (int)(m2 * scale));
                        p2 = new Point(OX + (int)(x0 * scale) + (int)(n1 * scale), OY - (int)(y0 * scale) - (int)(n2 * scale));
                        gr.DrawLine(RotatedAxesPen, p1, p2);

                        XY1 = -Plot.Width;
                        XY2 = 0;
                        m1 = XY1 * Math.Cos(angle) - XY2 * Math.Sin(angle); // rotated x0
                        m2 = XY1 * Math.Sin(angle) + XY2 * Math.Cos(angle); // rotated y0
                        XY1 = Plot.Width;
                        n1 = XY1 * Math.Cos(angle) - XY2 * Math.Sin(angle); // rotated x0
                        n2 = XY1 * Math.Sin(angle) + XY2 * Math.Cos(angle); // rotated y0
                        p1 = new Point(OX + (int)(x0 * scale) + (int)(m1 * scale), OY - (int)(y0 * scale) - (int)(m2 * scale));
                        p2 = new Point(OX + (int)(x0 * scale) + (int)(n1 * scale), OY - (int)(y0 * scale) - (int)(n2 * scale));
                        gr.DrawLine(RotatedAxesPen, p1, p2);
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
                                if ((OX + (int)(x1 * scale) > 0) && (OX + (int)(x1 * scale) < Plot.Width) && (OY - (int)(y * scale) > 0) && (OY - (int)(y * scale) < Plot.Height))
                                    btmp.SetPixel(OX + (int)(x1 * scale), OY - (int)(y * scale), pc);
                                if ((OX + (int)(x2 * scale) > 0) && (OX + (int)(x2 * scale) < Plot.Width) && (OY - (int)(y * scale) > 0) && (OY - (int)(y * scale) < Plot.Height))
                                    btmp.SetPixel(OX + (int)(x2 * scale), OY - (int)(y * scale), pc);
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
                                if ((OX + (int)(x * scale) > 0) && (OX + (int)(x * scale) < Plot.Width) && (OY - (int)(y1 * scale) > 0) && (OY - (int)(y1 * scale) < Plot.Height))
                                    btmp.SetPixel(OX + (int)(x * scale), OY - (int)(y1 * scale), pc);
                                if ((OX + (int)(x * scale) > 0) && (OX + (int)(x * scale) < Plot.Width) && (OY - (int)(y2 * scale) > 0) && (OY - (int)(y2 * scale) < Plot.Height))
                                    btmp.SetPixel(OX + (int)(x * scale), OY - (int)(y2 * scale), pc);
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
                                    if ((OX + (int)(x * scale) > 0) && (OX + (int)(x * scale) < Plot.Width) && (OY - (int)(y1 * scale) > 0) && (OY - (int)(y1 * scale) < Plot.Height))
                                        btmp.SetPixel(OX + (int)(x * scale), OY - (int)(y1 * scale), pc);
                                }
                                if ((x + accuracy > x0) && (x - accuracy < x0))
                                {
                                    x += accuracy * 10;
                                }
                                if (x > x0)
                                {
                                    if ((OX + (int)(x * scale) > 0) && (OX + (int)(x * scale) < Plot.Width) && (OY - (int)(y1 * scale) > 0) && (OY - (int)(y1 * scale) < Plot.Height))
                                        btmp.SetPixel(OX + (int)(x * scale), OY - (int)(y1 * scale), pc);
                                }
                                x += accuracy;
                            }
                            else
                            {
                                x1 = (-lyambda - 2 * tetta * x) / (2 * ksi * x + 2 * gamma);
                                if (x < y0)
                                {
                                    if ((OX + (int)(x1 * scale) > 0) && (OX + (int)(x1 * scale) < Plot.Width) && (OY - (int)(x * scale) > 0) && (OY - (int)(x * scale) < Plot.Height))
                                        btmp.SetPixel(OX + (int)(x1 * scale), OY - (int)(x * scale), pc);
                                }
                                if ((x + accuracy > y0) && (x - accuracy < y0))
                                {
                                    x += accuracy * 10;
                                }
                                if (x > y0)
                                {
                                    if ((OX + (int)(x1 * scale) > 0) && (OX + (int)(x1 * scale) < Plot.Width) && (OY - (int)(x * scale) > 0) && (OY - (int)(x * scale) < Plot.Height))
                                        btmp.SetPixel(OX + (int)(x1 * scale), OY - (int)(x * scale), pc);
                                }
                                x += accuracy;
                            }
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
        private void PSI_Resize(object sender, EventArgs e)
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

                #region CheckBox Of Reduce
        private void checkAround_CheckedChanged(object sender, EventArgs e)
        {
            checkA = checkAround.Checked;
            CalculateFunction();
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
