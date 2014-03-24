using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using tmtit_11.App_Code;

namespace tmtit_11
{
    public partial class speelschema : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            connectieDatabase database = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            DataTable dt = database.dataSelecteren("SELECT * FROM TEAMS");
            string vlag = dt.Rows[0]["Vlag"].ToString();
            if (dt.Rows.Count > 0)
            {
                Response.Write(dt.Rows[0]["Team_ID"].ToString());
                Response.Write(dt.Rows[0]["Team_naam"].ToString());
                
            }
            else
            {
                Response.Write("Error!");
            }
        }
    }
}