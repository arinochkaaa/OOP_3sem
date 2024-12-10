using System;
using System.Collections.Generic;
using System.Linq;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            // Массив месяцев
            var months = new string[]
            {
                "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
                "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
            };

            Console.WriteLine("Месяцы длиной 4 символа:");
            var lengthQuery = months.Where(m => m.Length == 4);
            foreach (var month in lengthQuery)
                Console.WriteLine(month);

            Console.WriteLine("\nЛетние и зимние месяцы:");
            var summerWinterQuery = months.Where(m => new[] { "Июнь", "Июль", "Август", "Декабрь", "Январь", "Февраль" }.Contains(m));
            foreach (var month in summerWinterQuery)
                Console.WriteLine(month);

            Console.WriteLine("\nМесяцы в алфавитном порядке:");
            var alphabeticalQuery = months.OrderBy(m => m);
            foreach (var month in alphabeticalQuery)
                Console.WriteLine(month);

            Console.WriteLine("\nКоличество месяцев с буквой 'у' и длиной не менее 4:");
            var countQuery = months.Count(m => m.Contains('у') && m.Length >= 4);
            Console.WriteLine(countQuery);

            
            var students = new List<Student>
            {
                new Student { Name = "Арина", Surname = "Волосюк", Age = 20, Specialization = "Программирование", Group = "ПР-101", Faculty = "ИТ" },
                new Student { Name = "Никита", Surname = "Бондарик", Age = 21, Specialization = "Физика", Group = "ФИ-202", Faculty = "Физфак" },
                new Student { Name = "Иван", Surname = "Филипчик", Age = 19, Specialization = "Программирование", Group = "ПР-101", Faculty = "ИТ" },
                new Student { Name = "Мария", Surname = "Морозова", Age = 22, Specialization = "Математика", Group = "МТ-303", Faculty = "Мехмат" },
                new Student { Name = "Елена", Surname = "Симченко", Age = 20, Specialization = "Программирование", Group = "ПР-102", Faculty = "ИТ" },
                new Student { Name = "Дмитрий", Surname = "Савчук", Age = 23, Specialization = "Физика", Group = "ФИ-202", Faculty = "Физфак" },
                new Student { Name = "Светлана", Surname = "Ерошина", Age = 18, Specialization = "Математика", Group = "МТ-303", Faculty = "Мехмат" },
                new Student { Name = "Владимир", Surname = "Козлов", Age = 21, Specialization = "Программирование", Group = "ПР-101", Faculty = "ИТ" },
                new Student { Name = "Анна", Surname = "Лебедева", Age = 20, Specialization = "Физика", Group = "ФИ-202", Faculty = "Физфак" },
                new Student { Name = "Михаил", Surname = "Морозов", Age = 22, Specialization = "Математика", Group = "МТ-303", Faculty = "Мехмат" }
            };

            var csStudents = students.Where(s => s.Specialization == "Программирование").OrderBy(s => s.Name);
            Console.WriteLine("\nСтуденты по специальности 'Программирование' (в алфавитном порядке):");
            foreach (var student in csStudents)
                Console.WriteLine($"{student.Name} {student.Surname}");

            var youngestInGroup = students.Where(s => s.Group == "ПР-101" && s.Faculty == "ИТ").OrderBy(s => s.Age).FirstOrDefault();
            Console.WriteLine($"\nСамый молодой студент в группе ПР-101, факультет ИТ: {youngestInGroup?.Name} {youngestInGroup?.Surname}");

            var studentCount = students.Where(s => s.Group == "ПР-101").OrderBy(s => s.Surname).Count();
            Console.WriteLine($"\nКоличество студентов в группе ПР-101: {studentCount}");

            var firstStudentWithName = students.FirstOrDefault(s => s.Name == "Арина");
            Console.WriteLine($"\nПервый студент с именем Арина: {firstStudentWithName?.Name} {firstStudentWithName?.Surname}");

            // Сложный запрос
            var complexQuery = students
                .Where(s => s.Age > 18 && s.Faculty == "ИТ")
                .OrderByDescending(s => s.Age)
                .GroupBy(s => s.Group)
                .Select(g => new { Group = g.Key, AverageAge = g.Average(s => s.Age), Students = g.ToList() })
                .Where(g => g.Students.Any(s => s.Name.StartsWith("А")));

            Console.WriteLine("\nРезультат сложного запроса:");
            foreach (var group in complexQuery)
            {
                Console.WriteLine($"Группа: {group.Group}, Средний возраст: {group.AverageAge}");
                foreach (var student in group.Students)
                {
                    Console.WriteLine($" - {student.Name} {student.Surname}");
                }
            }

            //Join
            var groups = new List<Group>
            {
                new Group { Name = "ПР-101", Faculty = "ИТ" },
                new Group { Name = "ФИ-202", Faculty = "Физфак" },
                new Group { Name = "МТ-303", Faculty = "Мехмат" }
            };

            var joinedQuery = students.Join(
                groups,
                student => student.Group,
                group => group.Name,
                (student, group) => new { StudentName = student.Name, GroupName = group.Name, Faculty = group.Faculty }
            );

            Console.WriteLine("\nРезультат запроса Join:");
            foreach (var item in joinedQuery)
            {
                Console.WriteLine($"Студент: {item.StudentName}, Группа: {item.GroupName}, Факультет: {item.Faculty}");
            }
        }
    }
}
