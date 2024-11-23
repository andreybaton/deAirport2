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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace deAirport2
{
    /// <summary>
    /// Interaction logic for SeatSelectionWindow.xaml
    /// </summary>
    public partial class SeatSelectionWindow : Window
    {
        public SeatSelectionWindow(SeatSelectionViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
    public class SeatSelectionViewModel : INotifyPropertyChanged
    {
        private string _selectedSeat;

        public ObservableCollection<string> AvailableSeats { get; set; }
        public string SelectedSeat
        {
            get => _selectedSeat;
            set { _selectedSeat = value; OnPropertyChanged(); }
        }

        public RelayCommand ConfirmSeatCommand { get; }

        public SeatSelectionViewModel(ObservableCollection<string> availableSeats)
        {
            AvailableSeats = availableSeats;
            ConfirmSeatCommand = new RelayCommand(ConfirmSeat);
        }

        private void ConfirmSeat()
        {
            if (string.IsNullOrEmpty(SelectedSeat))
            {
                MessageBox.Show("Пожалуйста, выберите место.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Закрываем окно после успешного выбора
            Application.Current.Windows
                .OfType<SeatSelectionWindow>()
                .FirstOrDefault()?.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
