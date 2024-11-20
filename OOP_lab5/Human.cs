using System;

namespace OOP_lab5
{
    public class Human : Create
    {
        public string Rank { get; set; }

        public Human(string name, int yearOfCreation, string rank) : base(name, yearOfCreation)
        {
            Rank = rank;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Человек: {Name}, Год рождения: {YearOfCreation}, Звание: {Rank}");
        }
    }
}
