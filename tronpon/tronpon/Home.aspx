<%@ Page Language="C#" MasterPageFile="~/Account.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="tronpon.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"> 
    <link type="text/css" rel="stylesheet" href="Content/CSS/StyleHome.css" /> 
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Homeimage" class="Homepage">
    <img href="http://25.media.tumblr.com/tumblr_lzri1rAyNd1qaxzado1_1280.png" />
    </div>
        <div id="HomeButtonGO" class="Homepage">
            <asp:Button ID="ButtonGO" runat="server" Text=">" />
        </div>
        
    </form>
</body>
</html>
