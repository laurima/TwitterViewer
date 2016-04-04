﻿using System;
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
            string _consumerKey = TwitterViewer.Properties.Settings.Default.ConsumerKey;
            string _consumerSecret = TwitterViewer.Properties.Settings.Default.ConsumerSecret;
            string _accessToken = TwitterViewer.Properties.Settings.Default.AccessToken;
            string _accessTokenSecret = TwitterViewer.Properties.Settings.Default.AccessTokenSecret;
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

        public static List<User> getFollowedUsers()
        {
            List<User> followedusers = new List<User>();
            try
            {
                // To get followed users from twitter api
                // Problem with this is twitter api limits

                /*
                var friendids = service.ListFriendIdsOf(new ListFriendIdsOfOptions());
                
                for (int id = 0; id < friendids.Count(); id++)
                {
                    TwitterFriendship info = service.GetFriendshipInfo(new GetFriendshipInfoOptions { SourceId = TwitterViewer.Properties.Settings.Default.UserID, TargetId = friendids[id].ToString() });
                    followedusers.Add(new User(info.Relationship.Target.Id, info.Relationship.Target.ScreenName));
                }
                */

                //DBTwitterViewer.SerializeFollowedUsers(followedusers);
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
        #region MyRegion
        public override string ToString()
        {
            return profilepic + " " + screenname;
        }
        #endregion
    }

}