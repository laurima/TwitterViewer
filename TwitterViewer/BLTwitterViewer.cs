using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TweetSharp;
using Newtonsoft.Json;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace TwitterViewer
{
    static class BLTwitterViewer
    {
        static TwitterService service;
        static OAuthRequestToken requestToken;
        static OAuthAccessToken accessToken;
        public static void testauthenticate()
        {
            string _consumerKey = TwitterViewer.Properties.Settings.Default.ConsumerKey;
            string _consumerSecret = TwitterViewer.Properties.Settings.Default.ConsumerSecret;
            string _accessToken = TwitterViewer.Properties.Settings.Default.AccessToken;
            string _accessTokenSecret = TwitterViewer.Properties.Settings.Default.AccessTokenSecret;
            // In v1.1, all API calls require authentication
            service = new TwitterService(_consumerKey, _consumerSecret);
            service.AuthenticateWith(_accessToken, _accessTokenSecret);
        }

        public static void OauthRequest()
        {
            service = new TwitterService(TwitterViewer.Properties.Settings.Default.ConsumerKey, TwitterViewer.Properties.Settings.Default.ConsumerSecret);
            requestToken = service.GetRequestToken();
        }

        public static void openAuthorizationUrl()
        {
            Uri uri = service.GetAuthorizationUri(requestToken);
            Process.Start(uri.ToString());
        }

        public static void OauthAccess(string pin)
        {
            accessToken = service.GetAccessToken(requestToken, pin);
        }

        public static void authenticate()
        {
            service.AuthenticateWith(accessToken.Token, accessToken.TokenSecret);
        }

        public static void AddCategory(string category)
        {
            try
            {
                Type type = typeof(string);
                JObject jobject = DBTwitterViewer.ReadCategoriesXML();
                /*string tmp = JsonConvert.DeserializeObject(jobject["category"].ToString(), type); is not yet functional
                //DBTwitterViewer.SerializeCategory(category);
                MessageBox.Show(tmp);*/
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public static void saveCategories(List<String> categories)
        {
            /*XElement xetmp = new XElement();
            xetmp.Add(categories);*/
        }
        public static List<String> showCategories()
        {
            XElement xetmp;
            List<String> list = new List<string>();
            return list;
        }

        public static void updateFollowedUsersJson()
        {
            try
            {
                List<User> followedusers = new List<User>();
                var friendids = service.ListFriendIdsOf(new ListFriendIdsOfOptions());

                for (int id = 0; id < friendids.Count(); id++)
                {
                    TwitterFriendship info = service.GetFriendshipInfo(new GetFriendshipInfoOptions { SourceId = TwitterViewer.Properties.Settings.Default.UserID, TargetId = friendids[id].ToString() });
                    followedusers.Add(new User(info.Relationship.Target.Id, info.Relationship.Target.ScreenName));
                }

                DBTwitterViewer.SerializeFollowedUsers(followedusers);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static List<Tweet> getUserTimeLine()
        {
            List<Tweet> homelinetweets = new List<Tweet>();
            try
            {
                IEnumerable<TwitterStatus> tweets = service.ListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions());

                for (int i = 0; i < tweets.Count(); i++)
                {
                    if (tweets.ElementAt(i).Id != 0)
                    {
                        TwitterStatus tweet = tweets.ElementAt(i);
                        homelinetweets.Add(new Tweet(new User(tweet.User.Id, tweet.User.ScreenName), tweet.Text));
                    }
                }

                return homelinetweets;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return homelinetweets;
            }

        }

        public static List<User> getFollowedUsers()
        {
            List<User> followedusers = new List<User>();
            try
            {
                followedusers = DBTwitterViewer.DeserializeFollowedUsers();

                return followedusers;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return followedusers;
            }
        }

        public static List<Tweet> getTweets(string screenname)
        {
            List<Tweet> usertweets = new List<Tweet>();
            try
            {
                var tweets = service.ListTweetsOnUserTimeline(new ListTweetsOnUserTimelineOptions { ScreenName = screenname });

                foreach (var tweet in tweets)
                {
                    if (tweet.Id != 0)
                    {
                        usertweets.Add(new Tweet(new User(tweet.User.Id, tweet.User.ScreenName), tweet.Text));
                    }
                    
                }
                return usertweets;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return usertweets;
            }

        }

    }

    class Tweet
    {
        #region PROPERTIES

        private User user;

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }


        #endregion
        #region CONSTRUCTOR
        public Tweet(User user, string message)
        {
            User = user;
            Message = message;
        }
        #endregion
        #region METHODS
        public override string ToString()
        {
            return user.Screenname + ": " + message;
        }
        #endregion
    }

    class User
    {
        #region PROPERTIES

        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private string screenname;

        public string Screenname
        {
            get { return screenname; }
            set { screenname = value; }
        }

        private string profilepic;

        public string Profilepic
        {
            get { return profilepic; }
            set { profilepic = value; }
        }

        #endregion
        #region CONSTRUCTOR
        [JsonConstructor]
        public User(long id, string screenname, string profilepic)
        {
            this.id = id;
            this.screenname = screenname;
            this.profilepic = profilepic;
        }
        public User(long id, string screenname)
        {
            this.id = id;
            this.screenname = screenname;
            this.profilepic = "https://twitter.com/" + screenname + "/profile_image?size=original";
        }

        public User(string screenname)
        {
            this.id = 0;
            this.screenname = screenname;
            this.profilepic = "https://twitter.com/" + screenname + "/profile_image?size=original";
        }
        #endregion
        #region METHODS
        public override string ToString()
        {
            return profilepic + " " + screenname;
        }
        #endregion
    }

    class Category
    {
        #region PROPERTIES
        private List<User> users;

        public List<User> Users
        {
            get { return users; }
            set { users = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        #endregion
        #region CONSTRUCTORS
        [JsonConstructor]
        public Category(List<User> users, string name)
        {
            this.users = users;
            this.name = name;
        }
        public Category(string name)
        {
            this.name = name;
        }
        public Category()
        {
        }
        #endregion
    }
}
