<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="veranderwachtwoord.aspx.cs" Inherits="tmtit_11.veranderwachtwoord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>WK 2014 - TMTIT-11 - Verander Wachtwoord </title>
    <link href="css/style.css" rel="stylesheet" />    
    <script src='http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js'></script>
	<script type='text/javascript' src='menu_jquery.js'></script>
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
            <div id="login">
                <form id="form1" runat="server">
                       <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell>Gebruikersnaam:</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="gebruikerVeld" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="gebruikerVeld" Text="Vul uw gebruikersnaam in!"></asp:RequiredFieldValidator></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Oud Wachtwoord:</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="oudwachtwoordVeld" runat="server" TextMode="password"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="oudwachtwoordVeld" Text="vul uw oude wachtwoord in!"></asp:RequiredFieldValidator></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Nieuw Wachtwoord:</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="nieuwWachtwoord" runat="server" TextMode="password"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="nieuwWachtwoord" Text="vul uw nieuwe wachtwoord in!"></asp:RequiredFieldValidator></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Nieuw Wachtwoord Herhaling:</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="nieuwWachtwoordHer" runat="server" TextMode="password"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="nieuwWachtwoordHer" Text="vul uw nieuwe wachtwoord in!"></asp:RequiredFieldValidator></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>&nbsp;</asp:TableCell>
                <asp:TableCell><asp:Button ID="bnVerander" runat="server" Text="Verander Wachtwoord" OnClick="bnVerander_Click"/></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
            <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                    </form>
            </div>
        </div>
        
        <div id="footer">
            <p>Copyright © 2014 Sulayman Hatuluwaja | 70059 | I2C2 & Zowie van Geest | 64253 | I2C2 </p>
        </div>
    </div>
</body>
</html>
