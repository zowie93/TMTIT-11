using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tmtit_11
{
    public partial class loguit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String naam = null;
            String savedId = null;

            string cookiestr;
            FormsAuthenticationTicket tkt = new FormsAuthenticationTicket(1, naam, DateTime.Now,
            DateTime.Now.AddMinutes(-5), false, savedId);
            cookiestr = FormsAuthentication.Encrypt(tkt);
            HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
            ck.Expires = tkt.Expiration;
            ck.Path = FormsAuthentication.FormsCookiePath;
            FormsAuthentication.SetAuthCookie(naam, false);
            HttpContext.Current.Response.Cookies.Add(ck);

            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
    }
}