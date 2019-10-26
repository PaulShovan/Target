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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void registrationButton_Click(object sender, EventArgs e)
        {
            int doReg = 0;
            Trainee hasTrainee = new Trainee();
            DatabaseIDU database = new DatabaseIDU();
            try
            {
                if (passwordTextBox.Text == rePasswordTextBox.Text)
                {
                    Trainee trainee = new Trainee();
                    trainee.TraineeId = idTextBox.Text;
                    trainee.TraineeName = nameTaxtBox.Text;
                    trainee.BatchNo = batchTaxtBox.Text;
                    trainee.UserName = userNameTextBox.Text;
                    trainee.Password = passwordTextBox.Text;
                    hasTrainee = database.CheckTrainee(trainee);
                    if (hasTrainee.UserName == trainee.UserName)
                    {
                        MessageBox.Show("Username already exists.Please try another one.");
                    }
                    else if (hasTrainee.TraineeId == trainee.TraineeId)
                    {
                        MessageBox.Show("Trainee id must be unique.");
                    }
                    else
                    {
                        doReg = database.Registration(trainee);
                        if (doReg > 0)
                        {
                            MessageBox.Show("Registration successful.");
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Password did not match.");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured.");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
