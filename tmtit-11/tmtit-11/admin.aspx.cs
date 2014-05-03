using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tmtit_11
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.Request.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void VeranderPW_Click(object sender, EventArgs e)
        {
            Response.Redirect("veranderwachtwoord.aspx");
        }

        protected void NieuweAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminMaken.aspx");
        }
    }
}