using System;

namespace ConsoleApplication1
{
    class Program
    {
        public static double f(double x)
        {
            return x * x - 4; // приклад: x² - 4 = 0 → корені ±2
        }

        static void Main(string[] args)
        {
            double a, b, c, Eps;
            int Lich = 0;

            Console.WriteLine("Input a, b, eps:");
            a = Convert.ToDouble(Console.ReadLine());
            b = Convert.ToDouble(Console.ReadLine());
            Eps = Convert.ToDouble(Console.ReadLine());
            if (f(a) * f(b) > 0)
            {
                Console.WriteLine("No root in the interval");
                Console.ReadLine();
                return;
            }

            if (Math.Abs(f(a)) < Eps)
            {
                Console.WriteLine("x = " + a + "  Lich = " + Lich);
                Console.ReadLine();
                return;
            }
            else if (Math.Abs(f(b)) < Eps)
            {
                Console.WriteLine("x = " + b + "  Lich = " + Lich);
                Console.ReadLine();
                return;
            }
            else
            {
                while (Math.Abs(b - a) > Eps)
                {
                    c = 0.5 * (a + b);
                    Lich++;

                    if (Math.Abs(f(c)) < Eps)
                    {
                        Console.WriteLine("x = " + c + "  Lich = " + Lich);
                        Console.ReadLine();
                        return;
                    }
                    else if (f(a) * f(c) < 0)
                        b = c;
                    else
                        a = c;
                }

                Console.WriteLine("x = " + (a + b) / 2 + "  Lich = " + Lich);
                Console.ReadLine();
            }
        }
    }
}
