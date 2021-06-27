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

                double _rSelected;
                switch (rList.SelectedIndex)
                {
                    case 0:
                        _rSelected = 0.001;
                        break;
                    case 1:
                        _rSelected = 0.01;
                        break;
                    case 2:
                        _rSelected = 1;
                        break;
                    case 3:
                        _rSelected = 1000;
                        break;
                    case 4:
                        _rSelected = 0.3048;
                        break;
                    case 5:
                        _rSelected = 0.9144;
                        break;
                    case 6:
                        _rSelected = 0.0254;
                        break;
                    case 7:
                        _rSelected = 1609.344;
                        break;
                    default:
                        _rSelected = 1;
                        break;
                }

                switch (checkVar)
                {
                    case true:
                        double _nSelected;
                        switch (nList.SelectedIndex)
                        {
                            case 0:
                                _nSelected = Math.PI / 180.0;
                                break;
                            case 1:
                                _nSelected = 1;
                                break;
                            default:
                                _nSelected = Math.PI / 180.0;
                                break;
                        }

                        double _final_nSelected = _nSelected * 0.5;

                        double _result = _final_nSelected * _rSelected * Math.Pow(_r, 2.0) * _n;

                        userResultStr.Text = Convert.ToString(_result);
                        break;
                    case false:
                        double _result2 = _n * _r / 2;
                        userResultStr.Text = Convert.ToString(_result2);
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
