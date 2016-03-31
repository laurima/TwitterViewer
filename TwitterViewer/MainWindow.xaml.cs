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
            createListViewColumns();
            listHomeLineTweets();
            listFollowedUsers();
        }

        public void createListViewColumns()
        {   //Add columns to userlisting
            var gridView = new GridView();
            this.lw_followedusers.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                DisplayMemberBinding = new Binding("userPic")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                DisplayMemberBinding = new Binding("userName")
            });

            this.lw_followedusers.Items.Add(new userListItem { userPic = "https://twitter.com/isaach/profile_image?size=original", userName = "David" });
        }

        public void listHomeLineTweets()
        {
            List<Tweet> tweets = BLTwitterViewer.getUserTimeLine();
            if (tweets.Count > 0 && tweets != null)
            {
                try
                {
                    foreach (Tweet tweet in tweets)
                    {

                        ListBoxItem item = new ListBoxItem();
                        item.Content = tweet.ToString();
                        lw_selectedtweets.Items.Add(item);

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
            List<string> users = BLTwitterViewer.getFollowedUsers();
            if (users.Count > 0 && users != null)
            {
                try
                {
                    foreach (var user in users)
                    {
                        ListBoxItem item = new ListBoxItem();
                        item.Content = user;
                        lw_followedusers.Items.Add(item);
                    }
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
