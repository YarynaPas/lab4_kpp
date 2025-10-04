using System;

namespace ConsoleApplication1
{
    class NewtoneMethod
    {

        public static double f(double x)
        {
            return x * x - 4; 
        }

        public static double fp(double x, double D)
        {
            return (f(x + D) - f(x)) / D;
        }

        public static double f2p(double x, double D)
        {
            return (f(x + D) + f(x - D) - 2 * f(x)) / (D * D);
        }

        static void Main(string[] args)
        {
            double a, b, Eps, D, x, Dx;
            int Kmax, i;

            Console.WriteLine("Метод Ньютона (дотичних) для рiвняння f(x)=0");
            Console.WriteLine("Введiть a, b, Eps, Kmax:");

            a = Convert.ToDouble(Console.ReadLine());
            b = Convert.ToDouble(Console.ReadLine());
            Eps = Convert.ToDouble(Console.ReadLine());
            Kmax = Convert.ToInt32(Console.ReadLine());

            D = Eps;
            x = b; 
            if (f(x) * f2p(x, D) < 0)
                x = a; 
            else if (f(x) * f2p(x, D) == 0)
            {
                Console.WriteLine("Для заданого рiвняння збiжність методу Ньютона не гарантується");
                Console.ReadLine();
                return;
            }
            for (i = 1; i <= Kmax; i++)
            {
                double fpx = fp(x, D);

                if (Math.Abs(fpx) < 1e-12)
                {
                    Console.WriteLine("Похiдна близька до нуля — метод зупинено (можлива розбiжність).");
                    Console.ReadLine();
                    return;
                }

                Dx = f(x) / fpx;
                x = x - Dx;

                if (Math.Abs(Dx) < Eps)
                {
                    Console.WriteLine($"\nКорiнь знайдено: x = {x:F10}");
                    Console.WriteLine($"Кiлькість iтерацiй: {i}");
                    Console.ReadLine();
                    return;
                }
            }
            Console.WriteLine($"\nЗа {Kmax} iтерацій корінь з точністю {Eps} не знайдено.");
            Console.ReadLine();
        }
    }
}
