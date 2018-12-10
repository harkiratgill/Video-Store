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
        Rented Obj_Rented = new Rented();
        

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
            int CustID = Convert.ToInt32(Customerid_txt.Text);
            Obj_Customer.UpdateCustomer(CustID , FirstName, LastName, Address, Phone);
            
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
            int CustID = Convert.ToInt32(Customerid_txt.Text);
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
            
            if (Rating_txt.Text != "" && Title_txt.Text != "" && Year_tx.Text != "" &&  Plot_txt.Text != "" && Genre_txt.Text != "" && copies_txt.Text != "")
            {
                int Mov_year = Convert.ToInt32(Year_tx.Text);
                int copies = Convert.ToInt32(copies_txt.Text);
                string rent;
                if (2018 - Mov_year > 5)
                {
                    rent = "2";
                        
                }
                else
                {
                    rent = "5";
                }

                Obj_Movies.AddMovies(Rating_txt.Text, Title_txt.Text, Year_tx.Text, rent, Plot_txt.Text, Genre_txt.Text, copies);
                Video_data.ItemsSource = Obj_Movies.ListMovies().DefaultView;
                Title_txt.Text = "";
                Rating_txt.Text = "";
                Plot_txt.Text = "";
                Year_tx.Text = "";
                Genre_txt.Text = "";
                copies_txt.Text = "";

            }
        }

        private void UpdateMovies_Click(object sender, RoutedEventArgs e)
        {
            int MoviedID = Convert.ToInt32(Movieid_txt.Text);
            int copies = Convert.ToInt32(copies_txt.Text);


            string Title = Title_txt.Text;
            string Rating = Rating_txt.Text;
            string Plot = Plot_txt.Text;
            string Genre = Genre_txt.Text;
            int Year = Convert.ToInt32(Year_tx.Text);
            Obj_Movies.UpdateMovie(MoviedID, Rating, Title, Year, Plot, Genre, copies );
            MessageBox.Show("Video Updated");
            Video_data.ItemsSource = Obj_Movies.ListMovies().DefaultView;
            Title_txt.Text = "";
            Rating_txt.Text = "";
            Plot_txt.Text = "";
            Year_tx.Text = "";
            Genre_txt.Text = "";
            copies_txt.Text = "";
        }

        private void DeleteMovie(object sender, RoutedEventArgs e)
        {
            int movie = Convert.ToInt32(Movieid_txt.Text);

            
          
                Obj_Customer.DeleteCustomer(movie);
                Video_data.ItemsSource = Obj_Movies.ListMovies().DefaultView;
                Title_txt.Text = "";
                Rating_txt.Text = "";
                Plot_txt.Text = "";
                Year_tx.Text = "";
                Genre_txt.Text = "";
            Movieid_txt.Text = "";



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

        private void Video_data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Customer_data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Issue_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Movieid_txt.Text != "" && Customerid_txt.Text != "" && dateissue_txt.Text != "" )
            {
                int MovieID = Convert.ToInt32(Movieid_txt.Text);
                int Customerid = Convert.ToInt32(Customerid_txt.Text);
               

                Obj_Rented.AddRented(Movieid_txt.Text, Title_txt.Text, Year_tx.Text, rent, Plot_txt.Text, Genre_txt.Text, copies);
                Video_data.ItemsSource = Obj_Movies.ListMovies().DefaultView;
                Title_txt.Text = "";
                Rating_txt.Text = "";
                Plot_txt.Text = "";
                Year_tx.Text = "";
                Genre_txt.Text = "";
                copies_txt.Text = "";

            }

        }
    }
}
