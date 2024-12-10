namespace lab11
{
    public class TestClass2
    {
        public string Name { get; set; }

        public TestClass2()
        {
            Name = "По умолчанию";
        }

        public override string ToString()
        {
            return $"TestClass2(Имя={Name})";
        }
    }
}
