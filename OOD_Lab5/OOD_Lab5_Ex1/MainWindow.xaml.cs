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

namespace OOD_Lab5_Ex1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static NORTHWNDEntities db = new NORTHWNDEntities();
        public enum StockLevel
        {
            Low,
            Normal,
            Overstocked
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Populate stocklevel listbox
            LBXStock.ItemsSource = Enum.GetNames(typeof(MainWindow.StockLevel));

            //Populate the suppliers listbox via an anonymous type
            var query1 = 
                from s in db.Suppliers
                orderby s.CompanyName
                select new
                {
                    supplierName = s.CompanyName,
                    supplierID = s.SupplierID,
                    country = s.Country
                };

            //Set the query's returned set as the data source for the listbox
            LBXSuppliers.ItemsSource = query1.ToList();

            //Query 2 - Query each supplier's associated country
            var query2 =
                query1
                    .OrderBy(S => S.country)
                    .Select(s => s.country);

            //Store the list of countries
            var countries = query2.ToList();

            //Set this list of countries as the data source for the countries listbox
            LBXCountries.ItemsSource = countries.Distinct();
        }

        private void LBXStock_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LBXSuppliers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LBXCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LBXProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

      

       
    }
}
