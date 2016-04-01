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
                        homelinetweets.Add(new Tweet(new User(tweet.User.ScreenName), tweet.Text));
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
        public static List<User> getFollowedUsers()
        {
            List<User> followedusers = new List<User>();
            try
            {

                var friendids = service.ListFriendIdsOf(new ListFriendIdsOfOptions());

                for (int id = 0; id > friendids.Count; id++)
                {
                    TwitterFriendship info = service.GetFriendshipInfo(new GetFriendshipInfoOptions { TargetId = friendids[id].ToString() });
                    followedusers.Add(new User(info.Relationship.Source.ScreenName));
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
                    usertweets.Add(new Tweet(new User(tweet.User.ScreenName), tweet.Text));
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

        private int id;

        public int Id
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
        public User(int id, string screenname) {
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
        #region MyRegion
        public override string ToString()
        {
            return profilepic + " " + screenname;
        }
        #endregion
    }

}
