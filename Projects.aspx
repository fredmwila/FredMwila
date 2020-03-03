<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Projects.aspx.cs" Inherits="Fred.Projects" %>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <div style="width:100%;">
         <div class="logo"><br /><br /><br /><img height="300px" class="logoimg" src="Images/logo2.png" />           
             <br /><h3 style="color:white;">My Projects</h3>
         </div>
     </div>
    <div class="banner3" style="background-image: url('images/rugby.jpg');">         
  
  </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     
        <asp:Repeater ID="ProjectRepeater" runat="server" OnItemDataBound = "ProjectRepeater_ItemDataBound" >
            <ItemTemplate>
     <div style="display:table; background-color:<%# Eval("ProjectBackgroundColor")%>;">
    <div class="left25" style=" background-image: url('<%# Eval("ProjectBackgroundImage")%>');">
        <h1 style="color:white;"><%# Eval("Projectname")%></h1>
        <h2 style="color:white;"><%# Eval("ProjectTimePeriod")%></h2>
 </div>      

    <div class="right50">
            <h2>Project <span style="color:<%# Eval("ProjectColor")%>;">Description</span></h2>
<%# Eval("ProjectDescription")%>
        

        <h2>Skills <span style="color:<%# Eval("ProjectColor")%>;">Used</span></h2>
        <asp:Repeater ID="ProjectSkillsRepeater" runat="server" >
            <ItemTemplate>
            <div class="skillspadding">
        <div class="skills" style="color:<%# Eval("ProjectColor")%>; border-color:<%# Eval("ProjectColor")%>;">
            <%# Eval("Skill")%>
        </div>
                
                </div>
                </ItemTemplate>
            </asp:Repeater>
           
            </div>
    
        </div>
                <asp:HiddenField ID="HiddenProjectID" Value='<%# Eval("ProjectID")%>' runat="server" />
                </ItemTemplate>
        </asp:Repeater>
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent2" runat="server">
   
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent3" runat="server">
    
</asp:Content>
