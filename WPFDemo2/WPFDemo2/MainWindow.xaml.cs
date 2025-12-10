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

namespace WPFDemo2
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (subscribecCheckBox.IsChecked == true)
            {
                infoLabel.Content = "aangevinkt";
            }

            
        }

        private void subscribecCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            infoLabel.Content = "aangevinkt";
        }

        private void subscribecCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            infoLabel.Content = "uitgevinkt";
        }
    }
}