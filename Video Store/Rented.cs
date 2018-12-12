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
        public string S2 { get; private set; }
        public string Strr { get; private set; }

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



        public void AddRented(int MovieIDFK, int CustIDFK, DateTime  DateRented, int copies, int isout)
        {
            try
            {
                cmd_Rented.Parameters.Clear();
                cmd_Rented.Connection = Conn_Rented;



                Query_Rented = "Insert into RentedMovies(MovieIDFK, CustIDFK, DateRented ,isout) Values( @MovieIDFk, @CustIDFK, @DateRented, @isout)";
                
                cmd_Rented.Parameters.AddWithValue("@MovieIDFK", MovieIDFK );
                cmd_Rented.Parameters.AddWithValue("@CustIDFK", CustIDFK );
                cmd_Rented.Parameters.AddWithValue("@DateRented", DateRented );
                cmd_Rented.Parameters.AddWithValue("@isout", isout);
                cmd_Rented.Parameters.AddWithValue("@copies", copies);


                cmd_Rented.CommandText = Query_Rented;

                //connection opened
                Conn_Rented.Open();

                // Executed query
                cmd_Rented.ExecuteNonQuery();

                Query_Rented = "Update Movies set copies = copies-1 where MoviedID = @MovieIDFK";
                cmd_Rented.CommandText = Query_Rented;
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


        public void UpdateRented(int RMID, int MoviedID, DateTime  DateRent, DateTime  DateReturned)
        {
            try
            {
                cmd_Rented.Parameters.Clear();
                cmd_Rented.Connection = Conn_Rented;
                int RentTotal = 0, Cost = 0;
                double days = (DateReturned - DateRent).TotalDays;

                string S1 = "Select Rental_Cost from Movies where MoviedID = @MovieIDFK";
                cmd_Rented.Parameters.AddWithValue("@MovieIDFK", MoviedID);

                cmd_Rented.CommandText = S1;
                Conn_Rented.Open();
                Cost = Convert.ToInt32(cmd_Rented.ExecuteScalar());

                if (Convert.ToInt32(days) == 0)
                {
                    RentTotal = Cost;
                }
                else
                {
                    RentTotal = Cost * Convert.ToInt32(days);
                }


                S2 = "Update RentedMovies Set DateReturned='" + DateReturned +"' where RMID = @RMID";
                cmd_Rented.Parameters.AddWithValue("@DateReurned", DateReturned);
                cmd_Rented.Parameters.AddWithValue("@RMID", RMID);
               
                cmd_Rented.CommandText = S2;

                cmd_Rented.ExecuteNonQuery();


                S2 = "Update Movies set Copies = Copies+1 where MoviedID = @MovieIDFK";
                this.cmd_Rented.CommandText = this.S2;

                this.cmd_Rented.ExecuteNonQuery();

                S2 = "Update RentedMovies set isout = 0 where RMID = @RMID";
                this.cmd_Rented.CommandText = this.S2;

                this.cmd_Rented.ExecuteNonQuery();

                MessageBox.Show("Total Rent is " + RentTotal);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception " + exception.Message);
            }
            finally
            {
                if (Conn_Rented != null)
                {
                    Conn_Rented.Close();
                }
            }


        }

        public void Best_Buyer()
        {
            int Best_BuyerID = 0, Max_number = 0, Total_Customer = 0;
            string Strr = "";
            try
            {
                cmd_Rented.Parameters.Clear();
                cmd_Rented.Connection = Conn_Rented;
                string Strr1 = "Select IDENT_CURRENT('Coustmer')";

                cmd_Rented.CommandText = Strr1;
                Conn_Rented.Open();
                Total_Customer = Convert.ToInt32(cmd_Rented.ExecuteScalar());

                for (int i = 1; i <= Total_Customer; i++)
                {

                    Strr = "select Count(*) from RentedMovies where CustIDFK= '" + i + "'";


                    cmd_Rented .CommandText = Strr;
                    int count = Convert.ToInt32(cmd_Rented.ExecuteScalar());
                    if (count > Max_number)
                    {
                        Max_number = count;
                        Best_BuyerID = i;
                    }
                }
                this.S2 = "Select FirstName from Coustmer where CustID ='" + Best_BuyerID + "'";
                this.cmd_Rented.CommandText = this.S2;
                String FirstName = Convert.ToString(cmd_Rented.ExecuteScalar());
                MessageBox.Show(FirstName + " (CustID " + Best_BuyerID + " ) is maximum movie buyer with " + Max_number + " times");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception " + exception.Message);
            }
            finally
            {
                if (Conn_Rented != null)
                {
                    Conn_Rented.Close();
                }
            }

        }


        public void Top_Movie()
        {
            int Top_MovieID = 0, Max_number = 0, Total_Movies = 0;
            string Strr = "";
            try
            {
                cmd_Rented .Parameters.Clear();
                cmd_Rented.Connection = Conn_Rented; 
                string Strr1 = "Select IDENT_CURRENT('Movies')";

                cmd_Rented.CommandText = Strr1;
                Conn_Rented.Open();
                Total_Movies = Convert.ToInt32(cmd_Rented.ExecuteScalar());

                for (int i = 1; i <= Total_Movies; i++)
                {

                    Strr = "select Count(*) from RentedMovies where MovieIDFK= '" + i + "'";


                    cmd_Rented.CommandText = Strr;
                    int count = Convert.ToInt32(cmd_Rented.ExecuteScalar());
                    if (count > Max_number)
                    {
                        Max_number = count;
                        Top_MovieID = i;
                    }
                }

                
                this.Strr= "Select Title from Movies where MovieID ='" + Top_MovieID + "'";
                this.cmd_Rented.CommandText = this.Strr;
                String Title = Convert.ToString(cmd_Rented.ExecuteScalar());
                MessageBox.Show(Title + " (Movie ID " + Top_MovieID + " ) is maximum rented movie with " + Max_number + " times");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception " + exception.Message);
            }
            finally
            {
                if (Conn_Rented != null)
                {
                    Conn_Rented.Close();
                }
            }

        }
    }
}

