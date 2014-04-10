<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pouleinvullen.aspx.cs" Inherits="tmtit_11.pouleinvullen1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WK 2014 - TMTIT-11 - Poule Invullen </title>
    <link href="css/style.css" rel="stylesheet" />
    <script src='http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js'></script>
	<script type='text/javascript' src='menu_jquery.js'></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="container_css">
        <div id="header_css">
            <div id="logo">
                <img src="img/logo.png" alt="Logo" />
            </div>
        </div>
        <div id="navigatie_css">
             <div id='cssmenu'>
                <ul>
                   <li class='has-sub' style='background: #4a4a4a;'><a href='default.aspx'><span>Home</span></a></li>
                   <li class='has-sub active'><a href='poulegegevens.aspx'><span>poulegegevens</span></a>
                      <ul>
                         <li class='active'><a href='pouleinvullen.aspx'><span>poule invullen</span></a></li>
                      </ul>
                   </li>
                   <li class='has-sub'><a href='speelschema.aspx'><span>speelschema</span></a>
                   </li>
                   <li class='has-sub'><a href='uitslagen.aspx'><span>uitslagen</span></a></li>
                   <li class='has-sub last'><a href='login.aspx'><span>login</span></a></li>
                </ul>
            </div>
         </div>
        <div id="content">

            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Horizontal" OnRowDataBound="gvGridView_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Wedstrijd_ID" HeaderText="ID" InsertVisible="False" SortExpression="Wedstrijd_ID" />
                            <asp:BoundField DataField="Teams.Team_naam" HeaderText="1" SortExpression="Teams.Team_naam" />
                            <asp:BoundField DataField="doelpuntenteam1" HeaderText="S1" SortExpression="doelpuntenteam1" />
                            <asp:BoundField DataField="" HeaderText="" SortExpression="" />
                            <asp:BoundField DataField="doelpuntenteam2" HeaderText="S2" SortExpression="doelpuntenteam2" />
                            <asp:BoundField DataField="Teams_1.Team_naam" HeaderText="2" SortExpression="Teams_1.Team_naam" />
                            <asp:ButtonField ButtonType="Button" CommandName="Update" Text="Edit" />
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT Wedstrijden.Wedstrijd_ID, Teams.Team_naam, Teams_1.Team_naam, Wedstrijden.doelpuntenteam1, Wedstrijden.doelpuntenteam2 FROM Teams AS Teams_1 INNER JOIN (Teams INNER JOIN Wedstrijden ON Teams.Team_ID = Wedstrijden.Team1_ID) ON Teams_1.Team_ID = Wedstrijden.Team2_ID"></asp:SqlDataSource>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
        <div id="footer">
            <p>Copyright © 2014 Sulayman Hatuluwaja | 70059 | I2C2 & Zowie van Geest | 64253 | I2C2 </p>
        </div>
    </div>
    </form>
</body>
</html>
