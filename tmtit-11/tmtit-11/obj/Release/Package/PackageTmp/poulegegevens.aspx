<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="poulegegevens.aspx.cs" Inherits="tmtit_11.poulegegevens" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>WK 2014 - TMTIT-11 - Poule Gegevens </title>
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
        
        <div id="content2">
            <table>
              <tr>
	              <td><div id="allepoules"><div id="allepoulestitel">POULES</div>
		              <div id="allepoulestxt"><br /><asp:Label ID="pouleGegevensA" runat="server" Text="Label" CssClass="pouleTXT" HorizontalAlign="center"></asp:Label></div></div></td>
              </tr>
            </table>
            <table>
                <tr>
                    <td><div id="pouleA"><div id="pouleAtitel">SCORES POULE A</div>
                        <div id="pouleAtxt"><asp:Label ID="pouleATXT" runat="server" Text="Label" CssClass="pouleTXT" HorizontalAlign="center"></asp:Label></div></div></td>
                    <td><div id="pouleB"><div id="pouleBtitel">SCORES POULE B</div>
                        <div id="pouleBtxt"><asp:Label ID="pouleBTXT" runat="server" Text="Label" CssClass="pouleTXT" HorizontalAlign="center"></asp:Label></div></div></td>
                </tr>
                <tr>
                    <td><div id="pouleC"><div id="pouleCtitel">SCORES POULE C</div>
                        <div id="pouleCtxt"><asp:Label ID="pouleCTXT" runat="server" Text="Label" CssClass="pouleTXT" HorizontalAlign="center"></asp:Label></div></div></td>
                    <td><div id="pouleD"><div id="pouleDtitel">SCORES POULE D</div>
                        <div id="pouleDtxt"><asp:Label ID="pouleDTXT" runat="server" Text="Label" CssClass="pouleTXT" HorizontalAlign="center"></asp:Label></div></div></td>
                </tr>
            </table>
            <h1 style="text-align:center; font-size: 20px; margin-top: 30px;">KWARTFINALES</h1>
                        <table>
                <tr>
                    <td><div id="kwartpouleA"><div id="kwartpouleAtitel">KWARTFINALE POULE A</div>
                        <div id="kwartpouleAtxt"><asp:Label ID="kwartpouleATXT" runat="server" Text="Label" CssClass="pouleTXT" HorizontalAlign="center"></asp:Label></div></div></td>
                    <td><div id="kwartpouleB"><div id="kwartpouleBtitel">KWARTFINALE POULE B</div>
                        <div id="kwartpouleBtxt"><asp:Label ID="kwartpouleBTXT" runat="server" Text="Label" CssClass="pouleTXT" HorizontalAlign="center"></asp:Label></div></div></td>
                </tr>
                <tr>
                    <td><div id="kwartpouleC"><div id="kwartpouleCtitel">KWARTFINALE POULE C</div>
                        <div id="kwartpouleCtxt"><asp:Label ID="kwartpouleCTXT" runat="server" Text="Label" CssClass="pouleTXT" HorizontalAlign="center"></asp:Label></div></div></td>
                    <td><div id="kwartpouleD"><div id="kwartpouleDtitel">KWARTFINALE POULE D</div>
                        <div id="kwartpouleDtxt"><asp:Label ID="kwartpouleDTXT" runat="server" Text="Label" CssClass="pouleTXT" HorizontalAlign="center"></asp:Label></div></div></td>
                </tr>
            </table>
            <h1 style="text-align:center; font-size: 20px; margin-top: 30px;">HALVE FINALES</h1>
              <table>
                <tr>
                    <td><div id="halvepouleAB"><div id="halvepouleABtitel">HALVE FINALE POULE A + B</div>
                        <div id="halvepouleABtxt"><asp:Label ID="halvefinaleABTXT" runat="server" Text="Label" CssClass="pouleTXT" HorizontalAlign="center"></asp:Label></div></div></td>
                    <td><div id="halvepouleCD"><div id="halvepouleCDtitel">HALVE FINALE POULE C + D</div>
                        <div id="halvepouleCDtxt"><asp:Label ID="halvefinaleCDTXT" runat="server" Text="Label" CssClass="pouleTXT" HorizontalAlign="center"></asp:Label></div></div></td>
                </tr>
            </table>
            <h1 style="text-align:center; font-size: 20px; margin-top: 30px;">FINALE TEAMS</h1>
              <table>
                  <tr>
                      <td><div id="finalepoule"><div id="finalepouletitel">FINALE</div>
                          <div id="finalepouletxt"><br /><asp:Label ID="finalepouleLabel" runat="server" Text="Label" CssClass="pouleTXT" HorizontalAlign="center"></asp:Label></div></div></td>
                  </tr>
              </table>
              <table>
                  <tr>
                      <td><div id="finalepoule2"><div id="finalepoule2titel">WINNAAR</div>
                          <div id="finalepoule2txt"><br /><asp:Label ID="finalepoule2Label" runat="server" Text="Label" CssClass="pouleTXT" HorizontalAlign="center"></asp:Label></div></div></td>
                  </tr>
              </table>
        </div>
        <div id="footer">
            <p>Copyright © 2014 Sulayman Hatuluwaja | 70059 | I2C2 & Zowie van Geest | 64253 | I2C2 </p>
        </div>
    </div>
    </form>
</body>
</html>