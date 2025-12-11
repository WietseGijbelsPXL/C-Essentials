using Registratie.Models;
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

namespace Registratie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadOlodInListBox(CreateOlodList());
        }

        private List<Olod> CreateOlodList()
        {
            return new List<Olod>()
         {
        new Olod() {
            Name = "C# Essentials",
            Credits = 7
        },
        new Olod() {
            Name = "C# Advanced",
            Credits = 6
        },
        new Olod() {
            Name = "C# Web1",
            Credits = 7
        },
        new Olod() {
            Name = "C# Mobile",
            Credits = 6
        },
        new Olod() {
            Name = "C# Web2",
            Credits = 4
            },
        };
        }

        private void LoadOlodInListBox(List<Olod> olods)
        {
            foreach (Olod olod in olods)
            {
                olodListBox.Items.Add(olod);
            }
        }

        private void olodListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Olod olod = (Olod)olodListBox.SelectedValue;
            int.TryParse(creditsTextBlock.Text, out int totalCredits);
            totalCredits += olod.Credits;
            creditsTextBlock.Text = totalCredits.ToString();

        }
    }
}