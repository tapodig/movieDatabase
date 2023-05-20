using Dapper;
using Filmadatbazis;
using Microsoft.Win32;
using movieDatabase.Model;
using System;
using System.Collections.Generic;
using System.IO;
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


namespace movieDatabase.Pages
{
    /// <summary>
    /// Interaction logic for InsertMovie.xaml
    /// </summary>
    public partial class InsertMovie : Page
    {
        private string selectedFilePath; // A kiválasztott fájl elérési útja
        private string fileName;
        public InsertMovie()
        {
            InitializeComponent();
        }

        private void btInsertMovie_Click(object sender, RoutedEventArgs e)
        {
            using (var connection = ConFactory.ConnFactory.GetOpenConnection())
            {

              
                
                var insert = connection.Query<enMovie>("INSERT INTO Movie (mov_title,mov_description,move_year,mov_time,mov_lang,mov_dt_rel,mov_rel_country,mov_trailer,mov_pic) VALUES ('" + tbMovieTitle.Text + "','" + tbMovieDesc.Text + "','" + tbMovieYear.Text + "','" + tbMovieLong.Text + "','" + tbMovieLang.Text + "','" + dpMovieDtRel.Text + "','" + tbMovieRelCountry.Text + "','" + fileName + "','" + tbMoviPic.Text + "')");
                MessageBox.Show("A rekord beszúrása megtörtént!");

            }
        }

        private void btFileBrowser_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP4 fájlok (*.mp4)|*.mp4";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                selectedFilePath = openFileDialog.FileName;

                // Fájl áthelyezése a "trailer" mappába
                string destinationFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "trailers");
                string destinationPath = Path.Combine(destinationFolder, Path.GetFileName(selectedFilePath));
                Directory.CreateDirectory(destinationFolder);
                File.Copy(selectedFilePath, destinationPath, true);

                // A fájl nevének lementése a string változóba
                fileName = Path.GetFileName(selectedFilePath);
            }
        }
    }
}
