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
using System.Windows.Shapes;

namespace Video_Store
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        Customer  Obj_Customer = new Customer() ;

        public int CustID;

        public Main()
        {
            InitializeComponent();
        }

        private void Update_btn_Click(object sender, RoutedEventArgs e)
        {
            string FirstName = First_txt.Text;
            string LastName = Last_txt.Text;
            string Address = Address_txt.Text;
            int Phone = Convert.ToInt32(Phone_txt.Text);
            Obj_Customer.UpdateCustomer(CustID , FirstName, LastName, Address, Phone  );
            MessageBox.Show("Book Updated");
            Customer_data.ItemsSource = Obj_Customer.Listcustomer().DefaultView;
            First_txt.Text = "";
            Last_txt.Text = "";
            Phone_txt.Text = "";
            Address_txt.Text = "";
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            int Phone_Number = Convert.ToInt32(Phone_txt.Text);
            if (First_txt.Text != "" && Last_txt.Text != "" && Address_txt.Text != "" && Phone_Number != 0)
            {
                Obj_Customer.AddCustomer( First_txt.Text, Last_txt.Text, Address_txt.Text, Phone_Number);
                Customer_data.ItemsSource = Obj_Customer.Listcustomer().DefaultView;
                First_txt.Text = "";
                Last_txt.Text = "";
                Address_txt.Text = "";
                Phone_txt.Text = "";

            }
        }

        private void Deletecustomer_Copy_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBoxResult dialogResult = MessageBox.Show("Do you wanna Delete This Customer ?", "Customer", MessageBoxButton.YesNo);
            if (dialogResult.ToString() == "Yes")
            {
                Obj_Customer.DeleteCustomer(CustID);
                MessageBox.Show("Customer Deleted");
                Customer_data.ItemsSource = Obj_Customer.Listcustomer().DefaultView;
                First_txt.Text = "";
                Last_txt.Text = "";
                Address_txt.Text = "";
                Phone_txt.Text = "";
            }
        }

        private void Customer_load(object sender, RoutedEventArgs e)
        {
            Customer_data.ItemsSource = Obj_Customer.Listcustomer().DefaultView;
        }

        private void SelectBookRow_Edit(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)Customer_data.SelectedItems[0];
            CustID = Convert.ToInt32(row["CustID"]);
            First_txt.Text = Convert.ToString(row["FirstName"]);
            Last_txt.Text = Convert.ToString(row["Lastname"]);
            Address_txt.Text = Convert.ToString(row["Address"]);
            Customer_data.ItemsSource = Obj_Customer.Listcustomer().DefaultView;
        }
    }
}
