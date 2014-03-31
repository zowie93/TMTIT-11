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
        string bodyText = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            connectieDatabase database = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            DataTable dt = database.dataSelecteren("SELECT Wedstrijden.Wedstrijd_ID, Stadions.Stadion_naam, Wedstrijden.Datum, Wedstrijden.Begintijd, Teams.Team_naam, Teams.Team_ID, Teams_1.* FROM ((Wedstrijden INNER JOIN Stadions ON Wedstrijden.Stadion_ID = Stadions.Stadion_ID) INNER JOIN Teams ON Wedstrijden.Team1_ID = Teams.Team_ID) INNER JOIN Teams AS Teams_1 ON Wedstrijden.Team2_ID = Teams_1.Team_ID");

            string wedstrijdid = "";
            string stadionaam = "";
            string teamnaam = "";
            string teamnaam2 = "";
            string begintijd = "";
            string vlag = "";
            string datum = "";

            int count = dt.Rows.Count;

            if (count > 0)
            {
                bodyText += "<table border='0'>";
                bodyText += "<td width='20px' style='text-align:center'><strong>ID</strong></td>";
                bodyText += "<td width='250px' style='text-align:center'><strong>Stadionaam</strong></td>";
                bodyText += "<td width='25px' style='text-align:center'><strong>Vlag</strong></td>";
                bodyText += "<td width='85px' style='text-align:center'><strong>Land</strong></td>";
                bodyText += "<td width='25px' style='text-align:center'></td>";
                bodyText += "<td width='25px' style='text-align:center'><strong>Vlag</strong></td>";
                bodyText += "<td width='85px' style='text-align:center'><strong>Land</strong></td>";
                bodyText += "<td width='150px' style='text-align:center'><strong>Datum</strong></td>";
                bodyText += "<td width='150px' style='text-align:center'><strong>Tijd</strong></td>";
                for(int i = 0; i < count; i++) 
                {
                    wedstrijdid = dt.Rows[i]["Wedstrijd_ID"].ToString();
                    stadionaam = dt.Rows[i]["Stadion_naam"].ToString();
                    vlag = dt.Rows[i]["vlag"].ToString();
                    teamnaam = dt.Rows[i]["Teams.Team_naam"].ToString();
                    teamnaam2 = dt.Rows[i]["Teams_1.Team_naam"].ToString();
                    datum = dt.Rows[i]["Datum"].ToString();
                    begintijd = dt.Rows[i]["Begintijd"].ToString();


                    if(i + 1 <= count)
                    {
                        bodyText += "<tr>";
                        bodyText += "<td width='20px'>" + wedstrijdid + "</td>";
                        bodyText += "<td width='250px'>" + stadionaam + "</td>";
                        bodyText += "<td width='25px'><img src='" + vlag + "' /></td>";
                        bodyText += "<td width='85px'>" + teamnaam + "</td>";
                        bodyText += "<td width='25px'> - </td>";
                        bodyText += "<td width='25px'><img src='" + vlag + "' /></td>";
                        bodyText += "<td width='85'px>" + teamnaam2 + "</td>";
                        bodyText += "<td width='150px' style='text-align:center'>" + datum + "</td>";
                        bodyText += "<td width='150px' style='text-align:center'>" + begintijd + "</td>";
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
                Response.Write(bodyText);
            }
                
            else
            {
                Response.Write(count);
            }
        }
    }
}