namespace QBD_2011
{
    partial class LoadingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingForm));
            this.LoagingImagePictureBox = new System.Windows.Forms.PictureBox();
            this.loadingStatusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LoagingImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LoagingImagePictureBox
            // 
            this.LoagingImagePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoagingImagePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("LoagingImagePictureBox.Image")));
            this.LoagingImagePictureBox.InitialImage = null;
            this.LoagingImagePictureBox.Location = new System.Drawing.Point(0, 0);
            this.LoagingImagePictureBox.Name = "LoagingImagePictureBox";
            this.LoagingImagePictureBox.Size = new System.Drawing.Size(397, 298);
            this.LoagingImagePictureBox.TabIndex = 0;
            this.LoagingImagePictureBox.TabStop = false;
            // 
            // loadingStatusLabel
            // 
            this.loadingStatusLabel.AutoSize = true;
            this.loadingStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.loadingStatusLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingStatusLabel.Location = new System.Drawing.Point(12, 276);
            this.loadingStatusLabel.Name = "loadingStatusLabel";
            this.loadingStatusLabel.Size = new System.Drawing.Size(73, 16);
            this.loadingStatusLabel.TabIndex = 1;
            this.loadingStatusLabel.Text = "Loading...";
            // 
            // LoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(397, 298);
            this.Controls.Add(this.loadingStatusLabel);
            this.Controls.Add(this.LoagingImagePictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoadingForm";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)(this.LoagingImagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox LoagingImagePictureBox;
        private System.Windows.Forms.Label loadingStatusLabel;
    }
}