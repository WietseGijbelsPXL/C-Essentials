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
            LoadOlodInListBox();
            InitScreen();
        }

        private void InitScreen()
        {
            nameTextBox.Text = string.Empty;
            birthDatePicker.SelectedDate = null;
            mRadioButton.IsChecked = vRadioButton.IsChecked = xRadioButton.IsChecked = secundaryCheckBox.IsChecked = higherCheckBox.IsChecked = false;
            olodListBox.SelectedItems.Clear();
            nameTextBox.Focus();
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

        private void LoadOlodInListBox()
        {
            foreach (Olod olod in CreateOlodList())
            {
                olodListBox.Items.Add(olod);
            }
        }

        private void olodListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int.TryParse(creditsTextBlock.Text, out int totalCredits);

            //if (e.AddedItems.Count != 0)
            //{
            //    Olod addedOlod = (Olod)e.AddedItems[0];
            //    creditsTextBlock.Text = (totalCredits + addedOlod.Credits).ToString();
            //}
            //else
            //{
            //    Olod deletedOlod = (Olod)e.RemovedItems[0];
            //    creditsTextBlock.Text = (totalCredits - deletedOlod.Credits).ToString();
            //}

            int totalCredits = 0;
            foreach (Olod olod in olodListBox.SelectedItems)
            {
                totalCredits += olod.Credits;
            }
            creditsTextBlock.Text = totalCredits.ToString();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                if (birthDatePicker.SelectedDate != null)
                {
                    if (mRadioButton.IsChecked == true || vRadioButton.IsChecked == true || xRadioButton.IsChecked == true)
                    {
                        if (secundaryCheckBox.IsChecked == true || higherCheckBox.IsChecked == true)
                        {
                            Student student = new Student();
                            student.Name = nameTextBox.Text;
                            student.BirthDate = birthDatePicker.SelectedDate.Value;
                            student.Sex = mRadioButton.IsChecked == true ? 'M' : vRadioButton.IsChecked == true ? 'V' : 'X';
                            foreach (Olod olod in olodListBox.SelectedItems)
                            {
                                student.Olods.Add(olod);
                            }
                            studentComboBox.Items.Add(student);
                            InitScreen();
                        }
                    }
                }
            }
        }

        private void studentComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (studentComboBox.SelectedItem != null)
            {
                Student student = (Student)studentComboBox.SelectedItem;
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Naam: {student.Name}");
                sb.AppendLine($"Geboortedatum: {student.BirthDate.ToLongDateString()}");
                sb.AppendLine($"Sex: {student.Sex}");
                sb.AppendLine($"Olods:");
                sb.AppendLine(student.GetOlodSummary());
                studentTextBlock.Text = sb.ToString();
            }
            else
            {
                studentTextBlock.Text = string.Empty;
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (studentComboBox.SelectedItem != null)
            {
                studentComboBox.Items.Remove(studentComboBox.SelectedItem);
            }
        }
    }
}