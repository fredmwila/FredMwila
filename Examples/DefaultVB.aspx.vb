
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("Username") Is Nothing Then
            LogIn.Visible = True
            LogOut.Visible = False
        Else
            Label1.Text = "welcome " & Session("Username").ToString
            LogIn.Visible = False
            LogOut.Visible = True
        End If


    End Sub

    Protected Sub LogIn_Click(sender As Object, e As EventArgs) Handles LogIn.Click
        Response.Redirect("loginvb.aspx")
    End Sub

    Protected Sub LogOut_Click(sender As Object, e As EventArgs) Handles LogOut.Click
        Session("Username") = Nothing
        Session("UserID") = Nothing
        LogIn.Visible = True
        LogOut.Visible = False
        Label1.Text = ""
    End Sub
End Class
