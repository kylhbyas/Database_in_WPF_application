using Database.Database11DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Database11ConnectionString
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Database11.accdb");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create a query string
            string query = "select* from Assets";

            // Create a Command
            OleDbCommand cmd = new OleDbCommand(query, cn);

            // Connect to the DB
            cn.Open();

            // Create a reader to read the result
            OleDbDataReader read = cmd.ExecuteReader();

            // Create a holder strings
            string col0 = "";
            string col1 = "";
            string sum = "";

            // Loop over the results of your database call
            while (read.Read())
            {
                col0 += read[0].ToString() + "\t";
                col1 += read[1].ToString() + "\t";
            }

            cn.Close();

            TextArea.Text = col0 + "\n" + col1;
        }

        OleDbConnection cn;

        private void EmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a query string
            string query = "select* from Employees";

            // Create a Command
            OleDbCommand cmd = new OleDbCommand(query, cn);

            // Connect to the DB
            cn.Open();

            // Create a reader to read the result
            OleDbDataReader read = cmd.ExecuteReader();

            // Create a holder strings
            string col0 = "";
            string col1 = "";
            string col2 = "";
            string sum = "";
            string total = "";

            // Loop over the results of your database call
            while (read.Read())
            {
                col0 += read[0].ToString() + "\t";
                col1 += read[1].ToString() + "\t";
                col2 += read[2].ToString() + "\t";
            }

            cn.Close();

            EmployeeArea1.Text = col0 + "\n" + col1 + "\n" + col2;
        }
    }
}
