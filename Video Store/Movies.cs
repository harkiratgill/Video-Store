using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace Video_Store
{
    class Movies
    {
        //this code will be used in all methods to access the sql connection
       SqlConnection Conn_Movies = new SqlConnection("Data Source=gill-pc\\sqlexpress;Initial Catalog=RENT;Integrated Security=True");
        //this code will be used in all methods to run sql command
        SqlCommand cmd_Movies = new SqlCommand();
        //Reader is the object of reader class and will be user in some methods
        SqlDataReader Reader_Movies;

        String Query_Movies;

        public IEnumerable DefaultView { get; internal set; }

       


        public DataTable ListMovies()
        { //this method is used to display all the movies in datagrid
            DataTable dt = new DataTable();
            try
            {
                cmd_Movies.Connection = Conn_Movies;
                Query_Movies = "Select * from Movies";

                cmd_Movies.CommandText = Query_Movies;
                //connection   opened
                Conn_Movies.Open();

                // get data stream
                Reader_Movies = cmd_Movies.ExecuteReader();

                if (Reader_Movies.HasRows)
                {
                    dt.Load(Reader_Movies);
                }
                return dt;
            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
                return null;
            }
            finally
            {
                // close reader
                if (Reader_Movies != null)
                {
                    Reader_Movies.Close();
                }

                // close connection
                if (Conn_Movies != null)
                {
                    Conn_Movies.Close();
                }
            }

        }



        public void AddMovies(string Rating, string Title, string Year, string Rental_Cost, string Plot, string Genre, int copies)
        {//This method is used to insert data into movie table
            try
            {
                cmd_Movies.Parameters.Clear();
                cmd_Movies.Connection = Conn_Movies;



                Query_Movies = "Insert into Movies(Rating, Title, Year, Rental_Cost, Plot, Genre, copies) Values( @Rating, @Title, @Year, @Rental_Cost, @Plot, @Genre, @copies)";


                cmd_Movies.Parameters.AddWithValue("@Rating", Rating);
                cmd_Movies.Parameters.AddWithValue("@Title", Title);
                cmd_Movies.Parameters.AddWithValue("@Year", Year);
                cmd_Movies.Parameters.AddWithValue("@Rental_Cost", Rental_Cost);
                cmd_Movies.Parameters.AddWithValue("@Plot", Plot);
                cmd_Movies.Parameters.AddWithValue("@Genre", Genre);
                cmd_Movies.Parameters.AddWithValue("@copies", copies);

                cmd_Movies.CommandText = Query_Movies;

                //connection opened
                Conn_Movies.Open();

                // Executed query
                cmd_Movies.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                // close connection
                if (Conn_Movies != null)
                {
                    Conn_Movies.Close();
                }
            }
        }

        public void DeleteMovie(int MovieID)
        {// this method is used to remove data from movie table
            try
            {
                cmd_Movies.Parameters.Clear();
                cmd_Movies.Connection = this.Conn_Movies ;


                //blow code is to check if the Movie is rented
                String check = "";
                check = "select Count(*) from RentedMovies where MovieIDFK = @MovieID and Rented ='1' ";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@MovieID", MovieID) };
                cmd_Movies.Parameters.Add(parameterArray[0]);

                cmd_Movies.CommandText = check;
                Conn_Movies.Open();
                //this code will delete the movie if its not rented otherwise the else statement would work
                int count = Convert.ToInt32(cmd_Movies.ExecuteScalar());
                if (count == 0)
                {
                    String k = "Delete from Movies where MovieID like @MovieID";
                    cmd_Movies.CommandText = k;
                    cmd_Movies.ExecuteNonQuery();
                    MessageBox.Show("Movie Deleted");
                }
                else
                {
                    //display the message if he has a movie on rent 
                    MessageBox.Show("Customer has Rented a Movie He needs to return it before u can delete the Customer ");
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
            }
            finally
            {
                if (this.Conn_Movies != null)
                {
                    this.Conn_Movies.Close();
                }

            }
        }

       

        public void UpdateMovie(int MovieID, string Rating, string Title, int Year, string Plot, string Genre, int copies)
        {//this method is used to update the movie 
            try
            {
                cmd_Movies.Parameters.Clear();
                cmd_Movies.Connection = Conn_Movies;
                Query_Movies = "Update Movies Set Rating = @Rating, Title = @Title, Year = @Year,  Plot = @Plot, Genre = @Genre, copies = @copies where MovieID like @MovieID";


                cmd_Movies.Parameters.AddWithValue("@MovieID", MovieID);
                cmd_Movies.Parameters.AddWithValue("@Rating", Rating);
                cmd_Movies.Parameters.AddWithValue("@Title", Title);
                cmd_Movies.Parameters.AddWithValue("@Year", Year);
                cmd_Movies.Parameters.AddWithValue("@Plot", Plot);
                cmd_Movies.Parameters.AddWithValue("@Genre", Genre);
                cmd_Movies.Parameters.AddWithValue("@copies", copies);


                cmd_Movies.CommandText = Query_Movies;

                //connection opened
                Conn_Movies.Open();

                // Executed query
                cmd_Movies.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                // close connection
                if (Conn_Movies != null)
                {
                    Conn_Movies.Close();
                }
            }
        }

        
    }
}
