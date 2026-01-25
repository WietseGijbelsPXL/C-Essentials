using System.Security.Cryptography;
using System.Text;
using System.Transactions;
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

namespace Rekensommenoefening
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random _rng = new Random();
        private int _expectedResult;
       private DispatcherTimer _stopWatch = new DispatcherTimer();
        DateTime _stopWatchBegin;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Range_TextChanged(object sender, TextChangedEventArgs e)
        {
            //string name = (string)sender.GetType().GetProperty("Name").GetValue(sender, null);

            TextBox textBox = (TextBox)sender;
            if (!int.TryParse(textBox.Text, out int range))
            {
                textBox.Background = Brushes.LightCoral;
            }
            else
            {
                if (range < 0 || range > 100) { textBox.Background = Brushes.LightCoral; }
                else { textBox.Background = Brushes.White; }
            }

            if( int.TryParse(firstNumberMaxTextBox.Text, out int firstMax) && int.TryParse(firstNumberMinTextBox.Text, out int firstMin) &&  int.TryParse(secondNumberMaxTextBox.Text, out int secondMax) && int.TryParse(secondNumberMinTextBox.Text, out int secondMin)){
                equalsLabel.IsEnabled = (firstMax >= firstMin && secondMax >= secondMin) ? equalsLabel.IsEnabled = true : equalsLabel.IsEnabled = false; }
        }

        private void Range_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.NumPad0 && e.Key != Key.NumPad1 && e.Key != Key.NumPad2 && e.Key != Key.NumPad3 && e.Key != Key.NumPad4 && e.Key != Key.NumPad5 && e.Key != Key.NumPad6 && e.Key != Key.NumPad7 && e.Key != Key.NumPad8 && e.Key != Key.NumPad9)
            {
                e.Handled = true;
            }
        }

        private void equalsLabel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           if( e.ChangedButton == MouseButton.Left)
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
            do
            {
                do
                {
                    //TODO: generate random numbers
                    number1 = _rng.Next(int.Parse(firstNumberMinTextBox.Text), int.Parse(firstNumberMaxTextBox.Text)+1);
                    number2 = _rng.Next(int.Parse(secondNumberMinTextBox.Text), int.Parse(secondNumberMaxTextBox.Text)+1);

                    //TODO: calculate result and store the value in _expectedResult

                    firstNumberLabel.Content = number1.ToString();
                    operatorLabel.Content = GetRandomOperator();
                    secondNumberLabel.Content = number2.ToString();
                    if (operatorLabel.Content.ToString() == "+")
                    {
                        _expectedResult = number1 + number2;
                    }
                    else { _expectedResult = number1 - number2; }
                } while (_expectedResult < 0 && disallowNegativeRadioButton.IsChecked == true);
            } while (applyMaximumRadioButton.IsChecked == true && int.Parse(maximumResultTextBox.Text) > _expectedResult);
                //TODO: call InitStopWatch
                InitStopWatch();
            resultTextBox.Focus();
        }

        private void InitStopWatch()
        {
            _stopWatchBegin = DateTime.Now;
            _stopWatch.Interval = TimeSpan.FromMilliseconds(1);
            _stopWatch.Tick += StopWatch_Tick;
            _stopWatch.Start();
        }
        private void StopWatch_Tick(object? sender, EventArgs e)
        {

            timerLabel.Content = (DateTime.Now - _stopWatchBegin).ToString();
        }

        private void resultTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (e.Key == Key.Enter)
            {
                if (CheckResult(textBox))
                {
                    resultTextBox.IsEnabled = false;
                    _stopWatch.Stop();
                }
                else { resultTextBox.Focus(); }

            }
        }
        private bool CheckResult(TextBox textBox)
        {
            //TODO:
            //check if the input from resultTextBox is a number (TIP: use TryParse)
            if(int.TryParse(textBox.Text, out int number))
            {
               if( number == _expectedResult)
               {
                    textBox.Background = Brushes.LightGreen;
                    return true;
               }
            }
            //check if the input is equal to _expectedResult
            //change the backgroundcolor to lightgreen or lightcoral
            textBox.Background = Brushes.LightCoral;
            return false;
        }

        private void showTimeButton_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show(DateTime.Now.ToLongDateString(), "Datum en tijd", MessageBoxButton.OK, MessageBoxImage.Information );
        }
        private string GetRandomOperator()
        {
            if (addOperatorCheckBox.IsChecked == true && subtractOperatorCheckBox.IsChecked == true)
            {
                int check = _rng.Next(0, 2);
                return (check == 0) ? "+" : "-";
            }
            else if (addOperatorCheckBox.IsChecked == true){ return "+"; }
            return "-";
        }

        private void applyMaximum_Checked(object sender, RoutedEventArgs e)
        {
            if (applyMaximumRadioButton.IsChecked == true) { maximumResultTextBox.IsEnabled = true; }
            else {maximumResultTextBox.IsEnabled = false;}    
        }

    }
}