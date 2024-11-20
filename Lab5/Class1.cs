using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    abstract class IntelligentBeing
    {
        public string Name {  get; set; }
        
        public IntelligentBeing(string name)
        {
            Name = name;
        }
        public abstract void Think();

        public override string ToString()
        {
            return $"Разумное существо: {Name}";
        }
    }
}
