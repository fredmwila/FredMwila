<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="vDetails.aspx.cs" Inherits="Fred.vDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" Runat="Server">
    <%-- <link rel="stylesheet" href="http://www.w3schools.com/lib/w3.css"/>--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
             
            Title: <asp:TextBox ID="TitleTextBox" runat="server" ></asp:TextBox>
    ED: <asp:TextBox ID="ED" runat="server" ></asp:TextBox>
            <br />
            <iframe id="I1" allowfullscreen="" runat="server" frameborder="0" name="I1" 
        
        style="width: 100%"></iframe><%--<asp:label ID="Literal1" runat="server"></asp:label>  --%>         
            <br />Embed: <asp:TextBox ID="Embed" runat="server" AutoPostBack="True"></asp:TextBox> 
            <br />Thumbnail: <asp:TextBox ID="Thumbnail" runat="server" AutoPostBack="True"></asp:TextBox>     
    <br />
    Views: <asp:Label ID="yViews" runat="server" Text=""></asp:Label>
    <br />
    Length: <asp:Label ID="yLength" runat="server" Text=""></asp:Label>
             <div>
                    <asp:FileUpload ID="FileUpload1" runat="server" /><asp:Label ID="Label1" runat="server"></asp:Label>
                    <asp:Button ID="uploadButton1" runat="server" AutoPostBack="true" OnClick="uploadButton1_Click" Text="Upload File" />
                </div>
    
    <br />Description:<asp:TextBox ID="Description" runat="server" AutoPostBack="True" TextMode="MultiLine"></asp:TextBox>
  <br />
    <asp:Button ID="Update" class="navigation" height="30px" style="font-size:15px;" runat="server" Text="Update" OnClick="Update_Click" />
        <br/>
    <asp:Button ID="Delete" class="navigation" height="30px" style="font-size:15px;" runat="server" Text="Delete" OnClick="Delete_Click" />
   
    <asp:HiddenField ID="id_video" runat="server" />
</asp:Content>
