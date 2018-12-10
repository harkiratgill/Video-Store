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
        Movies Obj_Movies = new Movies();

        public int CustID;
        public int MoviedID;

        public Main()
        {
            InitializeComponent();
        }

        private void Update_btn_Click(object sender, RoutedEventArgs e)
        {
            string FirstName = First_txt.Text;
            string LastName = Last_txt.Text;
            string Address = Address_txt.Text;
            string Phone = Phone_txt.Text;
            Obj_Customer.UpdateCustomer(CustID , FirstName, LastName, Address, Phone  );
            
            Customer_data.ItemsSource = Obj_Customer.Listcustomer().DefaultView;
            First_txt.Text = "";
            Last_txt.Text = "";
            Phone_txt.Text = "";
            Address_txt.Text = "";
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            
            if (First_txt.Text != "" && Last_txt.Text != "" && Address_txt.Text != "" && Phone_txt.Text != "")
            {
                Obj_Customer.AddCustomer( First_txt.Text, Last_txt.Text, Address_txt.Text, Phone_txt.Text);
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
            Customerid_txt.Text = Convert.ToString(row["CustID"]);
            First_txt.Text = Convert.ToString(row["FirstName"]);
            Last_txt.Text = Convert.ToString(row["Lastname"]);
            Address_txt.Text = Convert.ToString(row["Address"]);
            Phone_txt.Text = Convert.ToString(row["Phone"]);

            Customer_data.ItemsSource = Obj_Customer.Listcustomer().DefaultView;
        }

        private void AddMovies_Click(object sender, RoutedEventArgs e)
        {
            
            if (Rating_txt.Text != "" && Title_txt.Text != "" && Year_tx.Text != "" && Rent_txt.Text != "" && Plot_txt.Text != "" && Genre_txt.Text != "")
            {
                int Mov_year = Convert.ToInt32(Year_tx.Text);
                string rent;
                if (2018 - Mov_year > 5)
                {
                    rent = "2";
                        
                }
                else
                {
                    rent = "5";
                }

                Obj_Movies.AddMovies(Rating_txt.Text, Title_txt.Text, Year_tx.Text, rent, Plot_txt.Text, Genre_txt.Text);
                Video_data.ItemsSource = Obj_Movies.ListMovies().DefaultView;
                Title_txt.Text = "";
                Rating_txt.Text = "";
                Plot_txt.Text = "";
                Year_tx.Text = "";
                Genre_txt.Text = "";
                Rent_txt.Text = "";
            }
        }

        private void UpdateMovies_Click(object sender, RoutedEventArgs e)
        {
            string Title = Title_txt.Text;
            string Rating = Rating_txt.Text;
            string Plot = Plot_txt.Text;
            string Genre = Genre_txt.Text;
            string Rental_Cost = Rent_txt.Text;
            int Year = Convert.ToInt32(Year_tx.Text);
            Obj_Movies.UpdateMovie(MoviedID, Rating, Title, Year, Rental_Cost, Plot, Genre);
            MessageBox.Show("Video Updated");
            Video_data.ItemsSource = Obj_Movies.ListMovies().DefaultView;
            Title_txt.Text = "";
            Rating_txt.Text = "";
            Plot_txt.Text = "";
            Year_tx.Text = "";
            Genre_txt.Text = "";
            Rent_txt.Text = "";
        }

        private void DeleteMovie(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Do you wanna Delete This Movie ?", "Title", MessageBoxButton.YesNo);
            if (dialogResult.ToString() == "Yes")
            {
                Obj_Customer.DeleteCustomer(MoviedID);
                MessageBox.Show("Movie Deleted");
                Video_data.ItemsSource = Obj_Movies.ListMovies().DefaultView;
                Title_txt.Text = "";
                Rating_txt.Text = "";
                Plot_txt.Text = "";
                Year_tx.Text = "";
                Genre_txt.Text = "";
                Rent_txt.Text = "";
            }
        }

        private void Video_loaded(object sender, RoutedEventArgs e)
        {
           Video_data.ItemsSource = Obj_Movies.ListMovies().DefaultView;
        }

        private void SelectMovieRow_Edit(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)Video_data.SelectedItems[0];
            Title_txt.Text = Convert.ToString(row["Title"]);
            Plot_txt.Text = Convert.ToString(row["Plot"]);
            Genre_txt.Text = Convert.ToString(row["Genre"]);
            Year_tx.Text = Convert.ToString(row["Year"]);
            Rating_txt.Text = Convert.ToString(row["Rating"]);
            Rent_txt.Text = Convert.ToString(row["Rental_Cost"]);
            Movieid_txt.Text = Convert.ToString(row["MoviedID"]);

            Video_data.ItemsSource = Obj_Movies.ListMovies().DefaultView;
        }

        private void TabControl_SelectionChanged()
        {

        }

        private void Movieid_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Movieid_txt_Copy2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
