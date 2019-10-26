namespace QBD_2011
{
    partial class ShootSettinsForm
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
            this.shootPromptLabel = new System.Windows.Forms.Label();
            this.fixedRadioButton = new System.Windows.Forms.RadioButton();
            this.unlimitedRadioButton = new System.Windows.Forms.RadioButton();
            this.oKbutton = new System.Windows.Forms.Button();
            this.shootNumberLabel = new System.Windows.Forms.Label();
            this.shootTextBox = new System.Windows.Forms.TextBox();
            this.shootByTrigerRadioButton = new System.Windows.Forms.RadioButton();
            this.shootBySradioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // shootPromptLabel
            // 
            this.shootPromptLabel.AutoSize = true;
            this.shootPromptLabel.Location = new System.Drawing.Point(12, 26);
            this.shootPromptLabel.Name = "shootPromptLabel";
            this.shootPromptLabel.Size = new System.Drawing.Size(101, 13);
            this.shootPromptLabel.TabIndex = 0;
            this.shootPromptLabel.Text = "Select Shoot Type: ";
            // 
            // fixedRadioButton
            // 
            this.fixedRadioButton.AutoSize = true;
            this.fixedRadioButton.Location = new System.Drawing.Point(131, 22);
            this.fixedRadioButton.Name = "fixedRadioButton";
            this.fixedRadioButton.Size = new System.Drawing.Size(50, 17);
            this.fixedRadioButton.TabIndex = 1;
            this.fixedRadioButton.Text = "Fixed";
            this.fixedRadioButton.UseVisualStyleBackColor = true;
            this.fixedRadioButton.CheckedChanged += new System.EventHandler(this.fixedRadioButton_CheckedChanged);
            // 
            // unlimitedRadioButton
            // 
            this.unlimitedRadioButton.AutoSize = true;
            this.unlimitedRadioButton.Checked = true;
            this.unlimitedRadioButton.Location = new System.Drawing.Point(208, 22);
            this.unlimitedRadioButton.Name = "unlimitedRadioButton";
            this.unlimitedRadioButton.Size = new System.Drawing.Size(64, 17);
            this.unlimitedRadioButton.TabIndex = 2;
            this.unlimitedRadioButton.TabStop = true;
            this.unlimitedRadioButton.Text = "Practice";
            this.unlimitedRadioButton.UseVisualStyleBackColor = true;
            this.unlimitedRadioButton.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // oKbutton
            // 
            this.oKbutton.Location = new System.Drawing.Point(106, 214);
            this.oKbutton.Name = "oKbutton";
            this.oKbutton.Size = new System.Drawing.Size(75, 23);
            this.oKbutton.TabIndex = 3;
            this.oKbutton.Text = "OK";
            this.oKbutton.UseVisualStyleBackColor = true;
            this.oKbutton.Click += new System.EventHandler(this.oKbutton_Click);
            // 
            // shootNumberLabel
            // 
            this.shootNumberLabel.AutoSize = true;
            this.shootNumberLabel.Location = new System.Drawing.Point(19, 78);
            this.shootNumberLabel.Name = "shootNumberLabel";
            this.shootNumberLabel.Size = new System.Drawing.Size(94, 13);
            this.shootNumberLabel.TabIndex = 4;
            this.shootNumberLabel.Text = "How many shoots:";
            // 
            // shootTextBox
            // 
            this.shootTextBox.Enabled = false;
            this.shootTextBox.Location = new System.Drawing.Point(127, 75);
            this.shootTextBox.Name = "shootTextBox";
            this.shootTextBox.Size = new System.Drawing.Size(145, 20);
            this.shootTextBox.TabIndex = 5;
            this.shootTextBox.Text = "10";
            // 
            // shootByTrigerRadioButton
            // 
            this.shootByTrigerRadioButton.AutoSize = true;
            this.shootByTrigerRadioButton.Checked = true;
            this.shootByTrigerRadioButton.Location = new System.Drawing.Point(62, 19);
            this.shootByTrigerRadioButton.Name = "shootByTrigerRadioButton";
            this.shootByTrigerRadioButton.Size = new System.Drawing.Size(125, 17);
            this.shootByTrigerRadioButton.TabIndex = 6;
            this.shootByTrigerRadioButton.TabStop = true;
            this.shootByTrigerRadioButton.Text = "Shoot by press Triger";
            this.shootByTrigerRadioButton.UseVisualStyleBackColor = true;
            // 
            // shootBySradioButton
            // 
            this.shootBySradioButton.AutoSize = true;
            this.shootBySradioButton.Location = new System.Drawing.Point(62, 42);
            this.shootBySradioButton.Name = "shootBySradioButton";
            this.shootBySradioButton.Size = new System.Drawing.Size(109, 17);
            this.shootBySradioButton.TabIndex = 7;
            this.shootBySradioButton.Text = "Shoot by press \'S\'";
            this.shootBySradioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.shootByTrigerRadioButton);
            this.groupBox1.Controls.Add(this.shootBySradioButton);
            this.groupBox1.Location = new System.Drawing.Point(22, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 68);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // ShootSettinsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 249);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.shootTextBox);
            this.Controls.Add(this.shootNumberLabel);
            this.Controls.Add(this.oKbutton);
            this.Controls.Add(this.unlimitedRadioButton);
            this.Controls.Add(this.fixedRadioButton);
            this.Controls.Add(this.shootPromptLabel);
            this.Name = "ShootSettinsForm";
            this.Text = "Shoot Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label shootPromptLabel;
        private System.Windows.Forms.RadioButton fixedRadioButton;
        private System.Windows.Forms.RadioButton unlimitedRadioButton;
        private System.Windows.Forms.Button oKbutton;
        private System.Windows.Forms.Label shootNumberLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox shootTextBox;
        public System.Windows.Forms.RadioButton shootByTrigerRadioButton;
        public System.Windows.Forms.RadioButton shootBySradioButton;
    }
}