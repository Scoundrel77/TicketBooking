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
    /// Interaction logic for BookingListViewPage.xaml
    /// </summary>
    public partial class BookingListViewPage : Page
    {
        List<BookingCard> bookingCards = new List<BookingCard>();

        public BookingListViewPage(List<Flights> flights)
        {
            InitializeComponent();

            foreach(var f in flights)
            {
                bookingCards.Add(new BookingCard(f));
            }

            BookingCards.ItemsSource = bookingCards;
        }
    }
}
