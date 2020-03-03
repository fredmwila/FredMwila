<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Fred.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="main-content">
    <div class="login" style="margin-top:100px;">
        <asp:Panel ID="LoginPanel" runat="server" defaultbutton="LoginButton">
    Username<br/>
    <asp:TextBox ID="User_ID" runat="server"></asp:TextBox>
    <br/>
    Password
    <br />
    <asp:TextBox ID="Password" runat="server" TextMode="password"></asp:TextBox>
            <br />
            <asp:Button ID="LoginButton"  runat="server" Text="Log In" UseSubmitBehavior="True" />
    <asp:Label ID="errorLabel" runat="server"></asp:Label>
            </asp:Panel>
    <asp:Panel ID="LogoutPanel" runat="server" DefaultButton="LogoutButton">
        <asp:Button ID="LogoutButton" runat="server" Text="Log Out" OnClick="LogoutButton_Click" />
    </asp:Panel>
        </div>
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

     <%--<script>

            function FireDefaultButton(event, target) 
            {
                // srcElement is for IE
                var element = event.target || event.srcElement;

                if (13 == event.keyCode && !(element && "textarea" == element.tagName.toLowerCase())) 
                {
                    var defaultButton;
                    defaultButton = document.getElementById(target);

                    if (defaultButton && "undefined" != typeof defaultButton.click) 
                    {
                        defaultButton.click();
                        event.cancelBubble = true;
                        if (event.stopPropagation) 
                            event.stopPropagation();
                        return false;
                    }
                }
                return true;
            }
    </script>--%>
       </div>
</asp:Content>