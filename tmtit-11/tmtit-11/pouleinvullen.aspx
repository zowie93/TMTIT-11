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
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                        <Columns>
                            <asp:TemplateField HeaderText="ID">
                                <EditItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("Wedstrijd_ID") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Wedstrijd_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Team Naam 1">
                                <EditItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("Team1") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Team1") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Score">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Score1") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Score1") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="-">
                                <EditItemTemplate>
                                    <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text=" - "></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Score 2">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("Score2") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("Score2") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Team Naam 2">
                                <EditItemTemplate>
                                    <asp:Label ID="Label10" runat="server" Text='<%# Eval("Team2") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("Team2") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField HeaderText="Edit" ShowEditButton="True" />
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
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
