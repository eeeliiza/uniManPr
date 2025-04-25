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
    /// Логика взаимодействия для AddEditGradeWindow.xaml
    /// </summary>
    public partial class AddEditGradeWindow : Window
    {
        public string StudentName => StudentNameTextBox.Text;
        public string Course => CourseTextBox.Text;
        public string Grade => GradeTextBox.Text;
        public AddEditGradeWindow()
        {
            InitializeComponent();
        }
        public AddEditGradeWindow(object selectedItem) : this()
        {
            if (selectedItem is GradeRecord record)
            {
                StudentNameTextBox.Text = record.StudentName;
                CourseTextBox.Text = record.Course;
                GradeTextBox.Text = record.Grade;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }

    public class GradeRecord
    {
        public string StudentName { get; set; }
        public string Course { get; set; }
        public string Grade { get; set; }
    }
}
