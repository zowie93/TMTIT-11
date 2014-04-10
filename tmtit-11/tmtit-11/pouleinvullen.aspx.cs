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

        }

        protected void gvGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (DataControlRowType.DataRow == e.Row.RowType && e.Row.RowState != DataControlRowState.Edit && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
            {
                
                connectieDatabase database = new connectieDatabase("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|tmtit11database.mdb");
                DataTable dt = database.dataSelecteren("SELECT Wedstrijden.Wedstrijd_ID, Teams.Team_naam, Teams_1.Team_naam, Wedstrijden.doelpuntenteam1, Wedstrijden.doelpuntenteam2 FROM Teams AS Teams_1 INNER JOIN (Teams INNER JOIN Wedstrijden ON Teams.Team_ID = Wedstrijden.Team1_ID) ON Teams_1.Team_ID = Wedstrijden.Team2_ID");

                int count = dt.Rows.Count;
                /* string doelpuntenteam1 = ""; */
                
                
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        /*
                        doelpuntenteam1 = dt.Rows[i]["doelpuntenteam1"].ToString();
                        if (i + 1 <= count)
                        {
                            Response.Write(doelpuntenteam1);
                        }
                         */
                        
                    }

                    /*
                    TextBox tx = new TextBox();
                    tx.ID = "scoreteam1";
                    tx.Width = 30;
                    tx.Attributes.Add("runat", "server");
                    e.Row.Cells[3].Controls.Add(tx);

                    TextBox tx2 = new TextBox();
                    tx2.ID = "scoreteam2";
                    tx2.Width = 30;
                    tx2.Attributes.Add("runat", "server");
                    e.Row.Cells[5].Controls.Add(tx2);
                     */

                    Label streepje = new Label();
                    streepje.Text = "-";
                    streepje.Width = 40;
                    streepje.CssClass = "label_center";
                    streepje.Attributes.Add("runat", "server");
                    e.Row.Cells[3].Controls.Add(streepje);


                }
             
            }
             
        }
    }
}