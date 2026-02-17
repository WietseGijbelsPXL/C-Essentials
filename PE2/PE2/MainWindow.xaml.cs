using PE2.Models;
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

namespace PE2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Customer> _customers;
        List<LicensePlate> _licensePlates;

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            foreach (Customer customer in _customers)
            {
                customerComboBox.Items.Add(customer);
            }
        }

        private void LoadData()
        {
            _customers = new List<Customer>();
            _licensePlates = new List<LicensePlate>();
            Customer customer;
            LicensePlate plate;

            customer = new Customer() { Id = 1, Name = "John Doe" };
            _customers.Add(customer);
            plate = new LicensePlate() { Customer = customer, Plate = "2-ABC-123", Mileage = 12514 };
            _licensePlates.Add(plate);

            customer = new Customer() { Id = 2, Name = "Marcha Uber" };
            _customers.Add(customer);
            plate = new LicensePlate() { Customer = customer, Plate = "1-SFR-854", Mileage = 64258 };
            _licensePlates.Add(plate);

            customer = new Customer() { Id = 3, Name = "Stefanie Rovers" };
            _customers.Add(customer);
            plate = new LicensePlate() { Customer = customer, Plate = "2-HTB-487", Mileage = 458 };
            _licensePlates.Add(plate);
            plate = new LicensePlate() { Customer = customer, Plate = "ROVERS", Mileage = 43125 };
            _licensePlates.Add(plate);
            plate = new LicensePlate() { Customer = customer, Plate = "911-TURBO", Mileage = 8468 };
            _licensePlates.Add(plate);

            customer = new Customer() { Id = 4, Name = "Alex DeWitt" };
            _customers.Add(customer);
            plate = new LicensePlate() { Customer = customer, Plate = "2-KOZ-527", Mileage = 125658 };
            _licensePlates.Add(plate);
        }

        private void customerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customer customer = (Customer)((ComboBox)sender).SelectedValue;
            List<LicensePlate> licensePlates = _licensePlates.FindAll(e => e.Customer == customer);
            FillLIcensePlateListBox(licensePlates);
        }

        private void FillLIcensePlateListBox(List<LicensePlate> licensePlates)
        {
            licensePlateListBox.Items.Clear();

            foreach (LicensePlate licensePlate in licensePlates)
            {
                licensePlateListBox.Items.Add(licensePlate);
            }
        }

        private void EnableStartButton()
        {
            LicensePlate licensePlate = (LicensePlate)(licensePlateListBox.SelectedItem);
            int.TryParse(mileageTextBox.Text, out int mileage);
            if (mileage > licensePlate.Mileage)
            {
                if (defaultRadioButton.IsChecked == true || fastRadioButton.IsChecked == true || superRadioButton.IsChecked == true)
                {
                    startButton.IsEnabled = true;
                }
            }

        }

        private void mileageTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableStartButton();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            EnableStartButton();
        }

        private void licensePlateListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LicensePlate licensePlate = (LicensePlate)((ListBox)sender).SelectedItem;

            if (licensePlate != null)
            {
                chargeSessionsTextBlock.Text = licensePlate.ShowChargingSessions();
                mileageTextBox.Text = String.Empty;
                mileageTextBox.IsEnabled = true;
            }
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            LicensePlate licensePlate = (LicensePlate)licensePlateListBox.SelectedValue;
            int index = licensePlateListBox.SelectedIndex;
            licensePlate.Mileage = int.Parse(mileageTextBox.Text);
            FillLIcensePlateListBox(_licensePlates.FindAll(e => e.Customer == licensePlate.Customer));
            licensePlateListBox.SelectedIndex = index;
            startButton.IsEnabled = false;
            endButton.IsEnabled = true;
            chargingImage.Visibility = Visibility.Visible;
            customerComboBox.IsEnabled = licensePlateListBox.IsEnabled = mileageTextBox.IsEnabled = false;
        }

        private void endButton_Click(object sender, RoutedEventArgs e)
        {
            endButton.IsEnabled = false;
            Random random = new Random();
            int consumption = random.Next(40, 71);
            float cost = CalcutlateCost(consumption);
            ChargeSession newCS = new ChargeSession(consumption, cost, DateTime.Now);
            LicensePlate licensePlate = licensePlateListBox.SelectedItem as LicensePlate;
            licensePlate.ChargeSessions.Add(newCS);
            chargeSessionsTextBlock.Text = licensePlate.ShowChargingSessions();
            customerComboBox.IsEnabled = licensePlateListBox.IsEnabled = mileageTextBox.IsEnabled = true;
        }

        private float CalcutlateCost(int usedPower)
        {
            if (defaultRadioButton.IsChecked == true)
            {
                return 0.4f;
            }
            else if (fastRadioButton.IsChecked == true)
            {
                return 0.6f;
            }
            else
                return 0.9f;
        }
    }
}