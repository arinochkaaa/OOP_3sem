using System;

namespace OOP_lab5
{
    public abstract class Create
    {
        public string Name { get; set; }
        public int YearOfCreation { get; set; }

        public Create(string name, int yearOfCreation)
        {
            Name = name;
            YearOfCreation = yearOfCreation;
        }

        public abstract void DisplayInfo();
    }
}
