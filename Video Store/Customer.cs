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
    {         //this code will be used in all methods to access the sql connection

        SqlConnection Conn_customer = new SqlConnection("Data Source=gill-pc\\sqlexpress;Initial Catalog=RENT;Integrated Security=True");
        //this code will be used in all methods to run sql command

        SqlCommand cmd_customer = new SqlCommand();
        //Reader is the object of reader class and will be user in some methods

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
            {// this method is used to display customers on data grid
                cmd_customer.Connection = Conn_customer;
                Query_customer = "Select * from Coustmer";

                cmd_customer.CommandText = Query_customer;
                Conn_customer.Open();

                Reader_customer = cmd_customer.ExecuteReader();

                if (Reader_customer.HasRows)
                {
                    dt.Load(Reader_customer);
                }
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Exception" + ex.Message);
                return null;
            }
            finally
            {
                if (Reader_customer != null)
                {
                    Reader_customer.Close();
                }

                if (Conn_customer != null)
                {
                    Conn_customer.Close();
                }
            }

        }


        
        public void AddCustomer(string FirstName, string LastName, string Address, string Phone)
        {// this method is used to add customer
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
        {//this method is used to delete customer
            try
            {
                cmd_customer .Parameters.Clear();
                cmd_customer.Connection = this.Conn_customer;

                //below code is to find if the customer has rented a movie 
                String Strr = "";
                Strr = "select Count(*) from RentedMovies where CustIDFK= @CustID and isout ='1' ";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@CustID", CustID) };
                cmd_customer.Parameters.Add(parameterArray[0]);

                cmd_customer.CommandText = Strr;
                Conn_customer .Open();
                int count = Convert.ToInt32(cmd_customer.ExecuteScalar());
                if (count == 0)//if customer has not rented the movie it will be deleted if not then the customer first have to return the movie 
                {
                    Strr = "Delete from Coustmer where CustID like @CustID";
                    cmd_customer.CommandText = Strr;
                    cmd_customer.ExecuteNonQuery();
                    MessageBox.Show("User Deleted");
                }
                else
                {
                    MessageBox.Show("Customer has rented the movie. First take the movie back than you can delete the customer");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
            }
            finally
            {
                if (this.Conn_customer != null)
                {
                    this.Conn_customer.Close();
                }
            }
        }

    

    public void UpdateCustomer(int CustID, string FirstName, string LastName, string Address, string Phone)
        {//This method is Used to update customer table
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

