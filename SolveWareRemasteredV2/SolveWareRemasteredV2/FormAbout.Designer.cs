
namespace SolveWareRemasteredV2
{
    partial class FormAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.txtTextAbout = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.Label();
            this.txtCoder = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTextAbout
            // 
            this.txtTextAbout.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTextAbout.AutoSize = true;
            this.txtTextAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTextAbout.ForeColor = System.Drawing.Color.White;
            this.txtTextAbout.Location = new System.Drawing.Point(62, 39);
            this.txtTextAbout.Name = "txtTextAbout";
            this.txtTextAbout.Size = new System.Drawing.Size(977, 93);
            this.txtTextAbout.TabIndex = 0;
            this.txtTextAbout.Text = resources.GetString("txtTextAbout.Text");
            // 
            // txtVersion
            // 
            this.txtVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtVersion.AutoSize = true;
            this.txtVersion.ForeColor = System.Drawing.Color.White;
            this.txtVersion.Location = new System.Drawing.Point(12, 600);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(31, 13);
            this.txtVersion.TabIndex = 1;
            this.txtVersion.Text = "v 2.1";
            // 
            // txtCoder
            // 
            this.txtCoder.ActiveLinkColor = System.Drawing.Color.White;
            this.txtCoder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCoder.AutoSize = true;
            this.txtCoder.LinkColor = System.Drawing.Color.White;
            this.txtCoder.Location = new System.Drawing.Point(983, 600);
            this.txtCoder.Name = "txtCoder";
            this.txtCoder.Size = new System.Drawing.Size(111, 13);
            this.txtCoder.TabIndex = 2;
            this.txtCoder.TabStop = true;
            this.txtCoder.Text = "made by heeleewaree";
            this.txtCoder.VisitedLinkColor = System.Drawing.Color.White;
            this.txtCoder.Click += new System.EventHandler(this.txtCoder_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox1.Image = global::SolveWareRemasteredV2.Properties.Resources.tyan1;
            this.pictureBox1.Location = new System.Drawing.Point(245, 135);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(662, 496);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1106, 622);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtCoder);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.txtTextAbout);
            this.Name = "FormAbout";
            this.Text = "FormAbout";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtTextAbout;
        private System.Windows.Forms.Label txtVersion;
        private System.Windows.Forms.LinkLabel txtCoder;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}