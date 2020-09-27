using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

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

            for (int i = 1; i < N; i++)
            {
                int tmp1 = arr[i];

                for (int j = i; j > 0 && arr[j-1] < arr[j]; j--)
                {
                    int tmp2 = arr[j-1];
                    arr[j-1] = arr[j];
                    arr[j] = tmp2;
               
                }
            }

            using (StreamWriter output = new StreamWriter("output.txt"))
            {
                for (int i = 0; i < K; i++)
                {
                    output.Write(arr[i] + " ");
                }
            }

            Console.WriteLine("Файл output.txt сформирован.");

            Console.ReadKey();
        }
    }
}
