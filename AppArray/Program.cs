using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics.CodeAnalysis;


namespace AppArray
{
    class Program
    {
        static void Main()
        {
            int N, K;
            string str;
                                  
            List<int> arr = new List<int>();
            try
            {
                using (StreamReader input = new StreamReader("input.txt"))
                {
                    N = Convert.ToInt32(input.ReadLine());

                    str = input.ReadLine();

                    for (int i = 0; i < N; i++)
                    {
                        arr.Add(Convert.ToInt32(str.Split(' ')[i]));
                    }

                    K = Convert.ToInt32(input.ReadLine());
                }
                Console.WriteLine("Данные из файла получены.");
            }
            catch
            {
                Console.WriteLine("Ошибка! Проверьте наличие файла input.txt");

                Console.ReadKey();

                return;
            }

            SortedSet<ValueIndexPair> sorted = new SortedSet<ValueIndexPair>(new ValueIndexComparer());

            for (int i = 0; i < N; i++)
            {
               var pair = new ValueIndexPair(arr[i], i);
               if (sorted.Count < K)
               {
                    sorted.Add(pair);
               }
               else
               {
                    if(sorted.Max.Value < arr[i])
                    {
                        sorted.Remove(sorted.Max);
                        sorted.Add(pair);
                    }
               }
            }

            using (StreamWriter output = new StreamWriter("output.txt"))
            {
                foreach (var i in sorted)
                {
                    output.Write(i.Value + " ");
                }
            }

            Console.WriteLine("Файл output.txt сформирован.");

            Console.ReadKey();
        }

        class ValueIndexComparer : IComparer<ValueIndexPair>
        {
            public int Compare(ValueIndexPair x, ValueIndexPair y)
            {
                if (x.Value != y.Value) return -x.Value.CompareTo(y.Value);
                return x.Index.CompareTo(y.Index);
            }
        }

        struct ValueIndexPair
        {
            public readonly int Value;
            public readonly int Index;

            public ValueIndexPair(int value, int index)
            {
                Value = value;
                Index = index;
            }
        }
    }
}
