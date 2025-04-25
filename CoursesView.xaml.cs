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
    /// Логика взаимодействия для CoursesView.xaml
    /// </summary>
    public partial class CoursesView : Window
    {
        private ObservableCollection<string> courses = new ObservableCollection<string>();

        public CoursesView()
        {
            InitializeComponent();
            this.Closed += CoursesView_Closed;
            // Пример начальных курсов
            courses.Add("Программирование");
            courses.Add("Математика");
            courses.Add("Физика");

            CoursesDataGrid.ItemsSource = courses;
        }
        private void CoursesView_Closed(object sender, EventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddEditCourseWindow();
            if (window.ShowDialog() == true)
            {
                courses.Add(window.CourseName);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (CoursesDataGrid.SelectedItem is string selectedCourse)
            {
                var window = new AddEditCourseWindow(selectedCourse);
                if (window.ShowDialog() == true)
                {
                    int index = courses.IndexOf(selectedCourse);
                    courses[index] = window.CourseName;
                }
            }
            else
            {
                MessageBox.Show("Выберите курс для редактирования.");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (CoursesDataGrid.SelectedItem is string selectedCourse)
            {
                courses.Remove(selectedCourse);
            }
            else
            {
                MessageBox.Show("Выберите курс для удаления.");
            }
        }
    }
}