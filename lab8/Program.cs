using System;
using System.Collections.Generic;

namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Игра с событиями ===");

            Game game = new Game();

            GameObject warrior = new GameObject("Воин", 100);
            GameObject mage = new GameObject("Маг", 80);

            game.OnAttack += warrior.ReactToAttack;
            game.OnAttack += mage.ReactToAttack;

            game.OnHeal += amount =>
            {
                Console.WriteLine($"Анонимная обработка: Лечение на {amount}. Событие обработано без объекта.");
            };

            game.Attack(30);
            game.Heal(20);

            Console.WriteLine(warrior);
            Console.WriteLine(mage);

            Console.WriteLine("\n=== Обработка строки ===");

            string input = "   Арина сдала лабу по ООП!  ";
            Console.WriteLine($"Исходная строка: \"{input}\"");

            List<Func<string, string>> processors = new List<Func<string, string>>
            {
                StringProcessor.RemovePunctuation,
                StringProcessor.TrimSpaces,
                StringProcessor.ConvertToUpperCase,
                StringProcessor.AddSymbols,
                StringProcessor.ReplaceSpaces
            };

            string result = StringProcessor.ProcessString(input, processors);
            Console.WriteLine($"Результат обработки: \"{result}\"");
        }
    }
}
