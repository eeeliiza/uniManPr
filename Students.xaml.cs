using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace uniManPr
{
    /// <summary>
    /// Логика взаимодействия для Students.xaml
    /// </summary>
    public partial class Students : Window
    {
        public class Student
        {
            public int Id { get; set; }
            public string FullName { get; set; }
            public string Group { get; set; }
        }

        private ObservableCollection<Student> students;
        public Students()
        {
            InitializeComponent();
            this.Closed += Students_Closed;
            students = new ObservableCollection<Student>
            {
                new Student { Id = 1, FullName = "Иванов Иван Иванович", Group = "Группа 1" },
                new Student { Id = 2, FullName = "Петров Петр Петрович", Group = "Группа 2" }
            };

            StudentsDataGrid.ItemsSource = students;
        }
        private void Students_Closed(object sender, EventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Создаем диалоговое окно для добавления нового студента
            var dialog = new AddEditStudentWindow();
            if (dialog.ShowDialog() == true)
            {
                // Добавляем нового студента
                students.Add(new Student
                {
                    Id = students.Count + 1,
                    FullName = dialog.StudentName,
                    Group = dialog.StudentGroup
                });
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (StudentsDataGrid.SelectedItem is Student selectedStudent)
            {
                // Создаем диалоговое окно для редактирования
                var dialog = new AddEditStudentWindow
                {
                    StudentName = selectedStudent.FullName,
                    StudentGroup = selectedStudent.Group
                };

                if (dialog.ShowDialog() == true)
                {
                    // Обновляем данные студента
                    selectedStudent.FullName = dialog.StudentName;
                    selectedStudent.Group = dialog.StudentGroup;
                }
            }
            else
            {
                MessageBox.Show("Выберите студента для редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (StudentsDataGrid.SelectedItem is Student selectedStudent)
            {

                var result = MessageBox.Show(
            $"Удалить студента {selectedStudent.FullName}?",
            "Подтверждение удаления",
            MessageBoxButton.YesNo,
            MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    students.Remove(selectedStudent);
                }
            }
            else
            {
                MessageBox.Show("Выберите студента для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}