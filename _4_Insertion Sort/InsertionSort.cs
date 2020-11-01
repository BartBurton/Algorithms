using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace InsertionSort
{
    /// <summary>
    /// Класс для сравнения по умолчанию в при сортировке вставками.
    /// </summary>
    /// <typeparam name="T">Тип заполнителя реализующий IComparable.</typeparam>
    class StandartComparer<T> : IComparer<T> where T : IComparable
    {
        int IComparer<T>.Compare(T x, T y) => x.CompareTo(y);
    }

    /// <summary>
    /// Класс содержащий расширяющий метод для сортировки коллекций методом вставок.
    /// </summary>
    static class Sort
    {
        /// <summary>
        /// Сортировка втавками, любой коллекции, реализующей IEnumerable/IEnumerable<T>,
        /// при помощи IComparable типа T либо специального IComparer. По умолчанию сотировка производится
        /// по возрастанию т.е. возврат IComparer.Compare() > 0.
        /// </summary>
        /// <typeparam name="T">Тип заполнителя реализующий IComparable.</typeparam>
        /// <param name="seq">Коллекция сортирумых элементов.</param>
        /// <param name="comparer">Если нужно изменить порядок сортировки можно передать IComparer<T>.</param>
        /// <returns>Отсортированная последовательность.</returns>
        public static IEnumerable<T> InsertionSort<T>(this IEnumerable<T> seq, IComparer<T> comparer = null) where T : IComparable
        {
            //Получить из обообщенной коллекции список
            List<T> list = seq.ToList();
            T key;
            int j;
            //Задать способ сравнения эл. коллекции
            comparer ??= new StandartComparer<T>();

            //Сортировка вставкой 
            for (int i = 1; i < list.Count; i++)
            {
                key = list[i];
                j = i - 1;
                while (j > -1 && comparer.Compare(list[j], key) > 0)
                {
                    //Если бы использовался массив приходилось бы сдвигать
                    //элементы
                    j--;
                }
                list.RemoveAt(i);
                list.Insert(j + 1, key);
            }
            //Вернуть отсортированную последовательность
            return list;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] x = new int[100];
            Random r = new Random();
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = r.Next(100, 999);
            }
            Stopwatch time = new Stopwatch();

            time.Start();
            IEnumerable<int> y =  x.InsertionSort();
            time.Stop();

            Console.WriteLine(time.Elapsed.Milliseconds + " миллисек. понадобилось на сортировку");

            Console.WriteLine("Не отсортированная последовательность");
            foreach (int item in x)
            {
                Console.Write($"{item}  ");
            }
            Console.WriteLine();
            Console.WriteLine("Отсортированная последовательность");
            foreach (int item in y)
            {
                Console.Write($"{item}  ");
            }
        }
    }
}
