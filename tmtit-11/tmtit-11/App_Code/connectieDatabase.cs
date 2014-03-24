using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace tmtit_11.App_Code
{
    public class connectieDatabase
    {
        protected OleDbDataAdapter dataAdapter1 = new OleDbDataAdapter();
        public string errorBericht = "";
        public connectieDatabase(string connectionString)
        {
            OleDbConnection connectieDatabase = new OleDbConnection(connectionString);
            this.dataAdapter1.SelectCommand = new OleDbCommand("", connectieDatabase);
            this.dataAdapter1.InsertCommand = new OleDbCommand("", connectieDatabase);
        }

        public DataTable dataSelecteren(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                dataAdapter1.SelectCommand.CommandText = query;
                dataAdapter1.SelectCommand.Connection.Open();
                dataAdapter1.SelectCommand.ExecuteScalar().ToString();
                dataAdapter1.Fill(dt);
                dataAdapter1.SelectCommand.Connection.Close();
                errorBericht = "";
            }
            catch (Exception error)
            {
                errorBericht = error.Message;
                dataAdapter1.SelectCommand.Connection.Close();
            }
            finally
            {
                dataAdapter1.SelectCommand.Connection.Close();
            }
            return dt;
        }

        public int dataInvoegen(string query)
        {
            int resultaat = 0;
            try
            {
                dataAdapter1.InsertCommand.CommandText = query;
                dataAdapter1.InsertCommand.Connection.Open();
                resultaat = dataAdapter1.InsertCommand.ExecuteNonQuery();
                dataAdapter1.InsertCommand.Connection.Close();
                errorBericht = "";
                return resultaat;
            }
            catch (Exception error)
            {
                errorBericht = error.Message;
                dataAdapter1.InsertCommand.Connection.Close();
                return 0;
            }
            finally
            {
                dataAdapter1.SelectCommand.Connection.Close();
            }
        }

        public int dataUpdate(string query)
        {
            return dataInvoegen(query);
        }

        public int dataDelete(string query)
        {
            return dataInvoegen(query);
        }
    }
}