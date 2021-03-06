﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tmtit_11.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WK 2014 - TMTIT-11 - Home </title>
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
                   <li class='has-sub active' style='background: #4a4a4a;'><a href='default.aspx'><span>Home</span></a></li>
                   <li class='has-sub'><a href='poulegegevens.aspx'><span>poulegegevens</span></a>
                      <ul>
                         <li><a href='scoretabel.aspx'><span>Score Tabel</span></a></li>
                         <li><a href='pouleinvullen.aspx'><span>poule invullen</span></a></li>
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
        <br />
        <h1 style="text-align:center; font-size: 20px; margin-top: 30px;">Welkom op de website van het WK 2014 Invulpoule</h1><br />
            <span style="width: 1200px; margin-left: 300px; text-align:center; ">
                <iframe width="640" height="360" src="//www.youtube.com/embed/Kdu-YbadhLI" frameborder="0" allowfullscreen></iframe>
            </span>        
        </div>
        <div id="footer">
            <p>Copyright © 2014 Sulayman Hatuluwaja | 70059 | I2C2 & Zowie van Geest | 64253 | I2C2 </p>
        </div>
    </div>
</body>
</html>
