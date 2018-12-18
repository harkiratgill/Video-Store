using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Video_Store
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Register  Obj_register= new Register();

        public Window1()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {   //below code is used to Check if the user has fill both the column
            if (username_txt.Text != "" && password_txt.Text != "")
            {
                string username = Convert.ToString(username_txt.Text);//this code takes the value from the text box and put it in the variable 
                string password = Convert.ToString(password_txt.Text);
                Obj_register.Regis_method(username, password);//this code passes the variable to Regis_method in Register Class

                MessageBox.Show("Registered Successful");//this code display to the user by a pop up that they have been register successfully
                LoginPage w = new LoginPage();
                w.ShowDialog();//this code display the login window
                Hide();
            }

            else
            {
                MessageBox.Show("Please Fill The Username And Password");// this code display to the user by a pop up that they Does not filled the both column

            }

        }
    }
}
