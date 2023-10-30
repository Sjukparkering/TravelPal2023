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

namespace TravelPal2023
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
                     
            InitializeComponent();

            cmbCountry.ItemsSource = Enum.GetValues(typeof(Country));
        }

        private void Country_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameReg.Text;
            string password = PasswordReg.Password;
             

            //Kolla så användarnamet är ledigt
            //Om inte, skicka varningsmeddelande
            //Kolla så användaren har skrivit in något in textboxarna


            //Spara och skapa användaren så den kan logga in


            if (username == null || password == null || cmbCountry.SelectedIndex <= -1)
            {
                //Skicka varningsmeddelande
                MessageBox.Show("Please fill in all required fields");
            }
            else
            {
                //Spara värderna
                Country selectedCountry = (Country)cmbCountry.SelectedItem;

                bool addUserResult = UserManager.AddUser(new User(username, password, selectedCountry));

                if(addUserResult)
                {
                    // Det gick att lägga till en ny användare
                    MessageBox.Show("A new user was registered");

                    MainWindow mainWindow = new();
                    mainWindow.Show();
                    Close();
                }
                else
                {
                    // Användarnamnet var upptaget
                    MessageBox.Show("Failed to register a new user. The username might already be taken.");
                }
            }

           
            
        } 


    }
}
