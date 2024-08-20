using System;
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

namespace Sudoku_helper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
        }

        private void SetUpGame()
        {
            foreach (TextBox textBox in mainGrid.Children.OfType<TextBox>())
            {
                textBox.Text = "";
                Brush brush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                textBox.Background = brush;

            }
        }

        private void Clear_area()
        {
            foreach (TextBox textBox in mainGrid.Children.OfType<TextBox>())
            {
                Brush brush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                textBox.Background = brush;
            }
        }

        private void Check_match(string num)
        {
            foreach (TextBox textBox in mainGrid.Children.OfType<TextBox>())
            {
                if (textBox.Text == num)
                {
                    var row = Grid.GetRow(textBox);
                    var col = Grid.GetColumn(textBox);
                    Fill_table(row, col);
                    
                }
            }
        }
        private void Fill_table(int row, int col)
        {
            foreach (TextBox textBox in mainGrid.Children.OfType<TextBox>())
            {
                var n_row = Grid.GetRow(textBox);
                var n_col = Grid.GetColumn(textBox);
                //9 квадрат
                if ((row > 5 && col > 5) && (n_row > 5 && n_col >5))
                {
                    Brush brush = new SolidColorBrush(Color.FromArgb(123, 255, 0, 0));
                    textBox.Background = brush;
                }
                //8 квадрат
                else if ((row > 5 && col > 2  && col < 6) && (n_row > 5 && n_col > 2 && n_col < 6))
                {
                        Brush brush = new SolidColorBrush(Color.FromArgb(123, 255, 0, 0));
                        textBox.Background = brush;
                }
                //7 квадрат
                else if ((row > 5 && col > -1 && row < 9 && col < 3) && (n_row > 5 && n_col > -1 && n_row < 9 && n_col < 3))
                {
                    Brush brush = new SolidColorBrush(Color.FromArgb(123, 255, 0, 0));
                    textBox.Background = brush;
                }
                //6 квадрат
                else if ((row > 2 && col > 5 && row < 6 && col < 9) && (n_row > 2 && n_col > 5 && n_row < 6 && n_col < 9))
                {
                    Brush brush = new SolidColorBrush(Color.FromArgb(123, 255, 0, 0));
                    textBox.Background = brush;
                }
                //5 квадрат
                else if ((row > 2 && col > 2 && row < 6 && col < 6) && (n_row > 2 && n_col > 2 && n_row < 6 && n_col < 6))
                {
                    Brush brush = new SolidColorBrush(Color.FromArgb(123, 255, 0, 0));
                    textBox.Background = brush;
                }
                //4 квадрат
                else if ((row > 2 && col > -1 && row < 6 && col < 3) && (n_row > 2 && n_col > -1 && n_row < 6 && n_col < 3))
                {
                    Brush brush = new SolidColorBrush(Color.FromArgb(123, 255, 0, 0));
                    textBox.Background = brush;
                }
                //3 квадрат
                else if ((row > -1 && col > 5 && row < 3 && col < 9) && (n_row > -1 && n_col > 5 && n_row < 3 && n_col < 9))
                {
                    Brush brush = new SolidColorBrush(Color.FromArgb(123, 255, 0, 0));
                    textBox.Background = brush;
                }
                //2 квадрат
                else if ((row > -1 && col > 2 && row < 3 && col < 6) && (n_row > -1 && n_col > 2 && n_row < 3 && n_col < 6))
                {
                    Brush brush = new SolidColorBrush(Color.FromArgb(123, 255, 0, 0));
                    textBox.Background = brush;
                }
                //1 квадрат
                else if ((row > -1 && col > -1 && row < 3 && col < 3) && (n_row > -1 && n_col > -1 && n_row < 3 && n_col < 3))
                {
                    Brush brush = new SolidColorBrush(Color.FromArgb(123, 255, 0, 0));
                    textBox.Background = brush;
                }
                if (n_row == row || n_col == col)
                {
                    Brush brush = new SolidColorBrush(Color.FromArgb(123, 255, 0, 0));
                    textBox.Background = brush;
                }
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            string[] arr = ["1", "2", "3", "4", "5", "6", "7", "8", "9"];
            TextBox? textBox = sender as TextBox;
            if (!arr.Contains(textBox.Text))
            {
                textBox.Text = "";
            }
            else
            {
                Clear_area();
                Check_match(textBox.Text);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string[] arr = ["1", "2", "3", "4", "5", "6", "7", "8", "9"];
            TextBox? textBox = sender as TextBox;
            if (!arr.Contains(textBox.Text))
            {
                textBox.Text = "";
            }
            else
            {
                Clear_area();
                Check_match(textBox.Text);
            }
        }
    }
}