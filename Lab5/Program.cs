using Lab5;

namespace lab5;
class Program
{
    
    static void Main(string[] args)
    {
       Parameters CarParameters = new Parameters(4.2, 2.3, 2.5);
    Newcar car = new Newcar("Porsche 911", CarType.Электрическая, CarParameters);
        car.InfoCar();

        ArmyOfTransformersContainer<string> container = new(10);

        container.Add("Human");
        container.Add("Terminator");
        container.Add("Boss");
        container.Add("Victor");

        container.PrintItems();

        Console.WriteLine("Элемент с индексом 1: " + container.Get(1));
        Console.WriteLine("Элемент с индексом 2: " + container.Get(2));
        Console.WriteLine("Элемент с индексом 3: " + container.Get(3));
        Console.WriteLine("Элемент с индексом 4: " + container.Get(4));
    }
}
