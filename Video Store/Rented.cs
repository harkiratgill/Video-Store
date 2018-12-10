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
    class Rented
    {
        
        SqlConnection Conn_Rented = new SqlConnection("Data Source=gill-pc\\sqlexpress;Initial Catalog=RENT;Integrated Security=True");

        SqlCommand cmd_Rented = new SqlCommand();

        SqlDataReader Reader_Rented;

        String Query_Rented;

        public IEnumerable DefaultView { get; internal set; }

        internal object RentedDG()
        {
            throw new NotImplementedException();
        }


        public DataTable ListRented()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd_Rented.Connection = Conn_Rented;
                Query_Rented = "Select * from RentedMovies";

                cmd_Rented.CommandText = Query_Rented;
                //connection   opened
                Conn_Rented.Open();

                // get data stream
                Reader_Rented = cmd_Rented.ExecuteReader();

                if (Reader_Rented.HasRows)
                {
                    dt.Load(Reader_Rented);
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
                if (Reader_Rented  != null)
                {
                    Reader_Rented.Close();
                }

                // close connection
                if (Conn_Rented != null)
                {
                    Conn_Rented.Close();
                }
            }

        }



        public void AddRented(int MovieIDFK, int CustIDFK, DateTime DateRented )
        {
            try
            {
                cmd_Rented.Parameters.Clear();
                cmd_Rented.Connection = Conn_Rented;



                Query_Rented = "Insert into RentedMovies(MovieIDFK, CustIDFK, DateRented) Values( @MovieIDFk, @CustIDFK, @DateRented)";


                cmd_Rented.Parameters.AddWithValue("@MovieIDFK", MovieIDFK );
                cmd_Rented.Parameters.AddWithValue("@CustIDFK", CustIDFK );
                cmd_Rented.Parameters.AddWithValue("@DateRented", DateRented );
             

                cmd_Rented.CommandText = Query_Rented;

                //connection opened
                Conn_Rented.Open();

                // Executed query
                cmd_Rented.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                // close connection
                if (Conn_Rented != null)
                {
                    Conn_Rented.Close();
                }
            }
        }

        
        public void UpdateRented( int RMID, DateTime DateReturned)
        {
            try
            {
                cmd_Rented.Parameters.Clear();
                cmd_Rented.Connection = Conn_Rented;
                Query_Rented = "Update RentedMovies Set DateReturned = @DateReturned,  where RMID = @RMID";


                cmd_Rented.Parameters.AddWithValue("@RMID", RMID);
                cmd_Rented.Parameters.AddWithValue("@DateReturned", DateReturned);
               

                cmd_Rented.CommandText = Query_Rented;

                //connection opened
                Conn_Rented.Open();

                // Executed query
                cmd_Rented.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                // close connection
                if (Conn_Rented != null)
                {
                    Conn_Rented.Close();
                }
            }
        }

    }
}
}
