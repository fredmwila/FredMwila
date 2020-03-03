<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Watch.aspx.cs" Inherits="Fred.Watch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" Runat="Server">

     <asp:Panel ID="Panel1" runat="server">
     <div style="width:100%;">
         <div class="logo">
             <%--<br /><br /><br /><img height="100px" class="logoimg" src="Images/Logo2.png" />--%>
             <br />
             <br />
             <br />
             <h3 style="color:white;"><asp:Label ID="vTitle" runat="server" Text="Label"></asp:Label></h3>
         </div>
     </div>
    <div class="banner2">         
        <div style="height:300px; bottom:800px; position:relative; background: linear-gradient(rgba(0, 0, 0, 0.5), rgba(0, 0, 0, 0.5))">           
                    <img id="titlebanner" style="width:2000px; filter: blur(10px);
-webkit-filter: blur(10px);
-moz-filter: blur(10px);
-o-filter: blur(10px);
-ms-filter: blur(10px);" runat="server"/>     
            </div>     
  </div>
 
        </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
    
    <div class="main-content">
          <div class="left-column">
              <%--<h2><asp:Label ID="vTitle" runat="server"></asp:Label></h2> --%>            
                <div class="videoWrapper">
            <iframe id="I1" allowfullscreen="" runat="server" frameborder="0" name="I1" height="9" width="16"></iframe>
       </div>
              <div class="video-content">
            <h4>Uplaoded on <asp:Label ID="ED" runat="server"></asp:Label></h4>
            <p>
                <asp:Label ID="Description" runat="server" ></asp:Label>
                </p>
            Uploaded by <asp:Label ID="EU" runat="server"></asp:Label>
                  </div>
          </div>
                
              <div class="right-column">
                  <h2>Related Videos</h2>
                  <br />
                     <div class="videogrid2div">
                  <asp:Repeater ID="VideosRepeater" runat="server">
            <ItemTemplate>
                <div class="videogrid2">
                <table class="videogrid2">
                    <tr>
                        <td align="center" style="margin: 0px; padding:0px; table-layout: fixed; width:170px;">
                        <a id="A1" runat="server" href='<%# Eval("Video_ID", "~/Watch?ID={0}")%>'>
                            <div class="logo2"><br /><img class="logoimg2" src="Images/play.png" /></div>
                            <div class="thumbnail3">
                            <asp:Image ID="VideoThumbnail" src='<%# Eval("Thumbnail")%>' runat="server"/>
                                </div>
                        </a>
                      
                            </td>
                    <td style="height:40px; padding:0px; text-align:left; vertical-align:top;">
                        <a style="text-decoration:none;" href='<%# Eval("Video_ID", "Watch?ID={0}")%>'><b><span class="h3"><%# Eval("Title") %></span></b>    </a>                                       
                      <br />
    <br />
                        <span style="vertical-align:bottom;"><%# Eval("ED")%> </span>   
                        <asp:Panel id="editvideo"  visible="false" runat="server">
                         <a id="A2"  runat="server" href='<%# Eval("Video_ID", "~/vDetails?ID={0}")%>'>Edit Video</a>                    
                    </asp:Panel>
                    </td>
                    
                    
                        </tr>                    
                </table>
                    </div>
            </ItemTemplate>
        </asp:Repeater>
                         </div>
                  
</div>
    
 </div> 
    <asp:HiddenField ID="id_video" runat="server" />
</asp:Content>