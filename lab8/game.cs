using System;

namespace lab8
{
    public delegate void AttackHandler(int damage);
    public delegate void HealHandler(int amount);

    public class Game
    {
        public event AttackHandler OnAttack;
        public event HealHandler OnHeal;

        public void Attack(int damage)
        {
            Console.WriteLine($"Игра: Атака с уроном {damage}.");
            OnAttack?.Invoke(damage);
        }

        public void Heal(int amount)
        {
            Console.WriteLine($"Игра: Лечение на {amount}.");
            OnHeal?.Invoke(amount);
        }
    }
}
