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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            BLTwitterViewer.OauthRequest();
        }

        private void btn_openAuthUrl_Click(object sender, RoutedEventArgs e)
        {
            BLTwitterViewer.openAuthorizationUrl();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            
            BLTwitterViewer.OauthAccess(tb_pincode.Text);

            if (BLTwitterViewer.authenticate())
            {
                Mouse.OverrideCursor = Cursors.Wait;
                MainWindow main = new MainWindow();
                App.Current.MainWindow = main;
                this.Close();
                main.Show();
            }
            else
            {
                MessageBox.Show("Pincode was invalid. Please try again with new pincode.");
            }

            
        }
    }
}
