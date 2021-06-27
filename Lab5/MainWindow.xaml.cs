using System;
using System.Windows;
using System.Windows.Shapes;

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
            ResultCanvas.Children.Clear();

            double _x = Convert.ToDouble(userInputX.Text), y = 0, R = Convert.ToDouble(userInputR.Text);
            string function = "";
            if ((_x < -5) | (_x > 9))
            {
                function = "Аргумент за пределами графика!";
            }
            else if ((_x < -R) && (_x >= -5))
            {
                y = _x + R;
                function = "y = x + " + Convert.ToString(R); ;
            }
            else if ((-R <= _x) && (_x <= 0))
            {
                y = Math.Sqrt(Math.Pow(R, 2) - Math.Pow(_x, 2));
                function = "y = Sqrt( r^2 - x^2 )";
            }
            else if ((0 < _x) && (_x < 6))
            {
                y = (-0.5 * _x) + 3;
                function = "y = (-0.5 * x) + 3";
            }
            else if ((6 <= _x) && (_x < 9))
            {
                y = _x - 6;
                function = "y = x - 6";
            }
            userResultY.Text = Convert.ToString(y);

            userResultStr.Text = function;

            // тестовая линия
            Line myLine;
            myLine = new Line
            {
                Stroke = System.Windows.Media.Brushes.Black,
                X1 = 1,
                X2 = 50,
                Y1 = 1,
                Y2 = 50,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                StrokeThickness = 2
            };
            ResultCanvas.Children.Add(myLine);
        }

        private void btnClickClear(object sender, RoutedEventArgs e)
        {
            ResultCanvas.Children.Clear();
        }
    }
}
