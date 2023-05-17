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
    /// Interaction logic for InsertMovie.xaml
    /// </summary>
    public partial class InsertMovie : Page
    {
        public InsertMovie()
        {
            InitializeComponent();
        }

        private void btInsertMovie_Click(object sender, RoutedEventArgs e)
        {
            using (var connection = ConFactory.ConnFactory.GetOpenConnection())
            {
                var movieTitle = tbMovieTitle.Text;
                var movieDesc = tbMovieDesc.Text;
                var movieYear = tbMovieYear.Text;
                var movieLong = tbMovieLong.Text;
                var movieLang = tbMovieLang.Text;
                var movieDtRel = dpMovieDtRel.Text;
                
                var movieRelCountry = tbMovieRelCountry.Text;
                var movieTrailer = tbMobieTrailer.Text;
                var moviePic = tbMoviPic.Text;
                
                var insert = connection.Query<UsersModel>("INSERT INTO Movie (mov_title,mov_description,move_year,mov_time,mov_lang,mov_dt_rel,mov_rel_country,mov_trailer,mov_pic) VALUES ('" + tbMovieTitle.Text + "','" + tbMovieDesc.Text + "','" + tbMovieYear.Text + "','" + tbMovieLong.Text + "','" + tbMovieLang.Text + "','" + dpMovieDtRel.Text + "','" + tbMovieRelCountry.Text + "','" + tbMobieTrailer.Text + "','" + tbMoviPic.Text + "')");
                MessageBox.Show("A rekord beszúrása megtörtént!");

            }
        }
    }
}
