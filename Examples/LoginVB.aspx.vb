
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class Login
    Inherits System.Web.UI.Page

    Dim retval As String
    Dim UserID As Integer = 0


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack Then

            Page.Validate()


            If Page.IsValid Then
                validateLogin(Username.Text, Password.Text)
            End If
        End If


    End Sub


    Sub validateLogin(User As String, Pass As String)

        Dim Output As String

        Dim cn As New SqlConnection("Data Source=KATUTA-PC;Initial Catalog=LoginExample;Integrated Security=True")

        cn.Open()
        Dim cmd As SqlCommand = New SqlCommand("Login_SP", cn)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = User
        cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Pass
        cmd.Parameters.Add("@Output", SqlDbType.VarChar, 50).Value = ""

        cmd.Parameters("@Output").Direction = ParameterDirection.Output

        cmd.ExecuteNonQuery()

        cn.Close()

        Output = cmd.Parameters("@Output").Value.ToString()


        If Output = "fail" Then

            errorLabel.Text = "Invalid User ID or Password"
        Else
            'Login successful
            UserID = Output
            '---------  Set session cookies  ---------
            Session("UserID") = UserID
            Session("UserName") = Username.Text

            Response.Redirect("defaultVB.aspx")
        End If

    End Sub

End Class