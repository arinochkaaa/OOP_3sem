using System;

namespace OOP_lab5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Army army = new Army();

            try
            {
                try
                {
                    army.AddUnit(null);
                }
                catch (InvalidUnitDataException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }

                army.AddUnit(new Transformer("Оптимус Прайм", 2000, 3000));
                army.AddUnit(new Human("Джон", 1985, "Полковник"));

                try
                {
                    army.RemoveUnit("Мегатрон");
                }
                catch (UnitNotFoundException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }

                try
                {
                    army.FindUnitByYear(1999);
                }
                catch (UnitNotFoundException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }

                int unitCount = army.Count;
                if (unitCount > 0)
                {
                    int efficiency = army.CalculatePowerEfficiency(5000, unitCount);
                    Console.WriteLine($"Эффективность мощности: {efficiency}");
                }
                else
                {
                    Console.WriteLine("Ошибка: Невозможно рассчитать эффективность мощности - в армии нет боевых единиц.");
                }

                army.DisplayArmyInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Завершение работы программы.");
            }
        }
    }
}
