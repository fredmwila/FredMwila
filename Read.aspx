<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Read.aspx.cs" Inherits="Fred.Read" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" Runat="Server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="main-content" style="margin-top:100px;">
          <div class="left-column">
              <h1 style="margin-bottom:10px;"><asp:Label ID="aTitle" runat="server"></asp:Label></h1>                        
              <div style="min-height:120px; margin-bottom:10px;" class="authoracontent">                  
                      <table>
                          <tr>
                              <td>
                                <asp:Image ID="ProfilePic" Height="100px" runat="server" style=" border-radius: 50%; border-color:#EFE9E9;border-width:1px;border-style:Solid;height:100px;"/>
                              </td>
                              <td valign="top">
                                  <h4>by <asp:Label ID="EU" runat="server"></asp:Label>, <asp:Label ID="ED" runat="server"></asp:Label></h4>
                                <asp:Label ID="About" runat="server"></asp:Label>                                 
                              </td>
                          </tr>
                      </table>
                      </div>
            <div class="acontent">
                <asp:Label ID="Content" runat="server" ></asp:Label>
                </div>
                
            
          </div>
                
              <div class="right-column">
                  <h3>Related Articles</h3>
                     <div class="videogrid2div">
                  <asp:Repeater ID="AritcleRepeater" runat="server">
            <ItemTemplate>
                <div class="videogrid2">
                <table class="videogrid2" style=" width:220px;">
                    <tr>
                    <td style="height:40px; padding:0px; text-align:center;">
                        <a style="text-decoration:none;" href='<%# Eval("Article_ID", "Read?ID={0}")%>'><b><span class="h4"><%# Eval("Title") %></span></b>    </a>                                       
                    </td>
                    </tr>
                    <tr>
                    <td align="center" style="margin: 0px; padding: 5px 0px 5px 0px; vertical-align: top; table-layout: fixed;" height="130px">
                        <a id="A1" runat="server" href='<%# Eval("Video_ID", "~/Watch?ID={0}")%>'>
                            <div class="logo2"><br /><img class="logoimg2" src="Images/Logo.png" /></div>
                            <div class="thumbnail">
                            <asp:Image ID="ArticalThumbnail" width="200px" src='<%# Eval("Thumbnail")%>' runat="server"/>
                                </div>
                        </a>
                        <br />
                        <%# Eval("ED")%>    
                        <asp:Panel id="editarticle"  visible="false" runat="server">
                         <a id="A2"  runat="server" href='<%# Eval("Article_ID", "~/aDetails?ID={0}")%>'>Edit Article</a>                    
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
    <asp:HiddenField ID="id_article" runat="server" />
</asp:Content>
