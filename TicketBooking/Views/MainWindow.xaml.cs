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
using MySql.Data.MySqlClient;
using TicketBooking.Models;
using TicketBooking.Views.Pages;

namespace TicketBooking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Users users;
        private Users user;

        public MainWindow()
        {
            InitializeComponent();

            MySqlConnection mySqlConnection = new MySqlConnection("Server = 127.0.0.1; Port=3306; Database=ticketbooking; Uid=root");
            mySqlConnection.Open();
            string sql = "SELECT * FROM Users WHERE ID=1";
            MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                user = new Users()
                {
                    ID = Convert.ToInt32(reader[0]),
                    Name = Convert.ToString(reader[1]),
                    Surname = Convert.ToString(reader[2]),
                    Patronymic = Convert.ToString(reader[3]),
                    Email = Convert.ToString(reader[4]),
                    Password = Convert.ToString(reader[5]),
                    NumberPhone = Convert.ToString(reader[6])
                };

                users = user;
            }
            reader.Close();
            mySqlConnection.Close();

            FrameManager.Frame = MainFrame;
        }

        private void GoToProfilePage_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Frame.Navigate(new ProfilPage(user));
        }

        private void GoToBookingPage_Click(object sender, RoutedEventArgs e)
        {
            List<Flights> flights = new List<Flights>();

            MySqlConnection mySqlConnection = new MySqlConnection("Server = 127.0.0.1; Port=3306; Database=ticketbooking; Uid=root");
            mySqlConnection.Open();
            string sql = "SELECT * FROM flights, plane WHERE flights.PlaneID = plane.ID;";
            MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                flights.Add(new Flights()
                {
                    ID = Convert.ToInt32(reader[0]),
                    StartStation = Convert.ToString(reader[1]),
                    EndStation = Convert.ToString(reader[2]),
                    DepartureDate = Convert.ToDateTime(reader[3]),
                    DateOfStay = Convert.ToDateTime(reader[4]),
                    Price = Convert.ToInt32(reader[5]),
                    Plane = new Plane()
                    {
                        ID = Convert.ToInt32(reader[7]),
                        NamePlane = Convert.ToString(reader[8]),
                        NumberOfVacancies = Convert.ToInt32(reader[9]),
                        IsFree = Convert.ToBoolean(reader[10])
                    }
                });
            }
            reader.Close();
            mySqlConnection.Close(); 

            FrameManager.Frame.Navigate(new BookingListViewPage(flights));
        }

        private void GoToBookedPage_Click(object sender, RoutedEventArgs e)
        {
            List<Flights> flights = new List<Flights>();

            MySqlConnection mySqlConnection = new MySqlConnection("Server = 127.0.0.1; Port=3306; Database=ticketbooking; Uid=root");
            mySqlConnection.Open();
            string sql = $"SELECT flights.StartStation, flights.EndStation, flights.DepartureDate, flights.DateOfStay, flights.Price, plane.NamePlane FROM booking, flights, plane WHERE booking.UserID={users.ID} AND booking.FlightID=flights.ID AND flights.PlaneID=plane.ID";
            MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                flights.Add(new Flights()
                {
                    StartStation = Convert.ToString(reader[0]),
                    EndStation = Convert.ToString(reader[1]),
                    DepartureDate = Convert.ToDateTime(reader[2]),
                    DateOfStay = Convert.ToDateTime(reader[3]),
                    Price = Convert.ToInt32(reader[4]),
                    Plane = new Plane()
                    {
                        NamePlane = Convert.ToString(reader[5])
                    }
                });
            }

            reader.Close();
            mySqlConnection.Close();

            FrameManager.Frame.Navigate(new BookedPage(flights));
        }
    }
}
