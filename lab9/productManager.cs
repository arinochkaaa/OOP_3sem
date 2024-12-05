using System.Collections.Concurrent;

namespace lab9.Models
{
    public class ProductManager
    {
        private readonly ConcurrentBag<Product> _products = new();

        public void AddProduct(Product product) => _products.Add(product);

        public void RemoveProduct(Product product) => _products.TryTake(out _);

        public Product FindProductByName(string name)
        {
            foreach (var product in _products)
            {
                if (product.Name == name)
                    return product;
            }
            return null;
        }

        public void DisplayProducts()
        {
            foreach (var product in _products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
