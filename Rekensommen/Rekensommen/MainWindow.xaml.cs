using System.Globalization;
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

namespace Rekensommen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _expectedResult;
        DispatcherTimer _stopWatch = new DispatcherTimer();
        TimeSpan _elapsed = TimeSpan.Zero;

        public MainWindow()
        {
            InitializeComponent();
            timerLabel.Content = _elapsed.ToString(@"mm\:ss\.fff");
        }

        private void Range_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox rangeTextBox = (TextBox)sender;
            string content = (string)rangeTextBox.Text;
            if (!int.TryParse(content, out int result) || result < 0 || result > 100)
            {
                rangeTextBox.Background = Brushes.LightCoral;
            }
            else
            {
                rangeTextBox.Background = Brushes.Transparent;
            }
        }

        private void Range_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                e.Handled = false;
            }
            else if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void equalsLabel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                StartExercise();
            }
        }

        private void StartExercise()
        {
            resultTextBox.Clear();
            resultTextBox.Background = Brushes.White;
            resultTextBox.IsEnabled = true;

            int number1 = 0;
            int number2 = 0;

            Random random = new Random();

            string operatorr = GetRandomOperator();

            //_expectedResult = operatorr == "+" ? number1 + number2 : number1 - number2;

            /*if (disallowNegativeOutcomeRadioButton.IsChecked == true && applyMaximumRadioButton.IsChecked == true)
            {
                do
                {
                    number1 = random.Next(int.Parse(firstNumberMinTextBox.Text), int.Parse(firstNumberMaxTextBox.Text) + 1);
                    number2 = random.Next(int.Parse(secondNumberMinTextBox.Text), int.Parse(secondNumberMaxTextBox.Text) + 1);
                    _expectedResult = operatorr == "+" ? number1 + number2 : number1 - number2;
                } while (_expectedResult < 0 || int.Parse(maximumResultTextBox.Text) < _expectedResult);
            }
            else if (disallowNegativeOutcomeRadioButton.IsChecked == true && applyMaximumRadioButton.IsChecked == false)
            {
                do
                {
                    number1 = random.Next(int.Parse(firstNumberMinTextBox.Text), int.Parse(firstNumberMaxTextBox.Text) + 1);
                    number2 = random.Next(int.Parse(secondNumberMinTextBox.Text), int.Parse(secondNumberMaxTextBox.Text) + 1);
                    _expectedResult = operatorr == "+" ? number1 + number2 : number1 - number2;
                } while (_expectedResult < 0);
            }
            else if (disallowNegativeOutcomeRadioButton.IsChecked == false && applyMaximumRadioButton.IsChecked == true)
            {
                do
                {
                    number1 = random.Next(int.Parse(firstNumberMinTextBox.Text), int.Parse(firstNumberMaxTextBox.Text) + 1);
                    number2 = random.Next(int.Parse(secondNumberMinTextBox.Text), int.Parse(secondNumberMaxTextBox.Text) + 1);
                    _expectedResult = operatorr == "+" ? number1 + number2 : number1 - number2;
                } while (int.Parse(maximumResultTextBox.Text) < _expectedResult);
            }
            else
            {
                number1 = random.Next(int.Parse(firstNumberMinTextBox.Text), int.Parse(firstNumberMaxTextBox.Text) + 1);
                number2 = random.Next(int.Parse(secondNumberMinTextBox.Text), int.Parse(secondNumberMaxTextBox.Text) + 1);
                _expectedResult = operatorr == "+" ? number1 + number2 : number1 - number2;
            }*/

            do
            {
                do
                {
                    number1 = random.Next(int.Parse(firstNumberMinTextBox.Text), int.Parse(firstNumberMaxTextBox.Text) + 1);
                    number2 = random.Next(int.Parse(secondNumberMinTextBox.Text), int.Parse(secondNumberMaxTextBox.Text) + 1);
                    _expectedResult = operatorr == "+" ? number1 + number2 : number1 - number2;
                } while (disallowNegativeOutcomeRadioButton.IsChecked == true && _expectedResult < 0);
            }
            while (applyMaximumRadioButton.IsChecked == true && _expectedResult > int.Parse(maximumResultTextBox.Text));

            firstNumberLabel.Content = number1.ToString();
            operatorLabel.Content = operatorr;
            secondNumberLabel.Content = number2.ToString();

            InitStopWatch();

            resultTextBox.Focus();
        }

        private void resultTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (CheckResult((TextBox)sender))
                {
                    resultTextBox.IsEnabled = false;
                }
                else
                    resultTextBox.SelectAll();
            }
        }

        private bool CheckResult(TextBox textBox)
        {
            if (int.TryParse(resultTextBox.Text, out int result) && result == _expectedResult)
            {
                resultTextBox.Background = Brushes.LightGreen;
                _stopWatch.Stop();
                return true;
            }
            else
            {
                resultTextBox.Background = Brushes.LightCoral;
                return false;
            }
        }

        private void showTimeButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(DateTime.Now.ToString("ddd dd MMMM yyy hh:mm"), "Datum en tijd", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void InitStopWatch()
        {
            _elapsed = TimeSpan.Zero;
            _stopWatch.Interval = TimeSpan.FromMilliseconds(1);
            _stopWatch.Tick += StopWatch_Tick;
            _stopWatch.Start();
        }

        private void StopWatch_Tick(object sender, EventArgs e)
        {
            _elapsed += _stopWatch.Interval;
            timerLabel.Content = _elapsed.ToString(@"mm\:ss\.fff");
        }

        private string GetRandomOperator()
        {
            Random random = new Random();
            if (addOperatorCheckBox.IsChecked == true && subtractOperatorCheckBox.IsChecked == true)
            {
                return random.Next(0, 2) == 1 ? "-" : "+";
            }
            else if (addOperatorCheckBox.IsChecked == false)
            {
                return "-";
            }
            else
            {
                return "+";
            }
        }

        private void applyMaximumRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            maximumResultTextBox.IsEnabled = true;
        }

        private void applyMaximumRadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            maximumResultTextBox.IsEnabled = false;
        }
    }
}