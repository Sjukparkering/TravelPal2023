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
    
    public partial class AddTravelWindow : Window
    {
        public AddTravelWindow()
        {
            InitializeComponent();

            TravelType.Items.Add("Work trip");
            TravelType.Items.Add("Vacation");

            NumberTravelers.Items.Add("1");
            NumberTravelers.Items.Add("2");
            NumberTravelers.Items.Add("3");
            NumberTravelers.Items.Add("4");
            NumberTravelers.Items.Add("5");
            NumberTravelers.Items.Add("6");
            NumberTravelers.Items.Add("7");
            NumberTravelers.Items.Add("8");
            NumberTravelers.Items.Add("9");
            NumberTravelers.Items.Add("10");

           
            cbTravelTo.ItemsSource = Enum.GetValues(typeof(Country));
        }

        private void NumberTravelers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TravelType.SelectedItem == "Work trip")
            {
                DetailsOfTrip.Visibility = Visibility.Visible;
                WriteDetailsOfTrip.Visibility = Visibility.Visible;
                AllInclusiveText.Visibility = Visibility.Hidden;
                AllInclusiveBox.Visibility = Visibility.Hidden;

            }
            else if (TravelType.SelectedItem == "Vacation")
            {
                AllInclusiveText.Visibility = Visibility.Visible;
                AllInclusiveBox.Visibility = Visibility.Visible;
                DetailsOfTrip.Visibility = Visibility.Hidden;
                WriteDetailsOfTrip.Visibility = Visibility.Hidden;
            }

               
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new TravelsWindow();  
            travelsWindow.Show();
            Close();
        }

        

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            IUser u = UserManager.SignedInUser;
            User user = u as User;
            
            bool CityTwo = City2.Text.Trim().Length > 0;
            bool Travelers = NumberTravelers.SelectedItem != null;      
            bool CountryTo = cbTravelTo.SelectedItem != null;
            bool TypeOfTrip = TravelType.SelectedItem != null;

            if (CityTwo && Travelers  && CountryTo && TypeOfTrip)
            {
                if (TravelType.SelectedItem == "Work trip")
                {
                    if (string.IsNullOrWhiteSpace(WriteDetailsOfTrip.Text))
                    {
                        ShowErrorMessage("Please put in meeting details");
                        return;
                    }
                }


                
                Country countryTo = (Country)cbTravelTo.SelectedItem;
                string typeOfTrip = TravelType.SelectedItem.ToString();

                Travel travel = CreateTravel(countryTo, City2.Text, int.Parse(NumberTravelers.SelectedItem.ToString()), typeOfTrip);

                if (travel != null)
                {
                    user = (User)UserManager.SignedInUser;
                    user.Travels.Add(travel);

                    TravelsWindow travelsWindow = new TravelsWindow();
                    travelsWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to add travel");
                }
            }
            else
            {
                ShowErrorMessage("Please put in all info");
            }

            void ShowErrorMessage(string message)
            {
                MessageBox.Show(message, "Error");
            }

            Travel CreateTravel (Country countryTo, string cityTwo, int travelers, string tripType)
            {
                if (tripType == "Vacation")
                {
                    Vacation vacation = new Vacation((bool)AllInclusiveBox.IsChecked, cityTwo, countryTo, travelers);
                    return vacation;

                }
                else if (tripType == "Work trip")
                {
                    WorkTrip workTrip = new WorkTrip(WriteDetailsOfTrip: WriteDetailsOfTrip.Text, cbCountryTo: countryTo, cityTwo: cityTwo, travelers: travelers);
                    return workTrip;
                }
                return null;
            }



        }
    }
}
