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
    /// Interaction logic for InsertConnection.xaml
    /// </summary>
    public partial class InsertConnection : Page
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=movieDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        cnFilmadatbazis.Filmadatbazis _context;
        public InsertConnection()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            using (var connection = ConFactory.ConnFactory.GetOpenConnection())
               {            
                    connection.Query<UsersModel>("SET ANSI_WARNINGS OFF");
                  //  connection.Query<UsersModel>("INSERT INTO Actor (act_fname, act_lname, act_gender) VALUES('" +  + "','" +  + "','"+  + "')");
               }
        }

    }
}
