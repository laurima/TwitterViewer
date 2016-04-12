using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
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
using System.Xml.Linq;

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
            //BLTwitterViewer.testauthenticate();
            TwitterViewer.Properties.Settings.Default.FollowedUsersJSON = System.IO.Path.GetTempPath() + "\\FollowedUsers.json";
            BLTwitterViewer.updateFollowedUsersJson();
            listFollowedUsers();
            listHomeLineTweets();
<<<<<<< HEAD
            showCategories();
            
=======
            DBTwitterViewer.ReadCategoriesXML();
            listCategories();
>>>>>>> origin/master
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        public void showCategories()
        {
<<<<<<< HEAD
            BLTwitterViewer.getCategories();
=======
           // xe = XElement.Load();
>>>>>>> origin/master
        }

        public void listHomeLineTweets()
        {
            List<Tweet> tweets = BLTwitterViewer.getUserTimeLine();
            if (tweets.Count > 0 && tweets != null)
            {
                try
                {
                    lw_selectedtweets.ItemsSource = tweets;
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
            categoriesEditWindow editWindow = new categoriesEditWindow();
            editWindow.Show();
        }

        private void lw_followedusers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string user = lw_followedusers.SelectedItem.ToString().Split()[1];

            lw_selectedtweets.ItemsSource = null;

            List<Tweet> tweets = BLTwitterViewer.getTweets(user);
            if (tweets.Count > 0 && tweets != null)
            {
                try
                {
                    lw_selectedtweets.ItemsSource = tweets;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btn_showtimeline_Click(object sender, RoutedEventArgs e)
        {
            listHomeLineTweets();
        }

        private void btn_updatefollowesusers_Click(object sender, RoutedEventArgs e)
        {
            BLTwitterViewer.updateFollowedUsersJson();
            listFollowedUsers();
        }
    }
}
