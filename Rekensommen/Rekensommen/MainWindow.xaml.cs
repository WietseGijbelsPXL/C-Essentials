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

namespace Rekensommen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
            if(e.ChangedButton == MouseButton.Left)
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

            number1 = random.Next(int.Parse(firstNumberMinTextBox.Text), int.Parse(firstNumberMaxTextBox.Text)+1);
            number2 = random.Next(int.Parse(secondNumberMinTextBox.Text), int.Parse(secondNumberMaxTextBox.Text) + 1);
            
            //TODO: calculate result and store the value in _expectedResult

            firstNumberLabel.Content = number1.ToString();
            operatorLabel.Content = "+";
            secondNumberLabel.Content = number2.ToString();

            //TODO: call InitStopWatch

            resultTextBox.Focus();
        }
    }
}