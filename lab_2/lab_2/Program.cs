using System;
using System.Collections.Generic;
using System.Security.Policy;

public partial class Student
{
    // Поля класса
    private readonly int id;  // Поле только для чтения
    private string lastName;
    private string firstName;
    private string middleName;
    private DateTime birthDate;
    private string address;
    private string phone;
    private string faculty;
    private int course;
    private string group;


    public const string UniversityName = "XYZ University";

    // поле для подсчета количества студентов
    private static int studentCount;

    // Свойства
    public int ID { get { return id; } }  // ID только для чтения
    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string MiddleName
    {
        get { return middleName; }
        set { middleName = value; }
    }

    public DateTime BirthDate
    {
        get { return birthDate; }
        set { birthDate = value; }
    }

    public string Address
    {
        get { return address; }
        set { address = value; }
    }

    public string Phone
    {
        get { return phone; }
        set { phone = value; }
    }

    public string Faculty
    {
        get { return faculty; }
        set { faculty = value; }
    }

    public int Course
    {
        get { return course; }
        set { course = value; }
    }

    public string Group
    {
        get { return group; }
        set { group = value; }
    }

    // Статический конструктор
    static Student()
    {
        studentCount = 0;
    }

    // Приватный конструктор
    private Student(int id)
    {
        this.id = id;
    }

    // Публичные конструкторы
    public Student() : this(Guid.NewGuid().GetHashCode())
    {
        studentCount++;
    }

    public Student(string lastName, string firstName, string middleName) : this()
    {
        this.lastName = lastName;
        this.firstName = firstName;
        this.middleName = middleName;
    }

    public Student(string lastName, string firstName, string middleName, DateTime birthDate, string address, string phone, string faculty, int course, string group) : this(lastName, firstName, middleName)
    {
        this.birthDate = birthDate;
        this.address = address;
        this.phone = phone;
        this.faculty = faculty;
        this.course = course;
        this.group = group;
    }

    // Метод для расчета возраста
    public int CalculateAge()
    {
        var today = DateTime.Today;
        int age = today.Year - birthDate.Year;
        if (birthDate > today.AddYears(-age)) age--;
        return age;
    }

    // Метод для сравнения объектов Equals
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;
        Student other = (Student)obj;
        return id == other.id;
    }

    // Переопределение GetHashCode
    public override int GetHashCode()
    {
        return id.GetHashCode();
    }

    // Переопределение ToString для вывода информации
    public override string ToString()
    {
        return $"{LastName} {FirstName} {MiddleName}, факультет: {Faculty}, курс: {Course}, группа: {Group}, возраст: {CalculateAge()}";
    }

    // Статический метод для вывода информации о классе
    public static void DisplayClassInfo()
    {
        Console.WriteLine($"Всего студентов: {studentCount}");
    }

    // Метод с ref и out параметрами
    public void UpdateContactInfo(ref string newAddress, out string oldPhone)
    {
        oldPhone = phone;
        address = newAddress;
    }

    // Методы для вывода списка студентов по факультету и группе
    public static List<Student> GetStudentsByFaculty(List<Student> students, string faculty)
    {
        return students.FindAll(s => s.Faculty == faculty);
    }

    public static List<Student> GetStudentsByGroup(List<Student> students, string group)
    {
        return students.FindAll(s => s.Group == group);
    }
}

public partial class Student
{
    // Вызов приватного конструктора через фабричный метод
    public static Student CreatePrivateInstance()
    {
        return new Student(Guid.NewGuid().GetHashCode());
    }
}

// Пример использования класса
class Program
{
    static void Main(string[] args)
    {

        Student student1 = new Student("Иванов", "пётр", "ростиславович", new DateTime(2000, 5, 15), "ул.Зыбицкая, 10", "123456789", "Физика", 2, "Группа 1");
        Student student2 = new Student("Петров", "иван", "фёдорович", new DateTime(2001, 3, 20), "ул. Октябрьская, 5", "987654321", "Математика", 3, "Группа 2");


        Console.WriteLine(student1);
        Console.WriteLine(student2);



        List<Student> students = new List<Student> { student1, student2 };


        var physicsStudents = Student.GetStudentsByFaculty(students, "Физика");
        Console.WriteLine("Студенты факультета Физика:");
        foreach (var student in physicsStudents)
        {
            Console.WriteLine(student);
        }


        var group1Students = Student.GetStudentsByGroup(students, "Группа 1");
        Console.WriteLine("Студенты группы 1:");
        foreach (var student in group1Students)
        {
            Console.WriteLine(student);
        }


        Student.DisplayClassInfo();

        var tuple = (1, "2", '3', "4", 6);

        Console.WriteLine(tuple.Item3);

    }
}

















































































































































