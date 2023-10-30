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
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        public TravelsWindow()
        {
            InitializeComponent();

            UsernameLabel.Content = UserManager.SignedInUser.Username;
            // Hämta den nuvarande inloggade användaren
            // Displaya dens namn

            // Om det är en vanlig user
            // Hämta dens resor
            // Lägg till alla resor i ListView:en

            // Om det är en admin
            // Hämta alla resor
            // Lägg till dom i ListView:en
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }
}
