<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="vAdd.aspx.cs" Inherits="Fred.vAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" Runat="Server">
    <div style="width:100%; height:100px;"></div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
             <h2>Add a Video</h2>
    Youtube URL: <asp:TextBox ID="yEmbed" runat="server" AutoPostBack="True"></asp:TextBox> 
     Facebook URL: <asp:TextBox ID="fEmbed" runat="server" AutoPostBack="True"></asp:TextBox> 
            <br />Title: <asp:TextBox ID="vtitle" runat="server" ></asp:TextBox>
            <br />
    Youtube Video ID: <asp:Label ID="yVideoID" runat="server" Text="Label"></asp:Label>
    <br />
    Views: <asp:Label ID="yViews" runat="server" Text=""></asp:Label>
    <br />
    Length: <asp:Label ID="yLength" runat="server" Text=""></asp:Label>
    <div class="aspect-ratio">
             <iframe id="I1" allowfullscreen="" runat="server" frameborder="0" name="I1"></iframe>          
            </div>
            
            <br />Thumbnail: <asp:TextBox ID="Thumbnail" runat="server" AutoPostBack="True"></asp:TextBox>
    <asp:Image ID="Image1" runat="server" />         
             <div>
                    <asp:FileUpload ID="FileUpload1" runat="server" /><asp:Label ID="Label1" runat="server"></asp:Label>
                    <asp:Button ID="uploadButton1" runat="server" AutoPostBack="true" OnClick="uploadButton1_Click" Text="Upload File" />
                </div>
    
    <br />Description:<asp:TextBox ID="Description" runat="server" TextMode="MultiLine"></asp:TextBox>
    <br />Upload Date:<asp:TextBox ID="UploadDate" runat="server" TextMode="DateTime"></asp:TextBox>
  <br />
    <asp:Button ID="Update" runat="server" Text="Add Video" OnClick="Update_Click" />
    <asp:HiddenField ID="id_video" runat="server" />
</asp:Content>

