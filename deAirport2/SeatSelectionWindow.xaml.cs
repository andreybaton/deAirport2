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
                ResetToggleButtons(Seats, button);
                SelectedSeatName = (string)button.Content;
                int btncntnt = 0;
                char columnChar = SelectedSeatName[0];
                int column = char.ToUpper(columnChar) - 'A' + 1;
                int row = Convert.ToInt32(SelectedSeatName[1]);
                btncntnt = (column * 10) + row-48;

                SelectedSeat = btncntnt;
                

            }
        }
        public void ResetToggleButtons(Panel panel, ToggleButton checkedButton)
        {
            foreach (var child in panel.Children)
                if (child is ToggleButton button && button != checkedButton)
                    button.IsChecked = false;
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
    
}
