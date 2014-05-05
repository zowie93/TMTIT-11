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
        string pouleA = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            connectieDatabase database = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + HttpContext.Current.Server.MapPath("/database/tmtit11database.mdb") + "");
            DataTable dt = database.dataSelecteren("SELECT Wedstrijden.Wedstrijd_ID, Stadions.Stadion_naam, Teams.Team_naam, Teams.Team_ID, Teams_1.*, Teams.Vlag, Wedstrijden.Datum, Wedstrijden.Begintijd FROM ((Wedstrijden INNER JOIN Stadions ON Wedstrijden.Stadion_ID = Stadions.Stadion_ID) INNER JOIN Teams ON Wedstrijden.Team1_ID = Teams.Team_ID) INNER JOIN Teams AS Teams_1 ON Wedstrijden.Team2_ID = Teams_1.Team_ID");

            string wedstrijdid = "";
            string stadionaam = "";
            string teamnaam = "";
            string teamnaam2 = "";
            string begintijd = "";
            string vlag = "";
            string vlag2 = "";
            string datum = "";

            int count = dt.Rows.Count;

            if (count > 0)
            {
                pouleA += "<table border='1'>";
                pouleA += "<th width='250px' height='30px' style='text-align:center; font-weight:bold'>Stadionnaam</th>";
                pouleA += "<th width='25px'></th>";
                pouleA += "<th width='85px' style='text-align:left; font-weight:bold'>Land</th>";
                pouleA += "<th width='25px' style='text-align:center'></th>";
                pouleA += "<th width='25px'></th>";
                pouleA += "<th width='85px' style='text-align: left;font-weight:bold'>Land</th>";
                pouleA += "<th width='100px' style='text-align:center; font-weight:bold'>Datum</th>";
                pouleA += "<th width='100px' style='text-align:center; font-weight:bold'>Tijd</th>";
                for(int i = 0; i < count; i++) 
                {
                    wedstrijdid = dt.Rows[i]["Wedstrijd_ID"].ToString();
                    stadionaam = dt.Rows[i]["Stadion_naam"].ToString();
                    vlag = dt.Rows[i]["Teams.vlag"].ToString();
                    teamnaam = dt.Rows[i]["Teams.Team_naam"].ToString();
                    vlag2 = dt.Rows[i]["Teams_1.vlag"].ToString();
                    teamnaam2 = dt.Rows[i]["Teams_1.Team_naam"].ToString();
                    datum = dt.Rows[i]["Datum"].ToString();
                    begintijd = dt.Rows[i]["Begintijd"].ToString();


                    if(i + 1 <= count)
                    {
                        pouleA += "<tr>";
                        pouleA += "<td width='250px' height='24px'>" + stadionaam + "</td>";
                        pouleA += "<td width='25px'><img src='" + vlag + "' /></td>";
                        pouleA += "<td width='85px'>" + teamnaam + "</td>";
                        pouleA += "<td width='25px'> - </td>";
                        pouleA += "<td width='25px'><img src='" + vlag2 + "' /></td>";
                        pouleA += "<td width='85'px>" + teamnaam2 + "</td>";
                        pouleA += "<td width='100px' style='text-align:center'>" + datum + "</td>";
                        pouleA += "<td width='100px' style='text-align:center'>" + begintijd + "</td>";
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