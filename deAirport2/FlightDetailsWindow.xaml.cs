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

namespace deAirport2
{
    /// <summary>
    /// Interaction logic for FlightDetailsWindow.xaml
    /// </summary>
    public partial class FlightDetailsWindow : Window
    {
        public FlightDetailsWindow(FlightDetails flightDetails)
        {
            InitializeComponent();
            //string seat = flightDetails.Seat;
            int chislo = Convert.ToInt32(flightDetails.Seat);
            int col = chislo / 10;
            string row = (chislo % 10).ToString();
            char colchar = (char)('A' + col - 1);
            string seatstr = colchar + row;
            //MessageBox.Show(seatete);
            flightDetails.Seat = seatstr;
            DataContext = flightDetails;
            
            //if (flightDetails.Seat == "11")
            //    flightDetails.Seat = "A1";
            //else if (flightDetails.Seat == "12")
            //    flightDetails.Seat = "A2";
            //else if (flightDetails.Seat == "21")
            //    flightDetails.Seat = "B1";
            //else if (flightDetails.Seat == "22")
            //    flightDetails.Seat = "B2";
            //else if (flightDetails.Seat == "31")
            //    flightDetails.Seat = "C1";
            //else if (flightDetails.Seat == "32")
            //    flightDetails.Seat = "C2";
            //else if (flightDetails.Seat == "41")
            //    flightDetails.Seat = "D1";
            //else if (flightDetails.Seat == "42")
            //    flightDetails.Seat = "D2";
            //else if (flightDetails.Seat == "51")
            //    flightDetails.Seat = "E1";
            //else if (flightDetails.Seat == "52")
            //    flightDetails.Seat = "E2";
            //else if (flightDetails.Seat == "61")
            //    flightDetails.Seat = "F1";
            //else if (flightDetails.Seat == "62")
            //    flightDetails.Seat = "F1";
        }
    }
}
