<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="aAdd.aspx.cs" Inherits="Fred.aAdd" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Add an Article</h1>
    <br/>
    <div>
        Title: <asp:TextBox ID="aTitle" runat="server"></asp:TextBox>
        <br/>
        <br/>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
   <CKEditor:CKEditorControl ID="aContent" BasePath="/ckeditor/" runat="server">
   </CKEditor:CKEditorControl>
        <br/>
        <br/>
        <asp:Button ID="PreviewButton" class="navigation" height="30px" style="font-size:15px;" runat="server" Text="Preview" />
        <br/>
        <br/>
        <div class="acontent">
        <asp:Label ID="PreviewLabel" runat="server" autopostback="true"></asp:Label>
            </div>
         <br/>
        <br/>
        <asp:Button ID="Update" class="navigation" height="30px" style="font-size:15px;" runat="server" Text="Add" OnClick="Update_Click" />
</div>
</asp:Content>
