namespace lab9.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public override string ToString() => $"ID: {ID}, название: {Name}, стоимость: {Price}";
    }
}
