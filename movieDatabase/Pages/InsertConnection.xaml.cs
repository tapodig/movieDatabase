using Dapper;
using Filmadatbazis;
using Microsoft.Data.SqlClient;
using movieDatabase.Model;
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

namespace movieDatabase.Pages
{
    /// <summary>
    /// Interaction logic for InsertConnection.xaml
    /// </summary>
    public partial class InsertConnection : Page
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=movieDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        string getMov_ID = "";
        string getAct_ID = "";
        string getDir_ID;
        string getGenres_ID;
        // cnFilmadatbazis.Filmadatbazis _context;
        public InsertConnection()
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            //filmek
            string queryString = "SELECT mov_id, mov_title FROM Movie";
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            dgGridMovies.DataContext = dataSet.Tables[0];

            //szinészek
            queryString = "SELECT dir_id, dir_fname, dir_lname FROM Director";
            adapter = new SqlDataAdapter(queryString, connection);
            dataSet = new DataSet();
            adapter.Fill(dataSet);

            dgGridDirectors.DataContext = dataSet.Tables[0];

            //rendezők
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
        //Hozzárendelést végző gomb
        private void btnInsert_Click(object sender, RoutedEventArgs e) 
        {
            switch (tcdgSelector.SelectedIndex)
            {
                case 0:
                    if (tbRole.Text != "" || tbRole.Text != null)
                    {


                        using (var connection = ConFactory.ConnFactory.GetOpenConnection())
                        {

                            connection.Query<enMovie_Cast>("INSERT INTO Movie_Cast (act_id, mov_id, role) VALUES('" + getAct_ID + "','" + getMov_ID + "','" + tbRole.Text + "')");
                            MessageBox.Show("A szinész hozzárendelése megtörtént!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Töltse ki a szerep mezőt!");
                    }
                    break;
                case 1:
                    using (var connection = ConFactory.ConnFactory.GetOpenConnection())
                    {
                       

                        connection.Query<enMovie_Direction>("INSERT INTO Movie_Direction (dir_id, mov_id) VALUES('" + getDir_ID + "','" + getMov_ID + "')");
                        MessageBox.Show("A rendező hozzárendelése megtörtént!");
                    }
                    break;
                case 2:
                    using (var connection = ConFactory.ConnFactory.GetOpenConnection())
                    {


                        connection.Query<enMovie_Genres>("INSERT INTO Movie_Genres (mov_id, gen_id) VALUES('" + getMov_ID + "','" + getGenres_ID + "')");
                        MessageBox.Show("A műfaj hozzárendelése megtörtént!");
                    }
                    break;
                default:
                    break;
            }
            
        }

        //Elkéri az id-t kijelőlt elemtől a movie táblában.
        private void dgGridMovies_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
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


        //Mely táblja jelenjen meg a jobb oldalt
        private void tcdgSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (tcdgSelector.SelectedIndex)
            {
                case 0:
                    dgGridActors.Visibility = Visibility.Visible;
                    llRole.Visibility = Visibility.Visible;
                    tbRole.Visibility = Visibility.Visible;
                    dgGridDirectors.Visibility = Visibility.Hidden;
                    dgGridGenres.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    dgGridActors.Visibility = Visibility.Hidden;
                    llRole.Visibility = Visibility.Hidden;
                    tbRole.Visibility = Visibility.Hidden;
                    dgGridDirectors.Visibility = Visibility.Visible;
                    dgGridGenres.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    dgGridActors.Visibility = Visibility.Hidden;
                    llRole.Visibility = Visibility.Hidden;
                    tbRole.Visibility = Visibility.Hidden;
                    dgGridDirectors.Visibility = Visibility.Hidden;
                    dgGridGenres.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }

        
    }
}
