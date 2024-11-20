using System;

namespace OOP_lab5
{
    public class Transformer : Create
    {
        public int Power { get; set; }

        public Transformer(string name, int yearOfCreation, int power) : base(name, yearOfCreation)
        {
            Power = power;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Трансформер: {Name}, Год создания: {YearOfCreation}, Мощность: {Power}");
        }
    }
}
