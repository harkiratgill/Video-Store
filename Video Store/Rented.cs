using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Video_Store6
{
    class Rented
    {
        //this code will be used in all methods to access the sql connection

        SqlConnection Conn_Rented = new SqlConnection("Data Source=gill-pc\\sqlexpress;Initial Catalog=RENT;Integrated Security=True");
        //will be used in all methods to run sql command

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
                Query_Rented = "Select * from RentedMovies Order by RMID DESC";

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



        public void AddRented(int MovieIDFK, int CustIDFK, DateTime  DateRented, int copies, int Rented)
        {// thsi code is used to issue movie 
            try
            {
                cmd_Rented.Parameters.Clear();
                cmd_Rented.Connection = Conn_Rented;



                Query_Rented = "Insert into RentedMovies(MovieIDFK, CustIDFK, DateRented ,Rented) Values( @MovieIDFk, @CustIDFK, @DateRented, @Rented)";
                
                cmd_Rented.Parameters.AddWithValue("@MovieIDFK", MovieIDFK );
                cmd_Rented.Parameters.AddWithValue("@CustIDFK", CustIDFK );
                cmd_Rented.Parameters.AddWithValue("@DateRented", DateRented );
                cmd_Rented.Parameters.AddWithValue("@Rented", Rented);
                cmd_Rented.Parameters.AddWithValue("@copies", copies);


                cmd_Rented.CommandText = Query_Rented;

                //connection opened
                Conn_Rented.Open();

                // Executed query
                cmd_Rented.ExecuteNonQuery();

                Query_Rented = "Update Movies set copies = copies-1 where MovieID = @MovieIDFK";
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


        public void UpdateRented(int RMID, int MovieID, DateTime  DateRent, DateTime  DateReturned)
        {// this method is used to return the movie 
            try
            {
                cmd_Rented.Parameters.Clear();
                cmd_Rented.Connection = Conn_Rented;
                int RentTotal = 0, Cost = 0;
                double days = (DateReturned - DateRent).TotalDays;

                string S1 = "Select Rental_Cost from Movies where MovieID = @MovieIDFK";
                cmd_Rented.Parameters.AddWithValue("@MovieIDFK", MovieID);

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


                S2 = "Update Movies set copies = copies+1 where MovieID = @MovieIDFK";
                this.cmd_Rented.CommandText = this.S2;

                this.cmd_Rented.ExecuteNonQuery();

                S2 = "Update RentedMovies set Rented = 0 where RMID = @RMID";
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

        public void TopCustomer()
        {// this mehod is used to find the top Custometr
            int Top = 0, Max = 0, Total = 0;
            string Value = "";
            try
            {
                cmd_Rented.Parameters.Clear();
                cmd_Rented.Connection = Conn_Rented;
                string Val = "Select IDENT_CURRENT('Coustmer')";

                cmd_Rented.CommandText = Val;
                Conn_Rented.Open();
                Total = Convert.ToInt32(cmd_Rented.ExecuteScalar());

                for (int i = 1; i <= Total; i++)
                {

                    Value = "select Count(*) from RentedMovies where CustIDFK= '" + i + "'";


                    cmd_Rented .CommandText = Value;
                    int count = Convert.ToInt32(cmd_Rented.ExecuteScalar());
                    if (count > Max)
                    {
                        Max = count;
                        Top = i;
                    }
                }
                this.S2 = "Select FirstName from Coustmer where CustID ='" + Top + "'";
                this.cmd_Rented.CommandText = this.S2;
                String FirstName = Convert.ToString(cmd_Rented.ExecuteScalar());
                MessageBox.Show(FirstName + " (CustID " + Top + " ) is The Coustomer Rented Most Movies With " + Max + " times");
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


        public void TopMovie()
        {// this method is used to display the top movie 
            int Top = 0, Max = 0, Total = 0;
            string Value = "";
            try
            {
                cmd_Rented .Parameters.Clear();
                cmd_Rented.Connection = Conn_Rented; 
                string Val = "Select IDENT_CURRENT('Movies')";

                cmd_Rented.CommandText = Val;
                Conn_Rented.Open();
                Total = Convert.ToInt32(cmd_Rented.ExecuteScalar());

                for (int i = 1; i <= Total; i++)
                {

                    Value = "select Count(*) from RentedMovies where MovieIDFK= '" + i + "'";


                    cmd_Rented.CommandText = Value;
                    int count = Convert.ToInt32(cmd_Rented.ExecuteScalar());
                    if (count > Max)
                    {
                        Max = count;
                        Top = i;
                    }
                }

                
                this.Strr= "Select Title from Movies where MovieID ='" + Top + "'";
                this.cmd_Rented.CommandText = this.Strr;
                String Title = Convert.ToString(cmd_Rented.ExecuteScalar());
                MessageBox.Show(Title + " (MovieID " + Top + " ) Is The Movie Rented Most Time With " + Max + " times");
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

