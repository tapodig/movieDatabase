using Dapper;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace movieDatabase.Pages
{
    /// <summary>
    /// Interaction logic for InsertActor.xaml
    /// </summary>
    public partial class InsertActor : Page
    {
        public InsertActor()
        {
            InitializeComponent();
        }

        char ActorGender = 'M';

        private void tcActorGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tcActorGender.SelectedIndex == 0)
            {
                ActorGender = 'M';
            }
            else if (tcActorGender.SelectedIndex == 1)
            {
                ActorGender = 'F';
            }
            
        }

        private void btbeszur_Click(object sender, RoutedEventArgs e)
        {
            using (var connection = ConFactory.ConnFactory.GetOpenConnection())
            {
                
                connection.Query<UsersModel>("SET ANSI_WARNINGS OFF");
                connection.Query<UsersModel>("INSERT INTO Actor (act_fname, act_lname, act_gender) VALUES('" + tbActFname.Text + "','" + tbActLname.Text + "','"+ ActorGender + "')");
                MessageBox.Show("A rekord beszúrása megtörtént!");
            }
        }
    }
}
