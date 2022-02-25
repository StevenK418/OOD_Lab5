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
        private NORTHWNDEntities1 db = new NORTHWNDEntities1();
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
            //Query the stock associated with the level
            var query = 
                from p in db.Products
                where p.UnitsInStock < 50
                orderby p.ProductName
                select p.ProductName;

            string selected = (string)LBXStock.SelectedItem;
            switch (selected)
            {
                case "Low":
                    //No action needed, sort covered by above query
                    break;
                case "Normal":
                    query = from p in db.Products
                            where p.UnitsInStock >= 50 && p.UnitsInStock <= 100
                            orderby p.ProductName
                            select p.ProductName;
                    break;
                case "Overstocked":
                    query = from p in db.Products
                            where p.UnitsInStock > 100
                            orderby p.ProductName
                            select p.ProductName;
                    break;
            }

            //Assign the resultant query result set as the source for the product listbox
            LBXProducts.ItemsSource = query.ToList();
        }

        private void LBXSuppliers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Get the selected supplier via ID
            int supplierID = Convert.ToInt32(LBXSuppliers.SelectedValue);

            var query = from p in db.Products
                                    where p.SupplierID == supplierID
                                    orderby p.ProductName
                                    select p.ProductName;

            //Assign the query result set as the sourc e for the products listbox
            LBXProducts.ItemsSource = query.ToList();
        }

        private void LBXCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Get a reference to the selected country 
            string country = (string) (LBXCountries.SelectedValue);

            var query = from p in db.Products
                                    where p.Supplier.Country == country
                                    orderby p.ProductName
                                    select p.ProductName;

            //Assign the result set as the data source for the products listbox
            LBXProducts.ItemsSource = query.ToList();
        }
    }
}
