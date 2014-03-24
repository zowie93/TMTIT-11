<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="tmtit_11.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WK 2014 - TMTIT-11 - Login </title>
    <link href="css/style.css" rel="stylesheet" />
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
                    <li><a href='default.aspx'><span>Home</span></a></li>
                    <li><a href='poulegegevens.aspx'><span>poulegegevens</span></a></li>
                    <li><a href='speelschema.aspx'><span>speelschema</span></a></li>
                    <li><a href='uitslagen.aspx'><span>uitslagen</span></a></li>
                    <li class='last active'><a href='login.aspx'><span>login</span></a></li>
                </ul>
            </div>
         </div>
        <div id="content"><br /><br />
            <div id="login">

                Gebruikersnaam:<br />
                <asp:TextBox ID="gebruikerVeld" runat="server"></asp:TextBox>
                <br />
                Wachtwoord:<br />
                <asp:TextBox ID="wachtwoordVeld" runat="server" TextMode="Password"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="bnLogin" runat="server" OnClick="bnLogin_Click" Text="Login" />

                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

            </div>
        </div>
        <div id="footer">
            <p>Copyright © 2014 Sulayman Hatuluwaja | 70059 | I2C2 & Zowie van Geest | 64253 | I2C2 </p>
        </div>
    </div>
    </form>
</body>
</html>
