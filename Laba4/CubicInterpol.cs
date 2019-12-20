using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4
{
    class CubicInterpol
    {
        double CC = 0;
        double GO = 0;
        double TT = 0;
        private double Z;
        double[] X;
        double[] P;
        double[] Q;
        double[] D;
        double[] G;
        int N;//Если ничего не будет работать то +1
        public void CubicInterpolS()
        {
            

            Console.WriteLine("Введите число переменных");
            N = int.Parse(Console.ReadLine());
            X = new double[N];
            P = new double[N];
            Q = new double[N];
            D = new double[N];
            G = new double[N];
            Console.WriteLine("Начальная точка");
            for (int i = 1; i < N; i++)
            {
                X[i] = double.Parse(Console.ReadLine());
            }
            Console.WriteLine("Направление D");
            for (int i = 1; i < N; i++)
            {
                D[i] = double.Parse(Console.ReadLine());
            }
            Console.WriteLine("Задайте точность Е");
            double E = double.Parse(Console.ReadLine());
            Console.WriteLine("Предполагаемое занчение минимум");
            double FM = double.Parse(Console.ReadLine());
            Console.WriteLine("Текущие Значение");
            for (int i = 1; i < N; i++)
            {
                P[i] = X[i];
                Console.WriteLine("x\t" + i + "\t" + X[i]);
            }
            function5000();
            Console.WriteLine("Итерация " + CC + "Значение " + Z);
            double FP = Z;
            function6000();
            double G1 = GO;
            double GP, G2, G3, QX;

            while (true)
            {
                GP = 0;
                for (int I = 0; I < N; I++)
                    GP = GP + G[I] * D[I];
                if (GP <= 0)
                    break;

                QX = Math.Abs(2 * (FP - FM) / GP);
                if (QX > 1)
                    QX = 1;
                for (int i = 1; i < N; i++)
                {
                    X[i] = P[i] - QX * D[i];
                    P[i] = X[i];
                }
                function5000();
                FP = Z;
                Console.WriteLine("Возможна нестабильность?");
                function6000();
                G1 = GO;
            }


            double HH, BB;
            QX = Math.Abs(2 * (FP - FM) / GP);
            if (QX > 1)
                QX = 1;
            HH = QX;

            double FQ, GQ;

            while (true)
            {

                BB = HH;
                for (int i = 1; i < N; i++)
                {
                    Q[i] = P[i] + BB * D[i];
                    X[i] = Q[i];
                }
                function5000();
                FQ = Z;
                function6000();
                G2 = GO;
                GQ = 0;
                for (int i = 1; i < N; i++)
                    GQ = GQ + G[i] * D[i];
                if (GQ > 0 || FQ > FP)
                    break;
                HH = 2 * HH;
            }

            double ZZ, WW, W, DD, FR, GR;
            while (true)
            {
                ZZ = 3 * (FP - FQ) / HH;
                ZZ = ZZ + GP + GQ;
                WW = ZZ * ZZ - GP * GQ;
                if (WW < 0)
                    WW = 0;
                W = Math.Sqrt(WW);
                DD = HH * (1 - (GQ + W - ZZ) / (GQ - GP + 2 * W));
                for (int I = 0; I < N; I++)
                    X[I] = P[I] + DD * D[I];
                function5000();
                FR = Z;
                function6000();
                G3 = GO;
                GR = 0;
                for (int i = 1; i < N; i++)
                    GR = GR + G[i] * D[i];
                if (GR < 0)
                {
                    if (Math.Abs(GR) < E)
                        break;
                    HH = BB - DD;
                    for (int i = 1; i < N; i++)
                    {
                        P[i] = X[i];
                        Console.WriteLine("X " + i + "\t\t" + X[i]);
                    }
                    CC = CC + 1;
                    function5000();
                    function6000();
                    Console.WriteLine("Итерация  " + CC + "   Значение  " + Z);
                    FP = Z; GP = GR; G1 = GO;
                }
                else
                {
                    if (Math.Abs(GR) < E)
                        break;
                    HH = DD;
                    for (int i = 1; i < N; i++)
                    {
                        Q[i] = X[i];
                        Console.WriteLine("X " + i + "\t\t" + X[i]);
                    }
                    CC = CC + 1;
                    function5000();
                    function6000();
                    Console.WriteLine("Итерация  " + CC + "   Значение  " + Z);
                    FQ = Z; GQ = GR; G2 = GO;
                }
            }
            function5000();
            Console.WriteLine("Минимизация закончена");
            Console.WriteLine("Количество итераций =\t" + CC + "\tЗначение минимума = " + Z);
            for (int i = 1; i < N; i++)
                Console.WriteLine("X " + i + "\t\t" + X[i]);
        }

        private void function5000()
        {
            Z = 0;
            Z = 100 * Math.Pow((X[2] - X[1] * X[1]), 2);
            Z = Z + Math.Pow((1 - X[1]), 2);
            TT = TT + 1;
        }
        private void function6000()
        {
            GO = 0;
            G[1] = -400 * X[1] * (X[2] - X[1] * X[1]);
            G[1] = G[1] - 2 * (1 - X[1]);
            G[2] = 200 * (X[2] - X[1] * X[1]);
            for (int i = 0; i < N; i++)
            {
                GO = GO + G[i] * G[i];
            }
            GO = Math.Sqrt(GO);
        }
    }
}
