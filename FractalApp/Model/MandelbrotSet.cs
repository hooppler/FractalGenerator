// Author: Aleksandar Stojimirovic
// E-mail: stojimirovic@yahoo.com
// Mob:    +381 60 087 2516
using System;

namespace FractalApp.Model
{
    class MandelbrotSet
    {
        int CNT_MAX = 20;

        public int MAXItter
        {
            get { return CNT_MAX; }
            set { CNT_MAX = value; }
        }

        public int CalculatePointSpeed(ComplexNumber c)
        {
            int Cnt = 0;
            ComplexNumber z = new ComplexNumber(0, 0);

            while (Cnt < CNT_MAX && Absolute(z) < 2)
            {
                z = (z.Dot(z)).Sum(c);
                Cnt++;
            }
            return Cnt;
        }

        public double Absolute(ComplexNumber z)
        {
            return Math.Sqrt(Math.Pow(z.Re, 2) + Math.Pow(z.Im, 2));
        }

        public bool IsInMandelbrotSet(ComplexNumber c, int Trashold)
        {
            int n = CalculatePointSpeed(c);
            if (n < Trashold)
            {
                return true;
            }
            return false;
        }

        public int GetGrayCollor(ComplexNumber c)
        {
            double n = (double)CalculatePointSpeed(c);
            double color = 255 - 255 * (n / (double)MAXItter);
            return (int)color;
        }
    }
}
