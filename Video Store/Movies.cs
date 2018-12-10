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
                cmd_Movies.Connection = Conn_Movies;
                
                 

                cmd_Movies.Parameters.AddWithValue("@MoviedID", MoviedID);
                Query_Movies = "Delete from Movies where MoviedID = @MoviedID";

                cmd_Movies.CommandText = Query_Movies;


                Conn_Movies.Open();


                cmd_Movies.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                if (Conn_Movies != null)
                {
                    Conn_Movies.Close();
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
