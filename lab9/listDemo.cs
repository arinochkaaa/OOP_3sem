using System;
using System.Collections.Generic;

namespace lab9.Collections
{
    public static class ListDemo
    {
        public static void RunDemo()
        {
            
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine("Исходная коллекция:");
            list.ForEach(Console.WriteLine);

         
            int n = 3;
            list.RemoveRange(0, n);

           
            list.Add(11);
            list.AddRange(new[] { 12, 13 });

            Console.WriteLine("\nпосле модификации:");
            list.ForEach(Console.WriteLine);

            
            var dictionary = new Dictionary<int, int>();
            for (int i = 0; i < list.Count; i++)
            {
                dictionary[i] = list[i];
            }

           
            Console.WriteLine("\nвторая коллекция:");
            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"ключ: {kvp.Key}, значение: {kvp.Value}");
            }

            
            int searchValue = 13;
            bool found = dictionary.ContainsValue(searchValue);
            Console.WriteLine($"\nзгначение {searchValue} найдено: {found}");
        }
    }
}
