<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminMaken.aspx.cs" Inherits="tmtit_11.adminMaken" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>WK 2014 - TMTIT-11 - Login </title>
    <link href="css/style.css" rel="stylesheet" />
</head>
<body>
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
                   <li class='has-sub'><a href='poulegegevens.aspx'><span>poulegegevens</span></a>
                      <ul>
                         <li><a href='scoretabel.aspx'><span>Score Tabel</span></a></li>
                         <li><a href='pouleinvullen.aspx'><span>poule invullen</span></a></li>
                      </ul>
                   </li>
                   <li class='has-sub'><a href='speelschema.aspx'><span>speelschema</span></a>
                   </li>
                   <li class='has-sub active'><a href='admin.aspx'><span>Admin</span></a>
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
        <div id="content"><br /><br />
            <div id="adminpaneel">
                <form id="form1" runat="server">
                    <asp:Table ID="Table1" runat="server">
                        <asp:TableRow>
                            <asp:TableCell>Gebruikersnaam:</asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="gebruikersNaam" runat="server"></asp:TextBox></asp:TableCell>
                            <asp:TableCell><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="gebruikersNaam" Text="Vul een gebruikersnaam in!"></asp:RequiredFieldValidator></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Wachtwoord:</asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="wachtWoord" TextMode="Password" runat="server"></asp:TextBox></asp:TableCell>
                            <asp:TableCell><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="wachtWoord" Text="Vul een wachtwoord in!"></asp:RequiredFieldValidator></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Controle Wachtwoord:</asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="wachtWoordcontrole" TextMode="Password" runat="server"></asp:TextBox></asp:TableCell>
                            <asp:TableCell><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="wachtWoordcontrole" Text="Vul een wachtwoord in!"></asp:RequiredFieldValidator></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell><asp:Button ID="btnAanmaken" runat="server" Text="Aanmaken" OnClick="btnAanmakenClick" /></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table> 
                    <asp:Label ID="activatie" runat="server" Text=""></asp:Label>  
                </form>
                
            </div>
        </div>
        <div id="footer">
            <p>Copyright © 2014 Sulayman Hatuluwaja | 70059 | I2C2 & Zowie van Geest | 64253 | I2C2 </p>
        </div>
    </div>
</body>
</html>
