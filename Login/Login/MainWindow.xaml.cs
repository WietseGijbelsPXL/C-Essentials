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
        UserManager userManager = new UserManager();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowInfo(string message, Brush color)
        {
            errorTextBlock.Text = message;
            errorTextBlock.Foreground = color;
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration(userNameTextBox.Text, passwordPasswordBox.Password);
            if (userManager.TryLogin(registration))
            {
                ShowInfo("Login geslaagd.", Brushes.Green);
            }
            else
            {
                ShowInfo($"Ongeldige gebruikersnaam of wachtwoord (nog {userManager.Counter} pogingen te gaan)", Brushes.Red);
                if (userManager.Counter == 0)
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
                ShowInfo("Geef je gebruikersnaam.", Brushes.Gray);
            }
        }

        private void passwordPasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (passwordPasswordBox.Password == "")
            {
                ShowInfo("Geef je wachtwoord.", Brushes.Gray);
            }
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(userNameTextBox.Text) || string.IsNullOrEmpty(passwordPasswordBox.Password))
            {
                ShowInfo("Gebruikersnaam of wachtwoord leeg.", Brushes.Red);
            }
            else
            {
                if (userManager.Register(userNameTextBox.Text, passwordPasswordBox.Password))
                {
                    ShowInfo("Gebruiker toegevoegd.", Brushes.Green);
                }
            }
        }

        private void ClearScreen(bool ResetCounter = false)
        {
            userNameTextBox.Clear();
            passwordPasswordBox.Clear();
            if (ResetCounter)
            {
                userManager.ResetCounter();
                loginButton.IsEnabled = true;
            }
            userNameTextBox.Focus();
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            if (userManager.Counter == 0)
            {
                ClearScreen(true);
            }
            else
            {
                ClearScreen();
            }
        }
    }
}