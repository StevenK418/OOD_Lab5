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

namespace OOD_Lab5_Ex2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AdventureLiteEntities db = new AdventureLiteEntities();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Query DB for the customers
            var query = from o in db.SalesOrderHeaders
                orderby o.Customer.CompanyName
                select o.Customer.CompanyName;


            //Store the result
            var result = query.ToList();

            //Assign the result set as data source for the customers listbox
            LBXCustomers.ItemsSource = result.Distinct();
        }

        private void LBXCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LBXOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

     
    }
}
