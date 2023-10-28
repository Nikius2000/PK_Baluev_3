using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pr21._101_baluev_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_send_Click(object sender, RoutedEventArgs e)
        {
            string[] error_list = { "Число <= 0", "Вы ввели не цифры!" };
            try
            {
                int n = int.Parse(tb_input.Text);

                int min = int.Parse(tb_input_min.Text);

                int max = int.Parse(tb_input_max.Text);

                if (n <= 0 || min <= 0 || max <= 0)
                {
                    MessageBox.Show(error_list[0]);
                }
                else if(n.GetType() != typeof(Int32) || min.GetType() != typeof(Int32) || max.GetType() != typeof(Int32))
                {
                    MessageBox.Show(error_list[1]);
                }

                int[] array = GenerateArray(n, min, max);

                l_result_standart.Content = ArrayToString(array);

                SortArray(array);

                l_result_sort.Content = ArrayToString(array);
            }
            catch(FormatException ex)
            {
                MessageBox.Show("Вводить можно только цифры!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Произошла ошибка");
            }
            


        }
        static int[] GenerateArray(int n, int min, int max)
        {
            Random random = new Random();
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(min, max + 1);
                while(array[i] == 0)
                {
                    array[i] = random.Next(min, max + 1);
                }
            }
            return array;
        }
        static void SortArray(int[] array)
        {
            Array.Sort(array, (x, y) =>
            {
                if (x % 2 == 0 && y % 2 != 0)
                    return -1;
                if (x % 2 != 0 && y % 2 == 0)
                    return 1;
                return 0;
            });
        }
        static string ArrayToString(int[] array)
        {
            string temp_text = "";
            for (int i = 0; i < array.Length; i++)
            {
                temp_text += array[i].ToString();
            }
            return temp_text;
        }
    }
}
