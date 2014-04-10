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
    public partial class pouleinvullen1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            connectieDatabase database = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            DataTable dt = database.dataSelecteren("SELECT Wedstrijden.Wedstrijd_ID, Teams.Team_naam AS Team1, Teams_1.Team_naam AS Team2, Wedstrijden.doelpuntenteam1 AS Score1, Wedstrijden.doelpuntenteam2 AS Score2 FROM Teams AS Teams_1 INNER JOIN (Teams INNER JOIN Wedstrijden ON Teams.Team_ID = Wedstrijden.Team1_ID) ON Teams_1.Team_ID = Wedstrijden.Team2_ID");

            if (!IsPostBack)
            {
                fillgrid();
            }
        }
        public void fillgrid()
        {
            connectieDatabase database = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            DataTable dt = database.dataSelecteren("SELECT Wedstrijden.Wedstrijd_ID, Teams.Team_naam AS Team1, Teams_1.Team_naam AS Team2, Wedstrijden.doelpuntenteam1 AS Score1, Wedstrijden.doelpuntenteam2 AS Score2 FROM Teams AS Teams_1 INNER JOIN (Teams INNER JOIN Wedstrijden ON Teams.Team_ID = Wedstrijden.Team1_ID) ON Teams_1.Team_ID = Wedstrijden.Team2_ID");

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
            string id = ((Label)GridView1.Rows[e.RowIndex].FindControl("Label7")).Text;
            string team1 = ((Label)GridView1.Rows[e.RowIndex].FindControl("Label8")).Text;
            string score1 = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1")).Text;
            string streepje = ((Label)GridView1.Rows[e.RowIndex].FindControl("Label9")).Text;
            string score2 = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox2")).Text;
            string team2 = ((Label)GridView1.Rows[e.RowIndex].FindControl("Label10")).Text;

            string update = "UPDATE Wedstrijden SET doelpuntenteam1='" + score1 + "',doelpuntenteam2=" + score2 + " WHERE ID=" + id;

            connectieDatabase database2 = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
            //String dt = database2.dataUpdate(update);
        }
    }
}