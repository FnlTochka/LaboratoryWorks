using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lab3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool checkVar = true;

        public MainWindow()
        {
            InitializeComponent();
            ChangeCheck(true);
        }

        private void btnClickСalculate(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (checkVar)
                {
                    case true:
                        double _r = Convert.ToDouble(userInputR.Text), _n = Convert.ToDouble(userInputN.Text);

                        double qwe2;
                        switch (rList.SelectedIndex)
                        {
                            case 0:
                                qwe2 = 1;
                                break;
                            case 1:
                                qwe2 = 0.01;
                                break;
                            case 2:
                                qwe2 = 1;
                                break;
                            case 3:
                                qwe2 = 1000;
                                break;
                            case 4:
                                qwe2 = 0.3048;
                                break;
                            case 5:
                                qwe2 = 0.9144;
                                break;
                            case 6:
                                qwe2 = 0.0254;
                                break;
                            case 7:
                                qwe2 = 1609.344;
                                break;
                            default:
                                qwe2 = 0.001;
                                break;
                        }

                        double qwe;
                        switch (nList.SelectedIndex)
                        {
                            case 0:
                                qwe = Math.PI / 180.0;
                                break;
                            case 1:
                                qwe = 1;
                                break;
                            default:
                                qwe = Math.PI / 180.0;
                                break;
                        }

                        double qaaa = qwe * 0.5;

                        double _result = qaaa * qwe2 * Math.Pow(_r, 2.0) * _n;
                        //double v = _result * 100.0;

                        //result = Math.Pow(_r, 2.0) / 2.0 * (_n - Math.Sin(_n));
                        userResultStr.Text = Convert.ToString(_result);
                        break;
                    case false:

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

        private void ChangeCheck(bool isEnable)
        {
            switch (isEnable)
            {
                case true:
                    checkVar = true;
                    //canvasCheck.Visibility = Visibility.Visible;
                    img1.Visibility = Visibility.Visible;
                    img2.Visibility = Visibility.Hidden;
                    txt_InputN.Text = "θ:";
                    userResultStr.Text = Convert.ToString("");
                    checkArcLength.IsChecked = false;
                    checkSectorAngle.IsChecked = true;
                    checkSectorAngle.IsEnabled = false;
                    checkArcLength.IsEnabled = true;
                    break;
                case false:
                    checkVar = false;
                    //canvasCheck.Visibility = Visibility.Hidden;
                    img1.Visibility = Visibility.Hidden;
                    img2.Visibility = Visibility.Visible;
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
