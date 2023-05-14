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

namespace movieDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=movieDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        cnFilmadatbazis.Filmadatbazis _context;

        public MainWindow()
        {
            
            InitializeComponent();
            _context = new cnFilmadatbazis.Filmadatbazis();
        }


        private void keresoGomb_Click(object sender, RoutedEventArgs e)
        {
           //filmek listázása a keresés követően
           SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            // string queryString = "SELECT * FROM Movie WHERE mov_title like \'Csúcsformában\'";
            string queryString = "SELECT mov_title FROM Movie WHERE mov_title like \'%" + kereso.Text + "%\'";

           // SqlCommand command = new SqlCommand(queryString, connection);

            
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            dgGrid.DataContext = dataSet.Tables[0];
           // reader.Close();

            connection.Close();
        }

        private void dgGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
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
                            string queryStringForIMG = "SELECT mov_pic FROM Movie WHERE mov_title like \'" + list1[0] + "\'";
                            


                            SqlCommand mov_picture = new SqlCommand(queryStringForIMG, connection);
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
                            string queryStringforDesc = "SELECT mov_description FROM Movie WHERE mov_title like \'" + list1[0] + "\'";
                            SqlCommand mov_description = new SqlCommand(queryStringforDesc, connection);
                            result = mov_description.ExecuteScalar();
                            string descriptionString = result.ToString();
                            description.Text = descriptionString;

                            //Évjárat
                            string queryStringforYear = "SELECT move_year FROM Movie WHERE mov_title like \'" + list1[0] + "\'";
                            SqlCommand mov_year = new SqlCommand(queryStringforYear, connection); 
                            result = mov_year.ExecuteScalar();
                            string yearString = result.ToString();
                            year.Text = "Évjárat: " + yearString;

                            //Perc
                            string queryStringforMovTime = "SELECT mov_time FROM Movie WHERE mov_title like \'" + list1[0] + "\'";
                            SqlCommand mov_time = new SqlCommand(queryStringforMovTime, connection);
                            result = mov_time.ExecuteScalar();
                            string timeString = result.ToString();
                            time.Text = "Időtartam: " + timeString + " perc";

                            //eredeti nyelv
                            string queryStringforMovLang = "SELECT mov_lang FROM Movie WHERE mov_title like \'" + list1[0] + "\'";
                            SqlCommand mov_lang = new SqlCommand(queryStringforMovLang, connection);
                            result = mov_lang.ExecuteScalar();
                            string langString = result.ToString();
                            language.Text = "Eredeti nyelv: " + langString;

                            //Rendező
                                //fname
                            string queryStringforDirectorFname = "SELECT dir_fname " +
                                "FROM (director INNER JOIN movie_direction ON director.dir_id = movie_direction.dir_id) INNER JOIN Movie ON movie_direction.mov_id = Movie.mov_id " +
                                "WHERE mov_title like \'" + list1[0] + "\'";
                            SqlCommand getDirectorFname = new SqlCommand(queryStringforDirectorFname, connection);
                            result = getDirectorFname.ExecuteScalar();
                            string directorFnameString = result.ToString();

                                   //lname
                            string queryStringforDirectorLname = "SELECT dir_lname " +
                            "FROM (director INNER JOIN movie_direction ON director.dir_id = movie_direction.dir_id) INNER JOIN Movie ON movie_direction.mov_id = Movie.mov_id " +
                            "WHERE mov_title like \'" + list1[0] + "\'";
                            SqlCommand getDirectorLname = new SqlCommand(queryStringforDirectorLname, connection);
                            result = getDirectorLname.ExecuteScalar();
                            string directorLnameString = result.ToString();


                            director.Text = "Rendező: " + directorFnameString + " " + directorLnameString;

                            //Szereplők
                            string queryStringforMovActors = "SELECT act_fname, act_lname, role " +
                                "FROM (Actor INNER JOIN Movie_cast ON Actor.act_id = Movie_cast.act_id) INNER JOIN Movie ON Movie_cast.mov_id = Movie.mov_id " +
                                "WHERE mov_title like \'" + list1[0] + "\'";

                            SqlDataAdapter adapter2 = new SqlDataAdapter(queryStringforMovActors, connection);
                            DataSet dataSet2 = new DataSet();
                            adapter2.Fill(dataSet2);

                            dgGridActors.DataContext = dataSet2.Tables[0];


                            //Műfaj
                            string queryStringforGen = "SELECT gen_title " +
                                "FROM (genres INNER JOIN movie_genres ON genres.gen_id = movie_genres.gen_id) INNER JOIN Movie ON movie_genres.mov_id = Movie.mov_id " +
                                "WHERE mov_title like \'" + list1[0] + "\'";

                            SqlDataAdapter adapter3 = new SqlDataAdapter(queryStringforGen, connection);
                            DataSet dataSet3 = new DataSet();
                            adapter3.Fill(dataSet3);
                            dgGridGenres.DataContext = dataSet3.Tables[0];

                            connection.Close();

                            

                            //trailer
                            trailer.Source = new Uri("pack://application:,,,/trailer/Csucsformaban.mp4", UriKind.Absolute);
                            trailer.Play();

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
    }
}

