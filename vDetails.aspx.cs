using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Fred.FMjrDB;

namespace Fred
{
    public partial class vDetails : System.Web.UI.Page
    {

        private DataTable rs;
        private string retval;


        public void Page_Load(object Sender, EventArgs E)
        {
            Page.Title = "Video Details";

            if (Request.QueryString["ID"] != null)
                id_video.Value = Request.QueryString["ID"];

            if (Session["UserType"] == null)
                Response.Redirect("Watch?ID=" + id_video.Value);
            else if (Session["UserType"].ToString() != "admin")
                Response.Redirect("Watch?ID=" + id_video.Value);
            if (!IsPostBack)
                Load_Video();

            Embed.Text = Embed.Text.Replace("watch?v=", "embed/");

            I1.Src = Embed.Text;
        }

        public void Load_Video()
        {
            rs = GetVideos("Watch", int.Parse(id_video.Value));

            TitleTextBox.Text = rs.Rows[0]["Title"].ToString();
            Description.Text = rs.Rows[0]["Description"].ToString();
            // Literal1.Text = rs.Rows(0)("Embed").ToString
            Embed.Text = rs.Rows[0]["Embed"].ToString();
            Thumbnail.Text = rs.Rows[0]["Thumbnail"].ToString();
            ED.Text = rs.Rows[0]["ED"].ToString();
            yViews.Text= rs.Rows[0]["Views"].ToString();
            yLength.Text=rs.Rows[0]["Length"].ToString();
            rs = null;
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            UpdateVideo(int.Parse(id_video.Value), TitleTextBox.Text, Description.Text, yLength.Text, yViews.Text, Thumbnail.Text);
            Response.Redirect("Watch?ID=" + id_video.Value);
        }

        protected void uploadButton1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);
                if (fileExtension.ToLower() != ".jpg" && fileExtension.ToLower() != ".png")
                    Label1.Text = "You must upload an image file";
                else
                {
                    FileUpload1.SaveAs(Server.MapPath("~/Images/Thumbnails/" + FileUpload1.FileName));
                    Label1.Text = "File Uploaded";
                    Thumbnail.Text = "/Images/Thumbnails/" + FileUpload1.FileName;
                }
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            DeleteVideo(int.Parse(id_video.Value));
            Response.Redirect("/videos");
        }

    }
}
