using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace TwitterViewer
{
    /// <summary>
    /// Interaction logic for categoriesEditWindow.xaml
    /// </summary>
    public partial class categoriesEditWindow : Window
    {
        public categoriesEditWindow()
        {
            InitializeComponent();
            iniMyStuff();
        }

        private void iniMyStuff()
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

            listCategories();
        }

        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_addcategory_Click(object sender, RoutedEventArgs e)
        {
            string category = tb_addcategory.Text;
            BLTwitterViewer.addCategory(category);
            listCategories();
        }

        private void lw_categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string category = lw_categories.SelectedItem.ToString();
                listUsersInCategory(category);
            }
            catch (Exception)
            {
               
            }          
        }

        public void listCategories()
        {
            lw_categories.ItemsSource = BLTwitterViewer.getCategories();
        }

        private void listUsersInCategory(string category)
        {
            lw_usersincategory.ItemsSource = BLTwitterViewer.getUsersByCategory(category);
        }

        private void btn_removecategory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string category = lw_categories.SelectedItem.ToString();
                BLTwitterViewer.removeCategory(category);
                listCategories();
            }
            catch (Exception)
            {

                MessageBox.Show("Deletion of the category failed");
            }
        }

        private void btn_addusertocategory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string category = lw_categories.SelectedItem.ToString();
                User user = new User(lw_followedusers.SelectedItem.ToString().Split()[1]);
                BLTwitterViewer.addUserToCategory(category, user);
                listUsersInCategory(category);
            }
            catch (Exception)
            {

                MessageBox.Show("Please select user and category.");
            }
        }

        private void btn_deluserfromcategory_Click(object sender, RoutedEventArgs e)
        {
            string category = lw_categories.SelectedItem.ToString();
            User user = new User(lw_usersincategory.SelectedItem.ToString().Split()[1]);
            BLTwitterViewer.delUserFromCategory(category, user);
            listUsersInCategory(category);
        }
    }
}
