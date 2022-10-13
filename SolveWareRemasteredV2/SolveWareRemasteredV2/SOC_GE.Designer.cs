
namespace SolveWareRemasteredV2
{
    partial class SOC_GE
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
            this.btnCenter = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.checkGrid = new System.Windows.Forms.CheckBox();
            this.checkCrossingPoints = new System.Windows.Forms.CheckBox();
            this.checkHideNums = new System.Windows.Forms.CheckBox();
            this.Ooy = new System.Windows.Forms.Label();
            this.Oox = new System.Windows.Forms.Label();
            this.txtAngle = new System.Windows.Forms.Label();
            this.Oxy = new System.Windows.Forms.Label();
            this.txtEllipse = new System.Windows.Forms.Label();
            this.txtFigure = new System.Windows.Forms.Label();
            this.textF = new System.Windows.Forms.TextBox();
            this.textE = new System.Windows.Forms.TextBox();
            this.textD = new System.Windows.Forms.TextBox();
            this.textC = new System.Windows.Forms.TextBox();
            this.textB = new System.Windows.Forms.TextBox();
            this.textA = new System.Windows.Forms.TextBox();
            this.txtZero = new System.Windows.Forms.Label();
            this.txtYY = new System.Windows.Forms.Label();
            this.txtXX = new System.Windows.Forms.Label();
            this.txtY = new System.Windows.Forms.Label();
            this.txtXY = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.Label();
            this.Plot = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Plot)).BeginInit();
            this.SuspendLayout();
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
            this.btnCenter.TabIndex = 85;
            this.btnCenter.Text = "ᴄᴇɴᴛᴇʀɪɴɢ";
            this.btnCenter.UseVisualStyleBackColor = true;
            this.btnCenter.Click += new System.EventHandler(this.btnCenter_Click);
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
            this.btnApply.TabIndex = 84;
            this.btnApply.Text = "ᴀᴘᴘʟʏ";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(12, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 30);
            this.btnSave.TabIndex = 86;
            this.btnSave.Text = "sᴀᴠᴇ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // checkGrid
            // 
            this.checkGrid.AutoSize = true;
            this.checkGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic);
            this.checkGrid.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkGrid.Location = new System.Drawing.Point(12, 156);
            this.checkGrid.Name = "checkGrid";
            this.checkGrid.Size = new System.Drawing.Size(55, 22);
            this.checkGrid.TabIndex = 89;
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
            this.checkCrossingPoints.TabIndex = 88;
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
            this.checkHideNums.TabIndex = 87;
            this.checkHideNums.Text = "Hide numbers";
            this.checkHideNums.UseVisualStyleBackColor = true;
            this.checkHideNums.CheckedChanged += new System.EventHandler(this.checkHideNums_CheckedChanged);
            // 
            // Ooy
            // 
            this.Ooy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Ooy.AutoSize = true;
            this.Ooy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic);
            this.Ooy.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Ooy.Location = new System.Drawing.Point(8, 629);
            this.Ooy.Name = "Ooy";
            this.Ooy.Size = new System.Drawing.Size(0, 18);
            this.Ooy.TabIndex = 93;
            // 
            // Oox
            // 
            this.Oox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Oox.AutoSize = true;
            this.Oox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic);
            this.Oox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Oox.Location = new System.Drawing.Point(8, 602);
            this.Oox.Name = "Oox";
            this.Oox.Size = new System.Drawing.Size(0, 18);
            this.Oox.TabIndex = 92;
            // 
            // txtAngle
            // 
            this.txtAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAngle.AutoSize = true;
            this.txtAngle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtAngle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtAngle.Location = new System.Drawing.Point(8, 574);
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.Size = new System.Drawing.Size(0, 18);
            this.txtAngle.TabIndex = 91;
            // 
            // Oxy
            // 
            this.Oxy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Oxy.AutoSize = true;
            this.Oxy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic);
            this.Oxy.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Oxy.Location = new System.Drawing.Point(8, 546);
            this.Oxy.Name = "Oxy";
            this.Oxy.Size = new System.Drawing.Size(0, 18);
            this.Oxy.TabIndex = 90;
            // 
            // txtEllipse
            // 
            this.txtEllipse.AutoSize = true;
            this.txtEllipse.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtEllipse.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtEllipse.Location = new System.Drawing.Point(323, 72);
            this.txtEllipse.Name = "txtEllipse";
            this.txtEllipse.Size = new System.Drawing.Size(0, 18);
            this.txtEllipse.TabIndex = 95;
            // 
            // txtFigure
            // 
            this.txtFigure.AutoSize = true;
            this.txtFigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtFigure.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtFigure.Location = new System.Drawing.Point(240, 72);
            this.txtFigure.Name = "txtFigure";
            this.txtFigure.Size = new System.Drawing.Size(0, 18);
            this.txtFigure.TabIndex = 94;
            // 
            // textF
            // 
            this.textF.Location = new System.Drawing.Point(655, 22);
            this.textF.Name = "textF";
            this.textF.Size = new System.Drawing.Size(35, 20);
            this.textF.TabIndex = 107;
            this.textF.Text = "0";
            this.textF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_KeyPress);
            // 
            // textE
            // 
            this.textE.Location = new System.Drawing.Point(577, 22);
            this.textE.Name = "textE";
            this.textE.Size = new System.Drawing.Size(35, 20);
            this.textE.TabIndex = 106;
            this.textE.Text = "0";
            this.textE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_KeyPress);
            // 
            // textD
            // 
            this.textD.Location = new System.Drawing.Point(499, 22);
            this.textD.Name = "textD";
            this.textD.Size = new System.Drawing.Size(35, 20);
            this.textD.TabIndex = 105;
            this.textD.Text = "0";
            this.textD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_KeyPress);
            // 
            // textC
            // 
            this.textC.Location = new System.Drawing.Point(415, 22);
            this.textC.Name = "textC";
            this.textC.Size = new System.Drawing.Size(35, 20);
            this.textC.TabIndex = 104;
            this.textC.Text = "0";
            this.textC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_KeyPress);
            // 
            // textB
            // 
            this.textB.Location = new System.Drawing.Point(329, 22);
            this.textB.Name = "textB";
            this.textB.Size = new System.Drawing.Size(35, 20);
            this.textB.TabIndex = 103;
            this.textB.Text = "0";
            this.textB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_KeyPress);
            // 
            // textA
            // 
            this.textA.Location = new System.Drawing.Point(245, 22);
            this.textA.Name = "textA";
            this.textA.Size = new System.Drawing.Size(35, 20);
            this.textA.TabIndex = 102;
            this.textA.Text = "0";
            this.textA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_KeyPress);
            // 
            // txtZero
            // 
            this.txtZero.AutoSize = true;
            this.txtZero.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtZero.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtZero.Location = new System.Drawing.Point(696, 22);
            this.txtZero.Name = "txtZero";
            this.txtZero.Size = new System.Drawing.Size(33, 18);
            this.txtZero.TabIndex = 101;
            this.txtZero.Text = "=  0";
            // 
            // txtYY
            // 
            this.txtYY.AutoSize = true;
            this.txtYY.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtYY.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtYY.Location = new System.Drawing.Point(618, 22);
            this.txtYY.Name = "txtYY";
            this.txtYY.Size = new System.Drawing.Size(32, 18);
            this.txtYY.TabIndex = 100;
            this.txtYY.Text = "y  +";
            // 
            // txtXX
            // 
            this.txtXX.AutoSize = true;
            this.txtXX.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtXX.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtXX.Location = new System.Drawing.Point(540, 22);
            this.txtXX.Name = "txtXX";
            this.txtXX.Size = new System.Drawing.Size(32, 18);
            this.txtXX.TabIndex = 99;
            this.txtXX.Text = "x  +";
            // 
            // txtY
            // 
            this.txtY.AutoSize = true;
            this.txtY.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtY.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtY.Location = new System.Drawing.Point(456, 22);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(37, 18);
            this.txtY.TabIndex = 98;
            this.txtY.Text = "y²  +";
            // 
            // txtXY
            // 
            this.txtXY.AutoSize = true;
            this.txtXY.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtXY.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtXY.Location = new System.Drawing.Point(370, 22);
            this.txtXY.Name = "txtXY";
            this.txtXY.Size = new System.Drawing.Size(39, 18);
            this.txtXY.TabIndex = 97;
            this.txtXY.Text = "xy  +";
            // 
            // txtX
            // 
            this.txtX.AutoSize = true;
            this.txtX.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtX.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtX.Location = new System.Drawing.Point(286, 22);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(37, 18);
            this.txtX.TabIndex = 96;
            this.txtX.Text = "x²  +";
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
            this.Plot.TabIndex = 55;
            this.Plot.TabStop = false;
            // 
            // SOC_GE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1122, 661);
            this.Controls.Add(this.textF);
            this.Controls.Add(this.textE);
            this.Controls.Add(this.textD);
            this.Controls.Add(this.textC);
            this.Controls.Add(this.textB);
            this.Controls.Add(this.textA);
            this.Controls.Add(this.txtZero);
            this.Controls.Add(this.txtYY);
            this.Controls.Add(this.txtXX);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtXY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.txtEllipse);
            this.Controls.Add(this.txtFigure);
            this.Controls.Add(this.Ooy);
            this.Controls.Add(this.Oox);
            this.Controls.Add(this.txtAngle);
            this.Controls.Add(this.Oxy);
            this.Controls.Add(this.checkGrid);
            this.Controls.Add(this.checkCrossingPoints);
            this.Controls.Add(this.checkHideNums);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCenter);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.Plot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SOC_GE";
            this.Text = "SOC_GE";
            this.Resize += new System.EventHandler(this.SOC_GE_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.Plot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Plot;
        private System.Windows.Forms.Button btnCenter;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox checkGrid;
        private System.Windows.Forms.CheckBox checkCrossingPoints;
        private System.Windows.Forms.CheckBox checkHideNums;
        private System.Windows.Forms.Label Ooy;
        private System.Windows.Forms.Label Oox;
        private System.Windows.Forms.Label txtAngle;
        private System.Windows.Forms.Label Oxy;
        private System.Windows.Forms.Label txtEllipse;
        private System.Windows.Forms.Label txtFigure;
        private System.Windows.Forms.TextBox textF;
        private System.Windows.Forms.TextBox textE;
        private System.Windows.Forms.TextBox textD;
        private System.Windows.Forms.TextBox textC;
        private System.Windows.Forms.TextBox textB;
        private System.Windows.Forms.TextBox textA;
        private System.Windows.Forms.Label txtZero;
        private System.Windows.Forms.Label txtYY;
        private System.Windows.Forms.Label txtXX;
        private System.Windows.Forms.Label txtY;
        private System.Windows.Forms.Label txtXY;
        private System.Windows.Forms.Label txtX;
    }
}