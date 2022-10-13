
namespace SolveWareRemasteredV2
{
    partial class SOC_CE
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtPlus = new System.Windows.Forms.Label();
            this.txtEquals = new System.Windows.Forms.Label();
            this.textB = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.Label();
            this.textF = new System.Windows.Forms.TextBox();
            this.textA = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.Label();
            this.Plot = new System.Windows.Forms.PictureBox();
            this.checkGrid = new System.Windows.Forms.CheckBox();
            this.checkCrossingPoints = new System.Windows.Forms.CheckBox();
            this.checkHideNums = new System.Windows.Forms.CheckBox();
            this.txtEllipse = new System.Windows.Forms.Label();
            this.txtFigure = new System.Windows.Forms.Label();
            this.Ooy = new System.Windows.Forms.Label();
            this.Oox = new System.Windows.Forms.Label();
            this.btnCenter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Plot)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(12, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 30);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "sᴀᴠᴇ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnApply.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnApply.Location = new System.Drawing.Point(1023, 12);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(87, 30);
            this.btnApply.TabIndex = 53;
            this.btnApply.Text = "ᴀᴘᴘʟʏ";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtPlus
            // 
            this.txtPlus.AutoSize = true;
            this.txtPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtPlus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtPlus.Location = new System.Drawing.Point(295, 23);
            this.txtPlus.Name = "txtPlus";
            this.txtPlus.Size = new System.Drawing.Size(17, 18);
            this.txtPlus.TabIndex = 71;
            this.txtPlus.Text = "+";
            // 
            // txtEquals
            // 
            this.txtEquals.AutoSize = true;
            this.txtEquals.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtEquals.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtEquals.Location = new System.Drawing.Point(372, 23);
            this.txtEquals.Name = "txtEquals";
            this.txtEquals.Size = new System.Drawing.Size(17, 18);
            this.txtEquals.TabIndex = 70;
            this.txtEquals.Text = "=";
            // 
            // textB
            // 
            this.textB.Location = new System.Drawing.Point(324, 32);
            this.textB.Name = "textB";
            this.textB.Size = new System.Drawing.Size(40, 20);
            this.textB.TabIndex = 69;
            this.textB.Text = "0";
            this.textB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_KeyPress);
            // 
            // txtY
            // 
            this.txtY.AutoSize = true;
            this.txtY.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtY.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtY.Location = new System.Drawing.Point(332, 9);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(20, 18);
            this.txtY.TabIndex = 68;
            this.txtY.Text = "y²";
            // 
            // textF
            // 
            this.textF.Location = new System.Drawing.Point(403, 23);
            this.textF.Name = "textF";
            this.textF.Size = new System.Drawing.Size(40, 20);
            this.textF.TabIndex = 67;
            this.textF.Text = "0";
            this.textF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_KeyPress);
            // 
            // textA
            // 
            this.textA.Location = new System.Drawing.Point(245, 32);
            this.textA.Name = "textA";
            this.textA.Size = new System.Drawing.Size(40, 20);
            this.textA.TabIndex = 66;
            this.textA.Text = "0";
            this.textA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_KeyPress);
            // 
            // txtX
            // 
            this.txtX.AutoSize = true;
            this.txtX.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtX.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtX.Location = new System.Drawing.Point(253, 9);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(20, 18);
            this.txtX.TabIndex = 65;
            this.txtX.Text = "x²";
            // 
            // Plot
            // 
            this.Plot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Plot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Plot.Location = new System.Drawing.Point(245, 100);
            this.Plot.Name = "Plot";
            this.Plot.Size = new System.Drawing.Size(865, 549);
            this.Plot.TabIndex = 54;
            this.Plot.TabStop = false;
            // 
            // checkGrid
            // 
            this.checkGrid.AutoSize = true;
            this.checkGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic);
            this.checkGrid.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkGrid.Location = new System.Drawing.Point(12, 156);
            this.checkGrid.Name = "checkGrid";
            this.checkGrid.Size = new System.Drawing.Size(55, 22);
            this.checkGrid.TabIndex = 78;
            this.checkGrid.Text = "Grid";
            this.checkGrid.UseVisualStyleBackColor = true;
            this.checkGrid.CheckedChanged += new System.EventHandler(this.checkGrid_CheckedChanged);
            // 
            // checkCrossingPoints
            // 
            this.checkCrossingPoints.AutoSize = true;
            this.checkCrossingPoints.Checked = true;
            this.checkCrossingPoints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkCrossingPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic);
            this.checkCrossingPoints.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkCrossingPoints.Location = new System.Drawing.Point(12, 100);
            this.checkCrossingPoints.Name = "checkCrossingPoints";
            this.checkCrossingPoints.Size = new System.Drawing.Size(131, 22);
            this.checkCrossingPoints.TabIndex = 77;
            this.checkCrossingPoints.Text = "Crossing points";
            this.checkCrossingPoints.UseVisualStyleBackColor = true;
            this.checkCrossingPoints.CheckedChanged += new System.EventHandler(this.checkCrossingPoints_CheckedChanged);
            // 
            // checkHideNums
            // 
            this.checkHideNums.AutoSize = true;
            this.checkHideNums.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic);
            this.checkHideNums.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkHideNums.Location = new System.Drawing.Point(12, 128);
            this.checkHideNums.Name = "checkHideNums";
            this.checkHideNums.Size = new System.Drawing.Size(119, 22);
            this.checkHideNums.TabIndex = 76;
            this.checkHideNums.Text = "Hide numbers";
            this.checkHideNums.UseVisualStyleBackColor = true;
            this.checkHideNums.CheckedChanged += new System.EventHandler(this.checkHideNums_CheckedChanged);
            // 
            // txtEllipse
            // 
            this.txtEllipse.AutoSize = true;
            this.txtEllipse.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtEllipse.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtEllipse.Location = new System.Drawing.Point(323, 72);
            this.txtEllipse.Name = "txtEllipse";
            this.txtEllipse.Size = new System.Drawing.Size(0, 18);
            this.txtEllipse.TabIndex = 80;
            // 
            // txtFigure
            // 
            this.txtFigure.AutoSize = true;
            this.txtFigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtFigure.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtFigure.Location = new System.Drawing.Point(240, 72);
            this.txtFigure.Name = "txtFigure";
            this.txtFigure.Size = new System.Drawing.Size(0, 18);
            this.txtFigure.TabIndex = 79;
            // 
            // Ooy
            // 
            this.Ooy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Ooy.AutoSize = true;
            this.Ooy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic);
            this.Ooy.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Ooy.Location = new System.Drawing.Point(12, 631);
            this.Ooy.Name = "Ooy";
            this.Ooy.Size = new System.Drawing.Size(0, 18);
            this.Ooy.TabIndex = 82;
            // 
            // Oox
            // 
            this.Oox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Oox.AutoSize = true;
            this.Oox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic);
            this.Oox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Oox.Location = new System.Drawing.Point(12, 604);
            this.Oox.Name = "Oox";
            this.Oox.Size = new System.Drawing.Size(0, 18);
            this.Oox.TabIndex = 81;
            // 
            // btnCenter
            // 
            this.btnCenter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnCenter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCenter.Location = new System.Drawing.Point(1023, 48);
            this.btnCenter.Name = "btnCenter";
            this.btnCenter.Size = new System.Drawing.Size(87, 30);
            this.btnCenter.TabIndex = 83;
            this.btnCenter.Text = "ᴄᴇɴᴛᴇʀɪɴɢ";
            this.btnCenter.UseVisualStyleBackColor = true;
            this.btnCenter.Click += new System.EventHandler(this.btnCenter_Click);
            // 
            // SOC_CE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1122, 661);
            this.Controls.Add(this.btnCenter);
            this.Controls.Add(this.Ooy);
            this.Controls.Add(this.Oox);
            this.Controls.Add(this.txtEllipse);
            this.Controls.Add(this.txtFigure);
            this.Controls.Add(this.checkGrid);
            this.Controls.Add(this.checkCrossingPoints);
            this.Controls.Add(this.checkHideNums);
            this.Controls.Add(this.txtPlus);
            this.Controls.Add(this.txtEquals);
            this.Controls.Add(this.textB);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.textF);
            this.Controls.Add(this.textA);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.Plot);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SOC_CE";
            this.Text = "SOC_CE";
            this.Resize += new System.EventHandler(this.SOC_CE_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.Plot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.PictureBox Plot;
        private System.Windows.Forms.Label txtPlus;
        private System.Windows.Forms.Label txtEquals;
        private System.Windows.Forms.TextBox textB;
        private System.Windows.Forms.Label txtY;
        private System.Windows.Forms.TextBox textF;
        private System.Windows.Forms.TextBox textA;
        private System.Windows.Forms.Label txtX;
        private System.Windows.Forms.CheckBox checkGrid;
        private System.Windows.Forms.CheckBox checkCrossingPoints;
        private System.Windows.Forms.CheckBox checkHideNums;
        private System.Windows.Forms.Label txtEllipse;
        private System.Windows.Forms.Label txtFigure;
        private System.Windows.Forms.Label Ooy;
        private System.Windows.Forms.Label Oox;
        private System.Windows.Forms.Button btnCenter;
    }
}