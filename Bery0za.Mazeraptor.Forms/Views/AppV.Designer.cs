namespace Bery0za.Mazerator.Forms.Views
{
	partial class AppV
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.mazeView = new System.Windows.Forms.Panel();
            this.mazePicture = new System.Windows.Forms.PictureBox();
            this.mazeBox = new System.Windows.Forms.GroupBox();
            this.mazeLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.structureBox = new System.Windows.Forms.GroupBox();
            this.structureLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.structureList = new System.Windows.Forms.ComboBox();
            this.generatorBox = new System.Windows.Forms.GroupBox();
            this.generatorLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.generatorList = new System.Windows.Forms.ComboBox();
            this.seedTextBox = new System.Windows.Forms.TextBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.solverBox = new System.Windows.Forms.GroupBox();
            this.targetLabel = new System.Windows.Forms.Label();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.targetCellList = new System.Windows.Forms.ComboBox();
            this.sourceCellList = new System.Windows.Forms.ComboBox();
            this.solverLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.solverList = new System.Windows.Forms.ComboBox();
            this.solveButton = new System.Windows.Forms.Button();
            this.drawerBox = new System.Windows.Forms.GroupBox();
            this.cellSizeLabel = new System.Windows.Forms.Label();
            this.cellSizeNumeric = new System.Windows.Forms.NumericUpDown();
            this.fillTypeLabel = new System.Windows.Forms.Label();
            this.strokeWidthLabel = new System.Windows.Forms.Label();
            this.strokeWidthNumeric = new System.Windows.Forms.NumericUpDown();
            this.fillColorButton = new System.Windows.Forms.Button();
            this.fillCheckBox = new System.Windows.Forms.CheckBox();
            this.strokeColorButton = new System.Windows.Forms.Button();
            this.strokeCheckBox = new System.Windows.Forms.CheckBox();
            this.fillTypeList = new System.Windows.Forms.ComboBox();
            this.drawButton = new System.Windows.Forms.Button();
            this.saveImageButton = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.autoDrawCheckBox = new System.Windows.Forms.CheckBox();
            this.mazeView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mazePicture)).BeginInit();
            this.mazeBox.SuspendLayout();
            this.mazeLayout.SuspendLayout();
            this.structureBox.SuspendLayout();
            this.structureLayout.SuspendLayout();
            this.generatorBox.SuspendLayout();
            this.generatorLayout.SuspendLayout();
            this.solverBox.SuspendLayout();
            this.solverLayout.SuspendLayout();
            this.drawerBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cellSizeNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.strokeWidthNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // mazeView
            // 
            this.mazeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mazeView.AutoScroll = true;
            this.mazeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mazeView.Controls.Add(this.mazePicture);
            this.mazeView.Location = new System.Drawing.Point(8, 8);
            this.mazeView.Name = "mazeView";
            this.mazeView.Size = new System.Drawing.Size(714, 713);
            this.mazeView.TabIndex = 0;
            // 
            // mazePicture
            // 
            this.mazePicture.Location = new System.Drawing.Point(4, 4);
            this.mazePicture.Name = "mazePicture";
            this.mazePicture.Size = new System.Drawing.Size(705, 704);
            this.mazePicture.TabIndex = 0;
            this.mazePicture.TabStop = false;
            // 
            // mazeBox
            // 
            this.mazeBox.AutoSize = true;
            this.mazeBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mazeBox.Controls.Add(this.mazeLayout);
            this.mazeBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.mazeBox.Location = new System.Drawing.Point(725, 5);
            this.mazeBox.Margin = new System.Windows.Forms.Padding(0);
            this.mazeBox.Name = "mazeBox";
            this.mazeBox.Size = new System.Drawing.Size(278, 719);
            this.mazeBox.TabIndex = 1;
            this.mazeBox.TabStop = false;
            this.mazeBox.Text = "Maze";
            // 
            // mazeLayout
            // 
            this.mazeLayout.AutoScroll = true;
            this.mazeLayout.AutoSize = true;
            this.mazeLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mazeLayout.Controls.Add(this.structureBox);
            this.mazeLayout.Controls.Add(this.generatorBox);
            this.mazeLayout.Controls.Add(this.seedTextBox);
            this.mazeLayout.Controls.Add(this.generateButton);
            this.mazeLayout.Controls.Add(this.solverBox);
            this.mazeLayout.Controls.Add(this.solveButton);
            this.mazeLayout.Controls.Add(this.drawerBox);
            this.mazeLayout.Controls.Add(this.drawButton);
            this.mazeLayout.Controls.Add(this.saveImageButton);
            this.mazeLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mazeLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mazeLayout.Location = new System.Drawing.Point(3, 16);
            this.mazeLayout.Margin = new System.Windows.Forms.Padding(0);
            this.mazeLayout.Name = "mazeLayout";
            this.mazeLayout.Size = new System.Drawing.Size(272, 700);
            this.mazeLayout.TabIndex = 0;
            // 
            // structureBox
            // 
            this.structureBox.AutoSize = true;
            this.structureBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.structureBox.Controls.Add(this.structureLayout);
            this.structureBox.Location = new System.Drawing.Point(0, 0);
            this.structureBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.structureBox.Name = "structureBox";
            this.structureBox.Size = new System.Drawing.Size(272, 46);
            this.structureBox.TabIndex = 4;
            this.structureBox.TabStop = false;
            this.structureBox.Text = "Structure";
            // 
            // structureLayout
            // 
            this.structureLayout.AutoSize = true;
            this.structureLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.structureLayout.Controls.Add(this.structureList);
            this.structureLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.structureLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.structureLayout.Location = new System.Drawing.Point(3, 16);
            this.structureLayout.Name = "structureLayout";
            this.structureLayout.Size = new System.Drawing.Size(266, 27);
            this.structureLayout.TabIndex = 1;
            // 
            // structureList
            // 
            this.structureList.FormattingEnabled = true;
            this.structureList.Location = new System.Drawing.Point(3, 3);
            this.structureList.Name = "structureList";
            this.structureList.Size = new System.Drawing.Size(260, 21);
            this.structureList.TabIndex = 0;
            this.structureList.Text = "Select structure";
            // 
            // generatorBox
            // 
            this.generatorBox.AutoSize = true;
            this.generatorBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.generatorBox.Controls.Add(this.generatorLayout);
            this.generatorBox.Location = new System.Drawing.Point(0, 49);
            this.generatorBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.generatorBox.Name = "generatorBox";
            this.generatorBox.Size = new System.Drawing.Size(272, 46);
            this.generatorBox.TabIndex = 5;
            this.generatorBox.TabStop = false;
            this.generatorBox.Text = "Generator";
            // 
            // generatorLayout
            // 
            this.generatorLayout.AutoSize = true;
            this.generatorLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.generatorLayout.Controls.Add(this.generatorList);
            this.generatorLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generatorLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.generatorLayout.Location = new System.Drawing.Point(3, 16);
            this.generatorLayout.Name = "generatorLayout";
            this.generatorLayout.Size = new System.Drawing.Size(266, 27);
            this.generatorLayout.TabIndex = 0;
            // 
            // generatorList
            // 
            this.generatorList.FormattingEnabled = true;
            this.generatorList.Location = new System.Drawing.Point(3, 3);
            this.generatorList.Name = "generatorList";
            this.generatorList.Size = new System.Drawing.Size(260, 21);
            this.generatorList.TabIndex = 0;
            this.generatorList.Text = "Select generator";
            // 
            // seedTextBox
            // 
            this.seedTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.seedTextBox.Location = new System.Drawing.Point(3, 101);
            this.seedTextBox.Name = "seedTextBox";
            this.seedTextBox.Size = new System.Drawing.Size(266, 20);
            this.seedTextBox.TabIndex = 13;
            this.seedTextBox.Text = "Seed";
            // 
            // generateButton
            // 
            this.generateButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generateButton.Location = new System.Drawing.Point(0, 124);
            this.generateButton.Margin = new System.Windows.Forms.Padding(0);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(272, 40);
            this.generateButton.TabIndex = 7;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            // 
            // solverBox
            // 
            this.solverBox.AutoSize = true;
            this.solverBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.solverBox.Controls.Add(this.targetLabel);
            this.solverBox.Controls.Add(this.sourceLabel);
            this.solverBox.Controls.Add(this.targetCellList);
            this.solverBox.Controls.Add(this.sourceCellList);
            this.solverBox.Controls.Add(this.solverLayout);
            this.solverBox.Enabled = false;
            this.solverBox.Location = new System.Drawing.Point(0, 164);
            this.solverBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.solverBox.Name = "solverBox";
            this.solverBox.Size = new System.Drawing.Size(272, 113);
            this.solverBox.TabIndex = 8;
            this.solverBox.TabStop = false;
            this.solverBox.Text = "Solver";
            // 
            // targetLabel
            // 
            this.targetLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.targetLabel.AutoSize = true;
            this.targetLabel.Location = new System.Drawing.Point(9, 76);
            this.targetLabel.Name = "targetLabel";
            this.targetLabel.Size = new System.Drawing.Size(38, 13);
            this.targetLabel.TabIndex = 4;
            this.targetLabel.Text = "Target";
            this.targetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sourceLabel
            // 
            this.sourceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.Location = new System.Drawing.Point(6, 49);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(41, 13);
            this.sourceLabel.TabIndex = 3;
            this.sourceLabel.Text = "Source";
            this.sourceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // targetCellList
            // 
            this.targetCellList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.targetCellList.FormattingEnabled = true;
            this.targetCellList.Location = new System.Drawing.Point(53, 73);
            this.targetCellList.Name = "targetCellList";
            this.targetCellList.Size = new System.Drawing.Size(213, 21);
            this.targetCellList.TabIndex = 2;
            // 
            // sourceCellList
            // 
            this.sourceCellList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceCellList.FormattingEnabled = true;
            this.sourceCellList.Location = new System.Drawing.Point(53, 46);
            this.sourceCellList.Name = "sourceCellList";
            this.sourceCellList.Size = new System.Drawing.Size(213, 21);
            this.sourceCellList.TabIndex = 1;
            // 
            // solverLayout
            // 
            this.solverLayout.AutoSize = true;
            this.solverLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.solverLayout.Controls.Add(this.solverList);
            this.solverLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.solverLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.solverLayout.Location = new System.Drawing.Point(3, 16);
            this.solverLayout.Name = "solverLayout";
            this.solverLayout.Size = new System.Drawing.Size(266, 27);
            this.solverLayout.TabIndex = 0;
            // 
            // solverList
            // 
            this.solverList.FormattingEnabled = true;
            this.solverList.Location = new System.Drawing.Point(3, 3);
            this.solverList.Name = "solverList";
            this.solverList.Size = new System.Drawing.Size(260, 21);
            this.solverList.TabIndex = 0;
            this.solverList.Text = "Select solving algorithm";
            // 
            // solveButton
            // 
            this.solveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.solveButton.Enabled = false;
            this.solveButton.Location = new System.Drawing.Point(0, 280);
            this.solveButton.Margin = new System.Windows.Forms.Padding(0);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(272, 40);
            this.solveButton.TabIndex = 9;
            this.solveButton.Text = "Maze is not generated yet";
            this.solveButton.UseVisualStyleBackColor = true;
            // 
            // drawerBox
            // 
            this.drawerBox.AutoSize = true;
            this.drawerBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.drawerBox.Controls.Add(this.autoDrawCheckBox);
            this.drawerBox.Controls.Add(this.cellSizeLabel);
            this.drawerBox.Controls.Add(this.cellSizeNumeric);
            this.drawerBox.Controls.Add(this.fillTypeLabel);
            this.drawerBox.Controls.Add(this.strokeWidthLabel);
            this.drawerBox.Controls.Add(this.strokeWidthNumeric);
            this.drawerBox.Controls.Add(this.fillColorButton);
            this.drawerBox.Controls.Add(this.fillCheckBox);
            this.drawerBox.Controls.Add(this.strokeColorButton);
            this.drawerBox.Controls.Add(this.strokeCheckBox);
            this.drawerBox.Controls.Add(this.fillTypeList);
            this.drawerBox.Enabled = false;
            this.drawerBox.Location = new System.Drawing.Point(0, 320);
            this.drawerBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.drawerBox.Name = "drawerBox";
            this.drawerBox.Size = new System.Drawing.Size(272, 112);
            this.drawerBox.TabIndex = 10;
            this.drawerBox.TabStop = false;
            this.drawerBox.Text = "Drawer";
            // 
            // cellSizeLabel
            // 
            this.cellSizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cellSizeLabel.AutoSize = true;
            this.cellSizeLabel.Location = new System.Drawing.Point(132, 75);
            this.cellSizeLabel.Name = "cellSizeLabel";
            this.cellSizeLabel.Size = new System.Drawing.Size(45, 13);
            this.cellSizeLabel.TabIndex = 9;
            this.cellSizeLabel.Text = "Cell size";
            this.cellSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cellSizeNumeric
            // 
            this.cellSizeNumeric.DecimalPlaces = 1;
            this.cellSizeNumeric.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.cellSizeNumeric.Location = new System.Drawing.Point(183, 73);
            this.cellSizeNumeric.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.cellSizeNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cellSizeNumeric.Name = "cellSizeNumeric";
            this.cellSizeNumeric.Size = new System.Drawing.Size(83, 20);
            this.cellSizeNumeric.TabIndex = 0;
            this.cellSizeNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // fillTypeLabel
            // 
            this.fillTypeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fillTypeLabel.AutoSize = true;
            this.fillTypeLabel.Location = new System.Drawing.Point(146, 50);
            this.fillTypeLabel.Name = "fillTypeLabel";
            this.fillTypeLabel.Size = new System.Drawing.Size(31, 13);
            this.fillTypeLabel.TabIndex = 8;
            this.fillTypeLabel.Text = "Type";
            this.fillTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // strokeWidthLabel
            // 
            this.strokeWidthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.strokeWidthLabel.AutoSize = true;
            this.strokeWidthLabel.Location = new System.Drawing.Point(142, 24);
            this.strokeWidthLabel.Name = "strokeWidthLabel";
            this.strokeWidthLabel.Size = new System.Drawing.Size(35, 13);
            this.strokeWidthLabel.TabIndex = 7;
            this.strokeWidthLabel.Text = "Width";
            this.strokeWidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // strokeWidthNumeric
            // 
            this.strokeWidthNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.strokeWidthNumeric.DecimalPlaces = 1;
            this.strokeWidthNumeric.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.strokeWidthNumeric.Location = new System.Drawing.Point(183, 20);
            this.strokeWidthNumeric.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.strokeWidthNumeric.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.strokeWidthNumeric.Name = "strokeWidthNumeric";
            this.strokeWidthNumeric.Size = new System.Drawing.Size(83, 20);
            this.strokeWidthNumeric.TabIndex = 6;
            this.strokeWidthNumeric.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // fillColorButton
            // 
            this.fillColorButton.BackColor = System.Drawing.Color.White;
            this.fillColorButton.Location = new System.Drawing.Point(6, 45);
            this.fillColorButton.Name = "fillColorButton";
            this.fillColorButton.Size = new System.Drawing.Size(35, 22);
            this.fillColorButton.TabIndex = 4;
            this.fillColorButton.UseVisualStyleBackColor = false;
            // 
            // fillCheckBox
            // 
            this.fillCheckBox.AutoSize = true;
            this.fillCheckBox.Location = new System.Drawing.Point(47, 48);
            this.fillCheckBox.Name = "fillCheckBox";
            this.fillCheckBox.Size = new System.Drawing.Size(38, 17);
            this.fillCheckBox.TabIndex = 3;
            this.fillCheckBox.Text = "Fill";
            this.fillCheckBox.UseVisualStyleBackColor = true;
            // 
            // strokeColorButton
            // 
            this.strokeColorButton.BackColor = System.Drawing.Color.Black;
            this.strokeColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.strokeColorButton.Location = new System.Drawing.Point(6, 19);
            this.strokeColorButton.Name = "strokeColorButton";
            this.strokeColorButton.Size = new System.Drawing.Size(35, 22);
            this.strokeColorButton.TabIndex = 2;
            this.strokeColorButton.UseVisualStyleBackColor = false;
            // 
            // strokeCheckBox
            // 
            this.strokeCheckBox.AutoSize = true;
            this.strokeCheckBox.Location = new System.Drawing.Point(47, 22);
            this.strokeCheckBox.Name = "strokeCheckBox";
            this.strokeCheckBox.Size = new System.Drawing.Size(57, 17);
            this.strokeCheckBox.TabIndex = 1;
            this.strokeCheckBox.Text = "Stroke";
            this.strokeCheckBox.UseVisualStyleBackColor = true;
            // 
            // fillTypeList
            // 
            this.fillTypeList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fillTypeList.FormattingEnabled = true;
            this.fillTypeList.Location = new System.Drawing.Point(183, 46);
            this.fillTypeList.Name = "fillTypeList";
            this.fillTypeList.Size = new System.Drawing.Size(83, 21);
            this.fillTypeList.TabIndex = 5;
            // 
            // drawButton
            // 
            this.drawButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawButton.Enabled = false;
            this.drawButton.Location = new System.Drawing.Point(0, 435);
            this.drawButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(272, 40);
            this.drawButton.TabIndex = 11;
            this.drawButton.Text = "Maze is not generated yet";
            this.drawButton.UseVisualStyleBackColor = true;
            // 
            // saveImageButton
            // 
            this.saveImageButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveImageButton.Enabled = false;
            this.saveImageButton.Location = new System.Drawing.Point(0, 478);
            this.saveImageButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.saveImageButton.Name = "saveImageButton";
            this.saveImageButton.Size = new System.Drawing.Size(272, 40);
            this.saveImageButton.TabIndex = 12;
            this.saveImageButton.Text = "Maze is not generated yet";
            this.saveImageButton.UseVisualStyleBackColor = true;
            // 
            // colorDialog
            // 
            this.colorDialog.FullOpen = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Image Files (*.jpg; *.bmp; *.png)|*.jpg;*.bmp;*.png";
            this.openFileDialog.SupportMultiDottedExtensions = true;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "png";
            this.saveFileDialog.Filter = "PNG Image (*.png)|*.png";
            this.saveFileDialog.SupportMultiDottedExtensions = true;
            // 
            // autoDrawCheckBox
            // 
            this.autoDrawCheckBox.AutoSize = true;
            this.autoDrawCheckBox.Checked = true;
            this.autoDrawCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoDrawCheckBox.Location = new System.Drawing.Point(47, 74);
            this.autoDrawCheckBox.Name = "autoDrawCheckBox";
            this.autoDrawCheckBox.Size = new System.Drawing.Size(74, 17);
            this.autoDrawCheckBox.TabIndex = 10;
            this.autoDrawCheckBox.Text = "Auto draw";
            this.autoDrawCheckBox.UseVisualStyleBackColor = true;
            // 
            // AppV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.mazeBox);
            this.Controls.Add(this.mazeView);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "AppV";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mazeraptor";
            this.mazeView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mazePicture)).EndInit();
            this.mazeBox.ResumeLayout(false);
            this.mazeBox.PerformLayout();
            this.mazeLayout.ResumeLayout(false);
            this.mazeLayout.PerformLayout();
            this.structureBox.ResumeLayout(false);
            this.structureBox.PerformLayout();
            this.structureLayout.ResumeLayout(false);
            this.generatorBox.ResumeLayout(false);
            this.generatorBox.PerformLayout();
            this.generatorLayout.ResumeLayout(false);
            this.solverBox.ResumeLayout(false);
            this.solverBox.PerformLayout();
            this.solverLayout.ResumeLayout(false);
            this.drawerBox.ResumeLayout(false);
            this.drawerBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cellSizeNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.strokeWidthNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private System.Windows.Forms.Panel mazeView;
        private System.Windows.Forms.GroupBox mazeBox;
        private System.Windows.Forms.FlowLayoutPanel mazeLayout;
        private System.Windows.Forms.GroupBox structureBox;
        private System.Windows.Forms.FlowLayoutPanel structureLayout;
        private System.Windows.Forms.ComboBox structureList;
        private System.Windows.Forms.GroupBox generatorBox;
        private System.Windows.Forms.FlowLayoutPanel generatorLayout;
        private System.Windows.Forms.ComboBox generatorList;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.GroupBox solverBox;
        private System.Windows.Forms.FlowLayoutPanel solverLayout;
        private System.Windows.Forms.ComboBox solverList;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.GroupBox drawerBox;
        private System.Windows.Forms.CheckBox strokeCheckBox;
        private System.Windows.Forms.ComboBox fillTypeList;
        private System.Windows.Forms.Button fillColorButton;
        private System.Windows.Forms.CheckBox fillCheckBox;
        private System.Windows.Forms.Button strokeColorButton;
        private System.Windows.Forms.Label fillTypeLabel;
        private System.Windows.Forms.Label strokeWidthLabel;
        private System.Windows.Forms.NumericUpDown strokeWidthNumeric;
        private System.Windows.Forms.Label cellSizeLabel;
        private System.Windows.Forms.NumericUpDown cellSizeNumeric;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.Button saveImageButton;
        private System.Windows.Forms.PictureBox mazePicture;
        private System.Windows.Forms.ComboBox targetCellList;
        private System.Windows.Forms.ComboBox sourceCellList;
        private System.Windows.Forms.Label targetLabel;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.TextBox seedTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.CheckBox autoDrawCheckBox;
    }
}
