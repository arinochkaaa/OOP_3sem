using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab5
{
    public struct Parameters
    {
        public double Lenght { get; set; }
        public double Wight { get; set; }
        public double Height { get; set; }

        public Parameters(double lenght, double wight, double height)
        {
            Lenght = lenght;
            Wight = wight;
            Height = height;
        }

        public override string ToString()
        {
            return $"Длина:{Lenght} м, Ширина:{Wight} м, Высота:{Height} м.";
        }
    }
}
