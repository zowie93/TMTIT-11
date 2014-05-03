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

        public DataTable dataSelecteren2(string query)
        {
            DataTable dt2 = new DataTable();
            try
            {
                dataAdapter1.SelectCommand.CommandText = query;
                dataAdapter1.SelectCommand.Connection.Open();
                dataAdapter1.SelectCommand.ExecuteScalar().ToString();
                dataAdapter1.Fill(dt2);
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
            return dt2;
        }

        public DataTable dataSelecteren3(string query)
        {
            DataTable dt3 = new DataTable();
            try
            {
                dataAdapter1.SelectCommand.CommandText = query;
                dataAdapter1.SelectCommand.Connection.Open();
                dataAdapter1.SelectCommand.ExecuteScalar().ToString();
                dataAdapter1.Fill(dt3);
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
            return dt3;
        }

        public DataTable dataSelecteren4(string query)
        {
            DataTable dt4 = new DataTable();
            try
            {
                dataAdapter1.SelectCommand.CommandText = query;
                dataAdapter1.SelectCommand.Connection.Open();
                dataAdapter1.SelectCommand.ExecuteScalar().ToString();
                dataAdapter1.Fill(dt4);
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
            return dt4;
        }

        public DataTable dataSelecteren5(string query)
        {
            DataTable dt5 = new DataTable();
            try
            {
                dataAdapter1.SelectCommand.CommandText = query;
                dataAdapter1.SelectCommand.Connection.Open();
                dataAdapter1.SelectCommand.ExecuteScalar().ToString();
                dataAdapter1.Fill(dt5);
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
            return dt5;
        }

        public DataTable dataSelecteren6(string query)
        {
            DataTable dt6 = new DataTable();
            DataTable dt7 = new DataTable();
            DataTable dt8 = new DataTable();
            DataTable dt9 = new DataTable();
            try
            {
                dataAdapter1.SelectCommand.CommandText = query;
                dataAdapter1.SelectCommand.Connection.Open();
                dataAdapter1.SelectCommand.ExecuteScalar().ToString();
                dataAdapter1.Fill(dt6);
                dataAdapter1.Fill(dt7);
                dataAdapter1.Fill(dt8);
                dataAdapter1.Fill(dt9);
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
            return dt6;
            return dt7;
            return dt8;
            return dt9;
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
            int resultaat2 = 0;
            try
            {
                dataAdapter1.UpdateCommand.CommandText = query;
                dataAdapter1.UpdateCommand.Connection.Open();
                resultaat2 = dataAdapter1.UpdateCommand.ExecuteNonQuery();
                dataAdapter1.UpdateCommand.Connection.Close();
                errorBericht = "";
                return resultaat2;
            }
            catch (Exception error)
            {
                errorBericht = error.Message;
                dataAdapter1.UpdateCommand.Connection.Close();
                return 0;
            }
            finally
            {
                dataAdapter1.SelectCommand.Connection.Close();
            }
        }

        public int dataDelete(string query)
        {
            return dataInvoegen(query);
        }
    }
}