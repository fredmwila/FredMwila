<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="aDetails.aspx.cs" Inherits="Fred.aDetails" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" Runat="Server">
    <%-- <link rel="stylesheet" href="http://www.w3schools.com/lib/w3.css"/>--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
             
          Title: <asp:TextBox ID="aTitle" runat="server"></asp:TextBox>
        <br/>
        <br/>
   <CKEditor:CKEditorControl ID="aContent" BasePath="/ckeditor/" runat="server">
   </CKEditor:CKEditorControl>
        <br/>
        <br/>
        <asp:Button ID="PreviewButton" class="navigation" height="30px" style="font-size:15px;" runat="server" Text="Preview" OnClick="PreviewButton_Click" />
        <br/>
        <br/>
        <div class="acontent">
        <asp:Label ID="PreviewLabel" runat="server" autopostback="true"></asp:Label>
            </div>
         <br/>
        <br/>
        <asp:Button ID="Update" class="navigation" height="30px" style="font-size:15px;" runat="server" Text="Update" OnClick="Update_Click" />
        <br/>
        <br/>
    <asp:Button ID="Delete" class="navigation" height="30px" style="font-size:15px;" runat="server" Text="Delete" OnClick="Delete_Click" />
    <asp:HiddenField ID="id_article" runat="server" /><asp:HiddenField ID="EU" runat="server" /><asp:HiddenField ID="ED" runat="server" />
</asp:Content>