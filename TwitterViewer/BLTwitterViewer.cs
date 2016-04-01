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
                IEnumerable<TwitterStatus> tweets = service.ListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions());

                for (int i = 0; i < tweets.Count(); i++)
                {
                    if (tweets.ElementAt(i).Id != 0)
                    {
                        // DELETE node
                        TwitterStatus tweet = tweets.ElementAt(i);
                        homelinetweets.Add(new Tweet(tweet.User.ScreenName, tweet.Text, "https://twitter.com/" + tweet.User.ScreenName + "/profile_image?size=original"));
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
        // 2216257297
        public static List<string> getFollowedUsers()
        {
            List<string> followedusers = new List<string>();
            try
            {

                var friendids = service.ListFriendIdsOf(new ListFriendIdsOfOptions());

                for (int id = 0; id > friendids.Count; id++)
                {
                    TwitterFriendship info = service.GetFriendshipInfo(new GetFriendshipInfoOptions { TargetId = friendids[id].ToString() });
                    followedusers.Add(info.Relationship.Source.ScreenName);
                }

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
                    usertweets.Add(new Tweet(tweet.User.ScreenName, tweet.Text, "https://twitter.com/" + tweet.User.ScreenName + "/profile_image?size=original"));
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

        private string profilepic;

        public string Profilepic
        {
            get { return profilepic; }
            set { profilepic = value; }
        }


        #endregion
        #region CONSTRUCTOR
        public Tweet(string user, string message, string profilepic)
        {
            User = user;
            Message = message;
            Profilepic = profilepic;
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
