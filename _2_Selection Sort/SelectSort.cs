using System;
using System.Collections.Generic;
using System.Collections;

namespace SelectSort
{
    /// <summary>
    /// Структура с именами исполнителей и кол-вом прослушиваний их композиций.
    /// </summary>
    public struct Sound
    {
        public string Name { get; set; }
        public int CountOfPlaing { get; set; }

        public override string ToString() => $"Sounds of {Name}\t\t listened to \t{CountOfPlaing}\t times";
    }

    /// <summary>
    /// В порядке убывания чисел.
    /// </summary>
    class CountDown : IComparer<Sound>
    {
        int IComparer<Sound>.Compare(Sound x, Sound y) => x.CountOfPlaing.CompareTo(y.CountOfPlaing);
    }
    /// <summary>
    /// В порядке возрастания чисел.
    /// </summary>
    class CountUp : IComparer<Sound>
    {
        int IComparer<Sound>.Compare(Sound x, Sound y) => -x.CountOfPlaing.CompareTo(y.CountOfPlaing);
    }
    /// <summary>
    /// В обратном алфавитном пррядке.
    /// </summary>
    class AlphabetDown : IComparer<Sound>
    {
        int IComparer<Sound>.Compare(Sound x, Sound y) => String.Compare(x.Name, y.Name);
    }
    /// <summary>
    /// В прямом алфавитном порядке.
    /// </summary>
    class AlphabetUp : IComparer<Sound>
    {
        int IComparer<Sound>.Compare(Sound x, Sound y) => -String.Compare(x.Name, y.Name);
    }


    class Program
    {
        static Sound[] Sounds = new Sound[9]
        {
            new Sound(){ Name = "Slayer",               CountOfPlaing = 909213 },
            new Sound(){ Name = "Metalika",             CountOfPlaing = 123423 },
            new Sound(){ Name = "Pantera",              CountOfPlaing = 456456 },
            new Sound(){ Name = "Slipknot",             CountOfPlaing = 792454 },
            new Sound(){ Name = "Nirvana",              CountOfPlaing = 234563 },
            new Sound(){ Name = "Mick Gordon",          CountOfPlaing = 230009 },
            new Sound(){ Name = "Disturbed",            CountOfPlaing = 211109 },
            new Sound(){ Name = "Rammstein",            CountOfPlaing = 109999 },
            new Sound(){ Name = "Black Sabath",         CountOfPlaing = 456575 }
        };

        /// <summary>
        /// Поменять значениями a и b
        /// </summary>
        static void Swap<T>(ref T a, ref T b)
        {
            T c = a;
            a = b;
            b = c;
        }

        /// <summary>
        /// Алгоритм сортировки выбором
        /// </summary>
        /// <typeparam name="T">Тип данных сортируемого массива</typeparam>
        /// <param name="array">Сортируемый массив</param>
        /// <param name="comparer">Порядок сортировки</param>
        static void SelectionSort<T>(T[] array, IComparer<T> comparer)
        {
            int temp;
            for (int i = 0; i < array.Length - 1; i++)
            {
                temp = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    //Преместить индекс на элемент удволетворяющий условию
                    if (comparer.Compare(array[temp], array[j]) < 0)
                        temp = j;
                }
                
                Swap(ref array[temp], ref array[i]);
            }
        }

        /// <summary>
        /// Вывод коллекции в консоль.
        /// </summary>
        static void Output(IEnumerable enumerable)
        {
            foreach (var item in enumerable)
            {
                Console.WriteLine(item);
            }
        }
        
        static void Main(string[] args)
        {
            SelectionSort(Sounds, new CountDown());
            Output(Sounds);
            Console.WriteLine();

            SelectionSort(Sounds, new CountUp());
            Output(Sounds);
            Console.WriteLine();

            SelectionSort(Sounds, new AlphabetDown());
            Output(Sounds);
            Console.WriteLine();

            SelectionSort(Sounds, new AlphabetUp());
            Output(Sounds);
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
