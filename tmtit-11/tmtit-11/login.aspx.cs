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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void bnLogin_Click(object sender, EventArgs e)
        {
            String naam = gebruikerVeld.Text;
            String wachtwoord = wachtwoordVeld.Text;

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

                        Session["gebruiker"] = gebruikerVeld.Text;

                        string cookiestr;
                        FormsAuthenticationTicket tkt = new FormsAuthenticationTicket(1, naam, DateTime.Now,
                        DateTime.Now.AddMinutes(25), false, savedId);
                        cookiestr = FormsAuthentication.Encrypt(tkt);
                        HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                        ck.Expires = tkt.Expiration;
                        ck.Path = FormsAuthentication.FormsCookiePath;
                        FormsAuthentication.SetAuthCookie(naam, false);
                        HttpContext.Current.Response.Cookies.Add(ck);
                        Label1.Visible = true;
                        Label1.Text = Session["gebruiker"] + " u bent succesvol ingelogd";
                    }
                    else
                    {
                        Label1.Visible = true;
                        Label1.Text = "Uw wachtwoord is verkeerd!";
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