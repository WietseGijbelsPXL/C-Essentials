using Login.Models;
using Login.Services;
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

namespace Login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int x = 3;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            UserManager userManager = new UserManager();
            Registration registration = new Registration(userNameTextBox.Text, passwordPasswordBox.Password);
            if (userManager.TryLogin(registration))
            {
                errorTextBlock.Foreground = Brushes.Green;
                errorTextBlock.Text = "Login geslaagd.";
            }
            else
            {
                x --;
                errorTextBlock.Foreground = Brushes.Red;
                errorTextBlock.Text = $"Ongeldige gebruikersnaam of wachtwoord (nog {x} pogingen te gaan)";
                if (x == 0)
                {
                    loginButton.IsEnabled = false;
                }
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void userNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (userNameTextBox.Text == "")
            {
                errorTextBlock.Foreground = Brushes.Gray;
                errorTextBlock.Text = "Geef je gebruikersnaam.";
            }
        }

        private void passwordPasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (passwordPasswordBox.Password == "")
            {
                errorTextBlock.Foreground = Brushes.Gray;
                errorTextBlock.Text = "Geef je wachtwoord.";
            }
        }
    }
}