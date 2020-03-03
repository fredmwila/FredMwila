using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Net.Mail;
using System.Web;
//using IRMA;



partial class MasterPage : System.Web.UI.MasterPage
{
    

    public void Page_Load(object Sender, EventArgs E)
    {

        Page.Title = "Fred Mwila Jr";

        if (MainContent.Page.GetType().FullName == "ASP.default_aspx")
            // Home.ForeColor = System.Drawing.ColorTranslator.FromHtml("#efc109")
            HomeButton.CssClass = "HomeButtonCream";

        if (MainContent.Page.GetType().FullName == "ASP.about_aspx")
            About.CssClass="navigationFocus";

        if (MainContent.Page.GetType().FullName == "ASP.videos_aspx")
            Videos.CssClass = "navigationFocus";

        if (MainContent.Page.GetType().FullName == "ASP.projects_aspx")
            Projects.CssClass = "navigationFocus";

        if (MainContent.Page.GetType().FullName == "ASP.articles_aspx")
            Articles.CssClass = "navigationFocus";
    }

    protected void About_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/about");
    }

    protected void Videos_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/videos");
    }

    protected void Articles_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/articles");
    }

    protected void Projects_Click(object sender, EventArgs e)
    { 
        Response.Redirect("~/projects");
    }

    protected void Home_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/");
    }

    public void Send_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                // here on button click what will done
                SendMail();
                DisplayMessage.Text = "Thank you for sending me a message. I will get back to you as soon as I can.";
                DisplayMessage.Visible = true;
                YourSubject.Text = "";
                YourEmail.Text = "";
                YourName.Text = "";
                Comments.Text = "";
            }
            catch (Exception generatedExceptionName)
            {
                DisplayMessage.Text = "An Error Occured.";
            }
        }
    }

    protected void SendMail()
    {
        System.Net.Mail.MailMessage mm = new System.Net.Mail.MailMessage();
        System.Net.Mail.SmtpClient sc = new System.Net.Mail.SmtpClient();


        sc.Host = "smtp.gmail.com";

        sc.Port = 587;


        mm.From = new MailAddress("FredMwilaJr@gmail.com", "Fred Mwila");
        mm.To.Add(new MailAddress("FredMwilaJr@gmail.com"));
        mm.Subject = YourSubject.Text;

        string body = "From: " + YourName.Text + "<br/><br/>";
        body += "Email: " + YourEmail.Text + "<br/><br/>";
        body += "Subject: " + YourSubject.Text + "<br/><br/>";
        body += "Question: " + Constants.vbLf + Comments.Text + "<br/><br/>";
        body += "This message was sent via FredMwilaJr.azurewebsites.net";

        mm.IsBodyHtml = true; // specifies if the body is HTML or Plain Text 

        mm.Body = body;
        sc.UseDefaultCredentials = false;
        sc.EnableSsl = true;
        sc.Credentials = new System.Net.NetworkCredential("FredMwilaJr@gmail.com", "@12Greercres");
        sc.Send(mm);

        mm.Dispose();


    }

}
