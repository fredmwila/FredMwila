using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using static Fred.FMjrDB;
using static Fred.Youtube;

namespace Fred
{
    public partial class LoadViews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            LoadViewsLength();

        }


        public void LoadViewsLength()
        {
            //try
            //    { 
            DataTable dt;
            //dynamic video;
                string youtubestring = "";
                List<string> youtubeIDs= new List<string> { };
            List<string> youtubestrings = new List<string> { };
                dt = GetVideos("All", 0);

            var q = dt.Rows
          .Cast<DataRow>()
          .Select((r, i) => new { r, n = i / 50 })
          .GroupBy(p => p.n);

            foreach (var g in q)

            {

                Console.WriteLine("Group: " + g.Key);

                foreach (DataRow r in g.Select(p => p.r))

                {
                    
                        if ((r["YoutubeVideoID"].ToString() != null) & (r["YoutubeVideoID"].ToString() != ""))
                        {
                            youtubeIDs.Add(r["YoutubeVideoID"].ToString());
                        }
                    
                }
                   
                    youtubestring = String.Join("%2C", youtubeIDs);
                    
                    string GetVideo = "";
                    youtubestring = "https://www.googleapis.com/youtube/v3/videos?part=snippet%2CcontentDetails%2Cstatistics&id=" + youtubestring + "&key=AIzaSyAZn7BbNP3G_cBmy5cxKrs4SSAf1vMRCZQ";
                   System.Diagnostics.Debug.WriteLine(youtubestring);
                    GetVideo = Get(youtubestring);
                    //System.Diagnostics.Debug.WriteLine(GetVideo);
                    //System.Diagnostics.Debug.WriteLine(youtubestring);
                    //JObject o = JObject.Parse(GetVideo);

                    //List<dynamic> videosList = JsonConvert.DeserializeObject<List<dynamic>>(o);
                dynamic video = JsonConvert.DeserializeObject(GetVideo);

                JArray items = (JArray)video["items"];
                // System.Diagnostics.Debug.WriteLine(fideo.items[2].statistics.viewCount);

                foreach (DataRow row in dt.Rows)
                {
                    if ((row["YoutubeVideoID"].ToString() != null) & (row["YoutubeVideoID"].ToString() != ""))
                    {
                        string views = "";
                        string length = "";
                        for (int i = 0; i < items.Count; i++)
                        {
                            if (video.items[i].id == row["YoutubeVideoID"].ToString())
                            {
                                views = video.items[i].statistics.viewCount;
                                length = video.items[i].contentDetails.duration;
                                length = (ToShortForm(XmlConvert.ToTimeSpan(length))).ToString();
                                //string yCount = video.items[i].statistics.viewCount;
                                System.Diagnostics.Debug.WriteLine("VideoID:" + row["YoutubeVideoID"].ToString() + " Views: " + views + " Current Views: " + views + " Length: " + length);
                                break;
                            }
                           // System.Diagnostics.Debug.WriteLine(row["YoutubeVideoID"].ToString());

                            //System.Diagnostics.Debug.WriteLine(yCount);
                        }

                        if ((views=="") || (views==null)|| (length == "" || length == null))
                        {
                            continue;

                        }
                      
                        System.Diagnostics.Debug.WriteLine("Views: " + views);
                        System.Diagnostics.Debug.WriteLine("Length: " + length);

                        // System.Diagnostics.Debug.WriteLine();
                        string youtubeID = row["YoutubeVideoID"].ToString();
                        string title = row["Title"].ToString();
                        string desc = row["Description"].ToString();
                        int videoID = int.Parse(row["Video_ID"].ToString());
                        string thumbnail = row["Thumbnail"].ToString();
                        //video = GetYoutubeVideo(youtubeID);


                        UpdateVideo(videoID, title, desc, length, views, thumbnail);
                    }


                }


                //}
                Results.Text = "The Views and Length of all Youtube videos has been updated.";
                //Console.WriteLine(r["col0"]);
                youtubeIDs.Clear();
            }

            }

          
               
                
            }

            
                //}
            //catch
            //{
            //    Results.Text = "An Error Occured. Please Try again later.";
            //}

            
        
            
        }
    
