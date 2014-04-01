<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="speelschema.aspx.cs" Inherits="tmtit_11.speelschema" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>WK 2014 - TMTIT-11 - Speelschema</title>
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
                   <li class='has-sub active'><a href='speelschema.aspx'><span>speelschema</span></a></li>
                   <li class='has-sub'><a href='uitslagen.aspx'><span>uitslagen</span></a></li>
                   <li class='has-sub last'><a href='login.aspx'><span>login</span></a></li>
                </ul>
            </div>
         </div>
        <div id="content">
            <div id="speelschemacenter">
                <asp:Label ID="speelSchema" runat="server" CssClass="speelschema" HorizontalAlign="center"></asp:Label>
            </div>
        </div>
        <div id="footer">
            <p>Copyright © 2014 Sulayman Hatuluwaja | 70059 | I2C2 & Zowie van Geest | 64253 | I2C2 </p>
        </div>
    </div>
</body>
</html>
