using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Video_Store
{
    class Movies
    {
        SqlConnection Conn_Movies = new SqlConnection("Data Source=gill-pc\\sqlexpress;Initial Catalog=RENT;Integrated Security=True");

        SqlCommand cmd_Movies = new SqlCommand();

        SqlDataReader Reader_Movies;

        String Query_Movies;

        public IEnumerable DefaultView { get; internal set; }

       


        public DataTable ListMovies()
        {
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
        {
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

        public void DeleteMovie(int MoviedID)
        {
            try
            {
                cmd_Movies.Parameters.Clear();
                cmd_Movies.Connection = this.Conn_Movies ;


                //first of the all select the record from the Rented Movie is he already has a movie on rent or not if he has a movie on rent then he can't be able to delete the record from the table
                String Strr = "";
                Strr = "select Count(*) from RentalMovies where MovieIDFK= @MovieID and DateReturned ='1900-01-01' ";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@MoviedID", MoviedID) };
                cmd_Movies.Parameters.Add(parameterArray[0]);

                cmd_Movies.CommandText = Strr;
                Conn_Movies.Open();
                int count = Convert.ToInt32(cmd_Movies.ExecuteScalar());
                if (count == 0)
                {
                    Strr = "Delete from Movies where MoviedID like @MoviedID";
                    cmd_Movies.CommandText = Strr;
                    cmd_Movies.ExecuteNonQuery();
                    MessageBox.Show("Movie Deleted");
                }
                else
                {
                    //display the message if he has a movie on rent 
                    MessageBox.Show("Customer has rented the movie. First take the movie back than you can delete the movie");
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

       

        /*UpdateBooks method is taking 3 inputs i.e. BookID, BookName, Author, which are used in update query to update Books data in database */
        public void UpdateMovie(int MoviedID, string Rating, string Title, int Year, string Plot, string Genre, int copies)
        {
            try
            {
                cmd_Movies.Parameters.Clear();
                cmd_Movies.Connection = Conn_Movies;
                Query_Movies = "Update Movies Set Rating = @Rating, Title = @Title, Year = @Year,  Plot = @Plot, Genre = @Genre, copies = @copies where MoviedID like @MoviedID";


                cmd_Movies.Parameters.AddWithValue("@MoviedID", MoviedID);
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
