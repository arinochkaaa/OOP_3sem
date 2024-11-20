using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OOP_lab5
{
    public class Army
    {
        private List<Create> units;

        public Army()
        {
            units = new List<Create>();
        }

        public void AddUnit(Create unit)
        {
            if (unit == null || string.IsNullOrWhiteSpace(unit.Name))
                throw new InvalidUnitDataException("Данные боевой единицы некорректны: Имя не может быть пустым.");
            units.Add(unit);
        }

        public bool RemoveUnit(string name)
        {
            Create unitToRemove = units.Find(unit => unit.Name == name);
            if (unitToRemove != null)
            {
                units.Remove(unitToRemove);
                return true;
            }
            throw new UnitNotFoundException($"Боевая единица с именем '{name}' не найдена в армии.");
        }

        public Create FindUnitByYear(int year)
        {
            Create unit = units.Find(unit => unit.YearOfCreation == year);
            if (unit == null)
                throw new UnitNotFoundException($"Боевая единица с годом создания {year} не найдена.");
            return unit;
        }

        public List<Transformer> GetTransformersByPower(int power)
        {
            List<Transformer> result = new List<Transformer>();
            foreach (var unit in units)
            {
                if (unit is Transformer transformer && transformer.Power == power)
                {
                    result.Add(transformer);
                }
            }
            if (result.Count == 0)
                throw new UnitNotFoundException($"Трансформеры с мощностью {power} не найдены.");
            return result;
        }

        public void DisplayArmyInfo()
        {
            if (units.Count == 0)
            {
                Console.WriteLine("Армия пуста.");
                return;
            }
            foreach (var unit in units)
            {
                unit.DisplayInfo();
            }
        }

        public int Count => units.Count;

        public int CalculatePowerEfficiency(int totalPower, int unitCount)
        {
            Debug.Assert(unitCount != 0, "Количество единиц должно быть больше нуля.");
            if (unitCount == 0)
                throw new DivideByZeroException("Невозможно рассчитать эффективность мощности: количество боевых единиц равно нулю.");
            return totalPower / unitCount;
        }
    }
}
