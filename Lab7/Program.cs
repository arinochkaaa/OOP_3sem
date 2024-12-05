using System;
using System.Collections.Generic;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Тестирование с целыми числами:");
            var intCollection = new CollectionType<int>();
            intCollection.Add(10);
            intCollection.Add(20);
            intCollection.Add(30);
            intCollection.Remove(20);
            foreach (var item in intCollection.View(x => x > 10))
            {
                Console.WriteLine(item);
            }

            string intFilePath = "integers.json";
            intCollection.SaveToFile(intFilePath);
            intCollection.LoadFromFile(intFilePath);

            Console.WriteLine("\nТестирование с дробными числами:");
            var doubleCollection = new CollectionType<double>();
            doubleCollection.Add(10.5);
            doubleCollection.Add(20.1);
            doubleCollection.Add(30.2);
            foreach (var item in doubleCollection.View(x => x > 15))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nТестирование с пользовательским классом Person:");
            var personCollection = new CollectionType<Person>();
            personCollection.Add(new Person { Name = "Арина", Age = 19 });
            personCollection.Add(new Person { Name = "Дима", Age = 21 });
            personCollection.Add(new Person { Name = "Катя", Age = 43 });

            foreach (var person in personCollection.View(p => p.Age > 30))
            {
                Console.WriteLine(person);
            }

            string personFilePath = "persons.json";
            personCollection.SaveToFile(personFilePath);
            personCollection.LoadFromFile(personFilePath);
        }
    }
}
