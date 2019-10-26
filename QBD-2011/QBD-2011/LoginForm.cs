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
    public partial class LoginForm : Form
    {
        MainForm mainForm = null;
        public LoginForm(MainForm main)
        {
            InitializeComponent();
            mainForm = main;
            dateTimeTextBox.Text = DateTime.Now.ToString();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            int doLogin = 0;
            Login login = new Login();
            Trainee aTrainee = new Trainee();
            DatabaseIDU database = new DatabaseIDU();
            if (userNameTextBox.Text == "" || passwordTextBox.Text == "")
                MessageBox.Show("Please Enter Username And Password");
            else
            {
                try
                {
                    login.UserName = userNameTextBox.Text;
                    login.Password = passwordTextBox.Text;
                    login.Role = roleComboBox.SelectedItem.ToString();
                    login.Now = Convert.ToDateTime(dateTimeTextBox.Text);
                    if (login.Role == "Others")
                    {
                        aTrainee = database.Login(login);
                        if (aTrainee.TraineeId != null)
                        {
                            Login.loginOther = 1;
                            Login.BaNo = aTrainee.BatchNo;
                            Login.ShooterName = aTrainee.TraineeName;
                            Login.TraineeId = aTrainee.TraineeId;
                            MessageBox.Show("You are successfully logged in.");
                            mainForm.SetMenuItem(1);
                            this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect username or password.Please try again");
                        }
                    }
                    else if (login.Role == "Admin")
                    {
                        int doneLogin = database.AdminLogin(login);
                        if (doneLogin == 1)
                        {
                            Login.loginAdmin = 1;
                            MessageBox.Show("You are successfully logged in.");
                            //MainForm main = new MainForm();
                            //Application.Run(main);
                            mainForm.SetMenuItem(1);
                            this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect username or password.Please try again.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occured...");
                    //throw new Exception("Error", ex);
                }
                
            }
        }
    }
}
