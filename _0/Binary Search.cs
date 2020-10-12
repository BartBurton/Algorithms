using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] a = new int[1000];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = rand.Next(0, 1000000);
            }
            Array.Sort(a);

            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($" {a[i]}  ");
            }

            Console.WriteLine($"\n\n\n индекс - {BinarySearch(a, Convert.ToInt32(Console.ReadLine()))}");

            Console.ReadKey();
        }
        
        static int BinarySearch(int[] a, int value)
        {
            int midlle = a.Length / 2, //Центральный индекс.
                low = 0, //Нижний индекс.
                high = a.Length - 1; //Верхний индекс.

            while(low <= high) // Производить поиск пока нижний индекс меньше верхнего.
            {
                if (value == a[midlle]) return midlle; //Проверить равен ли средний элемент числу поиска.

                if (a[midlle] > value) 
                    high = midlle - 1; //Если центр выше, верхний индекс смещается под него.
                else
                    low = midlle + 1; //Если центр ниже, нижний индекс над ним.

                midlle = (high + low) / 2; //Определить центральный индекс м\у новыми значениями верхнего и нижнего индекса.
            }
            return -1; //Вернуть отрицательный индекс, если совпадений нет.
        }
    }
}
