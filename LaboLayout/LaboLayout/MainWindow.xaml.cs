using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LaboLayout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddCheckBox();
        }

        private void AddCheckBox()
        {
            CheckBox newCb = new CheckBox();
            List<string> diplomas = new List<string>() { "Secundair", "Graduaat", "Bachelor", "Master" };
            foreach (string diploma in diplomas)
            {
                newCb = new CheckBox();
                newCb.Content = diploma;
                newCb.Checked += OnCheckedChanged;
                newCb.Unchecked += OnCheckedChanged;
                checkBoxStackPanel.Children.Add(newCb);
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearInput();
        }

        private void ClearInput()
        {
            firstNameTextBox.Text = string.Empty;
            lastNameTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Registratie sutdent succesvol");
            ClearInput();
        }

        private void OnCheckedChanged(object sender, RoutedEventArgs e)
        {
            //if (sender is ToggleButton toggle)
            //{
            //    toggle.FontWeight = toggle.IsChecked == true ? FontWeights.Bold : FontWeights.Normal;
            //}
            if (sender is RadioButton rb)
            {
                rb.FontWeight = rb.IsChecked == true ? FontWeights.Bold : FontWeights.Regular;
            }
            else
            {
                ((CheckBox)sender).FontWeight = ((CheckBox)sender).IsChecked == true ? FontWeights.Bold : FontWeights.Regular;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dateLabel.Content = DateTime.Now.ToLongDateString();
            timeLabel.Content = DateTime.Now.ToLongTimeString();
            pxlImage.Source = new BitmapImage(new Uri("https://pxl-digital.pxl.be/web/image/1811-b4b5a8f4/logo_pxl_digital.png"));
        }
    }
}