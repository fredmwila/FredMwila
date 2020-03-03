<%@ Page Language="C#" AutoEventWireup="false" CodeFile="DefaultCS.aspx.cs" Inherits="_Default" MasterPageFile="ExamplesMasterPage.master" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ExampleContent" Runat="Server">
    <div>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br/>
        <asp:Button ID="LogIn" runat="server" Text="Log In" PostBackUrl="login.aspx" /><asp:Button ID="LogOut" runat="server" Text="Log Out" />
    </div>
</asp:Content>
