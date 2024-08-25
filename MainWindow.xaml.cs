using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
                if ((row > 5 && col > 5 && row < 9 && col < 9) && (n_row > 5 && n_col >5 && n_row < 9 && n_col < 9))
                {
                    Brush brush = new SolidColorBrush(Color.FromArgb(123, 255, 0, 0));
                    textBox.Background = brush;
                }
                //8 квадрат
                else if ((row > 5 && col > 2  && row < 9 && col < 6) && (n_row > 5 && n_col > 2 && n_row < 9 && n_col < 6))
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
                if (textBox.Text != "")
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SetUpGame();
        }

        private int[,,] Fill_matrix()
        {
            int[,,] matrix = new int[10, 9, 9];
            var brush = new SolidColorBrush(Color.FromArgb(123, 255, 0, 0)).ToString();
            for (int i = 1; i < 10; i++)
            {
                Clear_area();
                Check_match(Convert.ToString(i));
                foreach (TextBox textBox in mainGrid.Children.OfType<TextBox>())
                {
                    var row = Grid.GetRow(textBox);
                    var col = Grid.GetColumn(textBox);
                    var color = textBox.Background.ToString();
                    if (textBox.Text == Convert.ToString(i))
                    {
                        matrix[i, col, row] = i;
                    }
                    else if (color == brush || textBox.Text != "")
                    {
                        matrix[i, col, row] = 10;
                    }
                    else
                    {
                        matrix[i, col, row] = 0;
                    }
                }
            }
            return matrix;
        }

        private void BTN_match_Click(object sender, RoutedEventArgs e)
        {
                //while (Is_match(matrix) != true)
                //{
                for (int i = 1; i < 10; i++)
                {
                    var matrix = Fill_matrix();
                    matrix = Check_horizon(matrix, i);
                    Fill_grid(matrix);
                    matrix = Fill_matrix();
                    matrix = Check_vertical(matrix, i);
                    Fill_grid(matrix);
                }
            //}
            


        }

        private void Fill_grid(int[,,] matrix)
        {
            foreach (TextBox textBox in mainGrid.Children.OfType<TextBox>())
            {
                var row = Grid.GetRow(textBox);
                var col = Grid.GetColumn(textBox);
                for (int i = 1; i < 10; i++)
                {
                    if (matrix[i, col, row] == i)
                    {
                        textBox.Text = Convert.ToString(matrix[i,col, row]);
                    }
                }
            }
            
        }

        private int[,,] Check_vertical(int[,,] matrix, int num)
        {
            for (int i = 0; i < 9; i++)
            {
                int row = 0;
                int col = 0;
                bool checker = false;
                for (int j = 0; j < 9; j++)
                {
                    if (matrix[num, j, i] == 0)
                    {
                        if (checker)
                        {
                            checker = false;
                            break;
                        }
                        checker = true;
                        row = i;
                        col = j;
                    }
                }
                if (checker)
                {
                    matrix[num,col, row] = num;
                }
            }
            return matrix;
        }

        private int[,,] Check_horizon(int[,,] matrix, int num)
        {
            for (int i = 0; i < 9; i++)
            {
                int row = 0;
                int col = 0;
                bool checker = false;
                for (int j = 0; j < 9; j++)
                {
                    if (matrix[num,i, j] == 0)
                    {
                        if (checker)
                        {
                            checker = false;
                            break;
                        }
                        checker = true;
                        row = j;
                        col = i;
                    }
                }
                if (checker)
                {
                    matrix[num,col, row] = num;
                    return matrix;
                }
            }
            return matrix;
        }

        //private bool Is_match(int[,,] matrix)
        //{
        //    for (int i = 0; i < 9; i++)
        //    {
        //        for(int j = 0; j < 9; j++)
        //        {
        //            if (matrix[i,j] == 0)
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    return true;
        //}
    }
}