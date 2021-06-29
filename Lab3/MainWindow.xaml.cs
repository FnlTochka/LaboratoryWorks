using System;
using System.Windows;

namespace Lab3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool checkVar = true;
        ConverterDataBase DataConvert = new ConverterDataBase();
        ConverterDataBase2 DataConvert2 = new ConverterDataBase2();

        public MainWindow()
        {
            InitializeComponent();
            ChangeCheck(true);
        }

        private void BtnClickСalculate(object sender, RoutedEventArgs e)
        {
            try
            {
                double _r = Convert.ToDouble(userInputR.Text), _n = Convert.ToDouble(userInputN.Text);

                switch (checkVar)
                {
                    case true:
                        userResultStr.Text = $"{CountResultSectorAngle(_r, rList.SelectedIndex, _n, nList.SelectedIndex)}";
                        break;
                    case false:
                        userResultStr.Text = $"{CountResultArcLength(_r, _n)}";
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                userResultStr.Text = Convert.ToString("Некорректный ввод");
                MessageBox.Show("Поля, соответствующие значению радиуса, углу или длине сектора, должны быть заполнены!");
            }
        }

        private double CountResultSectorAngle(double num, int fromType, double num2, int toType)
        {
            double _final_nSelected = DataConvert2.fromMetresTo[toType] * 0.5;
            double res = _final_nSelected * DataConvert.fromMetresTo[fromType] * Math.Pow(num, 2.0) * num2;
            return res;
        }

        private double CountResultArcLength(double num, double num2)
        {
            double res = num2 * num / 2;
            return res;
        }

        /// <summary>
        /// Смена расчета
        /// </summary>
        /// <param name="isEnable"></param>
        private void ChangeCheck(bool isEnable)
        {
            switch (isEnable)
            {
                case true:
                    checkVar = true;
                    img1.Visibility = Visibility.Visible;
                    img2.Visibility = Visibility.Hidden;
                    rList.Visibility = Visibility.Visible;
                    nList.Visibility = Visibility.Visible;
                    txt_InputN.Text = "θ:";
                    userResultStr.Text = Convert.ToString("");
                    checkArcLength.IsChecked = false;
                    checkSectorAngle.IsChecked = true;
                    checkSectorAngle.IsEnabled = false;
                    checkArcLength.IsEnabled = true;
                    break;
                case false:
                    checkVar = false;
                    img1.Visibility = Visibility.Hidden;
                    img2.Visibility = Visibility.Visible;
                    rList.Visibility = Visibility.Hidden;
                    nList.Visibility = Visibility.Hidden;
                    txt_InputN.Text = "L:";
                    userResultStr.Text = Convert.ToString("");
                    checkArcLength.IsChecked = true;
                    checkSectorAngle.IsChecked = false;
                    checkSectorAngle.IsEnabled = true;
                    checkArcLength.IsEnabled = false;
                    break;
                default:
                    break;
            }
        }

        private void CheckSectorAngle_Checked(object sender, RoutedEventArgs e)
        {
            ChangeCheck(true);
        }

        private void CheckArcLength_Checked(object sender, RoutedEventArgs e)
        {
            ChangeCheck(false);
        }
    }
}
