namespace QBD_2011
{
    partial class RegistrationForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.nameTaxtBox = new System.Windows.Forms.TextBox();
            this.batchTaxtBox = new System.Windows.Forms.TextBox();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.rePasswordTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.registrationButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trainee Id :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name       :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Batch No :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Username :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Password :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Repeat Password :";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(21, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 163);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic Information";
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(106, 35);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(214, 20);
            this.idTextBox.TabIndex = 7;
            // 
            // nameTaxtBox
            // 
            this.nameTaxtBox.Location = new System.Drawing.Point(106, 76);
            this.nameTaxtBox.Name = "nameTaxtBox";
            this.nameTaxtBox.Size = new System.Drawing.Size(214, 20);
            this.nameTaxtBox.TabIndex = 8;
            // 
            // batchTaxtBox
            // 
            this.batchTaxtBox.Location = new System.Drawing.Point(106, 116);
            this.batchTaxtBox.Name = "batchTaxtBox";
            this.batchTaxtBox.Size = new System.Drawing.Size(214, 20);
            this.batchTaxtBox.TabIndex = 9;
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(126, 32);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(173, 20);
            this.userNameTextBox.TabIndex = 10;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(126, 76);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(173, 20);
            this.passwordTextBox.TabIndex = 11;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // rePasswordTextBox
            // 
            this.rePasswordTextBox.Location = new System.Drawing.Point(147, 300);
            this.rePasswordTextBox.Name = "rePasswordTextBox";
            this.rePasswordTextBox.Size = new System.Drawing.Size(173, 20);
            this.rePasswordTextBox.TabIndex = 12;
            this.rePasswordTextBox.UseSystemPasswordChar = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.userNameTextBox);
            this.groupBox2.Controls.Add(this.passwordTextBox);
            this.groupBox2.Location = new System.Drawing.Point(21, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(401, 190);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Login Information";
            // 
            // registrationButton
            // 
            this.registrationButton.Location = new System.Drawing.Point(21, 404);
            this.registrationButton.Name = "registrationButton";
            this.registrationButton.Size = new System.Drawing.Size(120, 42);
            this.registrationButton.TabIndex = 14;
            this.registrationButton.Text = "Ok";
            this.registrationButton.UseVisualStyleBackColor = true;
            this.registrationButton.Click += new System.EventHandler(this.registrationButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(285, 404);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(120, 42);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 480);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.registrationButton);
            this.Controls.Add(this.rePasswordTextBox);
            this.Controls.Add(this.batchTaxtBox);
            this.Controls.Add(this.nameTaxtBox);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "RegistrationForm";
            this.Text = "RegistrationForm";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox nameTaxtBox;
        private System.Windows.Forms.TextBox batchTaxtBox;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox rePasswordTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button registrationButton;
        private System.Windows.Forms.Button cancelButton;
    }
}