using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace QBD_2011
{
    public partial class DeleteRecords : Form
    {
        DatabaseIDU db = new DatabaseIDU();
        int delete = 0;
        List<ShootingData> allData = new List<ShootingData>();
        public DeleteRecords()
        {
            InitializeComponent();
            if (Login.loginAdmin == 1)
            {
                ShowData();
            }
        }
        public void ShowData()
        {
            allData = db.GetShootingData();
            dataGridView1.DataSource = allData;
        }
        public void DeleteText(string fileName)
        {
            if (File.Exists(Login.fileName + fileName + "Log" + ".txt"))
            {
                File.Delete(Login.fileName + fileName + "Log" + ".txt");
            }
            if (File.Exists(Login.fileName + fileName + ".txt"))
            {
                File.Delete(Login.fileName + fileName + ".txt");
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string fileName = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            try
            {
                delete = db.DeleteRecord(fileName);
                if (delete > 0)
                {
                    MessageBox.Show("File has been deleted.");
                    DeleteText(fileName);
                    ShowData();
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show("Sorry,File Cannot be deleted.");
            }
            
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }   
    }
}
