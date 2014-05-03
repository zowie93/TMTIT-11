using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tmtit_11.App_Code;

namespace tmtit_11
{
    public partial class pouleinvullen1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.Request.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }
            connectieDatabase database = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            DataTable dt = database.dataSelecteren("SELECT Wedstrijden.Wedstrijd_ID, Teams.Team_naam AS Team1, Teams_1.Team_naam AS Team2, Wedstrijden.doelpuntenteam1 AS Score1, Wedstrijden.doelpuntenteam2 AS Score2, Poule.Poule_naam AS Poulenaam FROM (Teams AS Teams_1 INNER JOIN (Teams INNER JOIN Wedstrijden ON Teams.Team_ID = Wedstrijden.Team1_ID) ON Teams_1.Team_ID = Wedstrijden.Team2_ID) INNER JOIN Poule ON Wedstrijden.Poule_ID = Poule.Poule_ID");

            if (!IsPostBack)
            {
                fillgrid();
            }

            lblTxtLand1.Visible = false;
            txtBoxScore1.Visible = false;
            lblTxtStreep.Visible = false;
            txtBoxScore2.Visible = false;
            lblTxtLand2.Visible = false;

            halvelblTxtLand1.Visible = false;
            halvelblTxtLand2.Visible = false;
            halvelblTxtLand3.Visible = false;
            halvelblTxtLand4.Visible = false;

            finalelblTxtLand1.Visible = false;
            finalelblTxtLand2.Visible = false;
            finaletxtBoxScore1.Visible = false;
            finaletxtBoxScore2.Visible = false;

            berekenPouleFinale.Visible = false;

            halvetxtBoxScore1.Visible = false;
            halvetxtBoxScore2.Visible = false;
            halvetxtBoxScore3.Visible = false;
            halvetxtBoxScore4.Visible = false;

            berekenPouleHalve1.Visible = false;
            berekenPouleHalve2.Visible = false;

            halvefinaleLbl.Visible = false;

            streep2.Visible = false;
            streep3.Visible = false;
            streep4.Visible = false;

            berekenPouleArest.Visible = false;
            Label13.Visible = false;
            halveFinaleTxt.Visible = false;
            finaleLbl.Visible = false;
            lblLeegScore.Visible = false;
        }
        public void fillgrid()
        {
            connectieDatabase database = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            DataTable dt = database.dataSelecteren("SELECT Wedstrijden.Wedstrijd_ID, Teams.Team_naam AS Team1, Teams_1.Team_naam AS Team2, Wedstrijden.doelpuntenteam1 AS Score1, Wedstrijden.doelpuntenteam2 AS Score2, Poule.Poule_naam AS Poulenaam FROM (Teams AS Teams_1 INNER JOIN (Teams INNER JOIN Wedstrijden ON Teams.Team_ID = Wedstrijden.Team1_ID) ON Teams_1.Team_ID = Wedstrijden.Team2_ID) INNER JOIN Poule ON Wedstrijden.Poule_ID = Poule.Poule_ID");


            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            fillgrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            string id        = ((Label)GridView1.Rows[e.RowIndex].FindControl("Label7")).Text;
            string team1     = ((Label)GridView1.Rows[e.RowIndex].FindControl("Label8")).Text;
            string score1    = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1")).Text;
            string streepje  = ((Label)GridView1.Rows[e.RowIndex].FindControl("Label9")).Text;
            string score2    = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox2")).Text;
            string team2     = ((Label)GridView1.Rows[e.RowIndex].FindControl("Label10")).Text;



            connectieDatabaseLos databaseLos = new connectieDatabaseLos();
            OleDbConnection connectieLos = databaseLos.connectieDatabaseLosFunc();

            string s = "UPDATE Wedstrijden SET doelpuntenteam1= " + score1 + ",doelpuntenteam2= " + score2 + " WHERE Wedstrijd_ID = " + id;
            OleDbCommand resultaat = new OleDbCommand(s, connectieLos);

            databaseLos.databaseOpen(connectieLos);
            resultaat.ExecuteNonQuery();
            GridView1.EditIndex = -1;
            databaseLos.databaseClose(connectieLos);

            fillgrid();
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = GridView1.SelectedRow.Cells[0].Text;

            string team1    = (GridView1.SelectedRow.FindControl("Label2") as Label).Text;
            string score1   = (GridView1.SelectedRow.FindControl("Label3") as Label).Text;
            string score2   = (GridView1.SelectedRow.FindControl("Label5") as Label).Text;
            string team2    = (GridView1.SelectedRow.FindControl("Label6") as Label).Text;

            int score1_int = Int32.Parse(score1);
            int score2_int = Int32.Parse(score2);
            int winst = 3;
            int gelijk = 1;
            int verlies = 0;


            if (score1_int > score2_int)
            {
                score1_txt.Text = "Score1 is groter dan Score2";
               
                connectieDatabaseLos databaseLos = new connectieDatabaseLos();
                OleDbConnection connectieLos = databaseLos.connectieDatabaseLosFunc();

                string s = "UPDATE Teams SET Winst=Winst+'" + winst + "' WHERE Team_naam = '" + team1 + "'";
                string ss = "UPDATE Teams SET Verloren=Verloren+'" + verlies + "' WHERE Team_naam = '" + team2 + "'";
                OleDbCommand resultaat = new OleDbCommand(s, connectieLos);
                OleDbCommand resultaat2 = new OleDbCommand(ss, connectieLos);

                databaseLos.databaseOpen(connectieLos);
                resultaat.ExecuteNonQuery();
                resultaat2.ExecuteNonQuery();
                databaseLos.databaseClose(connectieLos);
                
                
            }
            else if (score1_int < score2_int)
            {
                score1_txt.Text = "Score2 is groter dan Score1";

                connectieDatabaseLos databaseLos = new connectieDatabaseLos();
                OleDbConnection connectieLos = databaseLos.connectieDatabaseLosFunc();

                string s = "UPDATE Teams SET Winst=Winst+'" + winst + "' WHERE Team_naam = '" + team2 + "'";
                string ss = "UPDATE Teams SET Verloren=Verloren+'" + verlies + "' WHERE Team_naam = '" + team1 + "'";
                OleDbCommand resultaat = new OleDbCommand(s, connectieLos);
                OleDbCommand resultaat2 = new OleDbCommand(ss, connectieLos);

                databaseLos.databaseOpen(connectieLos);
                resultaat.ExecuteNonQuery();
                resultaat2.ExecuteNonQuery();
                databaseLos.databaseClose(connectieLos);
                

            }
            else if (score1_int == score2_int)
            {
                score1_txt.Text = "de scores zijn gelijk";

                connectieDatabaseLos databaseLos = new connectieDatabaseLos();
                OleDbConnection connectieLos = databaseLos.connectieDatabaseLosFunc();

                string s    = "UPDATE Teams SET Gelijkspel=Gelijkspel+'" + gelijk + "' WHERE Team_naam = '" + team1 + "'";
                string ss   = "UPDATE Teams SET Gelijkspel=Gelijkspel+'" + gelijk + "' WHERE Team_naam = '" + team2 + "'";
                OleDbCommand resultaat = new OleDbCommand(s, connectieLos);
                OleDbCommand resultaat2 = new OleDbCommand(ss, connectieLos);

                databaseLos.databaseOpen(connectieLos);
                resultaat.ExecuteNonQuery();
                resultaat2.ExecuteNonQuery();
                databaseLos.databaseClose(connectieLos);

            }
            else
            {
                score1_txt.Text = "Vul wel een score in";
            }

        }

        protected void berekenPouleA_Click(object sender, EventArgs e)
        {
            lblTxtLand1.Visible = true;
            txtBoxScore1.Visible = true;
            lblTxtStreep.Visible = true;
            txtBoxScore2.Visible = true;
            lblTxtLand2.Visible = true;
            berekenPouleArest.Visible = true;
            Label13.Visible = true;
            labelPouleA.Visible = true;
            lblLeegScore.Visible = false;

            string pouleA = "";

            connectieDatabase database = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            DataTable dt = database.dataSelecteren("SELECT TOP 2 Teams.Team_naam, Teams.Team_ID, Teams.Winst AS Winst, Poule.Poule_naam FROM Teams INNER JOIN Poule ON Teams.Poule_ID = Poule.Poule_ID WHERE (((Teams.Poule_ID)=1)) ORDER BY Teams.Winst DESC");

            string teamnaam = "";
            string teamnaam2 = "";

            int count = dt.Rows.Count;

            if (count > 0)
            {
                pouleA += "Deze 2 teams zijn door uit Poule A<br/>";
                    teamnaam = dt.Rows[0]["Team_naam"].ToString();
                    teamnaam2 = dt.Rows[1]["Team_naam"].ToString();
                labelPouleA.Text = pouleA;

            }

            else
            {
                Response.Write(count);
            }

            lblTxtLand1.Text = teamnaam;
            lblTxtLand2.Text = teamnaam2;

            berekenPouleArest.Visible = true;
        }

        protected void berekenPouleArest_Click(object sender, EventArgs e)
        {

            Label13.Visible = true;
            lblLeegScore.Visible = false;

            string score1 = txtBoxScore1.Text;
            string score2 = txtBoxScore2.Text;

            string teamnaam1 = lblTxtLand1.Text;
            string teamnaam2 = lblTxtLand2.Text;

            int winst = 3;
            int gelijk = 1;
            int verlies = 0;

            int score1_int = Int32.Parse(score1);
            int score2_int = Int32.Parse(score2);

            if (score1_int > score2_int)
            {
                Label13.Text = "<br/><br/>Uw gegevens zijn ingevoerd. <br/>Het is " + score1 + " - " + score2 + " voor " + teamnaam1 + " geworden.";

                
                connectieDatabaseLos databaseLos = new connectieDatabaseLos();
                OleDbConnection connectieLos = databaseLos.connectieDatabaseLosFunc();

                string s = "UPDATE Teams SET Winst=Winst+'" + winst + "' WHERE Team_naam = '" + teamnaam1 + "'";
                string ss = "UPDATE Teams SET Verloren=Verloren+'" + verlies + "' WHERE Team_naam = '" + teamnaam2 + "'";
                OleDbCommand resultaat = new OleDbCommand(s, connectieLos);
                OleDbCommand resultaat2 = new OleDbCommand(ss, connectieLos);

                databaseLos.databaseOpen(connectieLos);
                resultaat.ExecuteNonQuery();
                resultaat2.ExecuteNonQuery();
                databaseLos.databaseClose(connectieLos);
                
            } else if (score1_int < score2_int)
            {
                Label13.Text = "<br/><br/>Uw gegevens zijn ingevoerd. <br/>Het is " + score2 + " - " + score1 + " voor " + teamnaam2 + " geworden.";

                connectieDatabaseLos databaseLos = new connectieDatabaseLos();
                OleDbConnection connectieLos = databaseLos.connectieDatabaseLosFunc();

                string s = "UPDATE Teams SET Winst=Winst+'" + winst + "' WHERE Team_naam = '" + teamnaam2 + "'";
                string ss = "UPDATE Teams SET Verloren=Verloren+'" + verlies + "' WHERE Team_naam = '" + teamnaam1 + "'";
                OleDbCommand resultaat = new OleDbCommand(s, connectieLos);
                OleDbCommand resultaat2 = new OleDbCommand(ss, connectieLos);

                databaseLos.databaseOpen(connectieLos);
                resultaat.ExecuteNonQuery();
                resultaat2.ExecuteNonQuery();
                databaseLos.databaseClose(connectieLos);

            }
            else if (score1_int == score2_int)
            {
                Label13.Text = "<br/><br/>Uw gegevens zijn ingevoerd. <br/>Het is met " + score1 + " - " + score2 + " gelijkspel geworden.";

                connectieDatabaseLos databaseLos = new connectieDatabaseLos();
                OleDbConnection connectieLos = databaseLos.connectieDatabaseLosFunc();

                string s = "UPDATE Teams SET Gelijkspel=Gelijkspel+'" + gelijk + "' WHERE Team_naam = '" + teamnaam1 + "'";
                string ss = "UPDATE Teams SET Gelijkspel=Gelijkspel+'" + gelijk + "' WHERE Team_naam = '" + teamnaam2 + "'";
                OleDbCommand resultaat = new OleDbCommand(s, connectieLos);
                OleDbCommand resultaat2 = new OleDbCommand(ss, connectieLos);

                databaseLos.databaseOpen(connectieLos);
                resultaat.ExecuteNonQuery();
                resultaat2.ExecuteNonQuery();
                databaseLos.databaseClose(connectieLos);

            }
            else
            {
                Label13.Text = "Vul wel een score in";
            }
        }

        protected void berekenPouleB_Click(object sender, EventArgs e)
        {
            lblTxtLand1.Visible = true;
            txtBoxScore1.Visible = true;
            lblTxtStreep.Visible = true;
            txtBoxScore2.Visible = true;
            lblTxtLand2.Visible = true;
            berekenPouleArest.Visible = true;
            Label13.Visible = true;
            labelPouleA.Visible = true;
            lblLeegScore.Visible = false;

            string pouleA = "";

            connectieDatabase database = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            DataTable dt = database.dataSelecteren("SELECT TOP 2 Teams.Team_naam, Teams.Team_ID, Teams.Winst AS Winst, Poule.Poule_naam FROM Teams INNER JOIN Poule ON Teams.Poule_ID = Poule.Poule_ID WHERE (((Teams.Poule_ID)=2)) ORDER BY Teams.Winst DESC");

            string teamnaam = "";
            string teamnaam2 = "";

            int count = dt.Rows.Count;

            if (count > 0)
            {
                pouleA += "Deze 2 teams zijn door uit Poule B<br/>";
                teamnaam = dt.Rows[0]["Team_naam"].ToString();
                teamnaam2 = dt.Rows[1]["Team_naam"].ToString();
                labelPouleA.Text = pouleA;
            }

            else
            {
                Response.Write(count);
            }

            lblTxtLand1.Text = teamnaam;
            lblTxtLand2.Text = teamnaam2;

            berekenPouleArest.Visible = true;
        }

        protected void berekenPouleC_Click(object sender, EventArgs e)
        {
            lblTxtLand1.Visible = true;
            txtBoxScore1.Visible = true;
            lblTxtStreep.Visible = true;
            txtBoxScore2.Visible = true;
            lblTxtLand2.Visible = true;
            berekenPouleArest.Visible = true;
            Label13.Visible = true;
            labelPouleA.Visible = true;
            lblLeegScore.Visible = false;

            string pouleA = "";

            connectieDatabase database = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            DataTable dt = database.dataSelecteren("SELECT TOP 2 Teams.Team_naam, Teams.Team_ID, Teams.Winst AS Winst, Poule.Poule_naam FROM Teams INNER JOIN Poule ON Teams.Poule_ID = Poule.Poule_ID WHERE (((Teams.Poule_ID)=3)) ORDER BY Teams.Winst DESC");

            string teamnaam = "";
            string teamnaam2 = "";

            int count = dt.Rows.Count;

            if (count > 0)
            {
                pouleA += "Deze 2 teams zijn door uit Poule C<br/>";
                teamnaam = dt.Rows[0]["Team_naam"].ToString();
                teamnaam2 = dt.Rows[1]["Team_naam"].ToString();
                labelPouleA.Text = pouleA;
            }

            else
            {
                Response.Write(count);
            }

            lblTxtLand1.Text = teamnaam;
            lblTxtLand2.Text = teamnaam2;

            berekenPouleArest.Visible = true;

        }

        protected void berekenPouleD_Click(object sender, EventArgs e)
        {
            lblTxtLand1.Visible = true;
            txtBoxScore1.Visible = true;
            lblTxtStreep.Visible = true;
            txtBoxScore2.Visible = true;
            lblTxtLand2.Visible = true;
            berekenPouleArest.Visible = true;
            Label13.Visible = true;
            labelPouleA.Visible = true;
            lblLeegScore.Visible = false;

            string pouleA = "";

            connectieDatabase database = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            DataTable dt = database.dataSelecteren("SELECT TOP 2 Teams.Team_naam, Teams.Team_ID, Teams.Winst AS Winst, Poule.Poule_naam FROM Teams INNER JOIN Poule ON Teams.Poule_ID = Poule.Poule_ID WHERE (((Teams.Poule_ID)=4)) ORDER BY Teams.Winst DESC");

            string teamnaam = "";
            string teamnaam2 = "";

            int count = dt.Rows.Count;

            if (count > 0)
            {
                pouleA += "Deze 2 teams zijn door uit Poule D<br/>";
                teamnaam = dt.Rows[0]["Team_naam"].ToString();
                teamnaam2 = dt.Rows[1]["Team_naam"].ToString();
                labelPouleA.Text = pouleA;
            }

            else
            {
                Response.Write(count);
            }

            lblTxtLand1.Text = teamnaam;
            lblTxtLand2.Text = teamnaam2;

            berekenPouleArest.Visible = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            halvelblTxtLand1.Visible = true;
            halvelblTxtLand2.Visible = true;
            halvelblTxtLand3.Visible = true;
            halvelblTxtLand4.Visible = true;

            halvetxtBoxScore1.Visible = true;
            halvetxtBoxScore2.Visible = true;
            halvetxtBoxScore3.Visible = true;
            halvetxtBoxScore4.Visible = true;

            berekenPouleHalve1.Visible = true;
            berekenPouleHalve2.Visible = true;
            labelPouleA.Visible = false;
            lblLeegScore.Visible = false;

            streep2.Visible = true;
            streep3.Visible = true;

            halvefinaleLbl.Visible = true;

            string halvefinale = "";

            connectieDatabase database = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            DataTable dt = database.dataSelecteren("SELECT TOP 1 Teams.Team_naam, Teams.Team_ID, Teams.Winst AS Winst, Poule.Poule_naam FROM Teams INNER JOIN Poule ON Teams.Poule_ID = Poule.Poule_ID WHERE (((Teams.Poule_ID)=1)) ORDER BY Teams.Winst DESC");

            string halvefinaleteam1 = "";

            int count = dt.Rows.Count;

            if (count > 0)
            {
                halvefinale += "Deze 4 teams zitten in de Halve Finale!<br/>";
                halvefinaleteam1 = dt.Rows[0]["Team_naam"].ToString();
                halvefinaleLbl.Text = halvefinale;
            }

            else
            {
                Response.Write(count);
            }

            halvelblTxtLand1.Text = halvefinaleteam1;

            connectieDatabase database2 = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            DataTable dt2 = database2.dataSelecteren2("SELECT TOP 1 Teams.Team_naam, Teams.Team_ID, Teams.Winst AS Winst, Poule.Poule_naam FROM Teams INNER JOIN Poule ON Teams.Poule_ID = Poule.Poule_ID WHERE (((Teams.Poule_ID)=2)) ORDER BY Teams.Winst DESC");

            string halvefinaleteam2 = "";

            int count2 = dt2.Rows.Count;

            if (count2 > 0)
            {
                halvefinaleteam2 = dt2.Rows[0]["Team_naam"].ToString();
            }

            else
            {
                Response.Write(count);
            }

            halvelblTxtLand2.Text = halvefinaleteam2;

            connectieDatabase database3 = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            DataTable dt3 = database.dataSelecteren("SELECT TOP 1 Teams.Team_naam, Teams.Team_ID, Teams.Winst AS Winst, Poule.Poule_naam FROM Teams INNER JOIN Poule ON Teams.Poule_ID = Poule.Poule_ID WHERE (((Teams.Poule_ID)=3)) ORDER BY Teams.Winst DESC");

            string halvefinaleteam3 = "";

            int count3 = dt3.Rows.Count;

            if (count3 > 0)
            {
                halvefinaleteam3 = dt3.Rows[0]["Team_naam"].ToString();
            }

            else
            {
                Response.Write(count);
            }

            halvelblTxtLand3.Text = halvefinaleteam3;

            connectieDatabase database4 = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            DataTable dt4 = database2.dataSelecteren2("SELECT TOP 1 Teams.Team_naam, Teams.Team_ID, Teams.Winst AS Winst, Poule.Poule_naam FROM Teams INNER JOIN Poule ON Teams.Poule_ID = Poule.Poule_ID WHERE (((Teams.Poule_ID)=4)) ORDER BY Teams.Winst DESC");

            string halvefinaleteam4 = "";

            int count4 = dt4.Rows.Count;

            if (count4 > 0)
            {
                halvefinaleteam4 = dt4.Rows[0]["Team_naam"].ToString();
            }

            else
            {
                Response.Write(count);
            }

            halvelblTxtLand4.Text = halvefinaleteam4;



        }

        protected void berekenPouleHalve1_Click(object sender, EventArgs e)
        {
            halveFinaleTxt.Visible = true;
            lblLeegScore.Visible = false;

            string score1 = halvetxtBoxScore1.Text;
            string score2 = halvetxtBoxScore2.Text;

            string teamnaam1 = halvelblTxtLand1.Text;
            string teamnaam2 = halvelblTxtLand2.Text;

            int winst = 3;
            int gelijk = 1;
            int verlies = 0;

            int score1_int = Int32.Parse(score1);
            int score2_int = Int32.Parse(score2);

            if (score1_int > score2_int)
            {
                halveFinaleTxt.Text = "<br/><br/>Uw gegevens zijn ingevoerd. <br/>Het is " + score1 + " - " + score2 + " voor " + teamnaam1 + " geworden.";


                connectieDatabaseLos databaseLos = new connectieDatabaseLos();
                OleDbConnection connectieLos = databaseLos.connectieDatabaseLosFunc();

                string s = "UPDATE Teams SET Winst=Winst+'" + winst + "' WHERE Team_naam = '" + teamnaam1 + "'";
                string ss = "UPDATE Teams SET Verloren=Verloren+'" + verlies + "' WHERE Team_naam = '" + teamnaam2 + "'";
                OleDbCommand resultaat = new OleDbCommand(s, connectieLos);
                OleDbCommand resultaat2 = new OleDbCommand(ss, connectieLos);

                databaseLos.databaseOpen(connectieLos);
                resultaat.ExecuteNonQuery();
                resultaat2.ExecuteNonQuery();
                databaseLos.databaseClose(connectieLos);

            }
            else if (score1_int < score2_int)
            {
                halveFinaleTxt.Text = "<br/><br/>Uw gegevens zijn ingevoerd. <br/>Het is " + score2 + " - " + score1 + " voor " + teamnaam2 + " geworden.";

                connectieDatabaseLos databaseLos = new connectieDatabaseLos();
                OleDbConnection connectieLos = databaseLos.connectieDatabaseLosFunc();

                string s = "UPDATE Teams SET Winst=Winst+'" + winst + "' WHERE Team_naam = '" + teamnaam2 + "'";
                string ss = "UPDATE Teams SET Verloren=Verloren+'" + verlies + "' WHERE Team_naam = '" + teamnaam1 + "'";
                OleDbCommand resultaat = new OleDbCommand(s, connectieLos);
                OleDbCommand resultaat2 = new OleDbCommand(ss, connectieLos);

                databaseLos.databaseOpen(connectieLos);
                resultaat.ExecuteNonQuery();
                resultaat2.ExecuteNonQuery();
                databaseLos.databaseClose(connectieLos);

            }
            else if (score1_int == score2_int)
            {
                halveFinaleTxt.Text = "<br/><br/>Uw gegevens zijn ingevoerd. <br/>Het is met " + score1 + " - " + score2 + " gelijkspel geworden.";

                connectieDatabaseLos databaseLos = new connectieDatabaseLos();
                OleDbConnection connectieLos = databaseLos.connectieDatabaseLosFunc();

                string s = "UPDATE Teams SET Gelijkspel=Gelijkspel+'" + gelijk + "' WHERE Team_naam = '" + teamnaam1 + "'";
                string ss = "UPDATE Teams SET Gelijkspel=Gelijkspel+'" + gelijk + "' WHERE Team_naam = '" + teamnaam2 + "'";
                OleDbCommand resultaat = new OleDbCommand(s, connectieLos);
                OleDbCommand resultaat2 = new OleDbCommand(ss, connectieLos);

                databaseLos.databaseOpen(connectieLos);
                resultaat.ExecuteNonQuery();
                resultaat2.ExecuteNonQuery();
                databaseLos.databaseClose(connectieLos);

            }
            else
            {
                halveFinaleTxt.Text = "Vul wel een score in";
            }
        }

        protected void berekenPouleHalve2_Click(object sender, EventArgs e)
        {
            halveFinaleTxt.Visible = true;
            lblLeegScore.Visible = false;

            string score1 = halvetxtBoxScore3.Text;
            string score2 = halvetxtBoxScore4.Text;

            string teamnaam1 = halvelblTxtLand3.Text;
            string teamnaam2 = halvelblTxtLand4.Text;

            int winst = 3;
            int gelijk = 1;
            int verlies = 0;

            int score1_int = Int32.Parse(score1);
            int score2_int = Int32.Parse(score2);

            if (score1_int > score2_int)
            {
                halveFinaleTxt.Text = "<br/><br/>Uw gegevens zijn ingevoerd. <br/>Het is " + score1 + " - " + score2 + " voor " + teamnaam1 + " geworden.";


                connectieDatabaseLos databaseLos = new connectieDatabaseLos();
                OleDbConnection connectieLos = databaseLos.connectieDatabaseLosFunc();

                string s = "UPDATE Teams SET Winst=Winst+'" + winst + "' WHERE Team_naam = '" + teamnaam1 + "'";
                string ss = "UPDATE Teams SET Verloren=Verloren+'" + verlies + "' WHERE Team_naam = '" + teamnaam2 + "'";
                OleDbCommand resultaat = new OleDbCommand(s, connectieLos);
                OleDbCommand resultaat2 = new OleDbCommand(ss, connectieLos);

                databaseLos.databaseOpen(connectieLos);
                resultaat.ExecuteNonQuery();
                resultaat2.ExecuteNonQuery();
                databaseLos.databaseClose(connectieLos);

            }
            else if (score1_int < score2_int)
            {
                halveFinaleTxt.Text = "<br/><br/>Uw gegevens zijn ingevoerd. <br/>Het is " + score2 + " - " + score1 + " voor " + teamnaam2 + " geworden.";

                connectieDatabaseLos databaseLos = new connectieDatabaseLos();
                OleDbConnection connectieLos = databaseLos.connectieDatabaseLosFunc();

                string s = "UPDATE Teams SET Winst=Winst+'" + winst + "' WHERE Team_naam = '" + teamnaam2 + "'";
                string ss = "UPDATE Teams SET Verloren=Verloren+'" + verlies + "' WHERE Team_naam = '" + teamnaam1 + "'";
                OleDbCommand resultaat = new OleDbCommand(s, connectieLos);
                OleDbCommand resultaat2 = new OleDbCommand(ss, connectieLos);

                databaseLos.databaseOpen(connectieLos);
                resultaat.ExecuteNonQuery();
                resultaat2.ExecuteNonQuery();
                databaseLos.databaseClose(connectieLos);

            }
            else if (score1_int == score2_int)
            {
                halveFinaleTxt.Text = "<br/><br/>Uw gegevens zijn ingevoerd. <br/>Het is met " + score1 + " - " + score2 + " gelijkspel geworden.";

                connectieDatabaseLos databaseLos = new connectieDatabaseLos();
                OleDbConnection connectieLos = databaseLos.connectieDatabaseLosFunc();

                string s = "UPDATE Teams SET Gelijkspel=Gelijkspel+'" + gelijk + "' WHERE Team_naam = '" + teamnaam1 + "'";
                string ss = "UPDATE Teams SET Gelijkspel=Gelijkspel+'" + gelijk + "' WHERE Team_naam = '" + teamnaam2 + "'";
                OleDbCommand resultaat = new OleDbCommand(s, connectieLos);
                OleDbCommand resultaat2 = new OleDbCommand(ss, connectieLos);

                databaseLos.databaseOpen(connectieLos);
                resultaat.ExecuteNonQuery();
                resultaat2.ExecuteNonQuery();
                databaseLos.databaseClose(connectieLos);

            }
            else
            {
                halveFinaleTxt.Text = "Vul wel een score in";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            finalelblTxtLand1.Visible = true;
            finalelblTxtLand2.Visible = true;
            finaletxtBoxScore1.Visible = true;
            finaletxtBoxScore2.Visible = true;

            berekenPouleFinale.Visible = true;
            finaleLbl.Visible = true;
            streep4.Visible = true;
            lblLeegScore.Visible = false;

            string finale = "";

            connectieDatabase database = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            DataTable dt = database.dataSelecteren("SELECT TOP 2 Teams.Team_naam, Teams.Team_ID, Teams.Winst AS Winst, Teams.Gelijkspel, Teams.Verloren, Teams.Poule_ID, Poule.Poule_naam FROM Teams INNER JOIN Poule ON Teams.Poule_ID = Poule.Poule_ID ORDER BY Teams.Winst DESC");

            string teamnaam = "";
            string teamnaam2 = "";

            int count = dt.Rows.Count;

            if (count > 0)
            {
                finale += "Dit zijn de Finalisten!<br/>";
                teamnaam = dt.Rows[0]["Team_naam"].ToString();
                teamnaam2 = dt.Rows[1]["Team_naam"].ToString();
                finaleLbl.Text = finale;
            }

            else
            {
                Response.Write(count);
            }

            finalelblTxtLand1.Text = teamnaam;
            finalelblTxtLand2.Text = teamnaam2;


        }

        protected void berekenPouleFinale_Click(object sender, EventArgs e)
        {
            FinaleTxt.Visible = true;
            lblLeegScore.Visible = false;

            string score1 = finaletxtBoxScore1.Text;
            string score2 = finaletxtBoxScore2.Text;

            string teamnaam1 = finalelblTxtLand1.Text;
            string teamnaam2 = finalelblTxtLand2.Text;

            int winst = 3;
            int gelijk = 1;
            int verlies = 0;

            int score1_int = Int32.Parse(score1);
            int score2_int = Int32.Parse(score2);

            if (score1_int > score2_int)
            {
                FinaleTxt.Text = "<br/><br/>Uw gegevens zijn ingevoerd. <br/>Het is " + score1 + " - " + score2 + " voor " + teamnaam1 + " geworden.";
                winnaarTekst.Text = "EN DE WINNAAR VAN HET WK 2014 IS <br />" + teamnaam1 + ".";


                connectieDatabaseLos databaseLos = new connectieDatabaseLos();
                OleDbConnection connectieLos = databaseLos.connectieDatabaseLosFunc();

                string s = "UPDATE Teams SET Winst=Winst+'" + winst + "' WHERE Team_naam = '" + teamnaam1 + "'";
                string ss = "UPDATE Teams SET Verloren=Verloren+'" + verlies + "' WHERE Team_naam = '" + teamnaam2 + "'";
                OleDbCommand resultaat = new OleDbCommand(s, connectieLos);
                OleDbCommand resultaat2 = new OleDbCommand(ss, connectieLos);

                databaseLos.databaseOpen(connectieLos);
                resultaat.ExecuteNonQuery();
                resultaat2.ExecuteNonQuery();
                databaseLos.databaseClose(connectieLos);

            }
            else if (score1_int < score2_int)
            {
                FinaleTxt.Text = "<br/><br/>Uw gegevens zijn ingevoerd. <br/>Het is " + score2 + " - " + score1 + " voor " + teamnaam2 + " geworden.";
                winnaarTekst.Text = "EN DE WINNAAR VAN HET WK 2014 IS <br />" + teamnaam2 + ".";

                connectieDatabaseLos databaseLos = new connectieDatabaseLos();
                OleDbConnection connectieLos = databaseLos.connectieDatabaseLosFunc();

                string s = "UPDATE Teams SET Winst=Winst+'" + winst + "' WHERE Team_naam = '" + teamnaam2 + "'";
                string ss = "UPDATE Teams SET Verloren=Verloren+'" + verlies + "' WHERE Team_naam = '" + teamnaam1 + "'";
                OleDbCommand resultaat = new OleDbCommand(s, connectieLos);
                OleDbCommand resultaat2 = new OleDbCommand(ss, connectieLos);

                databaseLos.databaseOpen(connectieLos);
                resultaat.ExecuteNonQuery();
                resultaat2.ExecuteNonQuery();
                databaseLos.databaseClose(connectieLos);

            }
            else if (score1_int == score2_int)
            {
                FinaleTxt.Text = "<br/><br/>Uw gegevens zijn ingevoerd. <br/>Het is met " + score1 + " - " + score2 + " gelijkspel geworden.";
                winnaarTekst.Text = "HELAAS GELIJKSPEL! <br />" + teamnaam1 + ". EN " + teamnaam2 + ". SPEEL OPNIEUW!";

                connectieDatabaseLos databaseLos = new connectieDatabaseLos();
                OleDbConnection connectieLos = databaseLos.connectieDatabaseLosFunc();

                string s = "UPDATE Teams SET Gelijkspel=Gelijkspel+'" + gelijk + "' WHERE Team_naam = '" + teamnaam1 + "'";
                string ss = "UPDATE Teams SET Gelijkspel=Gelijkspel+'" + gelijk + "' WHERE Team_naam = '" + teamnaam2 + "'";
                OleDbCommand resultaat = new OleDbCommand(s, connectieLos);
                OleDbCommand resultaat2 = new OleDbCommand(ss, connectieLos);

                databaseLos.databaseOpen(connectieLos);
                resultaat.ExecuteNonQuery();
                resultaat2.ExecuteNonQuery();
                databaseLos.databaseClose(connectieLos);

            }
            else
            {
                FinaleTxt.Text = "Vul wel een score in";
            }
        }

        protected void leegScore_Click(object sender, EventArgs e)
        {


            connectieDatabaseLos databaseLos = new connectieDatabaseLos();
            OleDbConnection connectieLos = databaseLos.connectieDatabaseLosFunc();

            string del1 = "UPDATE Teams SET Winst = 0, Gelijkspel=0, Verloren=0 WHERE Team_ID = 1";
            string del2 = "UPDATE Teams SET Winst = 3, Gelijkspel=1, Verloren=0 WHERE Team_ID = 2";
            string del3 = "UPDATE Teams SET Winst = 6, Gelijkspel=0, Verloren=0 WHERE Team_ID = 3";
            string del4 = "UPDATE Teams SET Winst = 6, Gelijkspel=1, Verloren=0 WHERE Team_ID = 4";
            string del5 = "UPDATE Teams SET Winst = 3, Gelijkspel=0, Verloren=0 WHERE Team_ID = 5";
            string del6 = "UPDATE Teams SET Winst = 0, Gelijkspel=1, Verloren=0 WHERE Team_ID = 6";
            string del7 = "UPDATE Teams SET Winst = 6, Gelijkspel=0, Verloren=0 WHERE Team_ID = 7";
            string del8 = "UPDATE Teams SET Winst = 6, Gelijkspel=1, Verloren=0 WHERE Team_ID = 8";
            string del9 = "UPDATE Teams SET Winst = 3, Gelijkspel=0, Verloren=0 WHERE Team_ID = 9";
            string del10 = "UPDATE Teams SET Winst = 0, Gelijkspel=1, Verloren=0 WHERE Team_ID = 10";
            string del11 = "UPDATE Teams SET Winst = 6, Gelijkspel=0, Verloren=0 WHERE Team_ID = 11";
            string del12 = "UPDATE Teams SET Winst = 6, Gelijkspel=1, Verloren=0 WHERE Team_ID = 12";
            string del13 = "UPDATE Teams SET Winst = 3, Gelijkspel=0, Verloren=0 WHERE Team_ID = 13";
            string del14 = "UPDATE Teams SET Winst = 0, Gelijkspel=1, Verloren=0 WHERE Team_ID = 14";
            string del15 = "UPDATE Teams SET Winst = 6, Gelijkspel=0, Verloren=0 WHERE Team_ID = 15";
            string del16 = "UPDATE Teams SET Winst = 6, Gelijkspel=1, Verloren=0 WHERE Team_ID = 16";

            OleDbCommand resultaat1 = new OleDbCommand(del1, connectieLos);
            OleDbCommand resultaat2 = new OleDbCommand(del2, connectieLos);
            OleDbCommand resultaat3 = new OleDbCommand(del3, connectieLos);
            OleDbCommand resultaat4 = new OleDbCommand(del4, connectieLos);
            OleDbCommand resultaat5 = new OleDbCommand(del5, connectieLos);
            OleDbCommand resultaat6 = new OleDbCommand(del6, connectieLos);
            OleDbCommand resultaat7 = new OleDbCommand(del7, connectieLos);
            OleDbCommand resultaat8 = new OleDbCommand(del8, connectieLos);
            OleDbCommand resultaat9 = new OleDbCommand(del9, connectieLos);
            OleDbCommand resultaat10 = new OleDbCommand(del10, connectieLos);
            OleDbCommand resultaat11 = new OleDbCommand(del11, connectieLos);
            OleDbCommand resultaat12 = new OleDbCommand(del12, connectieLos);
            OleDbCommand resultaat13 = new OleDbCommand(del13, connectieLos);
            OleDbCommand resultaat14 = new OleDbCommand(del14, connectieLos);
            OleDbCommand resultaat15 = new OleDbCommand(del15, connectieLos);
            OleDbCommand resultaat16 = new OleDbCommand(del16, connectieLos);

            databaseLos.databaseOpen(connectieLos);
            resultaat1.ExecuteNonQuery();
            resultaat2.ExecuteNonQuery();
            resultaat3.ExecuteNonQuery();
            resultaat4.ExecuteNonQuery();
            resultaat5.ExecuteNonQuery();
            resultaat6.ExecuteNonQuery();
            resultaat7.ExecuteNonQuery();
            resultaat8.ExecuteNonQuery();
            resultaat9.ExecuteNonQuery();
            resultaat10.ExecuteNonQuery();
            resultaat11.ExecuteNonQuery();
            resultaat12.ExecuteNonQuery();
            resultaat13.ExecuteNonQuery();
            resultaat14.ExecuteNonQuery();
            resultaat15.ExecuteNonQuery();
            resultaat16.ExecuteNonQuery();
            databaseLos.databaseClose(connectieLos);

            lblLeegScore.Visible = true;
            lblLeegScore.Text = "Uw scores zijn met succes geleegd";
        }

    }
}