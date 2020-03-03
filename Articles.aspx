<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Articles.aspx.cs" Inherits="Fred.Articles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" Runat="Server">
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
             <br />           
            <h3 style="color:white;">Articles</h3>
         </div>
     </div>
    <div class="banner3" style="background-image: url('Images/articles_banner.jpg')">         
            
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
    <div class="main-content">
     <asp:Label ID="Results" runat="server" ></asp:Label>
  <br />
     <a id="AddArticle" visible="false" runat="server" href='~/aAdd'>Add Article</a> 
    <br />
     <div style="display: inline-block;
text-align: center;" >
        <asp:Repeater ID="ArticlesRepeater" runat="server">
            <ItemTemplate>
                <div class="videogrid" >
                    <%--<div class="logo2"><br /><img class="logoimg2" src="Images/logo2.png" /></div>--%>
                <table style="width:220px; height:223px;">
                    <tr style="background-color:black;">
                    <td style="padding:0px; text-align:center;">
                        <a href='<%# Eval("ArticleID", "Read?ID={0}")%>'><span class="h3" style="color:white;"><%# Eval("Title") %></span>    </a>                                       
                    </td>
                    </tr>
                    <tr>
                    <td align="center" style="margin: 0px; padding: 5px 0px 5px 0px; vertical-align: top; table-layout: fixed;">
                        
                        <a id="A1" runat="server" href='<%# Eval("ArticleID", "~/Read?ID={0}")%>'>
                            
                            <%# Eval("Content")%>
                        </a>
                        <p><%# Eval("EU")%> , <%# Eval("ED")%>   </p> 
                        <asp:Panel id="editArticle"  visible="false" runat="server">
                         <a id="A2"  runat="server" href='<%# Eval("ArticleID", "~/aDetails?ID={0}")%>'>Edit Article</a>                    
                    </asp:Panel>
                            </td>
                        </tr>                    
                </table>
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
        runat="server" ForeColor="White" Font-Bold="True"><%# Container.DataItem %>
                    </asp:LinkButton>
           </ItemTemplate>
        </asp:Repeater>
   </div>
    <asp:HiddenField ID="Search_Query" runat="server" />
        </div>
</asp:Content>

