<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Fred.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" Runat="Server">

      <div style="width:100%;">
         <div class="logo" <%--style="font-size:100px;"--%>>
             <br />
             <br />
             <%--<img height="800px" class="logoimg" src="Images/logo2.png" />--%>
             <img class="logoimg" src="Images/Logo2text.png" />
         </div>
     </div>
    <div class="banner2" style="height:1200px; background-image:url('images/banner10.jpg');" >         
               
                    <%--<img src="images/81294299_479217216313086_4372824766629806080_n.jpg"/>--%> 
           <%-- <img src="images/img_2434.jpg"/>    --%>
            <%--<img src="images/banner10.jpg"/>--%>
               
  </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="display:table; text-align:center;">
    <div class="left50" >
        <div style="display:table">
        <div class="left50img" style="background-image: url('Images/about4.jpg');">
            </div>
        </div>
 </div>      

    <div class="right50">
        <%--<a runat="server" href='/about'>--%>
            <h1>Muli Shani <span style="color:#efc109;">(Hello)</span></h1>

        <%--</a>--%>
        <p>
           My name is Fred Mwila. I am a .Net developer from Wellington, New Zealand. I was born in Lusaka Zambia in 1994 to a Zambian father and a New Zealand mother. At the age of four, my family travelled back to New Zealand where my mother grew up. It was during this time that I began playing rugby. <br /><br />
        As I grew older, I gained an interest in IT leading me to take design IT classes in high school that really helped me learn html and css. While studying for my bachelor of commerce degree at Victoria University of Wellington, I was very drawn to my Information Systems courses, in particular, those courses that utilized the asp.net web framework. I further developed a passion for .NET development while working as a .net developer during and after my final year at university.

        </p>
    </div>
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent3" Runat="Server">

    <div style="    background-color: white;
    background-image: url(images/skate7.gif);
    background-size: cover;
    background-attachment: fixed;
    BACKGROUND-POSITION-Y: center;">
        <div class="main-content">
 <a runat="server" href='/videos'><h1><span style="color:#efc109;">My</span> <span style="color:white;">Videos</span></h1></a>
            <p style="color:white;">A collection of skate videos that I have made over the years. Here are the latest.</p>
            <div class="videoWrapper">
            <iframe id="I1" allowfullscreen="" runat="server" frameborder="0" name="I1" height="9" width="16"></iframe>
       </div>
              <div class="video-content">
            <h4 style="color:white;">Uplaoded on <asp:Label ID="ED" runat="server"></asp:Label></h4>
            <p style="color:white;">
                <asp:Label ID="Description" runat="server" ></asp:Label>
                </p>
            <span style="color:white;">Uploaded by <asp:Label ID="EU" runat="server"></asp:Label></span>
                  </div>
            <div class="videogridcontainer">
        <asp:Repeater ID="VideosRepeater" runat="server">
            <ItemTemplate>
                <div class="videogrid3" >
                    <div class="thumbnail4">
                        <a href='<%# Eval("Video_ID", "Watch?ID={0}")%>'>  
                        <asp:Image ID="VideoThumbnail" src='<%# Eval("Thumbnail")%>' runat="server"/>
                            <div class="playhome"><br /><img class="logoimg3" style="height: 100px;
    width: 100px;
    margin-top: 100px;" src="Images/play.png" /></div>
                            <div class="videotitle"><h3 style="color:white;"><%# Eval("Title") %></h3></div>  
                             <span class="homedate"><%#DateTime.Parse(Eval("ED").ToString()).ToString("dd MMM yyyy")%></span>
                            </a> 
                    </div>

                    </div>
            </ItemTemplate>
        </asp:Repeater>
           </div>
       
    
            </div>
        </div>

    <div class="backgroundimg" >
        <div class="main-content">
            <a runat="server" href='/projects'><h1>My <span style="color:#efc109;">Projects</span></h1></a>
            <div class="homegridpadding">
                <div class="homegrid">
                <h2>Master Build Services</h2>
                <p>Assisted in the development of databases and websites for Master Build Services Ltd.
                </p>
                </div>
            </div>
            <div class="homegridpadding">
                <div class="homegrid">
                    <h2>Cat Genetics Calculator</h2>
                    <p>
                        Created a web application that calculates the genotype and phenotype probabilities of all possible outcomes of cats, depending on the parent cats genes.
                    </p>
                </div>
            </div>
             <div class="homegridpadding">
                 <div class="homegrid">
                     <h2>My Food Bag</h2>
                     <p>
                         Created a web application that automated logistic calculations, and improved staging sheets.
                     </p>
                 </div>
             </div>


        </div>
    </div>
</asp:Content>