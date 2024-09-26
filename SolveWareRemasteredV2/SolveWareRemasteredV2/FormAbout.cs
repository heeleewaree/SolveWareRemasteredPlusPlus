using System;
using System.Windows.Forms;
using static SolveWareRemasteredV2.GlobalVars;

namespace SolveWareRemasteredV2
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
            CustomDesign();
        }

        #region Custom Design
        private void CustomDesign()
        {
            this.BackColor = abc;
            txtVersion.ForeColor = tc;
            txtCoder.LinkColor = tc;
            txtTextAbout.ForeColor = tc;
            txtVersion.Text = "v 2.3";
            GC.Collect();
        }
        #endregion

        #region Coder
        private void txtCoder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.vk.com/65k_na_moih_nogah");
        }
        #endregion
    }
}
