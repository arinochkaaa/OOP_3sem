using System;

namespace lab8
{
    public class GameObject
    {
        public string Name { get; }
        public int Health { get; private set; }

        public GameObject(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void ReactToAttack(int damage)
        {
            Health -= damage;
            Console.WriteLine($"{Name} получил {damage} урона. Текущая жизнь: {Health}");
        }

        public void ReactToHeal(int amount)
        {
            Health += amount;
            Console.WriteLine($"{Name} получил {amount} здоровья. Текущая жизнь: {Health}");
        }

        public override string ToString()
        {
            return $"{Name}: {Health} HP";
        }
    }
}
