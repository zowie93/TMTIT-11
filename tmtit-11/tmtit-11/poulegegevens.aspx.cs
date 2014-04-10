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
    public partial class poulegegevens : System.Web.UI.Page
    {
        string poulesVerdeling = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            connectieDatabase database = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            DataTable dt = database.dataSelecteren("SELECT Poule.Poule_ID, Poule.Poule_naam, Teams.Team_naam, Teams_1.Team_naam, Teams_2.Team_naam, Teams_3.Team_naam, Teams.Vlag, Teams_1.Vlag, Teams_2.Vlag, Teams_3.Vlag FROM Teams AS Teams_3 INNER JOIN (Teams AS Teams_2 INNER JOIN (Teams AS Teams_1 INNER JOIN (Teams INNER JOIN Poule ON Teams.Team_ID = Poule.Team1_ID) ON Teams_1.Team_ID = Poule.Team2_ID) ON Teams_2.Team_ID = Poule.Team3_ID) ON Teams_3.Team_ID = Poule.Team4_ID");

            string pouleID = "";
            string pouleNaam = "";
            string team1 = "";
            string vlagteam1 = "";
            string team2 = "";
            string vlagteam2 = "";
            string team3 = "";
            string vlagteam3 = "";
            string team4 = "";
            string vlagteam4 = "";


            int count = dt.Rows.Count;

            if (count > 0)
            {
                poulesVerdeling += "<table border='1'>";
                poulesVerdeling += "<th width='20px' height='30px' style='font-weight:bold' colspan='9'><h2>Poules</h2></th>";
                for (int i = 0; i < count; i++)
                {
                    pouleID = dt.Rows[i]["Poule_ID"].ToString();
                    pouleNaam = dt.Rows[i]["Poule_naam"].ToString();
                    team1 = dt.Rows[i]["Teams.Team_naam"].ToString();
                    vlagteam1 = dt.Rows[i]["Teams.Vlag"].ToString();
                    team2 = dt.Rows[i]["Teams_1.Team_naam"].ToString();
                    vlagteam2 = dt.Rows[i]["Teams_1.Vlag"].ToString();
                    team3 = dt.Rows[i]["Teams_2.Team_naam"].ToString();
                    vlagteam3 = dt.Rows[i]["Teams_2.Vlag"].ToString();
                    team4 = dt.Rows[i]["Teams_3.Team_naam"].ToString();
                    vlagteam4 = dt.Rows[i]["Teams_3.Vlag"].ToString();



                    if (i + 1 <= count)
                    {
                        poulesVerdeling += "<tr>";
                        poulesVerdeling += "<td width='100px'>" + pouleNaam + "</td>";
                        poulesVerdeling += "<td width='25px'><img src='" + vlagteam1 + "' /></td>";
                        poulesVerdeling += "<td width='100px'>" + team1 + "</td>";
                        poulesVerdeling += "<td width='25px'><img src='" + vlagteam2 + "' /></td>";
                        poulesVerdeling += "<td width='100px'>" + team2 + "</td>";
                        poulesVerdeling += "<td width='25px'><img src='" + vlagteam3 + "' /></td>";
                        poulesVerdeling += "<td width='100px'>" + team3 + "</td>";
                        poulesVerdeling += "<td width='25px'><img src='" + vlagteam4 + "' /></td>";
                        poulesVerdeling += "<td width='100px'>" + team4 + "</td>";
                        poulesVerdeling += "</tr>";

                        for (int j = i + 1; j < count; j++)
                        {
                            string s = dt.Rows[j]["Poule_ID"].ToString();
                            string ss = dt.Rows[i]["Poule_ID"].ToString();
                            if (dt.Rows[j]["Poule_ID"].ToString() == dt.Rows[i]["Poule_ID"].ToString())
                            {
                                poulesVerdeling += "<tr>";
                                poulesVerdeling += "<td>" + dt.Rows[j]["Poule_naam"].ToString() + "</td>";
                                poulesVerdeling += "</tr>";
                                i = i + 1;
                            }
                        }
                    }
                }

                poulesVerdeling += "</table>";
                pouleGegevensA.Text = poulesVerdeling;

            }

            else
            {
                Response.Write(count);
            }
        }
    }
}