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

namespace uniManPr
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
        private void StudentsButton_Click(object sender, RoutedEventArgs e)
        {
            var studentsView = new Students();
            studentsView.Show();
            this.Hide();
        }

        private void CoursesButton_Click(object sender, RoutedEventArgs e)
        {
            var coursesView = new CoursesView();
            coursesView.Show();
            this.Hide();
        }

        private void GradesButton_Click(object sender, RoutedEventArgs e)
        {
            var gradesView = new GradesView();
            gradesView.Show();
            this.Hide();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

    }
}