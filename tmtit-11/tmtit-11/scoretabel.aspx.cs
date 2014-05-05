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
    public partial class scoretabel : System.Web.UI.Page
    {
        string scoretabelStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            connectieDatabase database = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + HttpContext.Current.Server.MapPath("/database/tmtit11database.mdb") + "");
            DataTable dt = database.dataSelecteren("SELECT Teams.Team_naam AS Team, Teams.Winst AS Winst, Teams.Gelijkspel AS Gelijkspel, Poule.Poule_naam AS Poule, Teams.Vlag AS Vlag FROM Teams INNER JOIN Poule ON Teams.Poule_ID = Poule.Poule_ID ORDER BY Teams.Winst DESC;");

            string vlag = "";
            string team = "";
            string winst = "";
            string gelijk = "";
            string poule = "";


            int count = dt.Rows.Count;

            if (count > 0)
            {
                scoretabelStr += "<table border='1'>";
                scoretabelStr += "<th width='25px' height='60px'></th>";
                scoretabelStr += "<th width='180px'>Teams</th>";
                scoretabelStr += "<th width='100px'>Winst</th>";
                scoretabelStr += "<th width='170px'>Gelijkspel</th>";
                scoretabelStr += "<th width='100px'>Poule</th>";
                for (int i = 0; i < count; i++)
                {
                    vlag = dt.Rows[i]["Vlag"].ToString();
                    team = dt.Rows[i]["Team"].ToString();
                    winst = dt.Rows[i]["Winst"].ToString();
                    gelijk = dt.Rows[i]["Gelijkspel"].ToString();
                    poule = dt.Rows[i]["Poule"].ToString();


                    if (i + 1 <= count)
                    {
                        scoretabelStr += "<tr>";
                        scoretabelStr += "<td width='25px' height='35px'><img src='" + vlag + "' /></td>";
                        scoretabelStr += "<td width='150px'>" + team + "</td>";
                        scoretabelStr += "<td width='40px' style='text-align:center'>" + winst + "</td>";
                        scoretabelStr += "<td width='40px' style='text-align:center'>" + gelijk + "</td>";
                        scoretabelStr += "<td width='70px' style='text-align:center'>" + poule + "</td>";
                        scoretabelStr += "</tr>";
                    }
                }

                scoretabelStr += "</table>";
                scoretabelLabel.Text = scoretabelStr;

            }

            else
            {
                Response.Write(count);
            }
        }
    }
}