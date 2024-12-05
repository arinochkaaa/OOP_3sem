using System;

namespace Lab7
{
    public class Person : IComparable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(object obj)
        {
            if (obj is Person other)
            {
                return Age.CompareTo(other.Age);
            }
            throw new ArgumentException("Объект не является экземпляром класса Person.");
        }

        public override string ToString()
        {
            return $"{Name}, возраст: {Age}";
        }
    }
}
