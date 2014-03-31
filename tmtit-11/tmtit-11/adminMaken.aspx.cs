using System;
using System.Data;
using tmtit_11.App_Code;

namespace tmtit_11
{
    public partial class adminMaken : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAanmakenClick(Object sender, EventArgs e)
        {
            String naam = gebruikersNaam.Text;
            String wachtwoord = wachtWoord.Text;
            String wachtwoord2 = wachtWoordcontrole.Text;
            

            encryptie encryptieClass = new encryptie();
            String salt = encryptieClass.GetRandomSalt();
            connectieDatabase database = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            //DataTable dt = database.dataInvoegen("INSERT INTO Admin (Gebruikersnaam, Wachtwoord, salt) VALUES ('" + naam + "','" + wachtwoord + "','" + salt + "')");
            
        }
    }
}