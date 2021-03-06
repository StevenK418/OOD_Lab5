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
        private AdventureLiteEntities1 db = new AdventureLiteEntities1();
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
            //Store the selected customer
            string customer = (string) LBXCustomers.SelectedItem;

            if (customer != null)
            {
                //Query the DB for the Ordersfor a given customer
                var query = from o in db.SalesOrderHeaders
                                                where o.Customer.CompanyName.Equals(customer)
                                                select o;

                //Assign the result set as data source for the orders listbox
                LBXOrders.ItemsSource = query.ToList();
            }
        }

        private void LBXOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Get the selected order ID
            int orderID = Convert.ToInt32(LBXOrders.SelectedValue);

            if (orderID > 0)
            {

                //Query the db for the Order Details associated with the selected ID
                var query = from od in db.SalesOrderDetails
                    where od.SalesOrderID == orderID
                    select new
                    {
                        ProductName = od.Product.Name,
                        od.UnitPrice,
                        od.UnitPriceDiscount,
                        od.OrderQty,
                        od.LineTotal
                    };

                //Set the query's result set as the source for the OrderDetails Datagrid.
                DGOrderDetails.ItemsSource = query.ToList();
            }
        }

     
    }
}
