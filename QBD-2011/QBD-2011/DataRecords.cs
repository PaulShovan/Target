using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QBD_2011
{
    public partial class DataRecords : Form
    {
        public DataRecords()
        {
            InitializeComponent();
            List<ShootingData> allData = new List<ShootingData>();
            DatabaseIDU db = new DatabaseIDU();

            if (Login.loginAdmin == 1)
            {
                allData = db.GetShootingData();
                shootDataGridView.DataSource = allData;
            }
            else if(Login.loginOther == 1)
            {
                allData = db.GetShootingDataTrainee(Login.TraineeId);
                shootDataGridView.DataSource = allData;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void shootDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string data = shootDataGridView.Rows[e.RowIndex].Cells[12].Value.ToString();
            ReplayForm replay = new ReplayForm(data);
            replay.Visible = true;
            //shootDataGridView.Rows[e.RowIndex].Cells[1]
        }
    }
}
