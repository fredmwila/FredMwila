using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using static Fred.FMjrDB;

namespace Fred
{
    public class Youtube
    {
        public static string Get(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public static dynamic GetYoutubeVideo(string youtubeID)
        {
            string GetVideo = "";

            GetVideo = Get("https://www.googleapis.com/youtube/v3/videos?part=snippet%2CcontentDetails%2Cstatistics&id=" + youtubeID + "&key=AIzaSyAZn7BbNP3G_cBmy5cxKrs4SSAf1vMRCZQ");



            dynamic video = JsonConvert.DeserializeObject(GetVideo);
            return video;
        }

        public static void GetYoutubeVideos(string[] youtubeIDs)
        {
            string youtubestring = "";
            foreach (string youtubeID in youtubeIDs)
            {
                youtubestring = youtubestring + youtubeID + ",";
            }
            youtubestring = String.Join(",", youtubeIDs);
            string GetVideo = "";

            GetVideo = Get("https://www.googleapis.com/youtube/v3/videos?part=snippet%2CcontentDetails%2Cstatistics&id=" + youtubestring + "&key=AIzaSyAZn7BbNP3G_cBmy5cxKrs4SSAf1vMRCZQ");



            //dynamic allVideos = JsonConvert.DeserializeObject(GetVideo);

            JObject o = JObject.Parse(GetVideo);

            List<dynamic> videosList = JsonConvert.DeserializeObject<List<dynamic>>(o["item"].ToString());

            foreach (dynamic video in videosList)
            {

            }

            //return videos;
        }
    }
}