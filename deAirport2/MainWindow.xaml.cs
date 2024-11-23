using deAirport2;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Linq;

//using (MyDataBaseКольцоваContext db = new MyDataBaseКольцоваContext())
//{
//    var users = db.Авиакомпанииs.ToList();
//    //foreach (var user in users)
//    //{
//    //    MessageBox.Show(user.ШтабКвартира);
//    //}
//}



namespace deAirport2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

    }

    public class FlightDetails
    {
        public string FlightNumber { get; set; }
        public string Seat {  get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public string DepartureTime { get; set; }
        public string Duration { get; set; }
    }
    public class MainViewModel : INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<string> _companyName;
        public ObservableCollection<string> Headquarters
        {
            get => _companyName;
            set { _companyName = value; OnPropertyChanged(); }
        }
        private string _selectedShtab;
        private string _userCode;
        private string _ticketCode;
        private FlightDetails _flightDetails;
        public string SelectedHeadquarter
        {
            get => _selectedShtab;
            set { _selectedShtab = value; OnPropertyChanged(); }
        }
        public string UserCode
        {
            get => _userCode;
            set { _userCode = value; OnPropertyChanged(); }
        }

        // Код билета
        public string TicketCode
        {
            get => _ticketCode;
            set { _ticketCode = value; OnPropertyChanged(); }
        }
        public FlightDetails FlightDetails
        {
            get => _flightDetails;
            set { _flightDetails = value; OnPropertyChanged(); }
        }
        public RelayCommand ValidateRegistrationCommand { get; }
        //public class FlightDetails
        //{
        //    public string FlightNumber { get; set; }
        //    public DateTime DepartureTime { get; set; }
        //    public string Destination { get; set; }
        //}
        public MainViewModel()
        {
            LoadShtabs();
            ValidateRegistrationCommand = new RelayCommand(ValidateRegistration);
        }
        private void ValidateRegistration()
        {
            using (var context = new MyDataBaseКольцоваContext())
            {
                var ticket = context.Билетыs
                    .FirstOrDefault(t => t.НомерБилета.ToString() == TicketCode && t.КодПассажира.ToString() == UserCode);
                if (ticket != null) 
                { 
                    var flight = context.Рейсыs
                        .FirstOrDefault(f=>f.НомерРейса == ticket.НомерРейса);
                    if (flight != null)
                    {
                        var airline = context.Авиакомпанииs
                            .FirstOrDefault(a => a.КодАвиакомпании == flight.КодАвиакомпании && a.НазваниеАвиакомпании == SelectedHeadquarter);
                        if (airline != null)
                        {
                            var availableSeats = new ObservableCollection<string>();
                                //(
                        //    context.Билетыs
                        //        .Where(t => t.НомерРейса == flight.НомерРейса && string.IsNullOrEmpty(t.НомерМеста.ToString()))
                        //        .Select(t => t.НомерМеста.ToString() ?? "Место " + t.НомерБилета)
                        //);
                            for (int i = 0; i<101;i++)
                                availableSeats.Add(i.ToString());
                            var seatSelectionViewModel = new SeatSelectionViewModel(availableSeats);
                            var seatSelectionWindow = new SeatSelectionWindow(seatSelectionViewModel);
                            seatSelectionWindow.ShowDialog();

                            if (string.IsNullOrEmpty(seatSelectionViewModel.SelectedSeat))
                            {
                                MessageBox.Show("Выбор места не завершен.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                                return;
                            }
                            
                            ticket.НомерМеста = Convert.ToInt32(seatSelectionViewModel.SelectedSeat);
                            context.SaveChanges();

                            FlightDetails = new FlightDetails
                            {
                                FlightNumber = flight.НомерРейса,
                                Seat = ticket.НомерМеста.ToString(),
                                Departure = flight.ПунктОтправления,
                                Destination = flight.ПунктПрибытия,
                                DepartureTime = flight.ВремяВылета,
                                Duration = flight.ВремяПути
                            };
                            var detailsWindow = new FlightDetailsWindow(FlightDetails);
                            detailsWindow.Show();
                            return;
                        }
                    }
                }
                MessageBox.Show("регистрация не пройдена");
                //var flight = context.Рейсыs
                //    .FirstOrDefault(f => f.КодАвиакомпании == SelectedShtab &&
                //                         f. == UserCode &&
                //                         f.TicketCode == TicketCode);

                //if (flight != null)
                //{
                //    // Успешная регистрация
                //    FlightDetails = new FlightDetails
                //    {
                //        FlightNumber = flight.FlightNumber,
                //        DepartureTime = flight.DepartureTime,
                //        Destination = flight.Destination
                //    };

                //    // Открытие нового окна
                //    var detailsWindow = new FlightDetailsWindow(FlightDetails);
                //    detailsWindow.Show();
                //}
                //else
                //{
                //    // Регистрация не удалась
                //    MessageBox.Show("Регистрация не пройдена. Проверьте данные.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                //}
            }
        }
        private void LoadShtabs()
        {
            using (var context = new MyDataBaseКольцоваContext())
            {
                // Получаем уникальные названия
                Headquarters = new ObservableCollection<string>(
                    context.Авиакомпанииs
                           .Select(a => a.НазваниеАвиакомпании!) // Предполагается, что поле называется НазваниеАвиакомпании
                           .Distinct()
                           .OrderBy(h => h)
                           .ToList()
                );
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        

        // Данные полета
        
        
    }
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}