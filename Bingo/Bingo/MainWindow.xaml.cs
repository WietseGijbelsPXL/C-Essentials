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

namespace Bingo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer _timer = new DispatcherTimer();
        List<int> _bingoNumbers;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            InitializeGrid(playerOneGrid);
            InitializeGrid(playerTwoGrid);
        }

        private void InitializeGrid(Grid bingoGrid)
        {
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (row == 2 && col == 2)
                    {
                        Image image = new Image();
                        image.Source = new BitmapImage(new Uri(@"logoPXL.png", UriKind.RelativeOrAbsolute));
                        image.Stretch = Stretch.Uniform;
                        Grid.SetColumn(image, col);
                        Grid.SetRow(image, row);
                        bingoGrid.Children.Add(image);
                    }
                    else
                    {
                        Label label = new Label();
                        Grid.SetColumn(label, col);
                        Grid.SetRow(label, row);
                        label.HorizontalAlignment = HorizontalAlignment.Stretch;
                        label.VerticalAlignment = VerticalAlignment.Stretch;
                        label.HorizontalContentAlignment = HorizontalAlignment.Center;
                        label.VerticalContentAlignment = VerticalAlignment.Center;
                        label.BorderBrush = Brushes.Black;
                        label.BorderThickness = new Thickness(1, 1, 1, 1);
                        bingoGrid.Children.Add(label);
                    }
                }
            }
        }

        private void GeneratePlayerCard(Grid bingoGrid)
        {
            //Get all Label controls from Grid:
            Label[] gridLabels = bingoGrid.Children.OfType<Label>().ToArray();
            Random random = new Random();
            List<int> numbers = new List<int>();
            int number;

            foreach (Label label in gridLabels)
            {
                //Get row + columns for label:
                int row = Grid.GetRow(label);
                int col = Grid.GetColumn(label);

                //Generate unique random number based on column:
                if (col == 0)
                {
                    do
                    {
                        number = random.Next(1, 16);
                    } while (numbers.Contains(number));

                    numbers.Add(number);
                    label.Content = number;
                }
                else if (col == 1)
                {
                    do
                    {
                        number = random.Next(16, 31);
                    } while (numbers.Contains(number));

                    numbers.Add(number);
                    label.Content = number;
                }
                else if (col == 2)
                {
                    do
                    {
                        number = random.Next(31, 46);
                    } while (numbers.Contains(number));

                    numbers.Add(number);
                    label.Content = number;
                }
                else if (col == 3)
                {
                    do
                    {
                        number = random.Next(46, 61);
                    } while (numbers.Contains(number));

                    numbers.Add(number);
                    label.Content = number;
                }
                else if (col == 4)
                {
                    do
                    {
                        number = random.Next(61, 76);
                    } while (numbers.Contains(number));

                    numbers.Add(number);
                    label.Content = number;
                }
            }
        }

        private void newGameMenuItem_Click(object sender, RoutedEventArgs e)
        {
            GeneratePlayerCard(playerOneGrid);
            GeneratePlayerCard(playerTwoGrid);
            StartTimer();
            _bingoNumbers = new List<int>();
        }

        private void closeGameMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void StartTimer()
        {
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            Random random = new Random();
            int number;
            do
            {
                number = random.Next(1, 76);
            } while (_bingoNumbers.Contains(number));

            _bingoNumbers.Add(number);

            lastNumberLabel.Content = number;

            if (numbersListbox.Items.Count > 8)
            {
                numbersListbox.Items.RemoveAt(0);
                numbersListbox.Items.Add(number);
            }
            else
            {
                numbersListbox.Items.Add(number);
            }

            Label[] gridLabels = playerOneGrid.Children.OfType<Label>().ToArray();
            foreach (Label label in gridLabels)
            {
                if ((int)label.Content == number)
                {
                    label.Background = Brushes.White;
                }
            }

            Label[] gridLabels2 = playerTwoGrid.Children.OfType<Label>().ToArray();
            foreach (Label label in gridLabels2)
            {
                if ((int)label.Content == number)
                {
                    label.Background = Brushes.White;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                if (checkCollumnBingo(playerOneGrid, i))
                {
                    _timer.Stop();
                    MessageBox.Show("bingo");
                }

                if (checkRowBingo(playerOneGrid, i))
                {
                    _timer.Stop();
                    MessageBox.Show("bingo");
                }

                if (checkCollumnBingo(playerTwoGrid, i))
                {
                    _timer.Stop();
                    MessageBox.Show("bingo");
                }

                if (checkRowBingo(playerTwoGrid, i))
                {
                    _timer.Stop();
                    MessageBox.Show("bingo");
                }
            }
        }

        private bool checkRowBingo(Grid grid, int row)
        {
            for (int col = 0; col < 5; col++)
            {
                Label label = grid.Children.OfType<Label>().FirstOrDefault(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == col);
                if (label.Background != Brushes.White)
                {
                    return false;
                }
            }
            return true;
        }

        private bool checkCollumnBingo(Grid grid, int col)
        {
            for (int row = 0; row < 5; row++)
            {
                Label label = grid.Children.OfType<Label>().FirstOrDefault(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == col);
                if (label.Background != Brushes.White)
                {
                    return false;
                }
            }
            return true;
        }
    }
}