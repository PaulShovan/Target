using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using QBD_2011.Database.ShootingInfoTableAdapters;
using QBD_2011.Database;
using System.Data.SqlClient;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.Generic;


namespace QBD_2011
{
    class DatabaseIDU
    {
        protected SqlConnection connectionObj;
        protected SqlCommand commandObj;
        public DatabaseIDU()
        {
            string connectionString = @"server = qbd2011-pc\SQLEXPRESS; database = QBD_11; integrated security = sspi;";
            //connectionObj = new SqlConnection(ConfigurationManager.ConnectionStrings["QBDConnectionString"].ConnectionString);
            connectionObj = new SqlConnection(connectionString);
            //ConnectionState connectionState = connectionObj.State;
        }
         
        //ShootingTableTableAdapter taShootingTable = new ShootingTableTableAdapter();
        //List<ShootingInfo.ShootingTableRow> lstShootingTable = new List<ShootingInfo.ShootingTableRow>();
        public bool insert(ShootingData data)
        {
            int insertSuccess = 0;
            try
            {
                connectionObj.Open();
                string query = String.Format("INSERT INTO ShootRecord VALUES('" + data.TraineeId + "','"+data.BaNo+"','" + data.ShooterName + "','" + data.Now + "','" + data.Shots + "','" + data.Hits + "','" + data.AvgAccuracy + "','" + data.AvgGrouping + "','" + data.Refex + "','" + data.Summary + "','"+data.FileName+"')");
                commandObj = new SqlCommand(query, connectionObj);
                insertSuccess = commandObj.ExecuteNonQuery();
                connectionObj.Close();
                if (insertSuccess > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                throw new Exception("Error occured! data connection is not ready", e);
            }
            finally
            {
                connectionObj.Close();
            }
        }
        public Trainee Login(Login login)
        {
            int loginSuccess = 0;
            Trainee aTrainee = new Trainee();
            try
            {
                connectionObj.Open();
                string query = String.Format("SELECT * FROM Trainee WHERE TraineeUserName = '" + login.UserName + "' AND TraineePassword = '" + login.Password + "'");
                commandObj = new SqlCommand(query, connectionObj);
                SqlDataReader readerObj = commandObj.ExecuteReader();
                if (readerObj.Read())
                {
                    aTrainee.TraineeId = readerObj["TraineeId"].ToString();
                    aTrainee.TraineeName = readerObj["TraineeName"].ToString();
                    aTrainee.BatchNo = readerObj["TraineeBatchNo"].ToString();
                }
                readerObj.Close();
                connectionObj.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error occured data connection is not ready", e);
            }
            finally
            {
                connectionObj.Close();
            }
            return aTrainee;
        }
        public int AdminLogin(Login login)
        {
            int loginSuccess = 0;
            try
            {
                connectionObj.Open();
                string query = String.Format("SELECT * FROM Administrator WHERE Username = '" + login.UserName + "' AND Password = '" + login.Password + "'");
                commandObj = new SqlCommand(query, connectionObj);
                SqlDataReader readerObj = commandObj.ExecuteReader();
                if (readerObj.Read())
                {
                    loginSuccess = 1;
                }
                readerObj.Close();
                connectionObj.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error occured data connection is not ready", e);
            }
            finally
            {
                connectionObj.Close();
            }
            return loginSuccess;
        }
        public int Registration(Trainee trainee)
        {
            int doneRegistration = 0;
            try
            {
                connectionObj.Open();
                string query = String.Format("INSERT INTO Trainee(TraineeId,TraineeName,TraineeBatchNo,TraineeUserName,TraineePassword) VALUES('" + trainee.TraineeId + "','" + trainee.TraineeName + "','" + trainee.BatchNo + "','" + trainee.UserName + "','" + trainee.Password + "')");
                commandObj = new SqlCommand(query, connectionObj);
                doneRegistration = commandObj.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error in registration", e);
            }
            finally
            {
                connectionObj.Close();
            }
            return doneRegistration;
        }

        public Trainee CheckTrainee(Trainee trainee)
        {
            Trainee aTrainee = new Trainee();
            try
            {
                connectionObj.Open();
                string query = String.Format("SELECT * FROM Trainee WHERE TraineeUserName = '" + trainee.UserName + "' OR TraineeId = '" + trainee.TraineeId + "'");
                commandObj = new SqlCommand(query, connectionObj);
                SqlDataReader readerObj = commandObj.ExecuteReader();
                if (readerObj.Read())
                {
                    aTrainee.TraineeId = readerObj["TraineeId"].ToString();
                    aTrainee.UserName = readerObj["TraineeUserName"].ToString();
                }
                readerObj.Close();
                connectionObj.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error occured data connection is not ready", e);
            }
            finally
            {
                connectionObj.Close();
            }
            return aTrainee;
        }

        public List<ShootingData> GetShootingData()
        {
            List<ShootingData> allData = new List<ShootingData>();
            try
            {
                connectionObj.Open();
                string query = String.Format("SELECT * FROM ShootRecord");
                commandObj = new SqlCommand(query, connectionObj);
                SqlDataReader readerObj = commandObj.ExecuteReader();
                while (readerObj.Read())
                {
                    ShootingData data = new ShootingData();
                    data.Id = readerObj["id"].ToString();
                    data.TraineeId = readerObj["TraineeId"].ToString();
                    data.BaNo = readerObj["BaNo"].ToString();
                    data.ShooterName = readerObj["ShooterName"].ToString();
                    data.Now = readerObj["DateTime"].ToString();
                    data.Shots = readerObj["Shots"].ToString();
                    data.Hits = readerObj["Hits"].ToString();
                    data.AvgAccuracy = readerObj["AvgAccuracy"].ToString();
                    data.AvgGrouping = readerObj["AvgGrouping"].ToString();
                    data.Refex = readerObj["Refex"].ToString();
                    data.Summary = readerObj["Summary"].ToString();
                    data.FileName = readerObj["FileName"].ToString();
                    allData.Add(data);
                }
                readerObj.Close();
                connectionObj.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error occured data connection is not ready", e);
            }
            finally
            {
                connectionObj.Close();
            }
            return allData;
        }

        public string CountData(string traineeId)
        {
            string countData = "";
            int count = 0;
            try
            {
                connectionObj.Open();
                string query = String.Format("SELECT  * FROM ShootRecord WHERE TraineeId = '" + traineeId + "'");
                commandObj = new SqlCommand(query, connectionObj);
                SqlDataReader readerObj = commandObj.ExecuteReader();
                while (readerObj.Read())
                {
                    count++;
                }
                readerObj.Close();
                connectionObj.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error occured data connection is not ready", e);
            }
            finally
            {
                connectionObj.Close();
            }
            countData = count.ToString();
            return countData;
            
        }

        public List<ShootingData> GetShootingDataTrainee(string traineeId)
        {
            List<ShootingData> allData = new List<ShootingData>();
            try
            {
                connectionObj.Open();
                string query = String.Format("SELECT * FROM ShootRecord WHERE TraineeId = '"+traineeId+"'");
                commandObj = new SqlCommand(query, connectionObj);
                SqlDataReader readerObj = commandObj.ExecuteReader();
                while (readerObj.Read())
                {
                    ShootingData data = new ShootingData();
                    data.Id = readerObj["id"].ToString();
                    data.TraineeId = readerObj["TraineeId"].ToString();
                    data.BaNo = readerObj["BaNo"].ToString();
                    data.ShooterName = readerObj["ShooterName"].ToString();
                    data.Now = readerObj["DateTime"].ToString();
                    data.Shots = readerObj["Shots"].ToString();
                    data.Hits = readerObj["Hits"].ToString();
                    data.AvgAccuracy = readerObj["AvgAccuracy"].ToString();
                    data.AvgGrouping = readerObj["AvgGrouping"].ToString();
                    data.Refex = readerObj["Refex"].ToString();
                    data.Summary = readerObj["Summary"].ToString();
                    data.FileName = readerObj["FileName"].ToString();
                    allData.Add(data);
                }
                readerObj.Close();
                connectionObj.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error occured data connection is not ready", e);
            }
            finally
            {
                connectionObj.Close();
            }
            return allData;
        }

        public int DeleteRecord(string fileName)
        {
            int doneDelete = 0;
            try
            {
                connectionObj.Open();
                string query = String.Format("DELETE FROM ShootRecord WHERE FileName = '"+fileName+"'");
                commandObj = new SqlCommand(query, connectionObj);
                doneDelete = commandObj.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error occured while delete the record.", e);
            }
            finally
            {
                connectionObj.Close();
            }
            return doneDelete;
        }
    }
}
