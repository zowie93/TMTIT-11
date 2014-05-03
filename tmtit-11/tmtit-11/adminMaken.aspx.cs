using System;
using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using tmtit_11.App_Code;

namespace tmtit_11
{
    public partial class adminMaken : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            if (!HttpContext.Current.Request.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }
             */
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


        protected void btnAanmakenClick(Object sender, EventArgs e)
        {
            String naam = gebruikersNaam.Text;
            String wachtwoord = wachtWoord.Text;
            String wachtwoord2 = wachtWoordcontrole.Text;
            String salt = GetRandomSalt();
            String hashedpassword = HashPassword(wachtwoord, salt);

            if (wachtwoord == wachtwoord2)
            {

                connectieDatabaseLos databaseLos = new connectieDatabaseLos();
                OleDbConnection connectieLos = databaseLos.connectieDatabaseLosFunc();

                string s = "INSERT INTO Admin (Gebruikersnaam, Wachtwoord, Salt) VALUES ('" + naam + "', '" + hashedpassword + "', '" + salt + "')";
                OleDbCommand resultaat = new OleDbCommand(s, connectieLos);

                databaseLos.databaseOpen(connectieLos);
                resultaat.ExecuteNonQuery();
                databaseLos.databaseClose(connectieLos);
            }
            
            
        }
    }
}