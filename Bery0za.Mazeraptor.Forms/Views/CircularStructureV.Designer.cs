using System.Windows.Forms;

namespace Bery0za.Mazerator.Forms.Views
{
    partial class CircularStructureV
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
            this.ringsLabel = new System.Windows.Forms.Label();
            this.ratioLabel = new System.Windows.Forms.Label();
            this.ringsNumeric = new System.Windows.Forms.NumericUpDown();
            this.ratioNumeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ringsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratioNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // ringsLabel
            // 
            this.ringsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ringsLabel.AutoSize = true;
            this.ringsLabel.Location = new System.Drawing.Point(90, 5);
            this.ringsLabel.Name = "ringsLabel";
            this.ringsLabel.Size = new System.Drawing.Size(81, 13);
            this.ringsLabel.TabIndex = 0;
            this.ringsLabel.Text = "Number of rings";
            this.ringsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ratioLabel
            // 
            this.ratioLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ratioLabel.AutoSize = true;
            this.ratioLabel.Location = new System.Drawing.Point(81, 31);
            this.ratioLabel.Name = "ratioLabel";
            this.ratioLabel.Size = new System.Drawing.Size(90, 13);
            this.ratioLabel.TabIndex = 1;
            this.ratioLabel.Text = "Ring division ratio";
            this.ratioLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ringsNumeric
            // 
            this.ringsNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ringsNumeric.Location = new System.Drawing.Point(177, 3);
            this.ringsNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ringsNumeric.Name = "ringsNumeric";
            this.ringsNumeric.Size = new System.Drawing.Size(80, 20);
            this.ringsNumeric.TabIndex = 2;
            this.ringsNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ratioNumeric
            // 
            this.ratioNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ratioNumeric.DecimalPlaces = 1;
            this.ratioNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ratioNumeric.Location = new System.Drawing.Point(177, 29);
            this.ratioNumeric.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            65536});
            this.ratioNumeric.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.ratioNumeric.Name = "ratioNumeric";
            this.ratioNumeric.Size = new System.Drawing.Size(80, 20);
            this.ratioNumeric.TabIndex = 3;
            this.ratioNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CircularStructureV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.ratioNumeric);
            this.Controls.Add(this.ringsNumeric);
            this.Controls.Add(this.ratioLabel);
            this.Controls.Add(this.ringsLabel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CircularStructureV";
            this.Size = new System.Drawing.Size(260, 52);
            ((System.ComponentModel.ISupportInitialize)(this.ringsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratioNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ringsLabel;
        private System.Windows.Forms.Label ratioLabel;
        private System.Windows.Forms.NumericUpDown ringsNumeric;
        private System.Windows.Forms.NumericUpDown ratioNumeric;
    }
}
