<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MainMaster.Master" AutoEventWireup="true" CodeBehind="content.aspx.cs" Inherits="tronpon.Pages.content" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Main -->
    <div id="main">

        <section id="content">
            <h4>Content</h4>
             <ul class="actions">                
                <li><a href="upload.aspx" class="button special">Upload</a></li>                                
            </ul>
            <div class="box alt">
                <div class="row 50% uniform">
                       <article class="8u$ work-item">
                        <a href="../images/fulls/01.jpg" target="_blank" class="image fit thumb">
                            <img src="../images/thumbs/05.jpg" alt="" /></a>
                    </article>                   
                    <article class="4u 12u$(xsmall) work-item">
                        <a href="../images/fulls/01.jpg" target="_blank" class="image fit thumb">
                            <img src="../images/thumbs/01.jpg" alt="" /></a>
                    </article>
                    <article class="4u$ 12u$(xsmall) work-item">
                        <a href="../images/fulls/02.jpg" target="_blank" class="image fit thumb">
                            <img src="../images/thumbs/02.jpg" alt="" /></a>
                    </article>
                    <article class="4u 12u$(xsmall) work-item">
                        <a href="../images/fulls/03.jpg" target="_blank" class="image fit thumb">
                            <img src="../images/thumbs/03.jpg" alt="" /></a>
                    </article>
                    <article class="4u$ 12u$(xsmall) work-item">
                        <a href="../images/fulls/04.jpg" target="_blank" class="image fit thumb">
                            <img src="../images/thumbs/04.jpg" alt="" /></a>
                    </article>
                    <article class="4u 12u$(xsmall) work-item">
                        <a href="../images/fulls/05.jpg" target="_blank" class="image fit thumb">
                            <img src="../images/thumbs/05.jpg" alt="" /></a>
                    </article>
                    <article class="4u$ 12u$(xsmall) work-item">
                        <a href="../images/fulls/06.jpg" target="_blank" class="image fit thumb">
                            <img src="../images/thumbs/06.jpg" alt="" /></a>
                    </article>
                     <article class="4u 12u$(xsmall) work-item">
                        <a href="../images/fulls/03.jpg" target="_blank" class="image fit thumb">
                            <img src="../images/thumbs/03.jpg" alt="" /></a>
                    </article>
                    <article class="4u$ 12u$(xsmall) work-item">
                        <a href="../images/fulls/04.jpg" target="_blank" class="image fit thumb">
                            <img src="../images/thumbs/04.jpg" alt="" /></a>
                    </article>
                </div>
            </div>

            <ul class="actions">
                <li><a href="#" runat="server" onserverclick="btnPrevPage_Click" class="button">Vorige pagina</a></li>
                <li><a href="#" runat="server" onserverclick="btnNextPage_Click" class="button">Volgende pagina</a></li>
            </ul>
        </section>
    </div>

</asp:Content>
