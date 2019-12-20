using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4
{
     class KvadratInter
    {

        private double Z;

       

        public void KvadratInterpolSearch(double a, double h, double epsilon)
        {
            double[] Xx = new double[5];
            double[] Ff = new double[5];
            double X;
            Xx[1] = a;
            X = Xx[1];
            function(X);
            Ff[1] = Z;
            Xx[2] = a + h;
            X = Xx[2];
            function(X);
            Ff[2] = Z;
            if (Ff[1] < Ff[2])
            {
                Xx[3] = a - h;
                X = Xx[3];
                function(X);
                Ff[3] = Z;
            }
            else
            {
                Xx[3] = a + 2 * h;
                X = Xx[3];
                function(X);
                Ff[3] = Z;
            }
            Console.WriteLine("Вычисление первого аппроксимирующего минимума");
            Console.WriteLine("X(I)\tF(I)");
            double DN = (Xx[2] - Xx[3]) * Ff[1];
            DN = DN + (Xx[3] - Xx[1]) * Ff[2] + (Xx[1] - Xx[2]) * Ff[3];
            double NM = (Xx[2] * Xx[2] - Xx[3] * Xx[3]) * Ff[1];
            NM = NM + (Xx[3] * Xx[3] - Xx[1] * Xx[1]) * Ff[2];
            NM = NM + (Xx[1] * Xx[1] - Xx[2] * Xx[2]) * Ff[3];
            Xx[4] = NM / (2 * DN);
            X = Xx[4];
            function(X);
            Ff[4] = Z;
            double F;
            while (true)
            {
                for (int j = 1; j < 4; j++)
                {
                    for (int k = j + 1; k < 5; k++)
                    {
                        if (Ff[j] <= Ff[k])
                        {
                            break;
                        }
                        X = Xx[j];
                        Xx[j] = Xx[k];
                        Xx[k] = X;
                        F = Ff[j];
                        Ff[j] = Ff[k];
                        Ff[k] = F;
                    }
                }
                for (int i = 1; i < 5; i++)
                {
                    Console.WriteLine(Xx[i] + "\t" + Ff[i]);
                }
                Console.WriteLine("\n");
                if (Math.Abs(Xx[1] - Xx[2]) < epsilon)
                {
                    break;
                }
                int S1 = getSignum(Xx[2] - Xx[1]);//Integer.signum()
                int S2 = getSignum(Xx[3] - Xx[1]);
                int S3 = getSignum(Xx[4] - Xx[1]);
                if (S1 == S2 && S1 == -S3)
                {
                    Xx[3] = Xx[4];
                    Ff[3] = Ff[4];
                }
                DN = (Xx[2] - Xx[3]) * Ff[1] + (Xx[3] - Xx[1]) * Ff[2] + (Xx[1] - Xx[2]) * Ff[3];
                F = (Ff[1] - Ff[2]) / (2 * DN);
                F = F * (Xx[2] - Xx[3]) * (Xx[3] - Xx[1]);
                Xx[4] = (Xx[1] + Xx[2]) / 2 + F;
                X = Xx[4];
                function(X);
                Ff[4] = Z;
            }
            Console.WriteLine("\n");
            Console.WriteLine("X=" + Xx[1] + " F=" + Ff[1]);

        }

        private void function(double X)
        {
            Z = 2 * X * X - Math.Exp(X);
        }

        private int getSignum(double number)
        {
            if (number == 0) return 0;
            if (number > 0) return 1;
            return -1;
        }
    }
}
