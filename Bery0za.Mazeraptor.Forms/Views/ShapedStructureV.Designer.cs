using System.Windows.Forms;

namespace Bery0za.Mazerator.Forms.Views
{
    partial class ShapedStructureV
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
            this.loadImageButton = new System.Windows.Forms.Button();
            this.shapeSelectorList = new System.Windows.Forms.ComboBox();
            this.loadImageLabel = new System.Windows.Forms.Label();
            this.shapeSelectorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loadImageButton
            // 
            this.loadImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadImageButton.Location = new System.Drawing.Point(234, 3);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(23, 23);
            this.loadImageButton.TabIndex = 4;
            this.loadImageButton.Text = "..";
            this.loadImageButton.UseVisualStyleBackColor = true;
            // 
            // shapeSelectorList
            // 
            this.shapeSelectorList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.shapeSelectorList.FormattingEnabled = true;
            this.shapeSelectorList.Location = new System.Drawing.Point(87, 32);
            this.shapeSelectorList.Name = "shapeSelectorList";
            this.shapeSelectorList.Size = new System.Drawing.Size(170, 21);
            this.shapeSelectorList.TabIndex = 5;
            // 
            // loadImageLabel
            // 
            this.loadImageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadImageLabel.Location = new System.Drawing.Point(6, 5);
            this.loadImageLabel.Name = "loadImageLabel";
            this.loadImageLabel.Size = new System.Drawing.Size(222, 18);
            this.loadImageLabel.TabIndex = 6;
            this.loadImageLabel.Text = "Select file";
            this.loadImageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // shapeSelectorLabel
            // 
            this.shapeSelectorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.shapeSelectorLabel.AutoSize = true;
            this.shapeSelectorLabel.Location = new System.Drawing.Point(3, 35);
            this.shapeSelectorLabel.Name = "shapeSelectorLabel";
            this.shapeSelectorLabel.Size = new System.Drawing.Size(78, 13);
            this.shapeSelectorLabel.TabIndex = 7;
            this.shapeSelectorLabel.Text = "Shape selector";
            this.shapeSelectorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ShapedStructureV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.shapeSelectorLabel);
            this.Controls.Add(this.loadImageLabel);
            this.Controls.Add(this.shapeSelectorList);
            this.Controls.Add(this.loadImageButton);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ShapedStructureV";
            this.Size = new System.Drawing.Size(260, 57);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button loadImageButton;
        private ComboBox shapeSelectorList;
        private Label loadImageLabel;
        private Label shapeSelectorLabel;
    }
}
