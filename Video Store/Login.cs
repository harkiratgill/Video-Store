using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Video_Store
{
    public class Login
    {
        SqlConnection Conn_Login = new SqlConnection("Data Source=gill-pc\\sqlexpress;Initial Catalog=RENT;Integrated Security=True");

        SqlCommand cmd_login = new SqlCommand();

        SqlDataReader Reader_Login;

        String Query_login;


        public bool Login_method(string username, string password)
        { //this method is used to check if the enter data exist in the user table s
            try
            {
                cmd_login.Connection = Conn_Login;

                Query_login = "Select username, password from userdata where UserName =  @UserName  and Password =  @password ";

             
                cmd_login.Parameters.AddWithValue("@UserName", username);
                cmd_login.Parameters.AddWithValue("@password", password);

                cmd_login.CommandText = Query_login;
                Conn_Login.Open();

                Reader_Login = cmd_login.ExecuteReader();

                if (Reader_Login.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Exception" + ex.Message);
                return false;
            }
            finally
            {
                if (Reader_Login != null)
                {
                    Reader_Login.Close();
                }

                if (Conn_Login != null)
                {
                    Conn_Login.Close();
                }
            }
        }

    }
}
