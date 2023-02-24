using MySql.Data.MySqlClient;
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
using TicketBooking.Models;

namespace TicketBooking.Views.Pages
{
    /// <summary>
    /// Interaction logic for BookingCard.xaml
    /// </summary>
    public partial class BookingCard : UserControl
    {
        private Flights currentFlight;

        public BookingCard(Flights flights)
        {
            InitializeComponent();

            currentFlight = flights;

            DataContext = currentFlight;
        }

        private void GoToBookedPage_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection mySqlConnection = new MySqlConnection("Server = 127.0.0.1; Port=3306; Database=ticketbooking; Uid=root");
            mySqlConnection.Open();
            string sql = $"INSERT INTO booking(UserID, FlightID) VALUES({MainWindow.users.ID},{currentFlight.ID})";
            MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
            MySqlDataReader reader = command.ExecuteReader();

            reader.Close();
            mySqlConnection.Close();
        }
    }
}
