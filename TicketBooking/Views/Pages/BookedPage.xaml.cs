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
    /// Interaction logic for BookedPage.xaml
    /// </summary>
    public partial class BookedPage : Page
    {
        List<BookedCard> bookedCards = new List<BookedCard>();

        public BookedPage(List<Flights> flights)
        {
            InitializeComponent();

            foreach(var f in flights)
            {
                bookedCards.Add(new BookedCard(f));
            }

            BookedCards.ItemsSource = bookedCards;
        }
    }
}
