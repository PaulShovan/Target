using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QBD_2011.Database
{
    public static class DatabaseConnection
    {
        public static System.Data.OleDb.OleDbConnection conn = null;
        public DatabaseConnection()
        {
            conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                                    @"Data source= G:\Target\kjhkh\QBD-2011\QBD-2011\QBD-2011"
        }
    }
}
