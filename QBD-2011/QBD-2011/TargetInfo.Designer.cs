namespace QBD_2011
{
    partial class TargetInfo
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
            this.totalShoot = new System.Windows.Forms.Label();
            this.shootCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // totalShoot
            // 
            this.totalShoot.AutoSize = true;
            this.totalShoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalShoot.Location = new System.Drawing.Point(133, 45);
            this.totalShoot.Name = "totalShoot";
            this.totalShoot.Size = new System.Drawing.Size(63, 31);
            this.totalShoot.TabIndex = 0;
            this.totalShoot.Text = "/ 05";
            // 
            // shootCount
            // 
            this.shootCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.shootCount.AutoSize = true;
            this.shootCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shootCount.ForeColor = System.Drawing.Color.Crimson;
            this.shootCount.Location = new System.Drawing.Point(47, 45);
            this.shootCount.Name = "shootCount";
            this.shootCount.Size = new System.Drawing.Size(80, 55);
            this.shootCount.TabIndex = 1;
            this.shootCount.Text = "05";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(67, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "HITS!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(146, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Total";
            // 
            // TargetInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shootCount);
            this.Controls.Add(this.totalShoot);
            this.Name = "TargetInfo";
            this.Size = new System.Drawing.Size(226, 114);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label totalShoot;
        private System.Windows.Forms.Label shootCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
