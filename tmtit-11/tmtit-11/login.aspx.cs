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

namespace tmtit_11
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bnLogin_Click(object sender, EventArgs e)
        {
            String naam = gebruikerVeld.Text;
            String wachtwoord = wachtwoordVeld.Text;
            connectieDatabase database = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            DataTable dt = database.dataSelecteren("select Admin_ID from Admin where Gebruikersnaam = '" + naam + "' and Wachtwoord = '" + wachtwoord + "'");
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                String savedId = row[0].ToString();

                string cookiestr;
                FormsAuthenticationTicket tkt = new FormsAuthenticationTicket(1, naam, DateTime.Now,
                    DateTime.Now.AddMinutes(25), false, savedId);
                cookiestr = FormsAuthentication.Encrypt(tkt);
                HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                ck.Expires = tkt.Expiration;
                ck.Path = FormsAuthentication.FormsCookiePath;
                FormsAuthentication.SetAuthCookie(naam, false);
                HttpContext.Current.Response.Cookies.Add(ck);
                //Response.Redirect("Admin.aspx");
            }
            else
            {
                Response.Write("Error!");
            }
        }
    }
}