using movieDatabase.Model;
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
using movieDatabase.ConFactory;
using Dapper;

namespace movieDatabase
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            using (var connection = ConFactory.ConnFactory.GetOpenConnection())
            {
                var users = connection.Query<UsersModel>("select * from [Users] where Active = 1");

                var _currentUser = users.FirstOrDefault(u => u.UserName == tbUser.Text.ToString());

                if (_currentUser != null)
                {
                    try
                    {
                        databaseManagment databasemanagment = new databaseManagment();
                        databasemanagment.Show();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Invalid ex " + ex.Message);
                    }
                }


            }
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
