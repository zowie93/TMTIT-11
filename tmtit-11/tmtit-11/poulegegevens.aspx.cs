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
        string pouleA = "";
        string pouleB = "";
        string pouleC = "";
        string pouleD = "";

        string kwartpouleA = "";
        string kwartpouleB = "";
        string kwartpouleC = "";
        string kwartpouleD = "";

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

            connectieDatabase database2 = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            DataTable dt2 = database2.dataSelecteren("SELECT Wedstrijden.Wedstrijd_ID, Teams.Team_naam AS Team1, Teams_1.Team_naam AS Team2, Wedstrijden.doelpuntenteam1 AS Score1, Wedstrijden.doelpuntenteam2 AS Score2, Poule.Poule_naam AS Poulenaam, Teams.Vlag, Teams_1.Vlag FROM (Teams AS Teams_1 INNER JOIN (Teams INNER JOIN Wedstrijden ON Teams.Team_ID = Wedstrijden.Team1_ID) ON Teams_1.Team_ID = Wedstrijden.Team2_ID) INNER JOIN Poule ON Wedstrijden.Poule_ID = Poule.Poule_ID WHERE Wedstrijden.Poule_ID=1;");

            string teamnaam_1 = "";
            string teamnaam2_1 = "";
            string vlag_1 = "";
            string vlag2_1 = "";
            string score1_1 = "";
            string score2_1 = "";

            int count2 = dt2.Rows.Count;
            Response.Write(count2);

            if (count2 > 0)
            {
                pouleA += "<table border='1'>";
                for (int i = 0; i < count2; i++)
                {
                    vlag_1 = dt2.Rows[i]["Teams.vlag"].ToString();
                    teamnaam_1 = dt2.Rows[i]["Team1"].ToString();
                    score1_1 = dt2.Rows[i]["Score1"].ToString();
                    score2_1 = dt2.Rows[i]["Score2"].ToString();
                    vlag2_1 = dt2.Rows[i]["Teams_1.vlag"].ToString();
                    teamnaam2_1 = dt2.Rows[i]["Team2"].ToString();


                    if (i + 1 <= count2)
                    {
                        pouleA += "<tr>";
                        pouleA += "<td width='145px' height='25px'>" + teamnaam_1 + "</td>";
                        pouleA += "<td width='35px'><img src='" + vlag_1 + "' /></td>";
                        pouleA += "<td width='20px'>" + score1_1 + "</td>";
                        pouleA += "<td width='15px'> - </td>";
                        pouleA += "<td width='30px'>" + score2_1 + "</td>";
                        pouleA += "<td width='80px'><img src='" + vlag2_1 + "' /></td>";
                        pouleA += "<td width='125'px>" + teamnaam2_1 + "</td>";
                        pouleA += "</tr>";

                      
                    }
                }

                pouleA += "</table>";
                
                pouleATXT.Text = pouleA;

            }

            else
            {
                Response.Write(count);
            }

            connectieDatabase database3 = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            DataTable dt3 = database3.dataSelecteren("SELECT Wedstrijden.Wedstrijd_ID, Teams.Team_naam AS Team1, Teams_1.Team_naam AS Team2, Wedstrijden.doelpuntenteam1 AS Score1, Wedstrijden.doelpuntenteam2 AS Score2, Poule.Poule_naam AS Poulenaam, Teams.Vlag, Teams_1.Vlag FROM (Teams AS Teams_1 INNER JOIN (Teams INNER JOIN Wedstrijden ON Teams.Team_ID = Wedstrijden.Team1_ID) ON Teams_1.Team_ID = Wedstrijden.Team2_ID) INNER JOIN Poule ON Wedstrijden.Poule_ID = Poule.Poule_ID WHERE Wedstrijden.Poule_ID=2;");

            string teamnaam_2 = "";
            string teamnaam2_2 = "";
            string vlag_2 = "";
            string vlag2_2 = "";
            string score1_2 = "";
            string score2_2 = "";

            int count3 = dt3.Rows.Count;
            Response.Write(count3);

            if (count3 > 0)
            {
                pouleB += "<table border='1'>";
                for (int i = 0; i < count3; i++)
                {
                    vlag_2 = dt3.Rows[i]["Teams.vlag"].ToString();
                    teamnaam_2 = dt3.Rows[i]["Team1"].ToString();
                    score1_2 = dt3.Rows[i]["Score1"].ToString();
                    score2_2 = dt3.Rows[i]["Score2"].ToString();
                    vlag2_2 = dt3.Rows[i]["Teams_1.vlag"].ToString();
                    teamnaam2_2 = dt3.Rows[i]["Team2"].ToString();


                    if (i + 1 <= count3)
                    {
                        pouleB += "<tr>";
                        pouleB += "<td width='145px' height='25px'>" + teamnaam_2 + "</td>";
                        pouleB += "<td width='35px'><img src='" + vlag_2 + "' /></td>";
                        pouleB += "<td width='20px'>" + score1_2 + "</td>";
                        pouleB += "<td width='15px'> - </td>";
                        pouleB += "<td width='30px'>" + score2_2 + "</td>";
                        pouleB += "<td width='80px'><img src='" + vlag2_2 + "' /></td>";
                        pouleB += "<td width='125'px>" + teamnaam2_2 + "</td>";
                        pouleB += "</tr>";


                    }
                }

                pouleB += "</table>";

                pouleBTXT.Text = pouleB;

            }

            else
            {
                Response.Write(count);
            }

            connectieDatabase database4 = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            DataTable dt4 = database4.dataSelecteren("SELECT Wedstrijden.Wedstrijd_ID, Teams.Team_naam AS Team1, Teams_1.Team_naam AS Team2, Wedstrijden.doelpuntenteam1 AS Score1, Wedstrijden.doelpuntenteam2 AS Score2, Poule.Poule_naam AS Poulenaam, Teams.Vlag, Teams_1.Vlag FROM (Teams AS Teams_1 INNER JOIN (Teams INNER JOIN Wedstrijden ON Teams.Team_ID = Wedstrijden.Team1_ID) ON Teams_1.Team_ID = Wedstrijden.Team2_ID) INNER JOIN Poule ON Wedstrijden.Poule_ID = Poule.Poule_ID WHERE Wedstrijden.Poule_ID=3;");

            string teamnaam_3 = "";
            string teamnaam2_3 = "";
            string vlag_3 = "";
            string vlag2_3 = "";
            string score1_3 = "";
            string score2_3 = "";

            int count4 = dt4.Rows.Count;
            Response.Write(count4);

            if (count4 > 0)
            {
                pouleC += "<table border='1'>";
                for (int i = 0; i < count4; i++)
                {
                    vlag_3 = dt4.Rows[i]["Teams.vlag"].ToString();
                    teamnaam_3 = dt4.Rows[i]["Team1"].ToString();
                    score1_3 = dt4.Rows[i]["Score1"].ToString();
                    score2_3 = dt4.Rows[i]["Score2"].ToString();
                    vlag2_3 = dt4.Rows[i]["Teams_1.vlag"].ToString();
                    teamnaam2_3 = dt4.Rows[i]["Team2"].ToString();


                    if (i + 1 <= count4)
                    {
                        pouleC += "<tr>";
                        pouleC += "<td width='145px' height='25px'>" + teamnaam_3 + "</td>";
                        pouleC += "<td width='35px'><img src='" + vlag_3 + "' /></td>";
                        pouleC += "<td width='20px'>" + score1_3 + "</td>";
                        pouleC += "<td width='15px'> - </td>";
                        pouleC += "<td width='30px'>" + score2_3 + "</td>";
                        pouleC += "<td width='80px'><img src='" + vlag2_3 + "' /></td>";
                        pouleC += "<td width='125'px>" + teamnaam2_3 + "</td>";
                        pouleC += "</tr>";


                    }
                }

                pouleC += "</table>";

                pouleCTXT.Text = pouleC;

            }

            else
            {
                Response.Write(count);
            }

            connectieDatabase database5 = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            DataTable dt5 = database5.dataSelecteren("SELECT Wedstrijden.Wedstrijd_ID, Teams.Team_naam AS Team1, Teams_1.Team_naam AS Team2, Wedstrijden.doelpuntenteam1 AS Score1, Wedstrijden.doelpuntenteam2 AS Score2, Poule.Poule_naam AS Poulenaam, Teams.Vlag, Teams_1.Vlag FROM (Teams AS Teams_1 INNER JOIN (Teams INNER JOIN Wedstrijden ON Teams.Team_ID = Wedstrijden.Team1_ID) ON Teams_1.Team_ID = Wedstrijden.Team2_ID) INNER JOIN Poule ON Wedstrijden.Poule_ID = Poule.Poule_ID WHERE Wedstrijden.Poule_ID=4;");

            string teamnaam_4 = "";
            string teamnaam2_4 = "";
            string vlag_4 = "";
            string vlag2_4 = "";
            string score1_4 = "";
            string score2_4 = "";

            int count5 = dt5.Rows.Count;
            Response.Write(count5);

            if (count5 > 0)
            {
                pouleD += "<table border='1'>";
                for (int i = 0; i < count5; i++)
                {
                    vlag_4 = dt5.Rows[i]["Teams.vlag"].ToString();
                    teamnaam_4 = dt5.Rows[i]["Team1"].ToString();
                    score1_4 = dt5.Rows[i]["Score1"].ToString();
                    score2_4 = dt5.Rows[i]["Score2"].ToString();
                    vlag2_4 = dt5.Rows[i]["Teams_1.vlag"].ToString();
                    teamnaam2_4 = dt5.Rows[i]["Team2"].ToString();


                    if (i + 1 <= count5)
                    {
                        pouleD += "<tr>";
                        pouleD += "<td width='145px' height='25px'>" + teamnaam_4 + "</td>";
                        pouleD += "<td width='35px'><img src='" + vlag_4 + "' /></td>";
                        pouleD += "<td width='20px'>" + score1_4 + "</td>";
                        pouleD += "<td width='15px'> - </td>";
                        pouleD += "<td width='30px'>" + score2_4 + "</td>";
                        pouleD += "<td width='80px'><img src='" + vlag2_4 + "' /></td>";
                        pouleD += "<td width='125'px>" + teamnaam2_4 + "</td>";
                        pouleD += "</tr>";


                    }
                }

                pouleD += "</table>";

                pouleDTXT.Text = pouleD;

            }

            else
            {
                Response.Write(count);
            }

            connectieDatabase database6 = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            DataTable dt6 = database6.dataSelecteren("SELECT TOP 2 Teams.Team_naam AS Team1, Teams.Team_ID AS Team2, Teams.Winst AS Winst, Teams.Vlag AS Vlag FROM Teams INNER JOIN Poule ON Teams.Poule_ID = Poule.Poule_ID WHERE (((Teams.Poule_ID)=1)) ORDER BY Teams.Winst DESC;");

            string kwartvlag = "";
            string team1_1 = "";
            string winst = "";


            int count6 = dt6.Rows.Count;

            if (count6 > 0)
            {
                kwartpouleA += "<table border='1'>";
                kwartpouleA += "<th width='40px'></th>";
                kwartpouleA += "<th width='175px'></th>";
                kwartpouleA += "<th width='50px'>Winst</th>";
                for (int i = 0; i < count6; i++)
                {
                    kwartvlag = dt6.Rows[i]["Vlag"].ToString();
                    team1_1 = dt6.Rows[i]["Team1"].ToString();
                    winst = dt6.Rows[i]["Winst"].ToString();

                    if (i + 1 <= count6)
                    {
                        kwartpouleA += "<tr>"; 
                        kwartpouleA += "<td width='40px'><img src='" + kwartvlag + "' /></td>";
                        kwartpouleA += "<td width='175px' height='25px'>" + team1_1 + "</td>";
                        kwartpouleA += "<td width='50px' style='text-align: center'>" + winst + "</td>";
                        kwartpouleA += "</tr>";
                    }
                }

                kwartpouleA += "</table>";
                kwartpouleATXT.Text = kwartpouleA;

            }
            else
            {
                Response.Write(count);
            }

            connectieDatabase database7 = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            DataTable dt7 = database7.dataSelecteren("SELECT TOP 2 Teams.Team_naam AS Team1, Teams.Team_ID AS Team2, Teams.Winst AS Winst, Teams.Vlag AS Vlag FROM Teams INNER JOIN Poule ON Teams.Poule_ID = Poule.Poule_ID WHERE (((Teams.Poule_ID)=2)) ORDER BY Teams.Winst DESC;");

            string kwartvlag2 = "";
            string team1_2 = "";
            string winst2 = "";


            int count7 = dt7.Rows.Count;

            if (count7 > 0)
            {
                kwartpouleB += "<table border='1'>";
                kwartpouleB += "<th width='40px'></th>";
                kwartpouleB += "<th width='175px'></th>";
                kwartpouleB += "<th width='50px'>Winst</th>";
                for (int i = 0; i < count7; i++)
                {
                    kwartvlag2 = dt7.Rows[i]["Vlag"].ToString();
                    team1_2 = dt7.Rows[i]["Team1"].ToString();
                    winst2 = dt7.Rows[i]["Winst"].ToString();

                    if (i + 1 <= count7)
                    {
                        kwartpouleB += "<tr>";
                        kwartpouleB += "<td width='40px'><img src='" + kwartvlag2 + "' /></td>";
                        kwartpouleB += "<td width='175px' height='25px'>" + team1_2 + "</td>";
                        kwartpouleB += "<td width='50px' style='text-align: center'>" + winst2 + "</td>";
                        kwartpouleB += "</tr>";
                    }
                }

                kwartpouleB += "</table>";
                kwartpouleBTXT.Text = kwartpouleB;

            }
            else
            {
                Response.Write(count);
            }

            connectieDatabase database8 = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            DataTable dt8 = database8.dataSelecteren("SELECT TOP 2 Teams.Team_naam AS Team1, Teams.Team_ID AS Team2, Teams.Winst AS Winst, Teams.Vlag AS Vlag FROM Teams INNER JOIN Poule ON Teams.Poule_ID = Poule.Poule_ID WHERE (((Teams.Poule_ID)=3)) ORDER BY Teams.Winst DESC;");

            string kwartvlag3 = "";
            string team1_3 = "";
            string winst3 = "";


            int count8 = dt8.Rows.Count;

            if (count8 > 0)
            {
                kwartpouleC += "<table border='1'>";
                kwartpouleC += "<th width='40px'></th>";
                kwartpouleC += "<th width='175px'></th>";
                kwartpouleC += "<th width='50px'>Winst</th>";
                for (int i = 0; i < count8; i++)
                {
                    kwartvlag3 = dt8.Rows[i]["Vlag"].ToString();
                    team1_3 = dt8.Rows[i]["Team1"].ToString();
                    winst3 = dt8.Rows[i]["Winst"].ToString();

                    if (i + 1 <= count8)
                    {
                        kwartpouleC += "<tr>";
                        kwartpouleC += "<td width='40px'><img src='" + kwartvlag3 + "' /></td>";
                        kwartpouleC += "<td width='175px' height='25px'>" + team1_3 + "</td>";
                        kwartpouleC += "<td width='50px' style='text-align: center'>" + winst3 + "</td>";
                        kwartpouleC += "</tr>";
                    }
                }

                kwartpouleC += "</table>";
                kwartpouleCTXT.Text = kwartpouleC;

            }
            else
            {
                Response.Write(count);
            }

            connectieDatabase database9 = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            DataTable dt9 = database9.dataSelecteren("SELECT TOP 2 Teams.Team_naam AS Team1, Teams.Team_ID AS Team2, Teams.Winst AS Winst, Teams.Vlag AS Vlag FROM Teams INNER JOIN Poule ON Teams.Poule_ID = Poule.Poule_ID WHERE (((Teams.Poule_ID)=4)) ORDER BY Teams.Winst DESC;");

            string kwartvlag4 = "";
            string team1_4 = "";
            string winst4 = "";


            int count9 = dt9.Rows.Count;

            if (count9 > 0)
            {
                kwartpouleD += "<table border='1'>";
                kwartpouleD += "<th width='40px'></th>";
                kwartpouleD += "<th width='175px'></th>";
                kwartpouleD += "<th width='50px'>Winst</th>";
                for (int i = 0; i < count9; i++)
                {
                    kwartvlag4 = dt9.Rows[i]["Vlag"].ToString();
                    team1_4 = dt9.Rows[i]["Team1"].ToString();
                    winst4 = dt9.Rows[i]["Winst"].ToString();

                    if (i + 1 <= count9)
                    {
                        kwartpouleD += "<tr>";
                        kwartpouleD += "<td width='40px'><img src='" + kwartvlag4 + "' /></td>";
                        kwartpouleD += "<td width='175px' height='25px'>" + team1_4 + "</td>";
                        kwartpouleD += "<td width='50px' style='text-align: center'>" + winst4 + "</td>";
                        kwartpouleD += "</tr>";
                    }
                }

                kwartpouleD += "</table>";
                kwartpouleDTXT.Text = kwartpouleD;

            }
            else
            {
                Response.Write(count);
            }
        }
    }
}