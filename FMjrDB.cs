using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Net;
using static Fred.Youtube;


namespace Fred
{
    public class FMjrDB
    {

        public static string connString = "Data Source=" + HttpContext.Current.Server.MapPath("FMjr.db") + ";Version=3;datetimeformat=CurrentCulture";

        public static SQLiteConnection sqlite_conn = new SQLiteConnection(connString);

        public static string DeleteHtmlTags(string value)
        {
            var str1 = Regex.Replace(value, @"<[^>]+>|&nbsp;", "").Trim();
            var str2 = Regex.Replace(str1, @"\s{2,}", " ");
            return str2;
        }
        static string[] GetWords(string input)
        {
            MatchCollection matches = Regex.Matches(input, @"\b[\w']*\b");

            var words = from m in matches.Cast<Match>()
                        //where m.Value != ""
                        select (m.Value);
            //select TrimSuffix(m.Value);

            return words.ToArray();
        }

        static string TrimSuffix(string word)
        {
            int apostropheLocation = word.IndexOf('\'');
            if (apostropheLocation != -1)
            {
                word = word.Substring(0, apostropheLocation);
            }

            return word;
        }

        public static string StripHTML(string htmlString)
        {

            string pattern = @"<(.|\n)*?>";

            return Regex.Replace(htmlString, pattern, string.Empty);
        }

        public static string TruncateLongString(string str, int maxLength)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return str.Substring(0, Math.Min(str.Length, maxLength));
        }
        public static void ExecuteQuery(string sql)
        {
            

            // open the connection:
            sqlite_conn.Open();
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);

            command.ExecuteNonQuery();
            
            sqlite_conn.Close();

        }

        public static string ToShortForm(TimeSpan t)
            {
                string shortForm = "";
                if (t.Hours > 0)
                {
                    shortForm += string.Format("{0}h", t.Hours.ToString());
                }
                if (t.Minutes > 0)
                {
                    shortForm += string.Format("{0}m", t.Minutes.ToString());
                }
                if (t.Seconds > 0)
                {
                    shortForm += string.Format("{0}s", t.Seconds.ToString());
                }
                return shortForm;
            }

        public static string GetLast(string source, int tail_length)
    {
        if (tail_length >= source.Length)
            return source;
        return source.Substring(source.Length - tail_length);
    }

        //public static void GetTitle(string url)
        //{
        //    WebClient x = new WebClient();
        //    string source = x.DownloadString(url);

        //        GetTitle = Regex.Match(source, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups("Title").Value;
        //    return GetTitle;
        //}




        public static DataTable SelectQuery(string sql)
        {
            // create a new database connection:
           
                // open the connection:
                sqlite_conn.Open();
                SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.SelectCommand = command;
                DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
            }

            catch
            {
              
            }
            command.Dispose();
                da.Dispose();
                sqlite_conn.Close();

                return dt;
            
        }


          

        public static string GetUserID(string username, string password)
        {
            string userID;
            string sql;


            // open the connection:
            sqlite_conn.Open();
           

            sql = "SELECT User_ID from Users Where (username = '" + username + "' and password = '" + password + "') or (user_email = '" + username + "' and password = '" + password + "')";

            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            try
                {
                userID = command.ExecuteScalar().ToString();
                }
                catch
                {
                userID = "fail";
            }

            sqlite_conn.Close();


            return userID;
        }

        public static DataTable GetUser(string userID)
        {
            string sql;
            DataTable dt;


            sql = "SELECT * from Users Where User_ID =" + userID + ";";

            dt = SelectQuery(sql);


            return dt;
        }


        public static int AddRecord(string sql, string table, string idColumn)
        {
            int id = 0;

            // open the connection:
            sqlite_conn.Open();
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);

            command.ExecuteNonQuery();

            sql = "SELECT " + idColumn + " from " + table + " order by " + idColumn + " DESC limit 1";

            command = new SQLiteCommand(sql, sqlite_conn);
            id = Convert.ToInt32(command.ExecuteScalar());

            sqlite_conn.Close();


            return id;

        }

        public static int AddArticle(string Title, string Content, string EU, DateTime ED)
        {
            int ArticleID = 0;

            string sql = "Insert into Articles (Title,Content ,EU,ED) VALUES('" + Title + "','" + Content + "','" + EU + "','" + ED + "'); ";

            ArticleID = AddRecord(sql, "Articles", "ArticleID");
            return ArticleID;
        }

        public static void UpdateArticle(int ArticleID, string Title, string Content)
        {

            string sql = "Update Articles Set Title ='" + Title + "', Content ='" + Content + "' where ArticleID =" + ArticleID +"; ";

            ExecuteQuery(sql);
        }

        public static void DeleteArticle(int ArticleID)
        {

            string sql = "Delete from Articles where ArticleID =" + ArticleID + "; ";

            ExecuteQuery(sql);
        }

        public static DataTable GetProjects()
        {
            string sql = "select * from projects where ProjectName is not null;";

            DataTable dt = SelectQuery(sql);

            return dt;
        }

        public static DataTable GetProjectSkills(int projectID)
        {
            string sql = "select * from projectskills ps inner join projects p on  p.projectid = ps.projectid  where p.projectID=" + projectID +";";

            DataTable dt = SelectQuery(sql);
            System.Diagnostics.Debug.WriteLine(sql);
            return dt;
        }

        public static DataTable GetVideos(string type, int VideoID)
        {
            
            
            string sql = "Select [VideoID] as 'Video_ID', [Title] as 'Title', [Description] as 'Description',[Embed] as 'Embed',[Thumbnail] as 'Thumbnail',[length] as 'Length', [Views] as 'Views', [EU] as 'EU', [ED] as 'ED', YoutubeVideoID From Videos ";

            switch (type)
            {
                case "All":
                    sql = sql + "Order By ED desc";
                    break;

                case "LatestVideos":
                    sql = sql + "where VideoID <> (select videoid from videos order by ed desc limit 1) order by ed desc limit 6 ";
                    break;
                case "LatestVideo":
                    sql = sql + "order by ed desc limit 1";
                    break;

                case "Watch":
                    sql = sql + "Where VideoID =" + VideoID + ";";
                    break;
            }

            DataTable dt = SelectQuery(sql);

            //dynamic video;

            //try
            //    {
            //    if (type == "Watch")
            //    {
            //foreach (DataRow row in dt.Rows)
            //{
            //    row["length"] = ToShortForm(TimeSpan.Parse(row["length"].ToString()));

            //}
            //    }
            //}
            //catch
            //{

            //}


            return dt;
        }

        public static int AddVideo(string youtubeVideoID, string title, string description, string embed, string thumbnail, string ed, string eu, int views, string length)
        {
            int VideoID = 0;

            string sql = "Insert into Videos (YoutubeVideoID, Title,Description ,Embed, Thumbnail, ED, EU, Views, Length) VALUES('" + youtubeVideoID + "','" + title + "','" + description + "','" + embed + "','" + thumbnail + "','" + ed + "','" + eu + "','" + views + "','" + length + "'); ";

           VideoID = AddRecord(sql, "Videos", "VideoID");
            return VideoID;
        }

        public static void UpdateVideo(int VideoID, string Title, string Description, string Length, string Views, string Thumbnail)
        {
            Description = Description.Replace("'", "''");
            Description = Description.Replace("'''", "''");
            string sql = "Update Videos Set Title ='" + Title + "', Description ='" + Description + "', Length ='" + Length + "', Views ='" + Views + "', Thumbnail ='" + Thumbnail + "' where VideoID =" + VideoID + "; ";
            System.Diagnostics.Debug.WriteLine(sql);
            ExecuteQuery(sql);
        }

        public static void DeleteVideo(int VideoID)
        {

            string sql = "Delete from Videos where VideoID =" + VideoID + "; ";

            ExecuteQuery(sql);
        }

        public static DataTable GetArticles(string type, int ArticleID)
        {
            string sql = "Select [ArticleID] as 'ArticleID',[Title] as 'Title',[Content] as 'Content', [wordcount] as 'wordcount', [Views] as 'Views', ed, u.user_profilepicture as 'Profile', u.user_about as 'About', u.F_Name || ' ' || u.l_name as 'EU' From Articles a inner join Users u on a.user_id=u.user_id ";

            switch (type)
            {
                case "All":
                    sql = sql + "Order By ED desc";
                    break;

                case "LatestArticles":
                    sql = sql + "where ArticleID <> (select articleid from videos order by ed desc limit 1) order by ed desc limit 6 ";
                    break;
                case "LatestArticle":
                    sql = sql + "order by ed desc limit 1";
                    break;

                case "Read":
                    sql = sql + "Where ArticleID =" + ArticleID + ";";
                    break;
            }

            System.Diagnostics.Debug.WriteLine(sql);

            DataTable dt = SelectQuery(sql);

            if (type!="Read")
            {
                foreach (DataRow row in dt.Rows)
                {
                    row["Content"] = TruncateLongString(StripHTML(row["Content"].ToString()), 100) + " ...";

                }
            }

            return dt;
        }


        public static DataTable GetSearchVideos(string search, string type,int videoID)
        {
            string sql;
            string[] match = GetWords(search);
            string matchsql="";
            if (match.Length>0)
            {
                matchsql = "(";
            }

            for (int i = 0; i < match.Length - 1; i++)
            {
               // matchsql = matchsql + match[i];

                if (i < match.Length-2)
                {
                    matchsql = matchsql + "SearchVideos Match '" + match[i] + "' or ";
                }
                else
                {
                    matchsql = matchsql + "SearchVideos Match '" + match[i] + "')";
                }
            }
            //HttpContext.Current.Response.Redirect(matchsql);
            sql = "Drop Table If exists SearchVideos;";
            ExecuteQuery(sql);

            sql = "CREATE VIRTUAL TABLE IF NOT EXISTS SearchVideos USING FTS3(Video_ID, Title, Description, Embed, Thumbnail,Length, Views, ED);";
            ExecuteQuery(sql);

            sql = "insert into SearchVideos Select VideoID, Title, Description, Embed, Thumbnail,Length, Views, ED From Videos;";
            ExecuteQuery(sql);

            sql = "SELECT Video_ID, Title, Description, Embed, Thumbnail, Length, Views, ED FROM SearchVideos  WHERE " + matchsql ;// SearchVideos MATCH '" + search + "'"; // (Title:" + search + " or Description:" + search +")' ";

           
            switch (type)
            {
                case "Related":
                    sql = sql + " and Video_ID <> " + videoID + "  Limit 6;";
                    break;
                case "Search":
                    sql = sql + ";";
                    break;

                    

            }

            // HttpContext.Current.Response.Redirect(sql);
            System.Diagnostics.Debug.WriteLine(sql);

            DataTable dt = SelectQuery(sql);
            return dt;
        }

        public static DataTable GetSearchArticles(string search, string type, int articleID)
        {
            string sql;
            string[] match = GetWords(search);
            string matchsql = "(";

            for (int i = 0; i < match.Length - 1; i++)
            {
                // matchsql = matchsql + match[i];

                if (i < match.Length - 2)
                {
                    matchsql = matchsql + "SearchArticles Match '" + match[i] + "' or ";
                }
                else
                {
                    matchsql = matchsql + "SearchArticles Match '" + match[i] + "')";
                }
            }
            //HttpContext.Current.Response.Redirect(matchsql);
            sql = "Drop Table If exists SearchArticles;";
            ExecuteQuery(sql);

            sql = "CREATE VIRTUAL TABLE IF NOT EXISTS SearchArticles USING FTS3(ArticleID, Title, Content, Thumbnail,WordCount, Views, EU, ED);";
            ExecuteQuery(sql);

            sql = "insert into SearchArticles Select ArticleID, Title, Content, Thumbnail,WordCount, Views,  u.F_Name || ' ' || u.l_name as 'EU', ED From Articles a inner join Users u on a.user_id=u.user_id  ;";
            ExecuteQuery(sql);

            sql = "SELECT ArticleID, Title, Content, Thumbnail,WordCount, Views, EU, ED FROM SearchArticles  WHERE " + matchsql;


            switch (type)
            {
                case "Related":
                    sql = sql + " and ArticleID <> " + articleID + "  Limit 6;";
                    break;
                case "Search":
                    sql = sql + ";";
                    break;



            }

            // HttpContext.Current.Response.Redirect(sql);
            System.Diagnostics.Debug.WriteLine(sql);

            DataTable dt = SelectQuery(sql);

            foreach (DataRow row in dt.Rows)
            {
               row["Content"] =TruncateLongString(StripHTML(row["Content"].ToString()),100) + " ...";
                
            }

            return dt;
        }

       
    }
}