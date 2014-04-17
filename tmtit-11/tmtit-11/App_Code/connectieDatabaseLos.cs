using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

namespace tmtit_11.App_Code
{
    public class connectieDatabaseLos
    {
        public OleDbConnection connectieDatabaseLosFunc()
        {
            String connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb";

            OleDbConnection connectieLos = new OleDbConnection(connectionString);

            return connectieLos;
        }

        public void databaseOpen(OleDbConnection con)
        {
            con.Open();
        }

        public void databaseClose(OleDbConnection con)
        {
            con.Close();
        }
    }
}