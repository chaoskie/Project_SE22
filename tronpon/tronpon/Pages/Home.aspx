<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MainMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="tronpon.Pages.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Main -->
    <div id="main">

        <!-- One -->
        <section id="one">
            <header class="major">
                <h2>Welkom,<br />
                    op de nummer 1 image database</h2>
            </header>
            <p>
                We hebben een groot scala aan images. Natuurlijk verwachten we dat je de content die je plaatst wel binnen de kaders van de wet vallen.
						Indien dit niet het geval is zal je een waarschuwing krijgen en zal je uiteindelijk worden gedeactiveerd. 
						Wil je graag weten welke afbeeldingen wel en niet toegestaan zijn dan nodigen we je uit om op onderstaande knop te drukken om meer te weten te komen.
						<br />
                Happy searching!
            </p>
            <ul class="actions">
                <li><a href="https://en.wikipedia.org/wiki/Wikipedia:Image_use_policy" target="_blank" class="button">Learn More</a></li>
            </ul>
        </section>

        <!-- Two -->
        <section id="two">
            <h2>Recente uploads</h2>
            <div class="row">
                <article class="6u 12u$(xsmall) work-item">
                    <a href="../images/fulls/01.jpg" class="image fit thumb">
                        <img src="../images/thumbs/01.jpg" alt="" /></a>
                </article>
                <article class="6u$ 12u$(xsmall) work-item">
                    <a href="../images/fulls/02.jpg" class="image fit thumb">
                        <img src="../images/thumbs/02.jpg" alt="" /></a>
                </article>
                <article class="6u 12u$(xsmall) work-item">
                    <a href="../images/fulls/03.jpg" class="image fit thumb">
                        <img src="../images/thumbs/03.jpg" alt="" /></a>
                </article>
                <article class="6u$ 12u$(xsmall) work-item">
                    <a href="../images/fulls/04.jpg" class="image fit thumb">
                        <img src="../images/thumbs/04.jpg" alt="" /></a>
                </article>
                <article class="6u 12u$(xsmall) work-item">
                    <a href="../images/fulls/05.jpg" class="image fit thumb">
                        <img src="../images/thumbs/05.jpg" alt="" /></a>
                </article>
                <article class="6u$ 12u$(xsmall) work-item">
                    <a href="../images/fulls/06.jpg" class="image fit thumb">
                        <img src="../images/thumbs/06.jpg" alt="" /></a>
                </article>
            </div>
            <ul class="actions">
                <li><a href="content.aspx" class="button">Alle content</a></li>
            </ul>
        </section>

        <!-- Three -->
        <section id="three">
            <h2>Get In Touch</h2>
            <p>Voor vragen en of opmerkingen kunt u hieronder terecht.</p>
            <div class="row">
                <div class="8u 12u$(small)">
                    <form method="post" action="#">
                        <div class="row uniform 50%">
                            <div class="6u 12u$(xsmall)">
                                <input type="text" name="name" id="name" placeholder="Name" />
                            </div>
                            <div class="6u$ 12u$(xsmall)">
                                <input type="email" name="email" id="email" placeholder="Email" />
                            </div>
                            <div class="12u$">
                                <textarea name="message" id="message" placeholder="Message" rows="4"></textarea>
                            </div>
                        </div>
                    </form>
                    <ul class="actions">
                        <li>
                            <input type="submit" value="Send Message" /></li>
                    </ul>
                </div>
                <div class="4u$ 12u$(small)">
                    <ul class="labeled-icons">
                        <li>
                            <h3 class="icon fa-home"><span class="label">Address</span></h3>
                            MijnStraat 3<br />
                            Veghel, 1234TK<br />
                            Netherlands
                        </li>
                        <li>
                            <h3 class="icon fa-mobile"><span class="label">Phone</span></h3>
                            0413-123456
                        </li>
                        <li>
                            <h3 class="icon fa-envelope-o"><span class="label">Email</span></h3>
                            <a href="mailto:l.blom@student.fontys.nl" target="_blank">l.blom@student.fontys.nl</a>
                        </li>
                    </ul>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
