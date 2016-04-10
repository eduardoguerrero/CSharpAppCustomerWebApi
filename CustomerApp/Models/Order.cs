namespace CustomerApp.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public double Amount { get; set; }
        public int Quantity { get; set; } 
    }
}