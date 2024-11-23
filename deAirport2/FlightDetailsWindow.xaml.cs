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
            DataContext = flightDetails;
        }
    }
}
