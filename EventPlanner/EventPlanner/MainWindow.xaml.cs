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
using System.Windows.Threading;

namespace EventPlanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TypeComboBox.Items.Add("Festival");
            TypeComboBox.Items.Add("Orkest");
            TypeComboBox.Items.Add("Opera");
            AddButton.IsEnabled = false;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            timeLabel.Content = DateTime.Now.ToLongTimeString();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NaamTextBox.Text) && !string.IsNullOrWhiteSpace(BezoekersTextBox.Text) && TypeComboBox.SelectedIndex > -1)
            {
                EventListBox.Items.Add(new Event(TypeComboBox.SelectedValue.ToString(), NaamTextBox.Text, int.Parse(BezoekersTextBox.Text)));
            }
            AddButton.IsEnabled = false;

            BezoekersTextBox.Text = string.Empty;
            NaamTextBox.Text = string.Empty;
            TypeComboBox.SelectedIndex = -1;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (EventListBox.SelectedIndex > -1)
            {
                if (MessageBox.Show($"Bent u zeker dat u het {((Event)EventListBox.SelectedItem).Type} {((Event)EventListBox.SelectedItem).Naam} wilt verwijderen?", "Verwijder confirmatie", MessageBoxButton.YesNo, MessageBoxImage.Exclamation, MessageBoxResult.No) == MessageBoxResult.Yes)
                    //EventListBox.Items.Remove(EventListBox.SelectedItem);
                    EventListBox.Items.RemoveAt(EventListBox.SelectedIndex);
            }
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RemoveAllEventsClick(object sender, RoutedEventArgs e)
        {
            EventListBox.Items.Clear();
        }

        private void StandaardClick(object sender, RoutedEventArgs e)
        {
            EventListBox.Items.Add(new Event("Orkest", "Jaarlijks optreden", 100));
        }

        private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EnableAddButtone();
        }

        private void NaamTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableAddButtone();

        }

        private void BezoekersTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableAddButtone();
        }

        private void EnableAddButtone()
        {
            //if (!string.IsNullOrWhiteSpace(NaamTextBox.Text) && !string.IsNullOrWhiteSpace(BezoekersTextBox.Text) && TypeComboBox.SelectedIndex > -1)
            //{
            //    AddButton.IsEnabled = true;
            //}
            //else
            //{
            //    AddButton.IsEnabled = false;
            //}
            AddButton.IsEnabled = (!string.IsNullOrWhiteSpace(NaamTextBox.Text) && !string.IsNullOrWhiteSpace(BezoekersTextBox.Text) && TypeComboBox.SelectedIndex > -1);
        }
    }
}