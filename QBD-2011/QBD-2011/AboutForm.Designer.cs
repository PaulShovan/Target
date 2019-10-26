namespace QBD_2011
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.libLink = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox
            // 
            this.imageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBox.Image = ((System.Drawing.Image)(resources.GetObject("imageBox.Image")));
            this.imageBox.Location = new System.Drawing.Point(0, 0);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(603, 300);
            this.imageBox.TabIndex = 0;
            this.imageBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(456, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // libLink
            // 
            this.libLink.AutoSize = true;
            this.libLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.libLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.libLink.LinkColor = System.Drawing.Color.Blue;
            this.libLink.Location = new System.Drawing.Point(25, 265);
            this.libLink.Name = "libLink";
            this.libLink.Size = new System.Drawing.Size(131, 16);
            this.libLink.TabIndex = 2;
            this.libLink.TabStop = true;
            this.libLink.Text = "www.ipackbd.com";
            this.libLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.libLink_LinkClicked);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 300);
            this.Controls.Add(this.libLink);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.imageBox);
            this.Name = "AboutForm";
            this.Text = "About Us";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AboutForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel libLink;
    }
}