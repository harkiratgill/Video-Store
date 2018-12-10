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
    class Customer
    {
        SqlConnection Conn_customer = new SqlConnection("Data Source=gill-pc\\sqlexpress;Initial Catalog=RENT;Integrated Security=True");

        SqlCommand cmd_customer = new SqlCommand();

        SqlDataReader Reader_customer;

        String Query_customer;

        public IEnumerable DefaultView { get; internal set; }

        internal object CustomerDG()
        {
            throw new NotImplementedException();
        }

     
        public DataTable Listcustomer()
        {
            DataTable  dt = new DataTable();
            try
            {
                cmd_customer.Connection = Conn_customer;
                Query_customer = "Select * from Coustmer";

                cmd_customer.CommandText = Query_customer;
                //connection   opened
                Conn_customer.Open();

                // get data stream
                Reader_customer = cmd_customer.ExecuteReader();

                if (Reader_customer.HasRows)
                {
                    dt.Load(Reader_customer);
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
                if (Reader_customer != null)
                {
                    Reader_customer.Close();
                }

                // close connection
                if (Conn_customer != null)
                {
                    Conn_customer.Close();
                }
            }

        }


        
        public void AddCustomer(string FirstName, string LastName, string Address, string Phone)
        {
            try
            {
                cmd_customer.Parameters.Clear();
                cmd_customer.Connection = Conn_customer;

                

                Query_customer = "Insert into Coustmer(FirstName, LastName, Address, Phone) Values( @FirstName, @LastName, @Address, @Phone)";

                
                cmd_customer.Parameters.AddWithValue("@FirstName", FirstName );
                cmd_customer.Parameters.AddWithValue("@LastName", LastName );
                cmd_customer.Parameters.AddWithValue("@Address", Address );
                cmd_customer.Parameters.AddWithValue("@Phone", Phone );

                cmd_customer.CommandText = Query_customer;

                //connection opened
                Conn_customer.Open();

                // Executed query
                cmd_customer.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                // close connection
                if (Conn_customer != null)
                {
                    Conn_customer.Close();
                }
            }
        }

        public void DeleteCustomer(Int32 CustID)
        {
            try
            {
                cmd_customer.Parameters.Clear();
                cmd_customer.Connection = Conn_customer;
                Query_customer = "Delete from Coustmer where CustID like @CustID";

               
                cmd_customer.Parameters.AddWithValue("@CustID", CustID);

                cmd_customer.CommandText = Query_customer;
               

                Conn_customer.Open();

                
                cmd_customer.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                if (Conn_customer != null)
                {
                    Conn_customer.Close();
                }
            }
        }

        /*UpdateBooks method is taking 3 inputs i.e. BookID, BookName, Author, which are used in update query to update Books data in database */
        public void UpdateCustomer(int CustID, string FirstName, string LastName, string Address, string Phone)
        {
            try
            {
                cmd_customer.Parameters.Clear();
                cmd_customer.Connection = Conn_customer;
                Query_customer = "Update Coustmer Set FirstName = @FirstName, LastName = @LastName, Address = @Address, Phone = @Phone where CustID = @CustID";


                cmd_customer.Parameters.AddWithValue("@CustID", CustID);
                cmd_customer.Parameters.AddWithValue("@FirstName", FirstName);
                cmd_customer.Parameters.AddWithValue("@LastName", LastName );
                cmd_customer.Parameters.AddWithValue("@Address", Address);
                cmd_customer.Parameters.AddWithValue("@Phone", Phone);

                cmd_customer.CommandText = Query_customer;

                //connection opened
                Conn_customer.Open();

                // Executed query
                cmd_customer.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                // close connection
                if (Conn_customer != null)
                {
                    Conn_customer.Close();
                }
            }
        }

    }
}   

