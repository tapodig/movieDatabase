using Dapper;
using Filmadatbazis;
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
    /// Interaction logic for InsertGenres.xaml
    /// </summary>
    public partial class InsertGenres : Page
    {
        public InsertGenres()
        {
            InitializeComponent();
        }

        private void btInsert_Click(object sender, RoutedEventArgs e)
        {
            using (var connection = ConFactory.ConnFactory.GetOpenConnection())
            {

                connection.Query<enGenres>("INSERT INTO Genres (gen_title) VALUES('" + tbInsertGenres.Text +"')");
                MessageBox.Show("A rekord beszúrása megtörtént!");
            }
        }
    }
}
