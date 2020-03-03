<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LoadViews.aspx.cs" Inherits="Fred.LoadViews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent2" runat="server">
    <div class="main-content" style="margin-top:100px;">
    <asp:Label ID="Results" runat="server" Text="Label"></asp:Label>
        </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent3" runat="server">
</asp:Content>
