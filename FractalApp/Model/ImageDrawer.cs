// Author: Aleksandar Stojimirovic
// E-mail: stojimirovic@yahoo.com
// Mob:    +381 60 087 2516
using System;
using System.Collections.Generic;
using System.Drawing;

namespace FractalApp.Model
{
    public class ImageDrawer
    {
        private Bitmap bmp;
        private int width;
        private int height;
        MandelbrotSet mbs = new MandelbrotSet();
        public double Scale { get; set; }
        public double Xoffset { get; set; }
        public double Yoffset { get; set; }
        public ImageDrawer(int Width, int Height)
        {
            this.width = Width;
            this.height = Height;
            this.bmp = new Bitmap(Width, Height);

            this.Scale = 0.01;
            this.Xoffset = -2;
            this.Yoffset = -2;
        }

        public Bitmap DrawBlackWhite()
        {
            for (int i=0; i<this.width; i++)
            {
                for (int j=0; j<this.height; j++)
                {
                    ComplexNumber c = new ComplexNumber((double)i/250 -2, (double)j/250 -2);
                    int n = mbs.CalculatePointSpeed(c);
                    if (n < 20)
                    {
                        bmp.SetPixel(i, j, Color.White);
                    }
                    else
                    {
                        bmp.SetPixel(i, j, Color.Black);
                    }
                }
            }
            return bmp;
        }

        public Bitmap DrawGray()
        {
            for (int i = 0; i < this.width; i++)
            {
                for (int j = 0; j < this.height; j++)
                {
                    ComplexNumber c = new ComplexNumber((double)i * Scale + Xoffset, (double)j * Scale + Yoffset);
                    int color = mbs.GetGrayCollor(c);

                    bmp.SetPixel(i, j, Color.FromArgb(color, color, color));

                }
            }
            return bmp;
        }

        public Bitmap DrawColor()
        {
            for (int i = 0; i < this.width; i++)
            {
                for (int j = 0; j < this.height; j++)
                {
                    //ComplexNumber c = new ComplexNumber((double)i / 250 - 2, (double)j / 250 - 2);
                    ComplexNumber c = new ComplexNumber((double)i * Scale + Xoffset, (double)j * Scale + Yoffset);
                    double saturation = mbs.CalculatePointSpeed(c) / mbs.MAXItter;

                    List<int> rgb = HSLtoRGB(200, saturation, 0.5);

                    bmp.SetPixel(i, j, Color.FromArgb(rgb[0], rgb[1], rgb[2]));

                }
            }
            return bmp;
        }

        public List<int> HSLtoRGB(double H, double S, double L)
        {
            double Rp = 0;
            double Gp = 0;
            double Bp = 0;
            int R, G, B;
            double C, X, m;
            List<int> Result = new List<int>();

            C = (1 - Math.Abs(2 * L - 1)) * S;
            X = C * (1 - Math.Abs(((H / 60) % 2) - 1));
            m = L - C / 2;

            if (0 <= H && H < 60) { Rp = C; Gp = X; Bp = 0; }
            if (60 <= H && H < 120) { Rp = X; Gp = C; Bp = 0; }
            if (120 <= H && H < 180) { Rp = 0; Gp = C; Bp = X; }
            if (180 <= H && H < 240) { Rp = 0; Gp = X; Bp = C; }
            if (240 <= H && H < 300) { Rp = X; Gp = 0; Bp = C; }
            if (300 <= H && H < 360) { Rp = C; Gp = 0; Bp = X; }

            R = (int)((Rp + m) * 255);
            G = (int)((Gp + m) * 255);
            B = (int)((Bp + m) * 255);

            Result.Add(R);
            Result.Add(G);
            Result.Add(B);

            return Result;
        }
    }
}
