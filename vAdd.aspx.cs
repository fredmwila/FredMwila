using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Fred.FMjrDB;
using Google.Apis.YouTube.v3;
using System.Net;
using System.IO;
using Google.Apis.YouTube.v3.Data;
using Newtonsoft.Json;
using System.Globalization;
using static Fred.Youtube;
using System.Xml;

namespace Fred
{
    public partial class vAdd : System.Web.UI.Page
    {

        private DataTable rs;
        private string retval;
        public string embed;


        public void Page_Load(object Sender, EventArgs E)
        {
            Page.Title = "Add Video";

            if (Request.QueryString["ID"] != null)
                id_video.Value = Request.QueryString["ID"];

            if (Session["UserType"] == null)
                Response.Redirect("Videos");
            else if (Session["UserType"].ToString() != "admin")
                Response.Redirect("Videos");

            if (yEmbed.Text != "")
                // Try
                loadyoutubevideo();
            if (fEmbed.Text != "")
                // Try
                loadfacebookvideo();

            Image1.ImageUrl = Thumbnail.Text;
        }

        public string GetBetween(string OriginalString, string StartMatch, string EndMatch, int startPos = 0)
        {
            List<string> TheMatches = new List<string>();
            string returnstr = "";

            while (OriginalString.IndexOf(StartMatch) >= 0)
            {
                OriginalString = OriginalString.Substring(OriginalString.IndexOf(StartMatch) + StartMatch.Length);
                TheMatches.Add(OriginalString.Substring(0, OriginalString.IndexOf(EndMatch)));
            }

            foreach (string _Match in TheMatches)
            {
                return _Match;
                returnstr = _Match;
            }
            return returnstr;
        }

        public void loadfacebookvideo()
        {

            // Dim urlstr As String
            // embed = FEmbed.Text
            string facebookVideoID;

            facebookVideoID = GetBetween(fEmbed.Text, "/videos/", "/");
            if (facebookVideoID != string.Empty)
                ViewState["fbid"] = facebookVideoID;
            fEmbed.Text = "https://www.facebook.com/video/embed?video_id=" + ViewState["fbid"];

            embed = fEmbed.Text;
            I1.Src = embed;
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            if (vtitle.Text != string.Empty & Description.Text != string.Empty & embed != string.Empty & Thumbnail.Text != string.Empty)
            {
                //retval = Database.Update.Generic("FMjr", "Amend_Videos", 0, "", 0, System.Web.UI.Page.Session["PersonName"].ToString(), 0, 0, vtitle.Text, Description.Text, embed, Thumbnail.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                int videoID;
                videoID = AddVideo(yVideoID.Text, vtitle.Text, Description.Text, embed, Thumbnail.Text, UploadDate.Text, Session["PersonName"].ToString(), int.Parse(yViews.Text), yLength.Text);
                Response.Redirect("Watch?ID=" + videoID);
            }
        }

        public string SearchY(string richt, string key, int i, string stop)
        {
            string source = richt;
            string extract = source.Substring(source.IndexOf(key) + i);
            string result = extract.Substring(0, extract.IndexOf(stop));
            return result;
        }

        

        public void loadyoutubevideo()
        {
            //try
            //{

                string url = yEmbed.Text;
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //StreamReader sr = new StreamReader(response.GetResponseStream());
            //string richBox = sr.ReadToEnd();
            // Dim youTubeVideoIdStartPos As Integer
            // youTubeVideoIdStartPos = Embed.Text + 3

           
            
//Authorization: Bearer[YOUR_ACCESS_TOKEN]
//Accept: application / json



                string youtubeVideoId;

            youtubeVideoId = GetLast(yEmbed.Text, 11);
            yVideoID.Text = youtubeVideoId;

                try
                {
                    dynamic video = GetYoutubeVideo(youtubeVideoId);


                    //get title
                    string ytitle = video.items[0].snippet.title;
                    vtitle.Text = ytitle;

                    //get description
                    Description.Text = video.items[0].snippet.description;

                    //Get Upload Date
                    DateTime ed = video.items[0].snippet.publishedAt;
                    UploadDate.Text = ed.ToString("yyyy-dd-MM ss:mm:HH", CultureInfo.InvariantCulture);
                    //UploadDate.Text = video.items[0].snippet.publishedAt;

                    //Get Views
                    yViews.Text = video.items[0].statistics.viewCount;

                    //Get Length
                    string duration = video.items[0].contentDetails.duration;
                    yLength.Text = XmlConvert.ToTimeSpan(duration).ToString();
                    //yLength.Text = XmlConvert.ToTimeSpan("PT36M54S").ToString();
                    System.Diagnostics.Debug.WriteLine("title:" + ytitle);
                }
                catch
                { }
                    

            // Response.Redirect(GetTitle(Embed.Text))
            // vtitle.Text = Replace(GetTitle(yEmbed.Text), "- YouTube", "");
            //vtitle.Text = video.items[0].title;


            yEmbed.Text = yEmbed.Text.Replace("watch?v=", "embed/");
                yEmbed.Text = yEmbed.Text.Replace("youtu.be", "youtube.com/embed/");
                embed = yEmbed.Text;
                I1.Src = yEmbed.Text;
                // Image1.ImageUrl = Thumbnail.Text

                string source;
                source = "http://img.youtube.com/vi/" + youtubeVideoId + "/0.jpg";

                string Destination;
                Destination = Server.MapPath("~/Images/Thumbnails/" + youtubeVideoId + ".jpg");


                WebClient Client = new WebClient();
                Client.DownloadFile(source, Destination);
                Client.Dispose();

                if (Thumbnail.Text == string.Empty)
                    // Client.DownloadFile(source, Destination)
                    Thumbnail.Text = "/Images/Thumbnails/" + youtubeVideoId + ".jpg";

            //get description 
            //string desc = SearchY(richBox, "<p id=\"eow-description\" >", 25, "</p>");


                //string s = "";
                //if (desc.Contains("<").Equals(true))
                //{
                //    s = SearchY(desc, "<", 1, ">");
                //    desc.Replace(s, "");
                //}
                //desc = DeleteHtmlTags(desc);
                //Description.Text = desc;

                //get tags
                //string tags = SearchY(richBox, "keywords\":", 12, "\"");
                //richTextBoxTags.Text = tags.Replace(",", "\n");
                // get views
                //string views = SearchY(richBox, "watch-view-count", 19, "</");
                //labelViewsCount.Text = views;
                ////get like
                //string like = SearchY(richBox, "like this video along with ", 27, "other");
                //labelLikeCount.Text = like;
                ////get dislike
                //string dislike = SearchY(richBox, "dislike this video along with ", 30, "other");
                //labelDislikeCount.Text = dislike;

                //get publish date
                //string pubdate = SearchY(richBox, "class=\"watch-time-text\"", 24, "</");
                //UploadDate.Text = pubdate;
            //    }
            //catch 
            //{
            //}
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
                    Image1.ImageUrl = Thumbnail.Text;
                }
            }
        }
    }
}
