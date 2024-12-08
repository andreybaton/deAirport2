using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
//using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.IO;
using iText.Kernel.Font;
using iText.IO.Font;


namespace deAirport2
{
    /// <summary>
    /// Interaction logic for FlightDetailsWindow.xaml
    /// </summary>
    public partial class FlightDetailsWindow : Window
    {
        private readonly FlightDetails flightDetails;
        public FlightDetailsWindow(FlightDetails flightDetails)
        {
            InitializeComponent();
            this.flightDetails = flightDetails;
            //string seat = flightDetails.Seat;
            int chislo = Convert.ToInt32(flightDetails.Seat);
            int col = chislo / 10;
            string row = (chislo % 10).ToString();
            char colchar = (char)('A' + col - 1);
            string seatstr = colchar + row;
            //MessageBox.Show(seatete);
            flightDetails.Seat = seatstr;
            DataContext = flightDetails;

            
        }
        public void ExportToPdf()
        {
            string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "FlightTicket.pdf");
            string fontPath = @"C:\Windows\Fonts\arial.ttf";
            using (PdfWriter writer = new PdfWriter(filePath))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                   // string idFlight = flightDetails.;
                    Document document = new Document(pdf);

                    PdfFont font = PdfFontFactory.CreateFont(fontPath,PdfEncodings.IDENTITY_H);
                    document.SetFont(font); 

                    document.Add(new Paragraph("Электронный билет").SetFontSize(18).SimulateBold());
                    document.Add(new Paragraph($"Номер рейса: {flightDetails.FlightNumber}"));
                    document.Add(new Paragraph($"Время отправления: {flightDetails.DepartureTime}"));
                    document.Add(new Paragraph($"Место отправления: {flightDetails.Departure}"));
                    document.Add(new Paragraph($"Время полета: {flightDetails.Duration}"));
                    document.Add(new Paragraph($"Место прибытия: {flightDetails.Destination}"));
                    document.Add(new Paragraph($"Место в самолете: {flightDetails.Seat}"));
                    //document.Add(new Paragraph($""));

                    document.Add(new Paragraph("\n Спасибо, что выбрали нашу авиакомпанию!")
                        .SetFontSize(12)
                        //.SetFontFamily(iText.Kernel.Font.
                        );
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ExportToPdf();
            MessageBox.Show("Ваш билет успешно загружен на рабочий стол");
        }
    }
}
