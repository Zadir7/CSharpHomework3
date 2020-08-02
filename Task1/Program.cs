using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool actionCheck = false;
            string actionRead;
            Complex z1 = new Complex(-1, 4);
            Complex z2 = new Complex(3, -14);
            Console.WriteLine($"Заданы два комплексных числа: {Complex.Print(z1)} и {Complex.Print(z2)}");
            do
            {
                Console.WriteLine($"Введите с клавиатуры действие: +, - али *:");
                actionRead = Console.ReadLine();
                switch (actionRead)
                {
                    case "+": 
                        Console.WriteLine($"Результат сложения: {Complex.Print(z1 + z2)}");
                        actionCheck = true;
                        break;
                    case "-":
                        Console.WriteLine($"Результат вычитания: {Complex.Print(z1 - z2)}");
                        actionCheck = true;
                        break;
                    case "*":
                        Console.WriteLine($"Результат умножения: {Complex.Print(z1 * z2)}");
                        actionCheck = true;
                        break;
                    default:
                        Console.WriteLine($"Вы ввели не действие!");
                        break;
                }
            }
            while (actionCheck == false);

            Console.ReadKey();
        }
    }

    public struct Complex
    {
        private double re;
        private double im;

        public Complex(double _re, double _im)
        {
            this.re = _re;
            this.im = _im;
        }


        #region operatoroverride
        public static Complex operator +(Complex com1, Complex com2)
        {
            return new Complex(com1.re+com2.re, com1.im+com2.im);
        }

        public static Complex operator -(Complex com1, Complex com2)
        {
            return new Complex(com1.re - com2.re, com1.im - com2.im);
        }

        public static Complex operator *(Complex com1, Complex com2)
        {
            return new Complex(com1.re * com2.re - com1.im * com2.im, com1.re * com2.im + com2.re * com1.im);
        }
        #endregion

        #region MathMethods
        /*public static Complex Subtract(Complex com1, Complex com2)
        {
            return new Complex(com1.re - com2.re, com1.im - com2.im);
        }
        public static Complex Add(Complex com1, Complex com2)
        {
            return new Complex(com1.re + com2.re, com1.im + com2.im);
        }
        public static Complex Multiply(Complex com1, Complex com2)
        {
            return new Complex(com1.re * com2.re - com1.im * com2.im, com1.re * com2.im + com2.re * com1.im);
        }
        */
        #endregion

        public static string Print(Complex com)
        {
            if (com.re == 0) { return $"{com.im}i"; }
            else if (com.im == 0) { return $"{com.re}"; }
            else if (com.im < 0) { return $"{com.re} - {-com.im}i"; }
            else { return $"{com.re} + {com.im}i"; }
        }
    }
}
