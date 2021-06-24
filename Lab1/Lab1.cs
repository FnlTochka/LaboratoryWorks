using System;

namespace Lab1
{
    internal class Lab1
    {
        private static void Main()
        {
            #region Пользовательский интерфейс

            Console.Write("Введите радиус окружности в формате Int32: ");
            int _circleRadius;

            while (!int.TryParse(Console.ReadLine(), out _circleRadius))
            {
                Console.Clear();
                Console.WriteLine("Вы ввели неверный радиус круга");
                Console.Write("Введите радиус окружности в формате Int32: ");
            }

            Console.Clear();
            Console.Write("Введите X точку в формате Double: ");
            double _circleX;

            while (!double.TryParse(Console.ReadLine(), out _circleX))
            {
                Console.Clear();
                Console.WriteLine("Вы ввели неверную X точку");
                Console.Write("Введите X точку в формате Double: ");
            }

            Console.Clear();
            Console.Write("Введите Y точку в формате Double: ");
            double _circleY;

            while (!double.TryParse(Console.ReadLine(), out _circleY))
            {
                Console.Clear();
                Console.WriteLine("Вы ввели неверную Y точку");
                Console.Write("Введите Y точку в формате Double: ");
            }

            Console.Clear();
            Console.Write("Введите N точку для проверки на принадлежность окружности в формате Double: ");
            double _pointN;

            while (!double.TryParse(Console.ReadLine(), out _pointN))
            {
                Console.Clear();
                Console.WriteLine("Вы ввели неверную N точку");
                Console.Write("Введите N точку для проверки на принадлежность окружности в формате Double: ");
            }

            Console.Clear();

            #endregion

            // Создание новой окружности
            Circle _circle = new(_circleRadius, new Point(_circleX, _circleY));

            Console.WriteLine(_circle.ToString());

            // Получение данных из круга и вывод пользователю
            string _strIsInside = _circle.IsInside(new Point(_pointN, _pointN)) ? "да" : "нет";
            Console.WriteLine("Проверка на принадлежность точки: {0}", _strIsInside);
            Console.WriteLine("Площадь = {0}", _circle.CircleArea);
            Console.WriteLine("Длина окружности = {0}", _circle.CircumFerence);

            Console.ReadKey();
        }

        /// <summary>
        /// Класс окружности
        /// </summary>
        public class Circle
        {
            public double Radius { get; set; }
            public Point Center { get; set; }

            /// <summary>
            /// Окружность
            /// </summary>
            public Circle(double radius, Point center)
            {
                Radius = radius;
                Center = center;
            }

            /// <summary>
            /// Площадь
            /// </summary>
            public double CircleArea => Math.PI * Radius * Radius;

            /// <summary>
            /// Длина окружности
            /// </summary>
            public double CircumFerence => Math.PI * 2 * Radius;

            /// <summary>
            /// Проверить, на принадлежность к точке
            /// </summary>
            /// <param name="point"></param>
            public bool IsInside(Point point)
            {
                Point vector = new(point.X - Center.X, point.Y - Center.Y);
                double distance = vector.X * vector.X + vector.Y * vector.Y;
                return distance <= Radius * Radius;
            }

            // Вывод пользователю
            public override string ToString()
            {
                return string.Format("Радиус: {0}; Центр: {1};", Radius, Center);
            }
        }

        /// <summary>
        /// Класс точки
        /// </summary>
        public class Point
        {
            /// <summary>
            /// Точка
            /// </summary>
            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }

            public double X { get; private set; }
            public double Y { get; private set; }

            // Вывод пользователю
            public override string ToString()
            {
                return string.Format("({0}, {1})", X, Y);
            }
        }
    }
}
