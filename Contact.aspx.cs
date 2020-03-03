using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fred
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
}