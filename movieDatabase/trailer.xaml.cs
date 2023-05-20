using Microsoft.Identity.Client;
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
    /// Interaction logic for trailer.xaml
    /// </summary>
    public partial class trailer : Window
    {
        private string trailerString;
        public trailer(string trailerString)
        {

            this.trailerString = trailerString;
            InitializeComponent();
            string videoPath = "trailers/" + trailerString;
            
           // string executablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
          //  string projectPath = System.IO.Path.GetDirectoryName(executablePath);
           // string videoFullPath = System.IO.Path.Combine(projectPath, videoPath);

            string alkalmazasKonyvtar = AppDomain.CurrentDomain.BaseDirectory;
            string videofajlUtvonal = System.IO.Path.Combine(alkalmazasKonyvtar, videoPath);

            meTrailer.Source = new Uri(videofajlUtvonal, UriKind.Absolute);
        }
    }
}
