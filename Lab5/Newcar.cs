using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
     class Newcar : ForCar
    {
        public string Model { get; set; }
        public CarType Type { get; set; }
        public Parameters CarParameters { get; set; }

        public Newcar(string model, CarType type, Parameters parameters)
        {
            Model = model;
            Type = type;
            CarParameters = parameters;
        }

        public override void InfoCar()
        {
            Console.WriteLine(Model);
            Console.WriteLine(Type);
            Console.WriteLine(CarParameters);
        }
    }
}

