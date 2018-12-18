using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Video_Store
{
    public class Register
    {
        SqlConnection Connect =
            new SqlConnection("Data Source=gill-pc\\sqlexpress;Initial Catalog=RENT;Integrated Security=True");

        SqlCommand cmd = new SqlCommand();
        String quy;

        public void Regis_method(string username, string password)
        { // this method is used to insert user details in the user table
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = Connect;

                quy = "Insert into userdata (UserName, Password) Values(@user, @pass)";
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);

                cmd.CommandText = quy;
                //connection opened
                Connect.Open();

                // get data stream
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                // close connection
                if (Connect != null)
                {
                    Connect.Close();
                }
            }
        }
    }
}
