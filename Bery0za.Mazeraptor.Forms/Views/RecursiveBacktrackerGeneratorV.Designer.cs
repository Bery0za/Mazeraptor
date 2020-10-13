namespace Bery0za.Mazerator.Forms.Views
{
    partial class RecursiveBacktrackerGeneratorV
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
            this.firstCellList = new System.Windows.Forms.ComboBox();
            this.leftCellList = new System.Windows.Forms.ComboBox();
            this.neighborCellList = new System.Windows.Forms.ComboBox();
            this.firstCellLabel = new System.Windows.Forms.Label();
            this.leftCellLabel = new System.Windows.Forms.Label();
            this.neighborCellLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstCellList
            // 
            this.firstCellList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.firstCellList.FormattingEnabled = true;
            this.firstCellList.Location = new System.Drawing.Point(166, 3);
            this.firstCellList.Name = "firstCellList";
            this.firstCellList.Size = new System.Drawing.Size(91, 21);
            this.firstCellList.TabIndex = 0;
            // 
            // leftCellList
            // 
            this.leftCellList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.leftCellList.FormattingEnabled = true;
            this.leftCellList.Location = new System.Drawing.Point(166, 30);
            this.leftCellList.Name = "leftCellList";
            this.leftCellList.Size = new System.Drawing.Size(91, 21);
            this.leftCellList.TabIndex = 1;
            // 
            // neighborCellList
            // 
            this.neighborCellList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.neighborCellList.FormattingEnabled = true;
            this.neighborCellList.Location = new System.Drawing.Point(166, 57);
            this.neighborCellList.Name = "neighborCellList";
            this.neighborCellList.Size = new System.Drawing.Size(91, 21);
            this.neighborCellList.TabIndex = 2;
            // 
            // firstCellLabel
            // 
            this.firstCellLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.firstCellLabel.AutoSize = true;
            this.firstCellLabel.Location = new System.Drawing.Point(76, 6);
            this.firstCellLabel.Name = "firstCellLabel";
            this.firstCellLabel.Size = new System.Drawing.Size(85, 13);
            this.firstCellLabel.TabIndex = 3;
            this.firstCellLabel.Text = "First cell selector";
            this.firstCellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // leftCellLabel
            // 
            this.leftCellLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.leftCellLabel.AutoSize = true;
            this.leftCellLabel.Location = new System.Drawing.Point(76, 33);
            this.leftCellLabel.Name = "leftCellLabel";
            this.leftCellLabel.Size = new System.Drawing.Size(84, 13);
            this.leftCellLabel.TabIndex = 4;
            this.leftCellLabel.Text = "Left cell selector";
            this.leftCellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // neighborCellLabel
            // 
            this.neighborCellLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.neighborCellLabel.AutoSize = true;
            this.neighborCellLabel.Location = new System.Drawing.Point(51, 60);
            this.neighborCellLabel.Name = "neighborCellLabel";
            this.neighborCellLabel.Size = new System.Drawing.Size(109, 13);
            this.neighborCellLabel.TabIndex = 5;
            this.neighborCellLabel.Text = "Neighbor cell selector";
            this.neighborCellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RecursiveBacktrackerGeneratorV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neighborCellLabel);
            this.Controls.Add(this.leftCellLabel);
            this.Controls.Add(this.firstCellLabel);
            this.Controls.Add(this.neighborCellList);
            this.Controls.Add(this.leftCellList);
            this.Controls.Add(this.firstCellList);
            this.Name = "RecursiveBacktrackerGeneratorV";
            this.Size = new System.Drawing.Size(260, 81);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox firstCellList;
        private System.Windows.Forms.ComboBox leftCellList;
        private System.Windows.Forms.ComboBox neighborCellList;
        private System.Windows.Forms.Label firstCellLabel;
        private System.Windows.Forms.Label leftCellLabel;
        private System.Windows.Forms.Label neighborCellLabel;
    }
}
