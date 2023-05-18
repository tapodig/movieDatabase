﻿using Dapper;
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
            queryString = "SELECT act_id, act_fname, act_lname FROM Actor";
            adapter = new SqlDataAdapter(queryString, connection);
            dataSet = new DataSet();
            adapter.Fill(dataSet);

            dgGridActors.DataContext = dataSet.Tables[0];
            // reader.Close();

            connection.Close();

        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            if (tbRole.Text != "" || tbRole.Text !=null)
            {
                //SqlConnection connection = new SqlConnection(connectionString);
                
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    //connection.Query<UsersModel>("SET ANSI_WARNINGS OFF");
                    
                    connection.Query<UsersModel>("INSERT INTO Movie_Cast (act_id, mov_id, role) VALUES('"+ getAct_ID + "','" + getMov_ID+ "','"+tbRole.Text + "')");
                    MessageBox.Show("Hozzárendelés megtörtént!");
                }
            } else 
            {
                MessageBox.Show("Töltse ki a szerep mezőt!");
            }
        }

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
    }
}
