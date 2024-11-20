using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class ArmyOfTransformersContainer<T>
    {
        private T[] items;
        private int count;

        
        public ArmyOfTransformersContainer(int transformers)
        {
            items = new T[transformers];
            count = 0;
        }

        
        public void Add(T item)
        {
            if (count < items.Length)
            {
                items[count] = item;
                
                count++;
            }
            else
            {
                Console.WriteLine("Армия заполнена");
            }
        }
        
        
        public T Get(int index)
        {
            if (index >= 0 && index < count)
            {
                return items[index];
            }
            else
            {
                throw new IndexOutOfRangeException("Порядковый номер в армии и имя");
            }
        }

       
        public int Count => count;

        
        public void PrintItems()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(items[i]);
            }
        }
    }

}
