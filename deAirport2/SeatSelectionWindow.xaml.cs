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
using System.Windows.Controls.Primitives;

namespace deAirport2
{
    /// <summary>
    /// Interaction logic for SeatSelectionWindow.xaml
    /// </summary>
    public partial class SeatSelectionWindow : Window
    {
        public int SelectedSeat; // Хранит выбранное место
        public string SelectedSeatName;
        public SeatSelectionWindow()
        {
            InitializeComponent();
        }

        // Событие при выборе места
        private void Seat_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as ToggleButton;
            if (button != null)
            {
                SelectedSeatName = (string)button.Content;
                int btncntnt = 0;
                if (SelectedSeatName == "A1")
                    btncntnt = 11;
                else if (SelectedSeatName == "A2")
                    btncntnt = 12;
                else if(SelectedSeatName == "B1")
                    btncntnt = 21;
                else if(SelectedSeatName == "B2")
                    btncntnt = 22;
                else if(SelectedSeatName == "C1")
                    btncntnt = 31;
                else if(SelectedSeatName == "C2")
                    btncntnt = 32;
                else if(SelectedSeatName == "D1")
                    btncntnt = 41;
                else if(SelectedSeatName == "D2")
                    btncntnt = 42;
                else if(SelectedSeatName == "E1")
                    btncntnt = 51;
                else if(SelectedSeatName == "E2")
                    btncntnt = 52;
                else if(SelectedSeatName == "F1")
                    btncntnt = 61;
                else if(SelectedSeatName == "F2")
                    btncntnt = 62;
                SelectedSeat = btncntnt;
            }
        }

        // Подтверждение выбора
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedSeat.ToString()))
            {
                MessageBox.Show("Пожалуйста, выберите место!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBox.Show($"Вы выбрали место: {SelectedSeatName}", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            // Закрыть окно
            this.Close();
        }
    }
    //public class SeatSelectionViewModel : INotifyPropertyChanged
    //{
    //    private string _selectedSeat;

    //    public ObservableCollection<string> AvailableSeats { get; set; }
    //    public string SelectedSeat
    //    {
    //        get => _selectedSeat;
    //        set { _selectedSeat = value; OnPropertyChanged(); }
    //    }

    //    public RelayCommand ConfirmSeatCommand { get; }

    //    public SeatSelectionViewModel(ObservableCollection<string> availableSeats)
    //    {
    //        AvailableSeats = availableSeats;
    //        ConfirmSeatCommand = new RelayCommand(ConfirmSeat);
    //    }

    //    private void ConfirmSeat()
    //    {
    //        if (string.IsNullOrEmpty(SelectedSeat))
    //        {
    //            MessageBox.Show("Пожалуйста, выберите место.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
    //            return;
    //        }

    //        // Закрываем окно после успешного выбора
    //        Application.Current.Windows
    //            .OfType<SeatSelectionWindow>()
    //            .FirstOrDefault()?.Close();
    //    }

    //    public event PropertyChangedEventHandler PropertyChanged;
    //    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    }
    //}
}
