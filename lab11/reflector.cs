using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace lab11
{
    public static class Reflector
    {
        // Метод для получения имени сборки
        public static void GetAssemblyName(string className, string outputPath)
        {
            var type = Type.GetType(className);
            if (type == null) return;
            var assemblyName = type.Assembly.GetName().Name;
            File.WriteAllText(outputPath, $"Сборка: {assemblyName}");
        }

        // Проверка наличия публичных конструкторов
        public static bool HasPublicConstructors(string className)
        {
            var type = Type.GetType(className);
            return type?.GetConstructors(BindingFlags.Public | BindingFlags.Instance).Length > 0;
        }

        // Получение всех публичных методов класса
        public static IEnumerable<string> GetPublicMethods(string className)
        {
            var type = Type.GetType(className);
            return type?.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                        .Select(m => m.Name) ?? Enumerable.Empty<string>();
        }

        // Получение полей и свойств класса
        public static IEnumerable<string> GetFieldsAndProperties(string className)
        {
            var type = Type.GetType(className);
            if (type == null) return Enumerable.Empty<string>();

            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                             .Select(f => $"Поле: {f.Name}");
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                 .Select(p => $"Свойство: {p.Name}");
            return fields.Concat(properties);
        }

        // Получение всех реализованных интерфейсов
        public static IEnumerable<string> GetImplementedInterfaces(string className)
        {
            var type = Type.GetType(className);
            return type?.GetInterfaces().Select(i => i.Name) ?? Enumerable.Empty<string>();
        }

        // Получение всех методов с параметром заданного типа
        public static IEnumerable<string> GetMethodsWithParameterType(string className, string parameterTypeName)
        {
            var type = Type.GetType(className);
            if (type == null) return Enumerable.Empty<string>();

            return type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                       .Where(m => m.GetParameters().Any(p => p.ParameterType.Name == parameterTypeName))
                       .Select(m => m.Name);
        }

        // Вызов метода с параметрами из файла
        public static object InvokeMethodFromFile(string className, string methodName, string filePath)
        {
            var parameters = ReadParametersFromFile(filePath); // Читаем параметры из файла
            return InvokeMethod(className, methodName, parameters); // Вызов метода с параметрами
        }

        // Считывание параметров из файла
        private static object[] ReadParametersFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath); // Читаем все строки из файла
            var parameters = new List<object>();

            foreach (var line in lines)
            {
                var parameter = ConvertParameter(line); // Преобразуем строку в нужный тип
                parameters.Add(parameter);
            }

            return parameters.ToArray();
        }

        // Преобразование строки в соответствующий тип
        private static object ConvertParameter(string parameter)
        {
            // Преобразуем строку в типы (int, bool, string и другие по мере необходимости)
            if (int.TryParse(parameter, out int intParam))
                return intParam;

            if (bool.TryParse(parameter, out bool boolParam))
                return boolParam;

            return parameter; // Если не int, не bool, возвращаем строку
        }

        // Вызов метода с переданными параметрами
        public static object InvokeMethod(string className, string methodName, object[] parameters)
        {
            var type = Type.GetType(className);
            if (type == null) throw new ArgumentException("Класс не найден");
            var method = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            if (method == null) throw new ArgumentException("Метод не найден");

            var instance = Activator.CreateInstance(type); // Создание экземпляра класса
            return method.Invoke(instance, parameters); // Вызов метода
        }

        // Обобщённый метод для создания объекта
        public static T Create<T>() where T : new()
        {
            return new T(); // Создаём новый объект типа T
        }
    }
}
