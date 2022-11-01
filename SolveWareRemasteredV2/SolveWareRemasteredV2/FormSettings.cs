using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static SolveWareRemasteredV2.GlobalVars;

namespace SolveWareRemasteredV2
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            CustomDesign();
            pbColors.MouseClick += new MouseEventHandler(mouseClick1);
        }

        #region Vars
        bool btnMBC = false;
        bool btnSMBC = false;
        bool btnABC = false;
        bool btnTC = false;

        bool btnPBC = false;
        bool btnMAC = false;
        bool btnNAC = false;
        bool btnRAC = false;
        bool btnGC = false;
        bool btnPC = false;
        bool btnCPC = false;
        bool btnNC = false;

        int colors = 1;

        Color MBC = mbc;
        Color SMBC = smbc;
        Color ABC = abc;
        Color TC = tc;

        Color PBC = pbc;
        Color MAC = mac;
        Color NAC = nac;
        Color RAC = rac;
        Color GC = gc;
        Color PC = pc;
        Color CPC = cpc;
        Color NC = nc;
        #endregion

        #region Form Resize
        private void FormSettings_Resize(object sender, EventArgs e)
        {
            System.GC.Collect();
        }
        #endregion

        #region GetPixel
        void mouseClick1(object sender, MouseEventArgs e)
        {
            #region Left Mouse Button
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    Bitmap btmp = new Bitmap(pbColors.Image, pbColors.Image.Size.Width, pbColors.Image.Size.Height);
                    btmp.SetResolution(pbColors.Image.HorizontalResolution, pbColors.Image.VerticalResolution);

                    double xratio = 1.0 * pbColors.Width / pbColors.Image.Width;
                    double yratio = 1.0 * pbColors.Height / pbColors.Image.Height;
                    int x = (int)(e.X / xratio);
                    int y = (int)(e.Y / yratio);

                    Color color = btmp.GetPixel(x, y);

                    #region Application Settings
                    if (btnMBC)
                    {
                        btnMenuBackColor.ForeColor = color;
                        btnMenuBackColor.FlatAppearance.BorderSize = 10;
                        MBC = color;
                        btnMBC = false;
                    }
                    if (btnSMBC)
                    {
                        btnSubMenuBackColor.ForeColor = color;
                        btnSubMenuBackColor.FlatAppearance.BorderSize = 10;
                        SMBC = color;
                        btnSMBC = false;
                    }
                    if (btnABC)
                    {
                        btnAppColor.ForeColor = color;
                        btnAppColor.FlatAppearance.BorderSize = 10;
                        ABC = color;
                        btnABC = false;
                    }
                    if (btnTC)
                    {
                        btnTextColor.ForeColor = color;
                        btnTextColor.FlatAppearance.BorderSize = 10;
                        TC = color;
                        btnTC = false;
                    }
                    #endregion

                    #region Plot Settings
                    if (btnPBC)
                    {
                        btnPlotBackColor.ForeColor = color;
                        btnPlotBackColor.FlatAppearance.BorderSize = 10;
                        PBC = color;
                        btnPBC = false;
                    }
                    if (btnMAC)
                    {
                        btnMainAxesColor.ForeColor = color;
                        btnMainAxesColor.FlatAppearance.BorderSize = 10;
                        MAC = color;
                        btnMAC = false;
                    }
                    if (btnNAC)
                    {
                        btnNewAxesColor.ForeColor = color;
                        btnNewAxesColor.FlatAppearance.BorderSize = 10;
                        NAC = color;
                        btnNAC = false;
                    }
                    if (btnRAC)
                    {
                        btnRotatedAxesColor.ForeColor = color;
                        btnRotatedAxesColor.FlatAppearance.BorderSize = 10;
                        RAC = color;
                        btnRAC = false;
                    }
                    if (btnGC)
                    {
                        btnGridColor.ForeColor = color;
                        btnGridColor.FlatAppearance.BorderSize = 10;
                        GC = color;
                        btnGC = false;
                    }
                    if (btnPC)
                    {
                        btnPlotColor.ForeColor = color;
                        btnPlotColor.FlatAppearance.BorderSize = 10;
                        PC = color;
                        btnPC = false;
                    }
                    if (btnCPC)
                    {
                        btnCrossingPointsColor.ForeColor = color;
                        btnCrossingPointsColor.FlatAppearance.BorderSize = 10;
                        CPC = color;
                        btnCPC = false;
                    }
                    if (btnNC)
                    {
                        btnNumsColor.ForeColor = color;
                        btnNumsColor.FlatAppearance.BorderSize = 10;
                        NC = color;
                        btnNC = false;
                    }
                    #endregion
                }
            }
            catch
            {
                return;
            }
            #endregion

            #region Right Mouse Button
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    switch (colors)
                    {
                        case 0: { pbColors.Image = Properties.Resources.pal3; colors = 1; } break;
                        case 1: { pbColors.Image = Properties.Resources.pal3_reversed; colors = 2; } break;
                        case 2: { pbColors.Image = Properties.Resources.pal3_001; colors = 3; } break;
                        case 3: { pbColors.Image = Properties.Resources.pal3_011; colors = 4; } break;
                        case 4: { pbColors.Image = Properties.Resources.pal3_100; colors = 5; } break;
                        case 5: { pbColors.Image = Properties.Resources.pal3_101; colors = 6; } break;
                        case 6: { pbColors.Image = Properties.Resources.pal3_110; colors = 0; } break;

                        default: break;
                    }
                    System.GC.Collect();
                }
            }
            catch
            {
                return;
            }
            #endregion
        }
        #endregion

        #region Color Buttons
        private void btnMenuBackColor_Click(object sender, EventArgs e)
        {
            if (!btnMBC)
            {
                btnMBC = true;
                btnMenuBackColor.FlatAppearance.BorderSize = 1;
            }
            else
            {
                btnMBC = false;
                btnMenuBackColor.FlatAppearance.BorderSize = 10;
            }
        }
        private void btnSubMenuBackColor_Click(object sender, EventArgs e)
        {
            if (!btnSMBC)
            {
                btnSMBC = true;
                btnSubMenuBackColor.FlatAppearance.BorderSize = 1;
            }
            else
            {
                btnSMBC = false;
                btnSubMenuBackColor.FlatAppearance.BorderSize = 10;
            }
        }

        private void btnAppColor_Click(object sender, EventArgs e)
        {
            if (!btnABC)
            {
                btnABC = true;
                btnAppColor.FlatAppearance.BorderSize = 1;
            }
            else
            {
                btnABC = false;
                btnAppColor.FlatAppearance.BorderSize = 10;
            }
        }
        private void btnTextColor_Click(object sender, EventArgs e)
        {
            if (!btnTC)
            {
                btnTC = true;
                btnTextColor.FlatAppearance.BorderSize = 1;
            }
            else
            {
                btnTC = false;
                btnTextColor.FlatAppearance.BorderSize = 10;
            }
        }

        private void btnPlotBackColor_Click(object sender, EventArgs e)
        {
            if (!btnPBC)
            {
                btnPBC = true;
                btnPlotBackColor.FlatAppearance.BorderSize = 1;
            }
            else
            {
                btnPBC = false;
                btnPlotBackColor.FlatAppearance.BorderSize = 10;
            }
        }

        private void btnMainAxesColor_Click(object sender, EventArgs e)
        {
            if (!btnMAC)
            {
                btnMAC = true;
                btnMainAxesColor.FlatAppearance.BorderSize = 1;
            }
            else
            {
                btnMAC = false;
                btnMainAxesColor.FlatAppearance.BorderSize = 10;
            }
        }

        private void btnNewAxesColor_Click(object sender, EventArgs e)
        {
            if (!btnNAC)
            {
                btnNAC = true;
                btnNewAxesColor.FlatAppearance.BorderSize = 1;
            }
            else
            {
                btnNAC = false;
                btnNewAxesColor.FlatAppearance.BorderSize = 10;
            }
        }

        private void btnRotatedAxesColor_Click(object sender, EventArgs e)
        {
            if (!btnRAC)
            {
                btnRAC = true;
                btnRotatedAxesColor.FlatAppearance.BorderSize = 1;
            }
            else
            {
                btnRAC = false;
                btnRotatedAxesColor.FlatAppearance.BorderSize = 10;
            }
        }

        private void btnGridColor_Click(object sender, EventArgs e)
        {
            if (!btnGC)
            {
                btnGC = true;
                btnGridColor.FlatAppearance.BorderSize = 1;
            }
            else
            {
                btnGC = false;
                btnGridColor.FlatAppearance.BorderSize = 10;
            }
        }

        private void btnPlotColor_Click(object sender, EventArgs e)
        {
            if (!btnPC)
            {
                btnPC = true;
                btnPlotColor.FlatAppearance.BorderSize = 1;
            }
            else
            {
                btnPC = false;
                btnPlotColor.FlatAppearance.BorderSize = 10;
            }
        }

        private void btnCrossingPointsColor_Click(object sender, EventArgs e)
        {
            if (!btnCPC)
            {
                btnCPC = true;
                btnCrossingPointsColor.FlatAppearance.BorderSize = 1;
            }
            else
            {
                btnCPC = false;
                btnCrossingPointsColor.FlatAppearance.BorderSize = 10;
            }
        }

        private void btnNumsColor_Click(object sender, EventArgs e)
        {
            if (!btnNC)
            {
                btnNC = true;
                btnNumsColor.FlatAppearance.BorderSize = 1;
            }
            else
            {
                btnNC = false;
                btnNumsColor.FlatAppearance.BorderSize = 10;
            }
        }
        #endregion

        #region Custom Design
        private void CustomDesign()
        {
            try
            {
                btnMenuBackColor.ForeColor = mbc;
                btnSubMenuBackColor.ForeColor = smbc;
                btnAppColor.ForeColor = abc;
                btnTextColor.ForeColor = tc;

                btnPlotBackColor.ForeColor = pbc;
                btnMainAxesColor.ForeColor = mac;
                btnNewAxesColor.ForeColor = nac;
                btnRotatedAxesColor.ForeColor = rac;
                btnGridColor.ForeColor = gc;
                btnPlotColor.ForeColor = pc;
                btnCrossingPointsColor.ForeColor = cpc;
                btnNumsColor.ForeColor = nc;

                this.BackColor = abc;
                txtApplicationSettings.ForeColor = tc;
                txtMenuBackColor.ForeColor = tc;
                txtSubMenuBackColor.ForeColor = tc;
                txtAppColor.ForeColor = tc;
                txtTextColor.ForeColor = tc;
                txtPlotSettings.ForeColor = tc;
                txtPlotBackColor.ForeColor = tc;
                txtMainAxesColor.ForeColor = tc;
                txtNewAxesColor.ForeColor = tc;
                txtRotatedAxesColor.ForeColor = tc;
                txtGridColor.ForeColor = tc;
                txtPlotColor.ForeColor = tc;
                txtCrossingPointsColor.ForeColor = tc;
                txtNumsColor.ForeColor = tc;

                btnSave.ForeColor = tc;
                btnReset.ForeColor = tc;
            }
            catch
            {
                return;
            }
        }
        #endregion

        #region Button Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                mbc = MBC;
                smbc = SMBC;
                abc = ABC;
                tc = TC;

                pbc = PBC;
                mac = MAC;
                nac = NAC;
                rac = RAC;
                gc = GC;
                pc = PC;
                cpc = CPC;
                nc = NC;

                StreamWriter file = new StreamWriter("Settings.cfg");
                file.Write(mbc.A);
                file.Write(";");
                file.Write(mbc.R);
                file.Write(";");
                file.Write(mbc.G);
                file.Write(";");
                file.Write(mbc.B);
                file.WriteLine();

                file.Write(smbc.A);
                file.Write(";");
                file.Write(smbc.R);
                file.Write(";");
                file.Write(smbc.G);
                file.Write(";");
                file.Write(smbc.B);
                file.WriteLine();

                file.Write(abc.A);
                file.Write(";");
                file.Write(abc.R);
                file.Write(";");
                file.Write(abc.G);
                file.Write(";");
                file.Write(abc.B);
                file.WriteLine();

                file.Write(tc.A);
                file.Write(";");
                file.Write(tc.R);
                file.Write(";");
                file.Write(tc.G);
                file.Write(";");
                file.Write(tc.B);
                file.WriteLine();

                file.Write(pbc.A);
                file.Write(";");
                file.Write(pbc.R);
                file.Write(";");
                file.Write(pbc.G);
                file.Write(";");
                file.Write(pbc.B);
                file.WriteLine();

                file.Write(mac.A);
                file.Write(";");
                file.Write(mac.R);
                file.Write(";");
                file.Write(mac.G);
                file.Write(";");
                file.Write(mac.B);
                file.WriteLine();

                file.Write(nac.A);
                file.Write(";");
                file.Write(nac.R);
                file.Write(";");
                file.Write(nac.G);
                file.Write(";");
                file.Write(nac.B);
                file.WriteLine();

                file.Write(rac.A);
                file.Write(";");
                file.Write(rac.R);
                file.Write(";");
                file.Write(rac.G);
                file.Write(";");
                file.Write(rac.B);
                file.WriteLine();

                file.Write(gc.A);
                file.Write(";");
                file.Write(gc.R);
                file.Write(";");
                file.Write(gc.G);
                file.Write(";");
                file.Write(gc.B);
                file.WriteLine();

                file.Write(pc.A);
                file.Write(";");
                file.Write(pc.R);
                file.Write(";");
                file.Write(pc.G);
                file.Write(";");
                file.Write(pc.B);
                file.WriteLine();

                file.Write(cpc.A);
                file.Write(";");
                file.Write(cpc.R);
                file.Write(";");
                file.Write(cpc.G);
                file.Write(";");
                file.Write(cpc.B);
                file.WriteLine();

                file.Write(nc.A);
                file.Write(";");
                file.Write(nc.R);
                file.Write(";");
                file.Write(nc.G);
                file.Write(";");
                file.Write(nc.B);
                file.WriteLine();

                file.Close();
            }
            catch
            {
                return;
            }

            CustomDesign();
            this.Close();
            System.GC.Collect();
        }
        #endregion

        #region Button Reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            MBC = Color.FromArgb(15, 15, 15);
            SMBC = Color.FromArgb(140, 15, 15);
            ABC = Color.FromArgb(20, 20, 20);
            TC = Color.FromArgb(255, 255, 255);
            PBC = Color.FromArgb(20, 20, 20);
            MAC = Color.FromArgb(15, 15, 140);
            NAC = Color.FromArgb(15, 140, 15);
            RAC = Color.FromArgb(255, 255, 255);
            GC = Color.FromArgb(70, 50, 15);
            PC = Color.FromArgb(255, 255, 255);
            CPC = Color.FromArgb(140, 15, 15);
            NC = Color.FromArgb(255, 255, 255);

            CustomDesign();
            btnSave_Click(sender, e);
            /*
            btnMBC = false;
            btnSMBC = false;
            btnABC = false;
            btnTC = false;

            btnPBC = false;
            btnMAC = false;
            btnNAC = false;
            btnRAC = false;
            btnGC = false;
            btnPC = false;
            btnCPC = false;
            btnNC = false;

            btnMenuBackColor.FlatAppearance.BorderSize = 10;
            btnSubMenuBackColor.FlatAppearance.BorderSize = 10;
            btnAppColor.FlatAppearance.BorderSize = 10;
            btnTextColor.FlatAppearance.BorderSize = 10;

            btnPlotBackColor.FlatAppearance.BorderSize = 10;
            btnMainAxesColor.FlatAppearance.BorderSize = 10;
            btnNewAxesColor.FlatAppearance.BorderSize = 10;
            btnRotatedAxesColor.FlatAppearance.BorderSize = 10;
            btnGridColor.FlatAppearance.BorderSize = 10;
            btnPlotColor.FlatAppearance.BorderSize = 10;
            btnCrossingPointsColor.FlatAppearance.BorderSize = 10;
            btnNumsColor.FlatAppearance.BorderSize = 10;*/
        }
        #endregion
    }
}
