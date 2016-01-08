<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MainMaster.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="tronpon.Pages.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../assets/css/reg.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main">
        <h3>Welkom,</h3>
        <p id="message" runat="server">
            Hier kunt u inloggen. 
        </p>
        <div id="credContainer" runat="server">
            <div class="display-inline">
                <p>Gebruikersnaam</p>
                <asp:TextBox ID="tbUname" runat="server" placeholder="Gebruikersnaam"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqFieldValidUname" runat="server" ValidationGroup="loginValidGroup" ErrorMessage="*" ControlToValidate="tbUname" ForeColor="#990000"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegexValidUname" runat="server" ErrorMessage="Mag niet!" ValidationGroup="loginValidGroup" ControlToValidate="tbUname" ForeColor="#990000" ValidationExpression="^[a-zA-Z0-9_-]{6,30}$"></asp:RegularExpressionValidator>
            </div>
            <div class="display-inline">
                <p>Wachtwoord</p>
                <asp:TextBox ID="tbPass" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqFieldValidPass" runat="server" ErrorMessage="*" ValidationGroup="loginValidGroup" ForeColor="#990000" ControlToValidate="tbPass"></asp:RequiredFieldValidator>
            </div>
        </div>
        <ul class="actions">
            <li>
                <asp:Button CssClass="button special" runat="server" ID="btnLogin" ValidationGroup="loginValidGroup" Text="Login" Enabled="True" /></li>
        </ul>
    </div>

</asp:Content>
