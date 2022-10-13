using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using static SolveWareRemasteredV2.GlobalVars;

namespace SolveWareRemasteredV2
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            ReadFromFile();
            CustomDesign();
        }

        #region Custom Design
        private void CustomDesign()
        {
            pnlSOC.Visible = false;
            pnlSOS.Visible = false;
            pnlSubForm.BackColor = abc;
            pnlMenu.BackColor = mbc;
            pnlSOC.BackColor = smbc;
            pnlSOS.BackColor = smbc;

            btnAbout.ForeColor = tc;
            btnSettings.ForeColor = tc;
            btnPSI.ForeColor = tc;
            btnSOC.ForeColor = tc;
            btnSOC_CE.ForeColor = tc;
            btnSOC_GE.ForeColor = tc;
            btnSOS.ForeColor = tc;
            btnSOS_CE.ForeColor = tc;
            btnSOS_GE.ForeColor = tc;
        }
        #endregion

        #region Open SubForm
        private new Form ActiveForm = null;
        private void OpenSubForm(Form SubForm)
        {
            if (ActiveForm != null)
                ActiveForm.Close();
            ActiveForm = SubForm;
            SubForm.TopLevel = false;
            SubForm.FormBorderStyle = FormBorderStyle.None;
            SubForm.Dock = DockStyle.Fill;
            pnlSubForm.Controls.Add(SubForm);
            pnlSubForm.Tag = SubForm;
            SubForm.BringToFront();
            SubForm.Show();
            SubForm.FormClosed += form_closed;
        }
        private void form_closed(object sender, EventArgs e)
        {
            CustomDesign();
        }
        #endregion

        #region Sub Panels

        #region Hide SubMenu
        private void HideSubMenu()
        {
            if (pnlSOC.Visible == true)
                pnlSOC.Visible = false;
            if (pnlSOS.Visible == true)
                pnlSOS.Visible = false;
        }
        #endregion

            #region Show SubMenu
        private void ShowSubMenu(Panel SubMenu)
        {
            if (SubMenu.Visible == false)
            {
                HideSubMenu();
                SubMenu.Visible = true;
            }
            else
                SubMenu.Visible = false;
        }
        #endregion

        #endregion

        #region Buttons

            #region Second Order Curves
        private void btnSOC_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlSOC);
        }
        private void btnSOC_CE_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
                ActiveForm.Close();
            OpenSubForm(new SOC_CE());
            HideSubMenu();
        }
        private void btnSOC_GE_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
                ActiveForm.Close();
            OpenSubForm(new SOC_GE());
            HideSubMenu();
        }
        #endregion

            #region Surfaces Of The Second Order
        private void btnSOS_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlSOS);
        }
        private void btnSOS_CE_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
                ActiveForm.Close();
            OpenSubForm(new SOS_CE());
            HideSubMenu();
        }
        private void btnSOS_GE_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
                ActiveForm.Close();
            OpenSubForm(new SOS_GE());
            HideSubMenu();
        }
        #endregion

            #region Plane-Surface Intersection
        private void btnPSI_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
                ActiveForm.Close();
            OpenSubForm(new PSI());
            HideSubMenu();
        }
        #endregion

            #region Settings
        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
                ActiveForm.Close();
            OpenSubForm(new FormSettings());
            HideSubMenu();
        }
        #endregion

            #region About
        private void btnAbout_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
                ActiveForm.Close();
            OpenSubForm(new FormAbout());
            HideSubMenu();
        }
        #endregion

            #region SWR
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
                ActiveForm.Close();
            HideSubMenu();
        }
        #endregion

        #endregion

        #region Set Color
        private Color SetColor(String line)
        {
            bool first = true;
            bool second = false;
            bool third = false;
            bool fourth = false;
            string first_str = "";
            string second_str = "";
            string third_str = "";
            string fourth_str = "";
            for (int i = 0; i < line.Length; i++)
            {
                if (first)
                {
                    if (line[i] != ';')
                    {
                        first_str += line[i];
                    }
                    else if (line[i] == ';')
                    {
                        first = false;
                        second = true;
                        i++;
                    }
                }
                if (second)
                {
                    if (line[i] != ';')
                    {
                        second_str += line[i];
                    }
                    else if (line[i] == ';')
                    {
                        second = false;
                        third = true;
                        i++;
                    }
                }
                if (third)
                {
                    if (line[i] != ';')
                    {
                        third_str += line[i];
                    }
                    else if (line[i] == ';')
                    {
                        third = false;
                        fourth = true;
                        i++;
                    }
                }
                if (fourth)
                {
                    fourth_str += line[i];
                }
            }
            return Color.FromArgb(Convert.ToByte(first_str), Convert.ToByte(second_str), Convert.ToByte(third_str), Convert.ToByte(fourth_str));
        }
        #endregion

        #region Read From File
        private void ReadFromFile()
        {
            String line;
            int operation = 0;
            try
            {
                StreamReader file = new StreamReader("Settings.cfg");
                line = file.ReadLine();
                while (line != null)
                {
                    if (operation == 0)
                        mbc = SetColor(line);
                    if (operation == 1)
                        smbc = SetColor(line);
                    if (operation == 2)
                        abc = SetColor(line);
                    if (operation == 3)
                        tc = SetColor(line);
                    if (operation == 4)
                        pbc = SetColor(line);
                    if (operation == 5)
                        mac = SetColor(line);
                    if (operation == 6)
                        nac = SetColor(line);
                    if (operation == 7)
                        rac = SetColor(line);
                    if (operation == 8)
                        gc = SetColor(line);
                    if (operation == 9)
                        pc = SetColor(line);
                    if (operation == 10)
                        cpc = SetColor(line);
                    if (operation == 11)
                        nc = SetColor(line);
                    line = file.ReadLine();
                    operation++;
                }
                file.Close();
            }
            catch
            {
                return;
            }
        }
        #endregion
    }
}
