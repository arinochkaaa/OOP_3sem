using System;

namespace OOP_lab5
{
    public class ArmyController
    {
        private Army army;

        public ArmyController(Army army)
        {
            this.army = army;
        }

        public Create SearchUnitByYear(int year)
        {
            return army.FindUnitByYear(year);
        }

        public void ShowTransformerByPower(int power)
        {
            var transformers = army.GetTransformersByPower(power);
            foreach (var transformer in transformers)
            {
                Console.WriteLine(transformer.Name);
            }
        }

        public void AddCreateUnit(Create unit)
        {
            army.AddUnit(unit);
        }

        public bool RemoveCreateUnit(string name)
        {
            return army.RemoveUnit(name);
        }

        public void ShowAllUnits()
        {
            army.DisplayArmyInfo();
        }

        public void ShowUnitCount()
        {
            Console.WriteLine($"Количество созданий в армии: {army.Count}");
        }
    }
}
