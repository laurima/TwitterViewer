using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TweetSharp;

namespace TwitterViewer
{
    static class BLTwitterViewer
    {
        static TwitterService service;
        public static void authenticate()
        {
            string _consumerKey = "hDfxDffMyp3xmnAFcCMM9IzuH";
            string _consumerSecret = "ic6M72jx7WcDtICakJHmXkehilHtxJ1sWgKC84dkujlPG9n8Fv";
            string _accessToken = "2216257297-3Nzd3W3Qyl4lCqJU4GzhKsNxgjeVmVZZmmstMoo";
            string _accessTokenSecret = "ie903ODJe2mApqI9TLt73mnGoymv65FSZGGwm9tUJ5zJd";
            // In v1.1, all API calls require authentication
            service = new TwitterService(_consumerKey, _consumerSecret);
            service.AuthenticateWith(_accessToken, _accessTokenSecret);
        }

        public static List<Tweet> getUserTimeLine()
        {
            List<Tweet> homelinetweets = new List<Tweet>();
            try
            {
                var tweets = service.ListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions());
                foreach (var tweet in tweets)
                {
                    //Console.WriteLine("{0} says '{1}'", tweet.User.ScreenName, tweet.Text);
                    homelinetweets.Add(new Tweet(tweet.User.ScreenName, tweet.Text));
                }
                return homelinetweets;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static List<string> getFollowedUsers()
        {
            List<string> followedusers = new List<string>();
            try
            {
                var users = service.ListSubscriptions(new ListSubscriptionsOptions());
                foreach (var user in users)
                {
                    followedusers.Add(user.ToString());
                }
                return followedusers;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

    }

    class Tweet 
    {
        #region PROPERTIES

        private string user;

        public string User
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
        public Tweet(string user, string message)
        {
            User = user;
            Message = message;
        }
        #endregion
        #region METHODS
        public override string ToString()
        {
            return user + ": " + message;
        }
        #endregion
    }
}
