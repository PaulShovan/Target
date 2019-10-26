namespace QBD_2011
{
    partial class TimeSettingsForm
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
            this.counterRadioButton = new System.Windows.Forms.RadioButton();
            this.unlimitedRadioButton = new System.Windows.Forms.RadioButton();
            this.minNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.secondNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.minLabel = new System.Windows.Forms.Label();
            this.secondLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.timeGroupBox = new System.Windows.Forms.GroupBox();
            this.promptLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.minNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondNumericUpDown)).BeginInit();
            this.timeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // counterRadioButton
            // 
            this.counterRadioButton.AutoSize = true;
            this.counterRadioButton.Location = new System.Drawing.Point(138, 15);
            this.counterRadioButton.Name = "counterRadioButton";
            this.counterRadioButton.Size = new System.Drawing.Size(51, 17);
            this.counterRadioButton.TabIndex = 1;
            this.counterRadioButton.TabStop = true;
            this.counterRadioButton.Text = "Timer";
            this.counterRadioButton.UseVisualStyleBackColor = true;
            this.counterRadioButton.CheckedChanged += new System.EventHandler(this.counterRadioButton_CheckedChanged);
            // 
            // unlimitedRadioButton
            // 
            this.unlimitedRadioButton.AutoSize = true;
            this.unlimitedRadioButton.Location = new System.Drawing.Point(217, 15);
            this.unlimitedRadioButton.Name = "unlimitedRadioButton";
            this.unlimitedRadioButton.Size = new System.Drawing.Size(62, 17);
            this.unlimitedRadioButton.TabIndex = 2;
            this.unlimitedRadioButton.TabStop = true;
            this.unlimitedRadioButton.Text = "Counter";
            this.unlimitedRadioButton.UseVisualStyleBackColor = true;
            this.unlimitedRadioButton.CheckedChanged += new System.EventHandler(this.unlimitedRadioButton_CheckedChanged);
            // 
            // minNumericUpDown
            // 
            this.minNumericUpDown.Location = new System.Drawing.Point(118, 19);
            this.minNumericUpDown.Name = "minNumericUpDown";
            this.minNumericUpDown.Size = new System.Drawing.Size(56, 20);
            this.minNumericUpDown.TabIndex = 3;
            // 
            // secondNumericUpDown
            // 
            this.secondNumericUpDown.Location = new System.Drawing.Point(118, 58);
            this.secondNumericUpDown.Name = "secondNumericUpDown";
            this.secondNumericUpDown.Size = new System.Drawing.Size(56, 20);
            this.secondNumericUpDown.TabIndex = 4;
            // 
            // minLabel
            // 
            this.minLabel.AutoSize = true;
            this.minLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minLabel.Location = new System.Drawing.Point(28, 26);
            this.minLabel.Name = "minLabel";
            this.minLabel.Size = new System.Drawing.Size(44, 13);
            this.minLabel.TabIndex = 5;
            this.minLabel.Text = "Minutes";
            // 
            // secondLabel
            // 
            this.secondLabel.AutoSize = true;
            this.secondLabel.Location = new System.Drawing.Point(23, 59);
            this.secondLabel.Name = "secondLabel";
            this.secondLabel.Size = new System.Drawing.Size(49, 13);
            this.secondLabel.TabIndex = 6;
            this.secondLabel.Text = "Seconds";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(129, 182);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // timeGroupBox
            // 
            this.timeGroupBox.Controls.Add(this.secondNumericUpDown);
            this.timeGroupBox.Controls.Add(this.minNumericUpDown);
            this.timeGroupBox.Controls.Add(this.minLabel);
            this.timeGroupBox.Controls.Add(this.secondLabel);
            this.timeGroupBox.Location = new System.Drawing.Point(63, 58);
            this.timeGroupBox.Name = "timeGroupBox";
            this.timeGroupBox.Size = new System.Drawing.Size(200, 100);
            this.timeGroupBox.TabIndex = 8;
            this.timeGroupBox.TabStop = false;
            // 
            // promptLabel
            // 
            this.promptLabel.AutoSize = true;
            this.promptLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.promptLabel.Location = new System.Drawing.Point(30, 17);
            this.promptLabel.Name = "promptLabel";
            this.promptLabel.Size = new System.Drawing.Size(88, 13);
            this.promptLabel.TabIndex = 9;
            this.promptLabel.Text = "Select time type: ";
            // 
            // TimeSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 217);
            this.Controls.Add(this.promptLabel);
            this.Controls.Add(this.timeGroupBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.unlimitedRadioButton);
            this.Controls.Add(this.counterRadioButton);
            this.Name = "TimeSettingsForm";
            this.Text = "Time Settings";
            ((System.ComponentModel.ISupportInitialize)(this.minNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondNumericUpDown)).EndInit();
            this.timeGroupBox.ResumeLayout(false);
            this.timeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton counterRadioButton;
        private System.Windows.Forms.RadioButton unlimitedRadioButton;
        private System.Windows.Forms.NumericUpDown minNumericUpDown;
        private System.Windows.Forms.NumericUpDown secondNumericUpDown;
        private System.Windows.Forms.Label minLabel;
        private System.Windows.Forms.Label secondLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox timeGroupBox;
        private System.Windows.Forms.Label promptLabel;
    }
}