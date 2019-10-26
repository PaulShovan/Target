namespace QBD_2011
{
    partial class DataRecords
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
            this.shootDataGridView = new System.Windows.Forms.DataGridView();
            this.buttonColoumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.shootDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // shootDataGridView
            // 
            this.shootDataGridView.AllowUserToAddRows = false;
            this.shootDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.shootDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shootDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.buttonColoumn});
            this.shootDataGridView.Location = new System.Drawing.Point(0, 0);
            this.shootDataGridView.Name = "shootDataGridView";
            this.shootDataGridView.Size = new System.Drawing.Size(1208, 398);
            this.shootDataGridView.TabIndex = 0;
            this.shootDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.shootDataGridView_CellContentClick);
            // 
            // buttonColoumn
            // 
            this.buttonColoumn.HeaderText = "Show";
            this.buttonColoumn.Name = "buttonColoumn";
            this.buttonColoumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.buttonColoumn.Text = "Replay";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(546, 403);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // DataRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 438);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.shootDataGridView);
            this.Name = "DataRecords";
            this.Text = "DataRecords";
            ((System.ComponentModel.ISupportInitialize)(this.shootDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView shootDataGridView;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.DataGridViewButtonColumn buttonColoumn;
    }
}