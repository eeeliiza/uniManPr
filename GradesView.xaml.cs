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
    /// Логика взаимодействия для GradesView.xaml
    /// </summary>
    public partial class GradesView : Window
    {
        private ObservableCollection<GradeRecord> grades = new ObservableCollection<GradeRecord>();
        public GradesView()
        {
            InitializeComponent();
            this.Closed += GradesView_Closed;
            GradesDataGrid.ItemsSource = grades;
        }
        private void GradesView_Closed(object sender, EventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
        private void AddGrade_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddEditGradeWindow();
            if (window.ShowDialog() == true)
            {
                grades.Add(new GradeRecord
                {
                    StudentName = window.StudentName,
                    Course = window.Course,
                    Grade = window.Grade
                });
            }
        }

        private void EditGrade_Click(object sender, RoutedEventArgs e)
        {
            if (GradesDataGrid.SelectedItem is GradeRecord selectedRecord)
            {
                var window = new AddEditGradeWindow(selectedRecord);
                if (window.ShowDialog() == true)
                {
                    selectedRecord.StudentName = window.StudentName;
                    selectedRecord.Course = window.Course;
                    selectedRecord.Grade = window.Grade;
                    GradesDataGrid.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для редактирования.");
            }
        }

        private void DeleteGrade_Click(object sender, RoutedEventArgs e)
        {
            if (GradesDataGrid.SelectedItem != null)
            {
                // временно удаляем из DataGrid
                GradesDataGrid.Items.Remove(GradesDataGrid.SelectedItem);
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления.");
            }
        }
    }
}