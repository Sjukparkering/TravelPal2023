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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TravelPal2023
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow(); 
            registerWindow.Show(); 
            this.Close();
        }

        private void BtnLogIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool userLoggedIn = UserManager.SignInUser(UserNameBox.Text, PasswordBox.Password);

                if (!userLoggedIn)
                {
                    MessageBox.Show("Wrong username or password");
                }
                else
                {
                    TravelsWindow travelsWindow = new TravelsWindow();
                    travelsWindow.Show();
                    this.Close();
                }
            }
            catch (NotImplementedException)
            {
                
            }
        }
    }
}
