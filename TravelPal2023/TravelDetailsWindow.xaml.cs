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
    /// Interaction logic for TravelDetailsWindow.xaml
    /// </summary>
    public partial class TravelDetailsWindow : Window
    {
        internal Travel PickedTravel { get; set; }
        public TravelDetailsWindow(Travel travel)
        {
            InitializeComponent();
            ListViewItem item = new();
            item.Tag = travel;
            item.Content = travel.GetInfo();
            SavedTrips.Items.Add(item);
           

        }

        private void BtnBackDetails_Click(object sender, RoutedEventArgs e)
        {                
         
         TravelsWindow travelsWindow = new TravelsWindow();
            this.Close();  
         travelsWindow.Show();        
        }
    }
}
