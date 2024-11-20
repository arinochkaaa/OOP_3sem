using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    sealed class Transformer : IntelligentBeing, ILive

    {
        public Transformer(string name) : base(name) { }

        public override void Think()
        {
            Console.WriteLine($"{Name} думает.");
        }
        public void start()
        {
            Console.WriteLine($"{Name} превратился в машину и едет");
        }
        public void stop()
        {
            Console.WriteLine($"{Name} превратился обратно в робота и остановился");
        }
        public override string ToString()
        {
            return $"Человек: {Name}";
        }
    }
}
