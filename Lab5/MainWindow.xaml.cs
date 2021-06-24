using System.Windows;

namespace Lab5
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

        private void btnClickPaint(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("btnClickPaint");
        }

        private void btnClickClear(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("btnClickClear");
        }
    }
}
