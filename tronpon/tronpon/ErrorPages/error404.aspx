<%@ Page Title="" Language="C#" MasterPageFile="~/ErrorPages/error.Master" AutoEventWireup="true" CodeBehind="error404.aspx.cs" Inherits="tronpon.ErrorPages.error404" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpErrorType" runat="server">Error 404</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpErrorHead" runat="server">Error 404: Pagina niet gevonden!</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpErrorBody" runat="server">De url bevat een fout, of de opgevraagde pagina bestaat niet meer op deze server.</asp:Content>