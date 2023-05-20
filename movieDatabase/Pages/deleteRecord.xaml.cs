using Dapper;
using Filmadatbazis;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace movieDatabase.Pages
{
    /// <summary>
    /// Interaction logic for deleteRecord.xaml
    /// </summary>
    public partial class deleteRecord : Page
    {
        SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString);
        SqlDataAdapter adapter = new SqlDataAdapter();
        string queryString;
        string getMov_ID;
        string getAct_ID;
        string getDir_ID;
        string getGenres_ID;
        public deleteRecord()
        {
            InitializeComponent();
            
            connection.Open();
            //filmek
            queryString = "SELECT mov_id, mov_title FROM Movie";
            adapter = new SqlDataAdapter(queryString, connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            dgGridMovies.DataContext = dataSet.Tables[0];

            //rendezők
            queryString = "SELECT dir_id, dir_fname, dir_lname FROM Director";
            adapter = new SqlDataAdapter(queryString, connection);
            dataSet = new DataSet();
            adapter.Fill(dataSet);

            dgGridDirectors.DataContext = dataSet.Tables[0];
            
            //szinészek
            queryString = "SELECT act_id, act_fname, act_lname FROM Actor";
            adapter = new SqlDataAdapter(queryString, connection);
            dataSet = new DataSet();
            adapter.Fill(dataSet);

            dgGridActors.DataContext = dataSet.Tables[0];

            //Műfajok
            queryString = "SELECT gen_id, gen_title FROM Genres";
            adapter = new SqlDataAdapter(queryString, connection);
            dataSet = new DataSet();
            adapter.Fill(dataSet);

            dgGridGenres.DataContext = dataSet.Tables[0];
            connection.Close();
        }


        private void tcdgSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (tcdgSelector.SelectedIndex)
            {
                case 0:
                    dgGridMovies.Visibility = Visibility.Visible;
                    dgGridActors.Visibility = Visibility.Hidden;
                    dgGridDirectors.Visibility = Visibility.Hidden;
                    dgGridGenres.Visibility = Visibility.Hidden;
                    break;

                case 1:
                    dgGridMovies.Visibility = Visibility.Hidden;
                    dgGridActors.Visibility = Visibility.Visible;
                    dgGridDirectors.Visibility = Visibility.Hidden;
                    dgGridGenres.Visibility = Visibility.Hidden;
                break;

                case 2:
                    dgGridMovies.Visibility = Visibility.Hidden;
                    dgGridActors.Visibility = Visibility.Hidden;
                    dgGridDirectors.Visibility = Visibility.Visible;
                    dgGridGenres.Visibility = Visibility.Hidden;
                break;

            case 3:
                    dgGridMovies.Visibility = Visibility.Hidden;
                    dgGridActors.Visibility = Visibility.Hidden;
                    dgGridDirectors.Visibility = Visibility.Hidden;
                    dgGridGenres.Visibility = Visibility.Visible;
                break;

            default:
                    break;
            }
        }

        private void dgGridMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cellInfos = dgGridMovies.SelectedCells;

            var list1 = new List<string>();
            foreach (DataGridCellInfo cellInfo in cellInfos)
            {
                if (cellInfo.IsValid)
                {
                    //GetCellContent returns FrameworkElement
                    var content = cellInfo.Column.GetCellContent(cellInfo.Item);

                    if (content != null)
                    {
                        var row = (DataRowView)content.DataContext;

                        //ItemArray returns an object array with single element
                        object[] obj = row.Row.ItemArray;

                        //store the obj array in a list or Arraylist for later use
                        list1.Add(obj[0].ToString());
                        getMov_ID = list1[0];
                    }
                }


            }

        }

        private void dgGridActors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cellInfos = dgGridActors.SelectedCells;

            var list1 = new List<string>();
            foreach (DataGridCellInfo cellInfo in cellInfos)
            {
                if (cellInfo.IsValid)
                {
                    //GetCellContent returns FrameworkElement
                    var content = cellInfo.Column.GetCellContent(cellInfo.Item);

                    if (content != null)
                    {
                        var row = (DataRowView)content.DataContext;

                        //ItemArray returns an object array with single element
                        object[] obj = row.Row.ItemArray;

                        //store the obj array in a list or Arraylist for later use
                        list1.Add(obj[0].ToString());
                        getAct_ID = list1[0];
                    }
                }


            }
        }

        private void dgGridDirectors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cellInfos = dgGridDirectors.SelectedCells;

            var list1 = new List<string>();

            foreach (DataGridCellInfo cellInfo in cellInfos)
            {
                if (cellInfo.IsValid)
                {
                    //GetCellContent returns FrameworkElement
                    var content = cellInfo.Column.GetCellContent(cellInfo.Item);

                    if (content != null)
                    {
                        var row = (DataRowView)content.DataContext;

                        //ItemArray returns an object array with single element
                        object[] obj = row.Row.ItemArray;

                        //store the obj array in a list or Arraylist for later use
                        list1.Add(obj[0].ToString());
                        getDir_ID = list1[0];
                    }
                }
            }
        }

        private void dgGridGenres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cellInfos = dgGridGenres.SelectedCells;

            var list1 = new List<string>();

            foreach (DataGridCellInfo cellInfo in cellInfos)
            {
                if (cellInfo.IsValid)
                {
                    //GetCellContent returns FrameworkElement
                    var content = cellInfo.Column.GetCellContent(cellInfo.Item);

                    if (content != null)
                    {
                        var row = (DataRowView)content.DataContext;

                        //ItemArray returns an object array with single element
                        object[] obj = row.Row.ItemArray;

                        //store the obj array in a list or Arraylist for later use
                        list1.Add(obj[0].ToString());
                        getGenres_ID = list1[0];
                    }
                }
            }
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            switch (tcdgSelector.SelectedIndex)
            {
                case 0: //filmek
                    using (var connection = ConFactory.ConnFactory.GetOpenConnection())
                    {

                        connection.Query<enMovie_Cast>("DELETE FROM Movie_Cast WHERE mov_id = '" + getMov_ID + "'");
                        connection.Query<enMovie_Direction>("DELETE FROM Movie_Direction WHERE mov_id = '" + getMov_ID + "'");
                        connection.Query<enMovie_Genres>("DELETE FROM Movie_Genres WHERE mov_id = '" + getMov_ID + "'");
                        connection.Query<enMovie>("DELETE FROM Movie WHERE mov_id = '" + getMov_ID + "'");
                        MessageBox.Show("A film törlése megtörtént! A hozzárendelések törölve!");
                        
                    }
                    queryString = "SELECT mov_id, mov_title FROM Movie";
                    connection.Open();
                    adapter = new SqlDataAdapter(queryString, connection);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    dgGridMovies.DataContext = dataSet.Tables[0];
                    break;
                case 1: //szinészek
                    using (var connection = ConFactory.ConnFactory.GetOpenConnection())
                    {
                        try
                        {
                            connection.Query<enActor>("DELETE FROM Actor WHERE act_id = '" + getAct_ID + "'");
                            MessageBox.Show("A színész sikeresen törölve lett az adatbázisból!");
                        }
                        catch (Microsoft.Data.SqlClient.SqlException)
                        {

                            MessageBox.Show("A színész törlése nem sikerült! Kérjük ellenőrizze, hogy a rekord nincs-e hozzárendelve egy vagy több filmhez!");
                        }
                        
                    }
                    queryString = "SELECT act_id, act_fname, act_lname FROM Actor";
                    adapter = new SqlDataAdapter(queryString, connection);
                    dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    dgGridActors.DataContext = dataSet.Tables[0];

                    break;
                case 2:
                    //rendezők
                    using (var connection = ConFactory.ConnFactory.GetOpenConnection())
                    {
                        try
                        {
                            connection.Query<enDirector>("DELETE FROM Director WHERE dir_id = '" + getDir_ID + "'");
                            MessageBox.Show("A rendező sikeresen törölve lett az adatbázisból!");
                        }
                        catch (Microsoft.Data.SqlClient.SqlException)
                        {

                            MessageBox.Show("A rendező törlése nem sikerült! Kérjük ellenőrizze, hogy a rekord nincs-e hozzárendelve egy vagy több filmhez!");
                        }

                    }
                    queryString = "SELECT dir_id, dir_fname, dir_lname FROM Director";
                    adapter = new SqlDataAdapter(queryString, connection);
                    dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    dgGridDirectors.DataContext = dataSet.Tables[0];
                    break;
                case 3:
                    //Műfajok
                    using (var connection = ConFactory.ConnFactory.GetOpenConnection())
                    {
                        try
                        {
                            connection.Query<enGenres>("DELETE FROM Genres WHERE gen_id = '" + getGenres_ID + "'");
                            MessageBox.Show("A műfaj sikeresen törölve lett az adatbázisból!");
                        }
                        catch (Microsoft.Data.SqlClient.SqlException)
                        {

                            MessageBox.Show("A műfaj törlése nem sikerült! Kérjük ellenőrizze, hogy a rekord nincs-e hozzárendelve egy vagy több filmhez!");
                        }

                    }

                    queryString = "SELECT gen_id, gen_title FROM Genres";
                    adapter = new SqlDataAdapter(queryString, connection);
                    dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    dgGridGenres.DataContext = dataSet.Tables[0];
                    connection.Close();
                    break;
                default:
                    break;
            }
        }
    }
}
