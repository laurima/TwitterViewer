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
            BLTwitterViewer.authenticate();
            listFollowedUsers();
            listHomeLineTweets(); 
        }


        public void listHomeLineTweets()
        {
            List<Tweet> tweets = BLTwitterViewer.getUserTimeLine();
            if (tweets.Count > 0 && tweets != null)
            {
                try
                {
                    List<Tweet> items = new List<Tweet>();
                    foreach (Tweet tweet in tweets)
                    {
                        items.Add(tweet);
                        lw_selectedtweets.ItemsSource = items;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        public void listFollowedUsers()
        {
            List<User> users = BLTwitterViewer.getFollowedUsers();
            if (users.Count > 0 && users != null)
            {
                try
                {
                    lw_followedusers.ItemsSource = users;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btn_editcategories_Click(object sender, RoutedEventArgs e)
        {
            var testitem2 = "category";
            lb_categories.Items.Add(testitem2);
        }
    }

    internal class userListItem
    {
        public string userName { get; set; }
        public string userPic { get; set; }
    }
}
