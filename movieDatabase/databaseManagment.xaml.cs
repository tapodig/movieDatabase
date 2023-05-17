using movieDatabase.Pages;
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

namespace movieDatabase
{
    /// <summary>
    /// Interaction logic for databaseManagment.xaml
    /// </summary>
    public partial class databaseManagment : Window
    {
        public databaseManagment()
        {
            InitializeComponent();
        }

        private void btInsetMovie_Click(object sender, RoutedEventArgs e)
        {
            frMain.NavigationService.Navigate(new InsertMovie());
        }

        private void btInsertActor_Click(object sender, RoutedEventArgs e)
        {
            frMain.NavigationService.Navigate(new InsertActor());
        }

        private void btInsertDirector_Click(object sender, RoutedEventArgs e)
        {
            frMain.NavigationService.Navigate(new InsertDirector());
        }

        private void btInsertGenres_Click(object sender, RoutedEventArgs e)
        {
            frMain.NavigationService.Navigate(new InsertGenres());
        }
    }
}
