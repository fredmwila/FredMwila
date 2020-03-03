<%@ Page Language="C#" AutoEventWireup="false" CodeFile="LoginCS.aspx.cs" Inherits="Login" MasterPageFile="ExamplesMasterPage.master" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ExampleContent" Runat="Server">
    <asp:panel ID="Panel1" DefaultButton="LoginButton" runat="server">
    Username<br/>
    <asp:TextBox ID="Username" runat="server"></asp:TextBox>
    <br/>
    Password
    <br />
    <asp:TextBox ID="Password" runat="server" TextMode="password"></asp:TextBox>
            <br />
            <asp:Button ID="LoginButton" runat="server" Text="Log In" />
    <asp:Label ID="errorLabel" runat="server"></asp:Label>
    </asp:panel>
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
 </asp:Content>
