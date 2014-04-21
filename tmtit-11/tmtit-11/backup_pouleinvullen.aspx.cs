using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tmtit_11.App_Code;

namespace tmtit_11
{
    public partial class pouleinvullen : System.Web.UI.Page
    {
        string pouleA = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            connectieDatabase database = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            DataTable dt = database.dataSelecteren("SELECT Wedstrijden.Wedstrijd_ID, Stadions.Stadion_naam, Teams.Team_naam, Teams.Team_ID, Teams_1.*, Teams.Vlag, Wedstrijden.Datum, Wedstrijden.Begintijd FROM ((Wedstrijden INNER JOIN Stadions ON Wedstrijden.Stadion_ID = Stadions.Stadion_ID) INNER JOIN Teams ON Wedstrijden.Team1_ID = Teams.Team_ID) INNER JOIN Teams AS Teams_1 ON Wedstrijden.Team2_ID = Teams_1.Team_ID");

            string teamnaam = "";
            string teamnaam2 = "";
            string vlag = "";
            string vlag2 = "";

            int count = dt.Rows.Count;

            TextBox txt = new TextBox();

            int n = 5;
            for (int i = 0; i < n; i++)
            {
                txt.ID = "score" + "" + ViewState["num"] + i;
                txt.Width = 30;
                txt.Height = 20;
            }

            if (count > 0)
            {
                pouleA += "<table border='1'>";

                pouleA += "<th width='25px'></th>";
                pouleA += "<th width='85px' style='text-align:left; font-weight:bold'>Land</th>";
                pouleA += "<th width='25px' style='text-align:center'></th>";
                pouleA += "<th width='25px'></th>";
                pouleA += "<th width='85px' style='text-align: left;font-weight:bold'>Land</th>";
                for (int i = 0; i < count; i++)
                {

                    vlag = dt.Rows[i]["Teams.vlag"].ToString();
                    teamnaam = dt.Rows[i]["Teams.Team_naam"].ToString();
                    vlag2 = dt.Rows[i]["Teams_1.vlag"].ToString();
                    teamnaam2 = dt.Rows[i]["Teams_1.Team_naam"].ToString();


                    if (i + 1 <= count)
                    {
                        pouleA += "<tr>";
                        pouleA += "<td width='25px'><img src='" + vlag + "' /></td>";
                        pouleA += "<td width='85px'>" + teamnaam + "</td>";
                        pouleA += "<form runat='server'>";
                        pouleA += "<td width='30px'></td>";
                        pouleA += "</form>";
                        pouleA += "<td width='25px'> - </td>";
                        pouleA += "<td width='25px'><img src='" + vlag2 + "' /></td>";
                        pouleA += "<td width='85'px>" + teamnaam2 + "</td>";
                        pouleA += "</tr>";

                        for (int j = i + 1; j < count; j++)
                        {
                            string s = dt.Rows[j]["Wedstrijd_ID"].ToString();
                            string ss = dt.Rows[i]["Wedstrijd_ID"].ToString();
                            if (dt.Rows[j]["Wedstrijd_ID"].ToString() == dt.Rows[i]["Wedstrijd_ID"].ToString())
                            {
                                pouleA += "<tr>";
                                pouleA += "<td>" + dt.Rows[j]["Team_naam"].ToString() + "</td>";
                                pouleA += "</tr>";
                                i = i + 1;
                            }
                        }
                    }
                }

                pouleA += "</table>";
                speelSchema.Text = pouleA;

            }

            else
            {
                Response.Write(count);
            }

        }
    }
}