namespace Bery0za.Mazerator.Forms.Views
{
    partial class GrowingTreeGeneratorV
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.firstCellList = new System.Windows.Forms.ComboBox();
            this.carvingCellList = new System.Windows.Forms.ComboBox();
            this.neighborCellList = new System.Windows.Forms.ComboBox();
            this.firstCellLabel = new System.Windows.Forms.Label();
            this.carvingCellLabel = new System.Windows.Forms.Label();
            this.neighborCellLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.leftCellList = new System.Windows.Forms.ComboBox();
            this.firstNumeric = new System.Windows.Forms.NumericUpDown();
            this.leftNumeric = new System.Windows.Forms.NumericUpDown();
            this.carvingNumeric = new System.Windows.Forms.NumericUpDown();
            this.ratioTooltip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.firstNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carvingNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // firstCellList
            // 
            this.firstCellList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.firstCellList.FormattingEnabled = true;
            this.firstCellList.Location = new System.Drawing.Point(111, 3);
            this.firstCellList.Name = "firstCellList";
            this.firstCellList.Size = new System.Drawing.Size(91, 21);
            this.firstCellList.TabIndex = 0;
            // 
            // carvingCellList
            // 
            this.carvingCellList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.carvingCellList.FormattingEnabled = true;
            this.carvingCellList.Location = new System.Drawing.Point(111, 57);
            this.carvingCellList.Name = "carvingCellList";
            this.carvingCellList.Size = new System.Drawing.Size(91, 21);
            this.carvingCellList.TabIndex = 1;
            // 
            // neighborCellList
            // 
            this.neighborCellList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.neighborCellList.FormattingEnabled = true;
            this.neighborCellList.Location = new System.Drawing.Point(111, 84);
            this.neighborCellList.Name = "neighborCellList";
            this.neighborCellList.Size = new System.Drawing.Size(91, 21);
            this.neighborCellList.TabIndex = 2;
            // 
            // firstCellLabel
            // 
            this.firstCellLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.firstCellLabel.AutoSize = true;
            this.firstCellLabel.Location = new System.Drawing.Point(21, 6);
            this.firstCellLabel.Name = "firstCellLabel";
            this.firstCellLabel.Size = new System.Drawing.Size(85, 13);
            this.firstCellLabel.TabIndex = 3;
            this.firstCellLabel.Text = "First cell selector";
            this.firstCellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // carvingCellLabel
            // 
            this.carvingCellLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.carvingCellLabel.AutoSize = true;
            this.carvingCellLabel.Location = new System.Drawing.Point(3, 60);
            this.carvingCellLabel.Name = "carvingCellLabel";
            this.carvingCellLabel.Size = new System.Drawing.Size(102, 13);
            this.carvingCellLabel.TabIndex = 4;
            this.carvingCellLabel.Text = "Carving cell selector";
            this.carvingCellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // neighborCellLabel
            // 
            this.neighborCellLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.neighborCellLabel.AutoSize = true;
            this.neighborCellLabel.Location = new System.Drawing.Point(-4, 87);
            this.neighborCellLabel.Name = "neighborCellLabel";
            this.neighborCellLabel.Size = new System.Drawing.Size(109, 13);
            this.neighborCellLabel.TabIndex = 5;
            this.neighborCellLabel.Text = "Neighbor cell selector";
            this.neighborCellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Left cell selector";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // leftCellList
            // 
            this.leftCellList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.leftCellList.FormattingEnabled = true;
            this.leftCellList.Location = new System.Drawing.Point(111, 30);
            this.leftCellList.Name = "leftCellList";
            this.leftCellList.Size = new System.Drawing.Size(91, 21);
            this.leftCellList.TabIndex = 6;
            // 
            // firstNumeric
            // 
            this.firstNumeric.DecimalPlaces = 1;
            this.firstNumeric.Enabled = false;
            this.firstNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.firstNumeric.Location = new System.Drawing.Point(208, 3);
            this.firstNumeric.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.firstNumeric.Name = "firstNumeric";
            this.firstNumeric.Size = new System.Drawing.Size(49, 20);
            this.firstNumeric.TabIndex = 8;
            this.ratioTooltip.SetToolTip(this.firstNumeric, "This value indicates the ratio at which one or another method are being applied");
            this.firstNumeric.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // leftNumeric
            // 
            this.leftNumeric.DecimalPlaces = 1;
            this.leftNumeric.Enabled = false;
            this.leftNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.leftNumeric.Location = new System.Drawing.Point(208, 30);
            this.leftNumeric.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.leftNumeric.Name = "leftNumeric";
            this.leftNumeric.Size = new System.Drawing.Size(49, 20);
            this.leftNumeric.TabIndex = 9;
            this.ratioTooltip.SetToolTip(this.leftNumeric, "This value indicates the ratio at which one or another method are being applied");
            this.leftNumeric.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // carvingNumeric
            // 
            this.carvingNumeric.DecimalPlaces = 1;
            this.carvingNumeric.Enabled = false;
            this.carvingNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.carvingNumeric.Location = new System.Drawing.Point(208, 57);
            this.carvingNumeric.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.carvingNumeric.Name = "carvingNumeric";
            this.carvingNumeric.Size = new System.Drawing.Size(49, 20);
            this.carvingNumeric.TabIndex = 10;
            this.ratioTooltip.SetToolTip(this.carvingNumeric, "This value indicates the ratio at which one or another method are being applied");
            this.carvingNumeric.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // ratioTooltip
            // 
            this.ratioTooltip.ToolTipTitle = "Probability ratio";
            // 
            // GrowingTreeGeneratorV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.carvingNumeric);
            this.Controls.Add(this.leftNumeric);
            this.Controls.Add(this.firstNumeric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.leftCellList);
            this.Controls.Add(this.neighborCellLabel);
            this.Controls.Add(this.carvingCellLabel);
            this.Controls.Add(this.firstCellLabel);
            this.Controls.Add(this.neighborCellList);
            this.Controls.Add(this.carvingCellList);
            this.Controls.Add(this.firstCellList);
            this.Name = "GrowingTreeGeneratorV";
            this.Size = new System.Drawing.Size(260, 108);
            ((System.ComponentModel.ISupportInitialize)(this.firstNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carvingNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox firstCellList;
        private System.Windows.Forms.ComboBox carvingCellList;
        private System.Windows.Forms.ComboBox neighborCellList;
        private System.Windows.Forms.Label firstCellLabel;
        private System.Windows.Forms.Label carvingCellLabel;
        private System.Windows.Forms.Label neighborCellLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox leftCellList;
        private System.Windows.Forms.NumericUpDown firstNumeric;
        private System.Windows.Forms.NumericUpDown leftNumeric;
        private System.Windows.Forms.NumericUpDown carvingNumeric;
        private System.Windows.Forms.ToolTip ratioTooltip;
    }
}
