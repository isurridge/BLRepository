<%@ Page Title="Welcome" Language="C#" MasterPageFile="~/Views/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


  


    <section class="box box-features"  >
        <ul class="tabs">
            <li><a href="#one" class="active">Blandit sed consequat?</a></li>
            <li><a href="#two">Lorem ipsum blandit</a></li>
            <li><a href="#three">Tempus consequat veroeros</a></li>
        </ul>
        <div class="viewer" >
            <div class="reel"  >
                <article id="one">
                    <h2 class="caption-1">Lorem ipsum dolor sit consequat tempus</h2>
                    <p class="caption-2">Hendrerit vel ligula accumsan erat neque dignissm blandit tellus quis sagittis .</p>
                    <img src="/Content/images/slide01.jpg" class="image image-full" alt="" />
                    <a href="#" class="link">Continue reading ...</a>
                </article>
                <article id="two">
                    <h2 class="caption-1">Feugiat ligula accumsan veroeros</h2>
                    <p class="caption-2">Tellus quis mauris sagittis hendrerit vel ligula, accumsan erat neque dignissm.</p>
                    <img src="/Content/images/slide03.jpg" class="image image-full" alt="" />
                    <a href="#" class="link">Continue reading ...</a>
                </article>
                <article id="three">
                    <h2 class="caption-1">Sed erat dignissim lorem ipsum dolore</h2>
                    <p class="caption-2">Accumsan erat neque dignissm blandit Tellus quis mauris sagittis hendrerit vel.</p>
                    <img src="/Content/images/slide02.jpg" class="image image-full" alt="" />
                    <a href="#" class="link">Continue reading ...</a>
                </article>
                
            </div>
                    
          
            

        </div>
        
          

        
        
        <div class="captions">
            <span class="caption-line-1"></span>
            <span class="caption-line-2"></span>
        </div>
    </section>


    


   


    <script src="/Content/init.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="/Content/js/jquery.dropotron-1.2.js"></script>
    <script src="/Content/js/jquery.slidertron-1.2.js"></script>
</asp:Content>
