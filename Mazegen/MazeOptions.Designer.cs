namespace Mazegen
{
    partial class MazeOptionsForm
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
            this.size_groupBox = new System.Windows.Forms.GroupBox();
            this.y_label = new System.Windows.Forms.Label();
            this.x_label = new System.Windows.Forms.Label();
            this.y_numeric = new System.Windows.Forms.NumericUpDown();
            this.x_numeric = new System.Windows.Forms.NumericUpDown();
            this.start_groupBox = new System.Windows.Forms.GroupBox();
            this.starty_label = new System.Windows.Forms.Label();
            this.startx_label = new System.Windows.Forms.Label();
            this.starty_numeric = new System.Windows.Forms.NumericUpDown();
            this.startx_numeric = new System.Windows.Forms.NumericUpDown();
            this.end_groupBox = new System.Windows.Forms.GroupBox();
            this.endy_label = new System.Windows.Forms.Label();
            this.endx_label = new System.Windows.Forms.Label();
            this.endy_numeric = new System.Windows.Forms.NumericUpDown();
            this.endx_numeric = new System.Windows.Forms.NumericUpDown();
            this.branching_groupBox = new System.Windows.Forms.GroupBox();
            this.branching_factor_numeric = new System.Windows.Forms.NumericUpDown();
            this.solved_checkBox = new System.Windows.Forms.CheckBox();
            this.cancel_button = new System.Windows.Forms.Button();
            this.apply_button = new System.Windows.Forms.Button();
            this.size_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.y_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.x_numeric)).BeginInit();
            this.start_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.starty_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startx_numeric)).BeginInit();
            this.end_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endy_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endx_numeric)).BeginInit();
            this.branching_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.branching_factor_numeric)).BeginInit();
            this.SuspendLayout();
            // 
            // size_groupBox
            // 
            this.size_groupBox.Controls.Add(this.y_label);
            this.size_groupBox.Controls.Add(this.x_label);
            this.size_groupBox.Controls.Add(this.y_numeric);
            this.size_groupBox.Controls.Add(this.x_numeric);
            this.size_groupBox.Location = new System.Drawing.Point(14, 15);
            this.size_groupBox.Name = "size_groupBox";
            this.size_groupBox.Size = new System.Drawing.Size(250, 49);
            this.size_groupBox.TabIndex = 0;
            this.size_groupBox.TabStop = false;
            this.size_groupBox.Text = "Size";
            // 
            // y_label
            // 
            this.y_label.AutoSize = true;
            this.y_label.Location = new System.Drawing.Point(133, 21);
            this.y_label.Name = "y_label";
            this.y_label.Size = new System.Drawing.Size(17, 13);
            this.y_label.TabIndex = 1;
            this.y_label.Text = "Y:";
            // 
            // x_label
            // 
            this.x_label.AutoSize = true;
            this.x_label.Location = new System.Drawing.Point(6, 21);
            this.x_label.Name = "x_label";
            this.x_label.Size = new System.Drawing.Size(17, 13);
            this.x_label.TabIndex = 1;
            this.x_label.Text = "X:";
            // 
            // y_numeric
            // 
            this.y_numeric.Location = new System.Drawing.Point(153, 19);
            this.y_numeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.y_numeric.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.y_numeric.Name = "y_numeric";
            this.y_numeric.Size = new System.Drawing.Size(83, 20);
            this.y_numeric.TabIndex = 0;
            this.y_numeric.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.y_numeric.ValueChanged += new System.EventHandler(this.NumericUpDown1_ValueChanged);
            // 
            // x_numeric
            // 
            this.x_numeric.Location = new System.Drawing.Point(26, 19);
            this.x_numeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.x_numeric.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.x_numeric.Name = "x_numeric";
            this.x_numeric.Size = new System.Drawing.Size(83, 20);
            this.x_numeric.TabIndex = 0;
            this.x_numeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.x_numeric.ValueChanged += new System.EventHandler(this.X_numeric_ValueChanged);
            // 
            // start_groupBox
            // 
            this.start_groupBox.Controls.Add(this.starty_label);
            this.start_groupBox.Controls.Add(this.startx_label);
            this.start_groupBox.Controls.Add(this.starty_numeric);
            this.start_groupBox.Controls.Add(this.startx_numeric);
            this.start_groupBox.Location = new System.Drawing.Point(14, 70);
            this.start_groupBox.Name = "start_groupBox";
            this.start_groupBox.Size = new System.Drawing.Size(121, 80);
            this.start_groupBox.TabIndex = 0;
            this.start_groupBox.TabStop = false;
            this.start_groupBox.Text = "Start";
            // 
            // starty_label
            // 
            this.starty_label.AutoSize = true;
            this.starty_label.Location = new System.Drawing.Point(6, 45);
            this.starty_label.Name = "starty_label";
            this.starty_label.Size = new System.Drawing.Size(17, 13);
            this.starty_label.TabIndex = 1;
            this.starty_label.Text = "Y:";
            // 
            // startx_label
            // 
            this.startx_label.AutoSize = true;
            this.startx_label.Location = new System.Drawing.Point(6, 21);
            this.startx_label.Name = "startx_label";
            this.startx_label.Size = new System.Drawing.Size(17, 13);
            this.startx_label.TabIndex = 1;
            this.startx_label.Text = "X:";
            // 
            // starty_numeric
            // 
            this.starty_numeric.Location = new System.Drawing.Point(26, 43);
            this.starty_numeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.starty_numeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.starty_numeric.Name = "starty_numeric";
            this.starty_numeric.Size = new System.Drawing.Size(83, 20);
            this.starty_numeric.TabIndex = 0;
            this.starty_numeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // startx_numeric
            // 
            this.startx_numeric.Location = new System.Drawing.Point(26, 19);
            this.startx_numeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.startx_numeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.startx_numeric.Name = "startx_numeric";
            this.startx_numeric.Size = new System.Drawing.Size(83, 20);
            this.startx_numeric.TabIndex = 0;
            this.startx_numeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // end_groupBox
            // 
            this.end_groupBox.Controls.Add(this.endy_label);
            this.end_groupBox.Controls.Add(this.endx_label);
            this.end_groupBox.Controls.Add(this.endy_numeric);
            this.end_groupBox.Controls.Add(this.endx_numeric);
            this.end_groupBox.Location = new System.Drawing.Point(141, 70);
            this.end_groupBox.Name = "end_groupBox";
            this.end_groupBox.Size = new System.Drawing.Size(123, 80);
            this.end_groupBox.TabIndex = 0;
            this.end_groupBox.TabStop = false;
            this.end_groupBox.Text = "End";
            // 
            // endy_label
            // 
            this.endy_label.AutoSize = true;
            this.endy_label.Location = new System.Drawing.Point(6, 45);
            this.endy_label.Name = "endy_label";
            this.endy_label.Size = new System.Drawing.Size(17, 13);
            this.endy_label.TabIndex = 1;
            this.endy_label.Text = "Y:";
            // 
            // endx_label
            // 
            this.endx_label.AutoSize = true;
            this.endx_label.Location = new System.Drawing.Point(6, 21);
            this.endx_label.Name = "endx_label";
            this.endx_label.Size = new System.Drawing.Size(17, 13);
            this.endx_label.TabIndex = 1;
            this.endx_label.Text = "X:";
            // 
            // endy_numeric
            // 
            this.endy_numeric.Location = new System.Drawing.Point(26, 43);
            this.endy_numeric.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.endy_numeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.endy_numeric.Name = "endy_numeric";
            this.endy_numeric.Size = new System.Drawing.Size(83, 20);
            this.endy_numeric.TabIndex = 0;
            this.endy_numeric.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // endx_numeric
            // 
            this.endx_numeric.Location = new System.Drawing.Point(26, 19);
            this.endx_numeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.endx_numeric.Name = "endx_numeric";
            this.endx_numeric.Size = new System.Drawing.Size(83, 20);
            this.endx_numeric.TabIndex = 0;
            this.endx_numeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // branching_groupBox
            // 
            this.branching_groupBox.Controls.Add(this.branching_factor_numeric);
            this.branching_groupBox.Location = new System.Drawing.Point(15, 152);
            this.branching_groupBox.Name = "branching_groupBox";
            this.branching_groupBox.Size = new System.Drawing.Size(120, 49);
            this.branching_groupBox.TabIndex = 0;
            this.branching_groupBox.TabStop = false;
            this.branching_groupBox.Text = "Branching Factor";
            // 
            // branching_factor_numeric
            // 
            this.branching_factor_numeric.Location = new System.Drawing.Point(25, 19);
            this.branching_factor_numeric.Name = "branching_factor_numeric";
            this.branching_factor_numeric.Size = new System.Drawing.Size(83, 20);
            this.branching_factor_numeric.TabIndex = 0;
            this.branching_factor_numeric.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.branching_factor_numeric.ValueChanged += new System.EventHandler(this.X_numeric_ValueChanged);
            // 
            // solved_checkBox
            // 
            this.solved_checkBox.AutoSize = true;
            this.solved_checkBox.Location = new System.Drawing.Point(150, 171);
            this.solved_checkBox.Name = "solved_checkBox";
            this.solved_checkBox.Size = new System.Drawing.Size(59, 17);
            this.solved_checkBox.TabIndex = 1;
            this.solved_checkBox.Text = "Solved";
            this.solved_checkBox.UseVisualStyleBackColor = true;
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(185, 208);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(80, 30);
            this.cancel_button.TabIndex = 2;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // apply_button
            // 
            this.apply_button.Location = new System.Drawing.Point(89, 208);
            this.apply_button.Name = "apply_button";
            this.apply_button.Size = new System.Drawing.Size(90, 30);
            this.apply_button.TabIndex = 2;
            this.apply_button.Text = "Apply";
            this.apply_button.UseVisualStyleBackColor = true;
            this.apply_button.Click += new System.EventHandler(this.Apply_button_Click);
            // 
            // MazeOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 250);
            this.Controls.Add(this.apply_button);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.solved_checkBox);
            this.Controls.Add(this.end_groupBox);
            this.Controls.Add(this.start_groupBox);
            this.Controls.Add(this.branching_groupBox);
            this.Controls.Add(this.size_groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MazeOptionsForm";
            this.Text = "Maze Parameters";
            this.Load += new System.EventHandler(this.MazeOptionsForm_Load);
            this.size_groupBox.ResumeLayout(false);
            this.size_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.y_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.x_numeric)).EndInit();
            this.start_groupBox.ResumeLayout(false);
            this.start_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.starty_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startx_numeric)).EndInit();
            this.end_groupBox.ResumeLayout(false);
            this.end_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endy_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endx_numeric)).EndInit();
            this.branching_groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.branching_factor_numeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox size_groupBox;
        private System.Windows.Forms.Label y_label;
        private System.Windows.Forms.Label x_label;
        private System.Windows.Forms.NumericUpDown y_numeric;
        private System.Windows.Forms.NumericUpDown x_numeric;
        private System.Windows.Forms.GroupBox start_groupBox;
        private System.Windows.Forms.Label starty_label;
        private System.Windows.Forms.Label startx_label;
        private System.Windows.Forms.NumericUpDown starty_numeric;
        private System.Windows.Forms.NumericUpDown startx_numeric;
        private System.Windows.Forms.GroupBox end_groupBox;
        private System.Windows.Forms.Label endy_label;
        private System.Windows.Forms.Label endx_label;
        private System.Windows.Forms.NumericUpDown endy_numeric;
        private System.Windows.Forms.NumericUpDown endx_numeric;
        private System.Windows.Forms.GroupBox branching_groupBox;
        private System.Windows.Forms.NumericUpDown branching_factor_numeric;
        private System.Windows.Forms.CheckBox solved_checkBox;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button apply_button;
    }
}