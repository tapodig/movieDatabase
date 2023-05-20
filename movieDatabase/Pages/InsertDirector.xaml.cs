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
    /// Interaction logic for InsertDirector.xaml
    /// </summary>
    public partial class InsertDirector : Page
    {
        public InsertDirector()
        {
            InitializeComponent();
        }

        private void btInsert_Click(object sender, RoutedEventArgs e)
        {
            using (var connection = ConFactory.ConnFactory.GetOpenConnection())
            {
                var check = connection.Query<enDirector>("select * from Director where dir_fname = '" + tbDirFname.Text + "' and  dir_lname='" + tbDirLname.Text + "'");
                var _currentDirector = check.FirstOrDefault(u => u.dir_fname == tbDirFname.Text.ToString());
                if (_currentDirector == null) 
                {
                    connection.Query<enDirector>("INSERT INTO Director (dir_fname, dir_lname) VALUES('" + tbDirFname.Text + "','" + tbDirLname.Text + "')");
                    MessageBox.Show("A rekord beszúrása megtörtént!");
                }
                else
                {
                    MessageBox.Show("A rendező már szerepel az adatbázisban!");
                }
                
            }
        }
    }
}
