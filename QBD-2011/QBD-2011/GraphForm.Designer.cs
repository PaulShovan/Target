namespace QBD_2011
{
    partial class GraphForm
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
            this.components = new System.ComponentModel.Container();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.distanceZedGraphControl = new ZedGraph.ZedGraphControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.circlezedGraphControl = new ZedGraph.ZedGraphControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.timeZedGraphControl = new ZedGraph.ZedGraphControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.averagePanel = new System.Windows.Forms.Panel();
            this.avgLabel = new System.Windows.Forms.Label();
            this.totalTimeLabel = new System.Windows.Forms.Label();
            this.groupLabel = new System.Windows.Forms.Label();
            this.distLabel = new System.Windows.Forms.Label();
            this.hitsLabel = new System.Windows.Forms.Label();
            this.shotsLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.accImg = new System.Windows.Forms.PictureBox();
            this.avgImage = new System.Windows.Forms.PictureBox();
            this.grpImg = new System.Windows.Forms.PictureBox();
            this.refImg = new System.Windows.Forms.PictureBox();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.averagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.avgImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refImg)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(590, 314);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.accImg);
            this.tabPage1.Controls.Add(this.distanceZedGraphControl);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(582, 288);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Accuracy";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // distanceZedGraphControl
            // 
            this.distanceZedGraphControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.distanceZedGraphControl.Location = new System.Drawing.Point(3, 3);
            this.distanceZedGraphControl.Name = "distanceZedGraphControl";
            this.distanceZedGraphControl.ScrollGrace = 0;
            this.distanceZedGraphControl.ScrollMaxX = 0;
            this.distanceZedGraphControl.ScrollMaxY = 0;
            this.distanceZedGraphControl.ScrollMaxY2 = 0;
            this.distanceZedGraphControl.ScrollMinX = 0;
            this.distanceZedGraphControl.ScrollMinY = 0;
            this.distanceZedGraphControl.ScrollMinY2 = 0;
            this.distanceZedGraphControl.Size = new System.Drawing.Size(576, 282);
            this.distanceZedGraphControl.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grpImg);
            this.tabPage2.Controls.Add(this.circlezedGraphControl);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(582, 288);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Grouping";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // circlezedGraphControl
            // 
            this.circlezedGraphControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.circlezedGraphControl.Location = new System.Drawing.Point(3, 3);
            this.circlezedGraphControl.Name = "circlezedGraphControl";
            this.circlezedGraphControl.ScrollGrace = 0;
            this.circlezedGraphControl.ScrollMaxX = 0;
            this.circlezedGraphControl.ScrollMaxY = 0;
            this.circlezedGraphControl.ScrollMaxY2 = 0;
            this.circlezedGraphControl.ScrollMinX = 0;
            this.circlezedGraphControl.ScrollMinY = 0;
            this.circlezedGraphControl.ScrollMinY2 = 0;
            this.circlezedGraphControl.Size = new System.Drawing.Size(576, 282);
            this.circlezedGraphControl.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.refImg);
            this.tabPage3.Controls.Add(this.timeZedGraphControl);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(582, 288);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Reflex";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // timeZedGraphControl
            // 
            this.timeZedGraphControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeZedGraphControl.Location = new System.Drawing.Point(0, 0);
            this.timeZedGraphControl.Name = "timeZedGraphControl";
            this.timeZedGraphControl.ScrollGrace = 0;
            this.timeZedGraphControl.ScrollMaxX = 0;
            this.timeZedGraphControl.ScrollMaxY = 0;
            this.timeZedGraphControl.ScrollMaxY2 = 0;
            this.timeZedGraphControl.ScrollMinX = 0;
            this.timeZedGraphControl.ScrollMinY = 0;
            this.timeZedGraphControl.ScrollMinY2 = 0;
            this.timeZedGraphControl.Size = new System.Drawing.Size(582, 288);
            this.timeZedGraphControl.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.averagePanel);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(582, 288);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Summary";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // averagePanel
            // 
            this.averagePanel.Controls.Add(this.avgImage);
            this.averagePanel.Controls.Add(this.avgLabel);
            this.averagePanel.Controls.Add(this.totalTimeLabel);
            this.averagePanel.Controls.Add(this.groupLabel);
            this.averagePanel.Controls.Add(this.distLabel);
            this.averagePanel.Controls.Add(this.hitsLabel);
            this.averagePanel.Controls.Add(this.shotsLabel);
            this.averagePanel.Controls.Add(this.label7);
            this.averagePanel.Controls.Add(this.label6);
            this.averagePanel.Controls.Add(this.label5);
            this.averagePanel.Controls.Add(this.label4);
            this.averagePanel.Controls.Add(this.label3);
            this.averagePanel.Controls.Add(this.label2);
            this.averagePanel.Controls.Add(this.label1);
            this.averagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.averagePanel.Location = new System.Drawing.Point(0, 0);
            this.averagePanel.Name = "averagePanel";
            this.averagePanel.Size = new System.Drawing.Size(582, 288);
            this.averagePanel.TabIndex = 0;
            // 
            // avgLabel
            // 
            this.avgLabel.AutoSize = true;
            this.avgLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgLabel.Location = new System.Drawing.Point(418, 122);
            this.avgLabel.Name = "avgLabel";
            this.avgLabel.Size = new System.Drawing.Size(39, 42);
            this.avgLabel.TabIndex = 12;
            this.avgLabel.Text = "0";
            // 
            // totalTimeLabel
            // 
            this.totalTimeLabel.AutoSize = true;
            this.totalTimeLabel.Location = new System.Drawing.Point(171, 184);
            this.totalTimeLabel.Name = "totalTimeLabel";
            this.totalTimeLabel.Size = new System.Drawing.Size(37, 13);
            this.totalTimeLabel.TabIndex = 11;
            this.totalTimeLabel.Text = "(none)";
            // 
            // groupLabel
            // 
            this.groupLabel.AutoSize = true;
            this.groupLabel.Location = new System.Drawing.Point(171, 149);
            this.groupLabel.Name = "groupLabel";
            this.groupLabel.Size = new System.Drawing.Size(37, 13);
            this.groupLabel.TabIndex = 10;
            this.groupLabel.Text = "(none)";
            // 
            // distLabel
            // 
            this.distLabel.AutoSize = true;
            this.distLabel.Location = new System.Drawing.Point(171, 116);
            this.distLabel.Name = "distLabel";
            this.distLabel.Size = new System.Drawing.Size(37, 13);
            this.distLabel.TabIndex = 9;
            this.distLabel.Text = "(none)";
            // 
            // hitsLabel
            // 
            this.hitsLabel.AutoSize = true;
            this.hitsLabel.Location = new System.Drawing.Point(171, 82);
            this.hitsLabel.Name = "hitsLabel";
            this.hitsLabel.Size = new System.Drawing.Size(37, 13);
            this.hitsLabel.TabIndex = 8;
            this.hitsLabel.Text = "(none)";
            // 
            // shotsLabel
            // 
            this.shotsLabel.AutoSize = true;
            this.shotsLabel.Location = new System.Drawing.Point(171, 54);
            this.shotsLabel.Name = "shotsLabel";
            this.shotsLabel.Size = new System.Drawing.Size(37, 13);
            this.shotsLabel.TabIndex = 7;
            this.shotsLabel.Text = "(none)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.OliveDrab;
            this.label7.Location = new System.Drawing.Point(267, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 31);
            this.label7.TabIndex = 6;
            this.label7.Text = "Summary:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Reflex : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Average Accuracy:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Average Grouping : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hits :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Shots : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Summary:";
            // 
            // accImg
            // 
            this.accImg.Image = global::QBD_2011.Properties.Resources.red_dot;
            this.accImg.Location = new System.Drawing.Point(518, 34);
            this.accImg.Name = "accImg";
            this.accImg.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.accImg.Size = new System.Drawing.Size(45, 42);
            this.accImg.TabIndex = 1;
            this.accImg.TabStop = false;
            // 
            // avgImage
            // 
            this.avgImage.Image = global::QBD_2011.Properties.Resources.red;
            this.avgImage.Location = new System.Drawing.Point(488, 94);
            this.avgImage.Name = "avgImage";
            this.avgImage.Size = new System.Drawing.Size(43, 103);
            this.avgImage.TabIndex = 13;
            this.avgImage.TabStop = false;
            // 
            // grpImg
            // 
            this.grpImg.Image = global::QBD_2011.Properties.Resources.red_dot;
            this.grpImg.Location = new System.Drawing.Point(518, 34);
            this.grpImg.Name = "grpImg";
            this.grpImg.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.grpImg.Size = new System.Drawing.Size(45, 42);
            this.grpImg.TabIndex = 2;
            this.grpImg.TabStop = false;
            // 
            // refImg
            // 
            this.refImg.Image = global::QBD_2011.Properties.Resources.red_dot;
            this.refImg.Location = new System.Drawing.Point(519, 30);
            this.refImg.Name = "refImg";
            this.refImg.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.refImg.Size = new System.Drawing.Size(45, 42);
            this.refImg.TabIndex = 2;
            this.refImg.TabStop = false;
            // 
            // GraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 314);
            this.Controls.Add(this.tabControl);
            this.Name = "GraphForm";
            this.Text = "Summary";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GraphForm_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.averagePanel.ResumeLayout(false);
            this.averagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.avgImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ZedGraph.ZedGraphControl distanceZedGraphControl;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private ZedGraph.ZedGraphControl circlezedGraphControl;
        private ZedGraph.ZedGraphControl timeZedGraphControl;
        private System.Windows.Forms.Panel averagePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label groupLabel;
        private System.Windows.Forms.Label distLabel;
        private System.Windows.Forms.Label hitsLabel;
        private System.Windows.Forms.Label shotsLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label avgLabel;
        private System.Windows.Forms.Label totalTimeLabel;
        public System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.PictureBox avgImage;
        private System.Windows.Forms.PictureBox accImg;
        private System.Windows.Forms.PictureBox grpImg;
        private System.Windows.Forms.PictureBox refImg;

    }
}