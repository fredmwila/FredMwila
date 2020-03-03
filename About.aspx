<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Fred.About" %>

<asp:Content ID="Content1"  ContentPlaceHolderID="FeaturedContent" Runat="Server">
        <asp:Panel ID="Panel1" runat="server">
     <div style="width:100%;">
         <div class="logo"><br /><br /><br /><img height="300px" class="logoimg" src="Images/logo2.png" />
             <br />
             <h3 style="color:white;"><asp:Label ID="vTitle" runat="server" Text="About"></asp:Label></h3>
         </div>
     </div>
   <div class="banner3" style="background-image: url('Images/aboutbanner1.jpg'); ">         
        <%--<img src="images/aboutbanner1.jpg"/>--%>     
            </div>     
  </div
 
        </asp:Panel>

</asp:Content>
<asp:Content ID="Content2" style="z-index:2;" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="main-content"> 
    <div class="acontent">
        <h1>
            About <span style="color:#efc109;">Me</span>
        </h1>
    <p>
         I was born in Lusaka Zambia in 1994 to a Zambian father and a New Zealand mother. At the age of four, my family travelled back to New Zealand where my mother grew up. It was during this time that I began playing rugby. <br />
        As I grew older, I gained an interest in IT leading me to take design IT classes in high school that really helped me learn html and css. While studying for my bachelor of commerce degree at Victoria University of Wellington, I was very drawn to my Information Systems courses, in particular, those courses that utilized the asp.net web framework. I further developed a passion for .NET development while working as a .net developer during and after my final year at university.


    </p>
        </div>
        </div>
</asp:Content>
