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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace uniManPr
{
    /// <summary>
    /// Логика взаимодействия для AddEditStudentWindow.xaml
    /// </summary>
    public partial class AddEditStudentWindow : Window
    {
        public string StudentName
        {
            get => NameTextBox.Text;
            set => NameTextBox.Text = value;
        }
        public string StudentGroup
        {
            get => GroupTextBox.Text;
            set => GroupTextBox.Text = value;
        }
        public AddEditStudentWindow()
        {
            InitializeComponent();
        }
        

        // Сохранение данных
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(StudentName))
            {
                MessageBox.Show("ФИО студента не может быть пустым!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DialogResult = true; // Закрываем окно с результатом "OK"
        }

        // Отмена
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
