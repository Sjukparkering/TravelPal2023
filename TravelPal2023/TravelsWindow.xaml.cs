using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TravelPal2023
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        public TravelsWindow()
        {
            InitializeComponent();
            // Hämta den nuvarande inloggade användaren
            // Displaya dens namn

            UsernameLabel.Content = UserManager.SignedInUser.Username;

            // Om det är en vanlig user
            // Hämta dens resor
            // Lägg till alla resor i ListView:en

            if(UserManager.SignedInUser is User)
            {
                foreach(var travel in ((User)UserManager.SignedInUser).Travels)
                {
                    ListViewItem item = new();
                    item.Content = travel.countryTo;
                    item.Tag = travel;

                    AddedTravels.Items.Add(item);
                }
            }
            else if (UserManager.SignedInUser is Admin)
            {
                List<Travel> allTravels = UserManager.GetAllUserTravels();

                foreach (var travel in allTravels)
                {
                    ListViewItem item = new();
                    item.Content = travel.countryTo;
                    item.Tag = travel;

                    AddedTravels.Items.Add(item);

                }
            }

        }

        private void BtnDetails_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem? selectedItem = AddedTravels.SelectedItem as ListViewItem;
            if(selectedItem != null)
            {
                Travel selectedTravel = (Travel)selectedItem.Tag;

                TravelDetailsWindow travelDetailsWindow = new(selectedTravel);
                travelDetailsWindow.Show();
                Close();
            }

        }

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {
            InfoTravelPal InfoTravelPal = new InfoTravelPal();
            InfoTravelPal.Show();
            this.Close();
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = (ListViewItem)AddedTravels.SelectedItem;

            if (selectedItem == null)
            {
                MessageBox.Show("Please select an item to remove.");
            }
            else
            {
                Travel travel = (Travel)selectedItem.Tag;

                AddedTravels.Items.Remove(selectedItem);

                if (UserManager.SignedInUser is User)
                {
                    User user = (User)UserManager.SignedInUser;
                    user.Travels.Remove(travel);
                }
                else if (UserManager.SignedInUser is Admin)
                {
                    // Ta bort resan från användaren som har den
                    UserManager.AdminRemoveTravel(travel);
                }
            }
        }
       






    private void AddTravel_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow addTravelWindow = new AddTravelWindow();
            addTravelWindow.Show();
            this.Close();

        }

        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }


    }
}
