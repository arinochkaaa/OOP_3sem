using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class Human: IntelligentBeing, ILive 

    {
        public Human(string name) : base(name) {}

        public override void Think()
        {
            Console.WriteLine($"{Name} думает.");
        }
        public void start()
        {
            Console.WriteLine($"{Name} идет");
        }
        public void stop()
        {
            Console.WriteLine($"{Name} остановился");
        }
        public override string ToString()
        {
            return $"Человек: {Name}";
        }
    }
}
