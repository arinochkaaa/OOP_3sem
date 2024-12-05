using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Lab7
{
    public class CollectionType<T> : IGenericCollection<T> where T : IComparable
    {
        private List<T> _items = new List<T>();

        public void Add(T item)
        {
            try
            {
                _items.Add(item);
                Console.WriteLine($"Добавлено: {item}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Операция добавления завершена.");
            }
        }

        public bool Remove(T item)
        {
            try
            {
                if (_items.Remove(item))
                {
                    Console.WriteLine($"Удалено: {item}");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Элемент {item} не найден.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении: {ex.Message}");
                return false;
            }
            finally
            {
                Console.WriteLine("Операция удаления завершена.");
            }
        }

        public IEnumerable<T> View(Func<T, bool> predicate)
        {
            try
            {
                return _items.Where(predicate);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при просмотре элементов: {ex.Message}");
                return Enumerable.Empty<T>();
            }
        }

        public void SaveToFile(string filePath)
        {
            try
            {
                var json = JsonSerializer.Serialize(_items);
                File.WriteAllText(filePath, json);
                Console.WriteLine($"Коллекция сохранена в файл: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении в файл: {ex.Message}");
            }
        }

        public void LoadFromFile(string filePath)
        {
            try
            {
                var json = File.ReadAllText(filePath);
                _items = JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
                Console.WriteLine($"Коллекция загружена из файла: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке из файла: {ex.Message}");
            }
        }
    }
}
