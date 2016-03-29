using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TweetSharp;

namespace TwitterViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string _consumerKey = "hDfxDffMyp3xmnAFcCMM9IzuH";
            string _consumerSecret = "ic6M72jx7WcDtICakJHmXkehilHtxJ1sWgKC84dkujlPG9n8Fv";
            string _accessToken = "2216257297-3Nzd3W3Qyl4lCqJU4GzhKsNxgjeVmVZZmmstMoo";
            string _accessTokenSecret = "ie903ODJe2mApqI9TLt73mnGoymv65FSZGGwm9tUJ5zJd";
            // In v1.1, all API calls require authentication
            var service = new TwitterService(_consumerKey, _consumerSecret);
            service.AuthenticateWith(_accessToken, _accessTokenSecret);

            try
            {
                var tweets = service.ListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions());
                foreach (var tweet in tweets)
                {
                    //Console.WriteLine("{0} says '{1}'", tweet.User.ScreenName, tweet.Text);
                    ListBoxItem item = new ListBoxItem();
                    item.Content = tweet.User.ScreenName + ": " + tweet.Text;
                    selectedtweets.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

    }
}
