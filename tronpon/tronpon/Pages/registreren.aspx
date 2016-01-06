<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MainMaster.Master" AutoEventWireup="true" CodeBehind="registreren.aspx.cs" Inherits="tronpon.Pages.registreren" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../assets/css/reg.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div id="main">
            <h3>Welkom,</h3>
            <p>
                Leuk dat u een account komt aanmaken. Vul onderstaande velden correct in. 
            </p>
            <div class="display-inline">
                <p>Gebruikersnaam</p>
                <asp:TextBox ID="tbUname" runat="server" placeholder="Gebruikersnaam"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqFieldValidUname" runat="server" ValidationGroup="RegisterValidGroup" ErrorMessage="*" ControlToValidate="tbUname" ForeColor="#990000"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegexValidUname" runat="server" ErrorMessage="Mag niet!" ValidationGroup="RegisterValidGroup" ControlToValidate="tbUname" ForeColor="#990000" ValidationExpression="^[a-zA-Z0-9_-]{6,30}$"></asp:RegularExpressionValidator>
            </div>
            <div class="display-inline">
                <p>Email</p>
                <asp:TextBox ID="tbMail" runat="server" placeholder="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqFieldValidMail" runat="server" ValidationGroup="RegisterValidGroup" ErrorMessage="*" ControlToValidate="tbMail" ForeColor="#990000"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegexValidMail" runat="server" ErrorMessage="Incorrect!" ValidationGroup="RegisterValidGroup" ForeColor="#990000" ControlToValidate="tbMail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
            <div class="display-inline">
                <p>Wachtwoord</p>
                <asp:TextBox ID="tbPass" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqFieldValidPass" runat="server" ErrorMessage="*" ValidationGroup="RegisterValidGroup" ForeColor="#990000" ControlToValidate="tbPass"></asp:RequiredFieldValidator>
            </div>
            <div class="display-inline">
                <p>Herhaal wachtwoord</p>
                <asp:TextBox ID="tbPassRepeat" runat="server" placeholder="Password herhalen" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqFieldValidPassRepeat" runat="server" ErrorMessage="*" ValidationGroup="RegisterValidGroup" ControlToValidate="tbPassRepeat" ForeColor="#990000"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="ComparePass" runat="server" ErrorMessage="Incorrect!" ValidationGroup="RegisterValidGroup" ControlToValidate="tbPassRepeat" ControlToCompare="tbPass" ForeColor="#990000"></asp:CompareValidator>
            </div>

            <ul class="actions">
                <li>
                    <asp:Button CssClass="button special" runat="server" ID="btnRegister" ValidationGroup="RegisterValidGroup" OnClientClick="btnRegister_Click" Text="Registreer" Enabled="True" /></li>
            </ul>
            <pre>
            Pro Tip: Een sterk wachtwoord bevat minimaal: 
                 A) 1 hoofdletter, 1 kleine letter, 1 speciaal teken en 1 cijfer.
                 B) 8 tekens
                 C) Scoort hoog genoeg op deze tester: <a href="https://blog.kaspersky.com/password-check/" target="_blank">Kaspersky Pass Checker</a>
        </pre>
        </div>
    </div>



</asp:Content>
