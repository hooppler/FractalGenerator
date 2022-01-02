// Author: Aleksandar Stojimirovic
// E-mail: stojimirovic@yahoo.com
// Mob:    +381 60 087 2516

namespace FractalApp.Model
{
    class ComplexNumber
    {
        public ComplexNumber(double x, double y)
        {
            Re = x;
            Im = y;
        }
        public double Re { get; set; }
        public double Im { get; set; }

        public ComplexNumber Sum(ComplexNumber x)
        {
            return new ComplexNumber(Re + x.Re, Im + x.Im);
        }

        public ComplexNumber Dot(ComplexNumber x)
        {
            return new ComplexNumber(Re * x.Re - Im * x.Im, Re * x.Im + Im * x.Re);
        }
    }
}
