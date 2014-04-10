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
        string bodyText = "";

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
                bodyText += "<table border='1'>";

                bodyText += "<th width='25px'></th>";
                bodyText += "<th width='85px' style='text-align:left; font-weight:bold'>Land</th>";
                bodyText += "<th width='25px' style='text-align:center'></th>";
                bodyText += "<th width='25px'></th>";
                bodyText += "<th width='85px' style='text-align: left;font-weight:bold'>Land</th>";
                for (int i = 0; i < count; i++)
                {

                    vlag = dt.Rows[i]["Teams.vlag"].ToString();
                    teamnaam = dt.Rows[i]["Teams.Team_naam"].ToString();
                    vlag2 = dt.Rows[i]["Teams_1.vlag"].ToString();
                    teamnaam2 = dt.Rows[i]["Teams_1.Team_naam"].ToString();


                    if (i + 1 <= count)
                    {
                        bodyText += "<tr>";
                        bodyText += "<td width='25px'><img src='" + vlag + "' /></td>";
                        bodyText += "<td width='85px'>" + teamnaam + "</td>";
                        bodyText += "<form runat='server'>";
                        bodyText += "<td width='30px'></td>";
                        bodyText += "</form>";
                        bodyText += "<td width='25px'> - </td>";
                        bodyText += "<td width='25px'><img src='" + vlag2 + "' /></td>";
                        bodyText += "<td width='85'px>" + teamnaam2 + "</td>";
                        bodyText += "</tr>";

                        for (int j = i + 1; j < count; j++)
                        {
                            string s = dt.Rows[j]["Wedstrijd_ID"].ToString();
                            string ss = dt.Rows[i]["Wedstrijd_ID"].ToString();
                            if (dt.Rows[j]["Wedstrijd_ID"].ToString() == dt.Rows[i]["Wedstrijd_ID"].ToString())
                            {
                                bodyText += "<tr>";
                                bodyText += "<td>" + dt.Rows[j]["Team_naam"].ToString() + "</td>";
                                bodyText += "</tr>";
                                i = i + 1;
                            }
                        }
                    }
                }

                bodyText += "</table>";
                speelSchema.Text = bodyText;

            }

            else
            {
                Response.Write(count);
            }

        }
    }
}