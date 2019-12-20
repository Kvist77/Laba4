using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите номер метода:\n 1) Золотое сечение\n 2) Квадратичная интерполяция\n 3) Кубическая интерполяция");
            int p = int.Parse(Console.ReadLine());
            if (p == 1) { ZolotoeSechenie(); }
            else if (p == 2)
            {
                KvadratInter kvadratInter = new KvadratInter();
                kvadratInter.KvadratInterpolSearch(1, 0.5, 0.001);
            }
            else if (p == 3)
            {
                CubicInterpol cubicInterpol = new CubicInterpol();
                cubicInterpol.CubicInterpolS();
            }
            Console.ReadLine();
        }
        

        static void ZolotoeSechenie()
        {
            double t1, t2, x0, x1, x2, x3, x, z, f1, f2, I;
            Console.WriteLine("Метод золотого сечения");
            Console.WriteLine("задайте интервал A и B");
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            t1 = 0.3819660113;
            t2 = 1 - t1;
            x0 = a;
            x1 = a + t1 * (b - a);
            x2 = a + t2 * (b - a);
            x3 = b;
            x = x1;
            z = 2 * Math.Pow(x, 2) + 3 * Math.Exp(-x);
            f1 = z;
            x = x2;
            z = 2 * Math.Pow(x, 2) + 3 * Math.Exp(-x);
            f2 = z;
            Console.WriteLine("Текущий интервал");
            while (true)
            {
                Console.WriteLine($"x0 = {x0} и x3 = {x3}");
                if (f2 < f1)
                {
                    I = x3 - x1;
                    x0 = x1;
                    x1 = x2;
                    x2 = x0 + t2 * I;
                    f1 = f2;
                    x = x2;
                    z = 2 * Math.Pow(x, 2) + 3 * Math.Exp(-x);
                    f2 = z;
                    if (I > 0.0005)
                    {
                        continue;
                    }
                    else break;
                }
                else
                {
                    I = x2 - x0;
                    x3 = x2;
                    x2 = x1;
                    x1 = x0 + t1 * I;
                    f2 = f1;
                    x = x1;
                    z = 2 * Math.Pow(x, 2) + 3 * Math.Exp(-x);
                    f1 = z;
                    if (I > 0.0005)
                    {
                        continue;
                    }
                    else break;
                }
            }
            Console.WriteLine($"x = {x1}, F(x) = {f1}");

        }

       

        static void kybinter()
        {

        }
    }
}
