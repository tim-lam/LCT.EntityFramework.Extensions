namespace samples.DomainModels
{
    public class OrderItem
    {
        public int Id { get; set; }

        public Order Order { get; set; }

        public int Qty { get; set; }

        public string ProductName { get; set; }
    }
}
