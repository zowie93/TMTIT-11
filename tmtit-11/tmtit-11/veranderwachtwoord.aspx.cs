using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using tmtit_11.App_Code;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace tmtit_11
{
    public partial class veranderwachtwoord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.Request.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }
        }

        public String HashPassword(String password, String salt)
        {
            var combinedPassword = String.Concat(password, salt);
            var sha256 = new SHA256Managed();
            var bytes = UTF8Encoding.UTF8.GetBytes(combinedPassword);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public String GetRandomSalt(Int32 size = 12)
        {
            var random = new RNGCryptoServiceProvider();
            var salt = new Byte[size];
            random.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }

        public Boolean ValidatePassword(String enteredPassword, String storedHash, String storedSalt)
        {
            var hash = HashPassword(enteredPassword, storedSalt);
            return String.Equals(storedHash, hash);
        }

        protected void bnVerander_Click(object sender, EventArgs e)
        {
            String naam = gebruikerVeld.Text;
            String wachtwoord = oudwachtwoordVeld.Text;
            String nieuwwachtwoord = nieuwWachtwoord.Text;
            String nieuwwachtwoordher = nieuwWachtwoordHer.Text;
            String salt = GetRandomSalt();
            String hashedpassword = HashPassword(nieuwwachtwoordher, salt);

            String opgeslagenpw = "";
            String opgeslagensalt = "";
            String opgeslagenID = "";

            connectieDatabase database = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + HttpContext.Current.Server.MapPath("/database/tmtit11database.mdb") + "");
            DataTable dt = database.dataSelecteren("select * from Admin where Gebruikersnaam = '" + naam + "'");
            if (dt.Rows.Count > 0)
            {
                opgeslagenpw = dt.Rows[0]["Wachtwoord"].ToString();
                opgeslagensalt = dt.Rows[0]["Salt"].ToString();

                if (ValidatePassword(wachtwoord, opgeslagenpw, opgeslagensalt))
                {
                    connectieDatabaseLos databaseLos = new connectieDatabaseLos();
                    OleDbConnection connectieLos = databaseLos.connectieDatabaseLosFunc();

                    string s = "SELECT * FROM Admin WHERE Gebruikersnaam = '" + naam + "' AND Wachtwoord = '" + opgeslagenpw + "'";
                    OleDbCommand resultaat = new OleDbCommand(s, connectieLos);
                    databaseLos.databaseOpen(connectieLos);
                    resultaat.ExecuteNonQuery();

                    opgeslagenID = dt.Rows[0]["Admin_ID"].ToString();
                    naam = dt.Rows[0]["Gebruikersnaam"].ToString();

                    databaseLos.databaseClose(connectieLos);

                    DataRow row = dt.Rows[0];
                    String savedId = row[0].ToString();

                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "Wachtwoord en Gebruikersnaam komen niet overeen!";
                }
                if (nieuwwachtwoord == nieuwwachtwoordher)
                {
                    connectieDatabaseLos databaseLos = new connectieDatabaseLos();
                    OleDbConnection connectieLos = databaseLos.connectieDatabaseLosFunc();

                    string s = "UPDATE Admin SET Wachtwoord = '" + hashedpassword + "', Salt = '" + salt + "' WHERE Gebruikersnaam = '" + naam + "'";
                    OleDbCommand resultaat = new OleDbCommand(s, connectieLos);

                    databaseLos.databaseOpen(connectieLos);
                    resultaat.ExecuteNonQuery();
                    databaseLos.databaseClose(connectieLos);
                    Label1.Visible = true;
                    Label1.Text = "Uw wachtwoord is gewijzigd";
                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "Uw wachtwoord is niet gewijzigd wachtwoorden komen niet overeen!";
                }

            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Uw gebruikersnaam / Wachtwoord is verkeerd";
            }
        }
    }
}