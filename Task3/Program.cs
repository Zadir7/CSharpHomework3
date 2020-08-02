using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int x, y;
            Console.WriteLine("Введите числитель первой дроби");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите знаменатель первой дроби");
            y = Convert.ToInt32(Console.ReadLine());
            Fraction userFr1 = new Fraction(x, y);
            Console.WriteLine("Введите числитель второй дроби");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите знаменатель второй дроби");
            y = Convert.ToInt32(Console.ReadLine());
            Fraction userFr2 = new Fraction(x, y);

            Console.WriteLine("Отображаем дроби в десятичном виде:");
            Console.WriteLine($"{userFr1.DC:f2}");
            Console.WriteLine($"{userFr2.DC:f2}");

            Console.WriteLine("Производим все возможные действия с дробями и сокращаем результат:");
            Fraction Fr3 = userFr1 + userFr2;
            Fraction.Reduce(Fr3);
            Console.WriteLine($"{Fraction.Print(userFr1)} + {Fraction.Print(userFr2)} = {Fraction.Print(Fr3)} = {Fr3.DC:f2}");
            Fraction Fr4 = userFr1 - userFr2;
            Fraction.Reduce(Fr4);
            Console.WriteLine($"{Fraction.Print(userFr1)} - {Fraction.Print(userFr2)} = {Fraction.Print(Fr4)}  = {Fr4.DC:f2}");
            Fraction Fr5 = userFr1 * userFr2;
            Fraction.Reduce(Fr5);
            Console.WriteLine($"{Fraction.Print(userFr1)} * {Fraction.Print(userFr2)} = {Fraction.Print(Fr5)}  = {Fr5.DC:f2}");
            Fraction Fr6 = userFr1 / userFr2;
            Fraction.Reduce(Fr6);
            Console.WriteLine($"{Fraction.Print(userFr1)} / {Fraction.Print(userFr2)} = {Fraction.Print(Fr6)}  = {Fr6.DC:f2}");

            Console.ReadKey();
        }
    }

    class Fraction
    {
        public int num;
        public int denom;
        public readonly double DC;

        public Fraction(int numerator, int denominator)
        {
            this.num = numerator;
            if (denominator == 0)
            {
                throw new System.ArgumentException("Знаменатель не может быть равен 0");
            }
            else { this.denom = denominator; }
            this.DC = (double)numerator/(double)denominator;
        }
        public static int gcd(int a, int b)
        {
            if (a < b) { (a, b) = (b, a); }
            return b == 0 ? a : gcd(b, a % b);
        }

        #region operators
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.num * f2.denom + f2.num*f1.denom, f1.denom * f2.denom);
        }
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.num * f2.denom - f2.num * f1.denom, f1.denom * f2.denom);
        }
        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.num * f2.num, f1.denom * f2.denom);
        }
        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            if (f2.num == 0)
            {
                throw new System.DivideByZeroException("Числитель второй дроби равен нулю, деление на 0 невозможно");
            } else return new Fraction(f1.num * f2.denom, f1.denom * f2.num);
        }

        #endregion

        public static string Print(Fraction f)
        {
            if (f.denom == 1)
            {
                return $"{f.num}";
            }
            else if (f.num == 0) { return "0"; }
            else return $"{f.num}/{f.denom}";
        }

        public static Fraction Reduce(Fraction f)
        {
            int r = Fraction.gcd(f.num, f.denom);
            f.num /= r;
            f.denom /= r;
            return f;
        }

    }
}
