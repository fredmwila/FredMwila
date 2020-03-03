<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Videos.aspx.cs" Inherits="Fred.Videos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent"  Runat="Server">
     <script>
         function WebForm_FireDefaultButton(event, target) {
             if (event.keyCode == 13) {
                 var src = event.srcElement || event.target;
                 if (!src || (src.tagName.toLowerCase() != "textarea")) {
                     var defaultButton;
                     //if (__nonMSDOMBrowser) {
                     defaultButton = document.getElementById(target);
                     //}
                     //else {
                     //    defaultButton = document.all[target];
                     //}
                     if (defaultButton && typeof (defaultButton.click) != "undefined") {
                         defaultButton.click();
                         event.cancelBubble = true;
                         if (event.stopPropagation) event.stopPropagation();
                         return false;
                     }
                 }
             }
             return true;
         }
    </script>
    <asp:Panel ID="Panel1" runat="server" DefaultButton="SearchButton">
     <div style="width:100%;">
         <div class="logo"><br /><br /><br /><img height="300px" class="logoimg" src="Images/logo2.png" />           
             <br /><h3 style="color:white;">Videos</h3>
         </div>
     </div>
    <div class="banner3" style="background-image: url('images/gif.gif');">         
  
  </div>
    <div  style="background-color: #0000005e; position:relative; text-align:left; padding:0; z-index:10; margin-top:-60px;">
                 <div style="max-width:960px; margin: 0 auto; position: relative;">
            <div class="search"><asp:TextBox ID="Search" placeholder="Search" runat="server" AutoPostBack="True"></asp:TextBox><div class="searchbutton"><asp:Button ID="SearchButton" runat="server" Text="Search" Enabled="true" OnClick="SearchButton_Click" Font-Size="20pt"/></div>
                <%--<ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="Search" WatermarkText="Search"></ajaxToolkit:TextBoxWatermarkExtender>--%>
            </div>
                </div>
                </div>
        </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server" >
    <%--    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />--%>
    <%--<h1>Videos</h1>--%>
    <div class="main-content">
    <p><asp:Label ID="Results" visible="true" runat="server" ></asp:Label></p>
    <asp:Panel ID="AddVideoPanel" runat="server" Visible="false">
        <br />
         <a id="AddVideo"  runat="server" href='~/vAdd'>Add Video</a> 
   <br />
    </asp:Panel>
    
    <div class="videogridcontainer">
        <asp:Repeater ID="VideosRepeater" runat="server" OnItemDataBound = "VideosRepeater_ItemEvent">
            <ItemTemplate>
                <div class="videogrid" >
                    <div class="thumbnail">
                        <a href='<%# Eval("Video_ID", "Watch?ID={0}")%>'>  
                        <asp:Image ID="VideoThumbnail" src='<%# Eval("Thumbnail")%>' runat="server"/>
                            <div class="logo4"><br /><img class="logoimg3" style="height: 100px;
    width: 100px;
    margin-top: 50px;" src="Images/play.png" /></div>
                             
                            <div class="videotitle"><h3 style="color:white;"><%# Eval("Title") %></h3></div>  
                            
                             <span class="date"><%#DateTime.Parse(Eval("ED").ToString()).ToString("dd MMM yyyy")%></span>
                            <span class="date" style="margin-left:-160px">Views: <%# Eval("Views")%></span>
                            <br /><span class="date" style="margin-left:-160px">Length: <%# Eval("Length")%></span>
                            </a> 
                    </div>
                    <asp:Panel id="editvideo"  visible="false" runat="server">
                         <span><a  runat="server" href='<%# Eval("Video_ID", "~/vDetails?ID={0}")%>'>Edit Video</a></span>                    
                    </asp:Panel>
                <%--<table style="width:220px; min-height:210px; ">
                    <tr>
                    <td style="height:58px; padding:0px; text-align:center;background-color:#00000014;"> --%><%--:#efc109--%>
                                                              
                    <%--</td>
                    </tr>
                    <tr>
                    <td align="center" style="margin: 0px; padding: 0px; table-layout: fixed; height:120px;">
                        
                        <a id="A1" runat="server" href='<%# Eval("Video_ID", "~/Watch?ID={0}")%>'>
                            
                            <div class="thumbnail">
                            
                                </div>
                        </a>
                        </td>
                        </tr>--%>
                    <%--<tr>
                        <td style="padding:0px 0px 0px 0px;">
                            <a href='<%# Eval("Video_ID", "Watch?ID={0}")%>'><span class="h2"><%# Eval("Title") %></span>    </a>                                       
                         <hr width="200px" color="#b82601" style="border-width:0.5px"/>
                        </td>
                        </tr>--%>
                   <%-- <tr>
                        <td style="text-align:right; padding:0px; margin:0px; vertical-align:bottom;">
                            
                           
                       
                         
                        
                            </td>
                        </tr>                    
                </table>--%>
                    </div>
            </ItemTemplate>
        </asp:Repeater>
           </div>
     <div style="overflow: hidden; text-align:center">
        <asp:Repeater ID="rptPaging" runat="server" OnItemCommand="rptPaging_ItemCommand">
            <ItemTemplate>

                    <asp:LinkButton ID="btnPage"
                        class="pagebtn"
        style=""
    CommandName="Page" CommandArgument="<%# Container.DataItem %>"
        runat="server"><%# Container.DataItem %>
                    </asp:LinkButton>

           </ItemTemplate>
        </asp:Repeater>
   </div>
    <br />
    <asp:HiddenField ID="Search_Query" runat="server" />
      </div>  
</asp:Content>