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
        {
            string username = Convert.ToString(username_txt.Text);
            string password = Convert.ToString(password_txt.Text);
            Obj_register.Regis_method(username,password);
          
                MessageBox.Show("Registered Successful");
                LoginPage w = new LoginPage();
                w.ShowDialog();
                this.Close();
            

        }
    }
}
