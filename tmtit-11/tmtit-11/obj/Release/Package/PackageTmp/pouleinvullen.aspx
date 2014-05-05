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
                         <li><a href='scoretabel.aspx'><span>Score Tabel</span></a></li>
                         <li class="active"><a href='pouleinvullen.aspx'><span>poule invullen</span></a></li>
                      </ul>
                   </li>
                   <li class='has-sub'><a href='speelschema.aspx'><span>speelschema</span></a>
                   </li>
                   <li class='has-sub'><a href='admin.aspx'><span>Admin</span></a>
                        <ul>
                            <li><a href='veranderwachtwoord.aspx'><span>Verander Wachtwoord</span></a></li>
                            <li><a href="adminMaken.aspx"><span>Nieuwe Admin</span></a></li>
                        </ul>
                   </li>
                   <% if(Session["gebruiker"] == null) { %>
                   <li class='has-sub last'><a href='login.aspx'><span>login</span></a></li>
                    <% } else { %>
                    <li class='has-sub last'><a href='loguit.aspx'><span>loguit</span></a></li>
                    <% } %>
                </ul>
            </div>
         </div>
        <div id="content">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Label ID="score1_txt" runat="server" Text=""></asp:Label><br /><br />
                    <asp:Label ID="score2_txt" runat="server" Text=""></asp:Label>


                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField HeaderText="ID" ItemStyle-Width="30px">
                                <EditItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("Wedstrijd_ID") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Wedstrijd_ID") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Team Naam 1" ItemStyle-Width="150px">
                                <EditItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("Team1") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Team1") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Score" ItemStyle-Width="50px">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Score1") %>' ItemStyle-HorizontalAlign="Center" CssClass="textalignmidden"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Score1") %>' ItemStyle-HorizontalAlign="Center" CssClass="textalignmidden"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="50px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="-" ItemStyle-Width="100px">
                                <EditItemTemplate>
                                    <asp:Label ID="Label9" runat="server" style="text-align:center" Text="-" ItemStyle-HorizontalAlign="Center" CssClass="textalignmidden"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" style="text-align:center" Text="-" ItemStyle-HorizontalAlign="Center" CssClass="textalignmidden"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="textalignmidden" Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Score 2" ItemStyle-Width="50px">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("Score2") %>' CssClass="textalignmidden"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("Score2") %>' CssClass="textalignmidden"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="80px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Team Naam 2" ItemStyle-Width="150px">
                                <EditItemTemplate>
                                    <asp:Label ID="Label10" runat="server" Text='<%# Eval("Team2") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("Team2") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Poule" ItemStyle-Width="150px">
                                <EditItemTemplate>
                                    <asp:Label ID="Label12" runat="server" Text='<%# Eval("Poulenaam") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("Poulenaam") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="150px" />
                            </asp:TemplateField>
                            <asp:CommandField HeaderText="Edit" ShowEditButton="True" />
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="Black" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                    <br />
                    <br />
                    <div id="kwartfinale" style="background-color:#ffffff">
                        <h1 style="text-align: center">KWART FINALE</h1>
                    <br />
                    <asp:Button ID="berekenPouleA" runat="server" OnClick="berekenPouleA_Click" Text="Bereken Poule A" />
                    <asp:Button ID="berekenPouleB" runat="server" Text="Bereken Poule B" OnClick="berekenPouleB_Click" />
                    <asp:Button ID="berekenPouleC" runat="server" Text="Bereken Poule C" OnClick="berekenPouleC_Click" />
                    <asp:Button ID="berekenPouleD" runat="server" Text="Bereken Poule D" OnClick="berekenPouleD_Click" />
                    <br />
                    <asp:Label ID="labelPouleA" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblTxtLand1" runat="server"></asp:Label>
                    <asp:TextBox ID="txtBoxScore1" runat="server"></asp:TextBox>
                    <asp:Label ID="lblTxtStreep" runat="server" Text="-"></asp:Label>
                    <asp:TextBox ID="txtBoxScore2" runat="server"></asp:TextBox>
                    <asp:Label ID="lblTxtLand2" runat="server"></asp:Label>
                    <asp:Button ID="berekenPouleArest" runat="server" OnClick="berekenPouleArest_Click" Text="Invoeren" />
                    <asp:Label ID="Label13" runat="server"></asp:Label>
                    </div>
                    <div id="halvefinale">
                    <h1 style="text-align: center">HALVE FINALE</h1>
                    <br />
                        <asp:Button ID="Button1" runat="server" Text="Bereken Halve Finale" OnClick="Button1_Click" /><br />
                        <asp:Label ID="halvefinaleLbl" runat="server"></asp:Label><br />
                        <asp:Label ID="halvelblTxtLand1" runat="server" Width="90px"></asp:Label>
                        <asp:TextBox ID="halvetxtBoxScore1" runat="server"></asp:TextBox>
                        <asp:Label ID="streep2" runat="server" Text="-"></asp:Label>
                        <asp:TextBox ID="halvetxtBoxScore2" runat="server"></asp:TextBox>
                        <asp:Label ID="halvelblTxtLand2" runat="server" Width="90px"></asp:Label>
                        <asp:Button ID="berekenPouleHalve1" runat="server" OnClick="berekenPouleHalve1_Click" Text="Invoeren" />
                        <br />
                        <asp:Label ID="halvelblTxtLand3" runat="server" Width="90px"></asp:Label>
                        <asp:TextBox ID="halvetxtBoxScore3" runat="server"></asp:TextBox>
                        <asp:Label ID="streep3" runat="server" Text="-"></asp:Label>
                        <asp:TextBox ID="halvetxtBoxScore4" runat="server"></asp:TextBox>
                        <asp:Label ID="halvelblTxtLand4" runat="server" Width="90px"></asp:Label>
                        <asp:Button ID="berekenPouleHalve2" runat="server" OnClick="berekenPouleHalve2_Click" Text="Invoeren" />
                        <br />
                        <br />
                        <asp:Label ID="halveFinaleTxt" runat="server"></asp:Label>
                    </div>
                    <div id="finale">
                    <h1 style="text-align: center">FINALE</h1>
                        <br />
                        <asp:Button ID="Button2" runat="server" Text="Bereken Finale" OnClick="Button2_Click" /><br />
                        <asp:Label ID="finaleLbl" runat="server"></asp:Label>
                        <br />
                    <br />
                        <asp:Label ID="finalelblTxtLand1" runat="server" Width="90px"></asp:Label>
                        <asp:TextBox ID="finaletxtBoxScore1" runat="server"></asp:TextBox>
                        <asp:Label ID="streep4" runat="server" Text="-"></asp:Label>
                        <asp:TextBox ID="finaletxtBoxScore2" runat="server"></asp:TextBox>
                        <asp:Label ID="finalelblTxtLand2" runat="server" Width="90px"></asp:Label>
                        <asp:Button ID="berekenPouleFinale" runat="server" Text="Invoeren" OnClick="berekenPouleFinale_Click" />
                        <br />
                        <br />
                        <asp:Label ID="FinaleTxt" runat="server"></asp:Label>
                    </div>
                    <div id="leegscore">
                                            <h1 style="text-align: center">LEEG SCORES</h1>
                        <br />
                        <asp:Button ID="leegScore" runat="server" Text="LEEG SCORES" Width="600px" CausesValidation="False"
onclientclick="return confirm('Weet u zeker dat u de scores wilt verwijderen?')" OnClick="leegScore_Click" />
                                            <br />
                                            <asp:Label ID="lblLeegScore" runat="server" Visible="False"></asp:Label>
                    </div>
                    <div id="winnaar" aria-autocomplete="none">
                        <asp:Label ID="winnaarTekst" runat="server" CssClass="label_center"></asp:Label>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        </div>
        <div id="footer">
            <p>Copyright © 2014 Sulayman Hatuluwaja | 70059 | I2C2 & Zowie van Geest | 64253 | I2C2     </p>        
                </div>
    </form>
</body>
</html>
