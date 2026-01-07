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

namespace WPFDemo_4
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

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = new MenuItem();
            menuItem.Header = "Help";
            MenuItem subMenuItem = new MenuItem();
            subMenuItem.Header = "About";

            subMenuItem.Click += SubMenuItem_Click;

            menuItem.Items.Add(subMenuItem);
            TopMenu.Items.Add(menuItem);
        }

        private void SubMenuItem_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}