using System;

namespace lab11
{
    public class TestClass1
    {
        public int Field1;
        private string Field2;

        public string Property1 { get; set; }

        public TestClass1() { }

        public TestClass1(int value) { }

        public void ExampleMethod(int x)
        {
            Console.WriteLine($"ExampleMethod вызван с параметром {x}");
        }

        public void AnotherMethod(string str) { }
    }
}
