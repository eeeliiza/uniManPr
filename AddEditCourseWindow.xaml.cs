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

namespace uniManPr
{
    /// <summary>
    /// Логика взаимодействия для AddEditCourseWindow.xaml
    /// </summary>
    public partial class AddEditCourseWindow : Window
    {
        public string CourseName { get; private set; }

        public AddEditCourseWindow(string initialName = "")
        {
            InitializeComponent();
            CourseNameTextBox.Text = initialName;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            CourseName = CourseNameTextBox.Text;
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
