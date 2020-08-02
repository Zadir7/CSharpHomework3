using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string Read;
            int sum = 0;
            string Numbers = string.Empty;
            Console.WriteLine($"Введите что-нибудь. Нечетные положительные числа будут суммированы. Введите 0 для выхода.");
            do
            {
                Read = Console.ReadLine();
                if(int.TryParse(Read, out int num) && num>0 && (num % 2 == 1))
                {
                    sum += num;
                    Numbers += $"{num}, ";
                }
            }
            while (Read != "0");
            Console.WriteLine($"Сумма введенных нечетных положительных чисел {Numbers} составила {sum}.");
            Console.ReadKey();
        }
    }
}
