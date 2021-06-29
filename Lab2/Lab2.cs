using System;
using System.Collections.Generic;

namespace Lab2
{
    internal class Lab2
    {
        private static void Main()
        {
            #region Пользовательский интерфейс

            Console.Write("Введите числа в формате Long: ");
            long _inputNumber;

            while (!long.TryParse(Console.ReadLine(), out _inputNumber))
            {
                Console.Clear();
                Console.WriteLine("Неверный формат данных!");
                Console.Write("Введите числа в формате Long: ");
            }

            Console.Clear();

            #endregion

            // Создание проверки
            Integers _integers = new(_inputNumber);

            Console.WriteLine("Проверка цифер в числе: {0}", _inputNumber);

            // Получение данных чисел и вывод пользователю
            Console.WriteLine(_integers.Distinct ? "Цифры различны" : "Цифры повторяются");

            Console.ReadKey();
        }

        /// <summary>
        /// Класс целые числа
        /// </summary>
        public class Integers
        {
            /// <returns> true - цифры различны, false - цифры повторяются </returns>
            public bool Distinct { get; set; }

            /// <summary>
            /// Конструктор - проверить, будут ли все буквы введенной строки различными
            /// </summary>
            /// <param name="val"></param>
            public Integers(long val)
            {
                HashSet<long> _digits = new();
                Distinct = true;
                // Бесконечный цикл поиска повтора цифр
                for (val = Math.Abs(val); val != 0; val /= 10)
                {
                    // Пока возвращается true, продолжаем поиск
                    if (!_digits.Add(val % 10))
                    {
                        // Иначе заканчиваем цикл
                        Distinct = false;
                        break;
                    }
                }
            }
        }
    }
}
