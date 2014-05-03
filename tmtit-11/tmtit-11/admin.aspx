<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="tmtit_11.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>WK 2014 - TMTIT-11 - Admin </title>
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
        <div id="content">
        <br />
        <h1 style="text-align:center; font-size: 20px; margin-top: 30px;">Admin Pagina</h1><br /><br /><br />
            <form runat="server">
            <asp:Button ID="VeranderPW" runat="server" Text="VERANDER WACHTWOORD" Width="300" Height="50" CssClass="centerbutton" OnClick="VeranderPW_Click" /><br /><br />
            <asp:Button ID="NieuweAdmin" runat="server" Text="NIEUWE ADMIN" Width="300" Height="50"  CssClass="centerbutton" OnClick="NieuweAdmin_Click" />
            </form>
        </div>
        <div id="footer">
            <p>Copyright © 2014 Sulayman Hatuluwaja | 70059 | I2C2 & Zowie van Geest | 64253 | I2C2 </p>
        </div>
    </div>
</body>
</html>