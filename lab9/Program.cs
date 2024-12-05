using lab9.Collections;
using lab9.Models;

namespace lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ConcurrentBag<Product> Demo ===");
            var manager = new ProductManager();
            manager.AddProduct(new Product { ID = 1, Name = "Ноутбук", Price = 1500 });
            manager.AddProduct(new Product { ID = 2, Name = "Телефон", Price = 800 });
            manager.DisplayProducts();

            Console.WriteLine("\n=== List<int> and Dictionary<int, int> Demo ===");
            ListDemo.RunDemo();

            Console.WriteLine("\n=== ObservableCollection<Product> Demo ===");
            ObservableDemo.RunDemo();
        }
    }
}
