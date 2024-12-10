using System;

namespace lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            // Путь для вывода данных
            string outputPath = "reflector_output.txt";

            
            Console.WriteLine("== Исследование TestClass1 ==");
            Reflector.GetAssemblyName("lab11.TestClass1", outputPath);
            Console.WriteLine($"Название сборки записано в файл {outputPath}");

            Console.WriteLine($"Есть публичные конструкторы: {Reflector.HasPublicConstructors("lab11.TestClass1")}");
            Console.WriteLine("Публичные методы:");
            foreach (var method in Reflector.GetPublicMethods("lab11.TestClass1"))
                Console.WriteLine(method);

            Console.WriteLine("Поля и свойства:");
            foreach (var item in Reflector.GetFieldsAndProperties("lab11.TestClass1"))
                Console.WriteLine(item);

            Console.WriteLine("Реализованные интерфейсы:");
            foreach (var item in Reflector.GetImplementedInterfaces("lab11.TestClass1"))
                Console.WriteLine(item);

            Console.WriteLine("Методы с параметром типа int:");
            foreach (var method in Reflector.GetMethodsWithParameterType("lab11.TestClass1", "Int32"))
                Console.WriteLine(method);

            // Вызов метода с параметрами из файла
            Console.WriteLine("Вызов метода с параметрами из файла:");
            var result = Reflector.InvokeMethodFromFile("lab11.TestClass1", "ExampleMethod", "parameters.txt");
            Console.WriteLine($"Результат: {result}");

            // Создание объекта через обобщённый метод
            Console.WriteLine("Создание объекта с использованием Create<T>:");
            var obj = Reflector.Create<TestClass2>();
            Console.WriteLine($"Созданный объект: {obj}");
        }
    }
}
