<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="tmtit_11.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WK 2014 - TMTIT-11 - Login </title>
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
                   <li class='has-sub'><a href='default.aspx'><span>Home</span></a></li>
                   <li class='has-sub'><a href='poulegegevens.aspx'><span>poulegegevens</span></a>
                      <ul>
                         <li><a href='pouleinvullen.aspx'><span>poule invullen</span></a></li>
                      </ul>
                   </li>
                   <li class='has-sub'><a href='speelschema.aspx'><span>speelschema</span></a></li>
                   <li class='has-sub'><a href='uitslagen.aspx'><span>uitslagen</span></a></li>
                   <li class='has-sub last active'><a href='login.aspx'><span>login</span></a></li>
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
                <asp:TableCell>Wachtwoord:</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="wachtwoordVeld" runat="server" TextMode="password"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="wachtwoordVeld" Text="vul uw wachtwoord in!"></asp:RequiredFieldValidator></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>&nbsp;</asp:TableCell>
                <asp:TableCell><asp:Button ID="bnLogin" runat="server" Text="Login" OnClick="bnLogin_Click" /></asp:TableCell>
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
