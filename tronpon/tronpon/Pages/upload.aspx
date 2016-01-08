<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MainMaster.Master" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="tronpon.Pages.upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../assets/css/reg.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="main">
        <h3>Welkom,</h3>
        <p id="message" runat="server">
            Hier kunt u afbeeldingen uploaden. 
        </p>

        <asp:FileUpload runat="server" ID="fileUpload" />
        <ul class="actions">
            <li>
                <asp:Button CssClass="button special" runat="server" ID="btnUpload" onClientClick="btnUpload_Click" Text="Upload" Enabled="True" /></li>
        </ul>
    </div>

</asp:Content>
