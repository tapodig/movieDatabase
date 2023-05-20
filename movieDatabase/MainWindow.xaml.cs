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
using cnFilmadatbazis;
using Filmadatbazis;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Controls;
using Dapper;

namespace movieDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string trailerString;
        cnFilmadatbazis.Filmadatbazis _context;

        public MainWindow()
        {
            
            InitializeComponent();
            _context = new cnFilmadatbazis.Filmadatbazis();
        }


        private void keresoGomb_Click(object sender, RoutedEventArgs e)
        {
           /* using (var connection2 = ConFactory.ConnFactory.GetOpenConnection())
            {
                connection2.Query<UsersModel>("SELECT mov_title FROM Movie WHERE mov_title like \'%" + kereso.Text + "%\'");
            }*/
            
            //filmek listázása a keresés követően
                SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString);
            connection.Open();

            // string queryString = "SELECT * FROM Movie WHERE mov_title like \'Csúcsformában\'";
            string queryString = "SELECT mov_title FROM Movie WHERE mov_title like \'%" + kereso.Text + "%\'";
          
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            dgGrid.DataContext = dataSet.Tables[0];

            connection.Close();
        }

        private void dgGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btViewTrailer.Visibility = Visibility.Visible;
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString);
            connection.Open();

            //

            var cellInfos = dgGrid.SelectedCells;

            var list1 = new List<string>();

            foreach (DataGridCellInfo cellInfo in cellInfos)
            {
                if (cellInfo.IsValid)
                {
                    //GetCellContent returns FrameworkElement
                    var content = cellInfo.Column.GetCellContent(cellInfo.Item);

                    //Need to add the extra lines of code below to get desired output

                    //get the datacontext from FrameworkElement and typecast to DataRowView
                    if (content != null)
                    {
                        try
                        {
                            var row = (DataRowView)content.DataContext;

                            //ItemArray returns an object array with single element
                            object[] obj = row.Row.ItemArray;

                            //store the obj array in a list or Arraylist for later use
                            list1.Add(obj[0].ToString());

                            //kép lekérése
                            string queryString = "SELECT mov_pic FROM Movie WHERE mov_title like \'" + list1[0] + "\'";
                            
                            SqlCommand mov_picture = new SqlCommand(queryString, connection);
                            object result = mov_picture.ExecuteScalar();
                            string cover_image_source = result.ToString();
                            BitmapImage bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.UriSource = new Uri(cover_image_source);
                            bitmap.EndInit();
                            cover_image.Source = bitmap;
                           
                            

                            //cím
                            title.FontSize = 30;
                            title.Text = list1[0];
                            //Leírás
                            queryString = "SELECT mov_description FROM Movie WHERE mov_title like \'" + list1[0] + "\'";
                            SqlCommand mov_description = new SqlCommand(queryString, connection);
                            result = mov_description.ExecuteScalar();
                            string descriptionString = result.ToString();
                            description.Text = descriptionString;

                            //Évjárat
                            queryString = "SELECT move_year FROM Movie WHERE mov_title like \'" + list1[0] + "\'";
                            SqlCommand mov_year = new SqlCommand(queryString, connection); 
                            result = mov_year.ExecuteScalar();
                            string yearString = result.ToString();
                            year.Text = "Évjárat: " + yearString;

                            //Perc
                            queryString = "SELECT mov_time FROM Movie WHERE mov_title like \'" + list1[0] + "\'";
                            SqlCommand mov_time = new SqlCommand(queryString, connection);
                            result = mov_time.ExecuteScalar();
                            string timeString = result.ToString();
                            time.Text = "Időtartam: " + timeString + " perc";

                            //eredeti nyelv
                            queryString = "SELECT mov_lang FROM Movie WHERE mov_title like \'" + list1[0] + "\'";
                            SqlCommand mov_lang = new SqlCommand(queryString, connection);
                            result = mov_lang.ExecuteScalar();
                            string langString = result.ToString();
                            language.Text = "Eredeti nyelv: " + langString;

                            //Rendező
                            //fname
                            queryString = "SELECT dir_fname " +
                                "FROM (director INNER JOIN movie_direction ON director.dir_id = movie_direction.dir_id) INNER JOIN Movie ON movie_direction.mov_id = Movie.mov_id " +
                                "WHERE mov_title like \'" + list1[0] + "\'";
                            SqlCommand getDirectorFname = new SqlCommand(queryString, connection);
                            result = getDirectorFname.ExecuteScalar();
                            string directorFnameString = result.ToString();

                            //lname
                            queryString = "SELECT dir_lname " +
                            "FROM (director INNER JOIN movie_direction ON director.dir_id = movie_direction.dir_id) INNER JOIN Movie ON movie_direction.mov_id = Movie.mov_id " +
                            "WHERE mov_title like \'" + list1[0] + "\'";
                            SqlCommand getDirectorLname = new SqlCommand(queryString, connection);
                            result = getDirectorLname.ExecuteScalar();
                            string directorLnameString = result.ToString();


                            director.Text = "Rendező: " + directorFnameString + " " + directorLnameString;

                            //Szereplők
                            queryString = "SELECT act_fname, act_lname, role " +
                                "FROM (Actor INNER JOIN Movie_cast ON Actor.act_id = Movie_cast.act_id) INNER JOIN Movie ON Movie_cast.mov_id = Movie.mov_id " +
                                "WHERE mov_title like \'" + list1[0] + "\'";

                            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                            DataSet dataSet = new DataSet();
                            adapter.Fill(dataSet);

                            dgGridActors.DataContext = dataSet.Tables[0];


                            //Műfaj
                            queryString = "SELECT gen_title " +
                                "FROM (genres INNER JOIN movie_genres ON genres.gen_id = movie_genres.gen_id) INNER JOIN Movie ON movie_genres.mov_id = Movie.mov_id " +
                                "WHERE mov_title like \'" + list1[0] + "\'";

                            adapter = new SqlDataAdapter(queryString, connection);
                            dataSet = new DataSet();
                            adapter.Fill(dataSet);
                            dgGridGenres.DataContext = dataSet.Tables[0];

                            //Trailer
                            queryString = "SELECT mov_trailer FROM Movie WHERE mov_title like \'" + list1[0] + "\'";
                            SqlCommand getTrailer = new SqlCommand(queryString, connection);
                            result = getTrailer.ExecuteScalar();
                            trailerString = result.ToString();
                            connection.Close();

                            

                            
                            

                        }
                        catch (InvalidCastException)
                        {

                            MessageBox.Show("HIBA");
                        }

                        
                    }
                   
                    
                    
                }
            }






            //
            
            
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btAbout_Click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
        }

        private void btViewTrailer_Click(object sender, RoutedEventArgs e)
        {
            
            trailer trailer = new trailer(trailerString);
            trailer.Show();
        }
    }
}

