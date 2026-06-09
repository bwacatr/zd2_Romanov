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

namespace zd2_Romanov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PhoneBook phoneBook;
        public MainWindow()
        {
            InitializeComponent();
            phoneBook = new PhoneBook();
        }

        private void UpdateGrid() //Обновление DataGrid
        {
            Grid.Items.Clear();
            foreach (var item in phoneBook.contacts)
            {
                Grid.Items.Add(item);
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e) //Загрузка контактов из файла
        {
            if (!string.IsNullOrWhiteSpace(TextBox_fileName.Text))
            {
                PhoneBookLoader.Load(phoneBook, TextBox_fileName.Text);
                UpdateGrid();
            }
            else
            {
                MessageBox.Show("Введите путь к файлу");
            }

        }

        private void Save_Click(object sender, RoutedEventArgs e) //Сохранение контактов в файл
        {
            if (!string.IsNullOrWhiteSpace(TextBox_fileName.Text))
            {
                PhoneBookLoader.Save(phoneBook, TextBox_fileName.Text);
            }
            else
            {
                MessageBox.Show("Введите путь к файлу");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e) //Добавление контакта
        {
            if (!string.IsNullOrWhiteSpace(TextBox_Name.Text))
            {
                if (!string.IsNullOrWhiteSpace(TextBox_Phone.Text))
                {
                    phoneBook.AddContact(TextBox_Name.Text, TextBox_Phone.Text);
                    UpdateGrid();
                }
                else
                    MessageBox.Show("Введите номер телефона");
            }
            else
                MessageBox.Show("Введите имя и фамилию");

        }

        private void Exit_Click(object sender, RoutedEventArgs e) // закрытие программы через кнопку выход
        {
            Exit();
        }

        private void Delete_Click(object sender, RoutedEventArgs e) //Удаление выбранного контакта
        {
            try
            {
                phoneBook.DeleteContact((Contact)Grid.SelectedItem);
                UpdateGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите строку перед удалением");
            }

        }

        private void DeleteIndex_Click(object sender, RoutedEventArgs e) //Удаление контакта по индексу
        {
            try
            {
                phoneBook.DeleteContact(int.Parse(TextBox_Index.Text));
                UpdateGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Введен некорректный индекс");
            }

        }

        private void Search_Click(object sender, RoutedEventArgs e) //Поиск по имени и фамилии
        {
            Grid.Items.Clear();
            foreach (var item in phoneBook.SearchByName(TextBox_Name.Text))
            {
                Grid.Items.Add(item);
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e) //Сброс списка
        {
            UpdateGrid();
        }

        

        private void Exit() // метод закрытия программы
        {
            MessageBoxResult msgBox = MessageBox.Show("Вы действительно хотите закрыть программу?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (msgBox == MessageBoxResult.Yes)
                this.Close();
        }

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e) // вывод индекса выделенного контакта
        {
            TextBox_Index.Text = Grid.SelectedIndex.ToString();
        }
    }
}
