using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using lab9.Models;

namespace lab9.Collections
{
    public static class ObservableDemo
    {
        public static void RunDemo()
        {
            var products = new ObservableCollection<Product>();

            
            products.CollectionChanged += Products_CollectionChanged;

            
            products.Add(new Product { ID = 1, Name = "телефон", Price = 500 });
            products.Add(new Product { ID = 2, Name = "планшет", Price = 300 });

            
            products.RemoveAt(0);

            
            products[0] = new Product { ID = 3, Name = "ноутбук", Price = 1000 };
        }

        private static void Products_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Product newItem in e.NewItems)
                    Console.WriteLine($"добавлен: {newItem}");
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Product oldItem in e.OldItems)
                    Console.WriteLine($"удалён: {oldItem}");
            }
            else if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                foreach (Product oldItem in e.OldItems)
                    Console.WriteLine($"заменено: {oldItem}");

                foreach (Product newItem in e.NewItems)
                    Console.WriteLine($"на: {newItem}");
            }
        }
    }
}
