namespace ApplicationCore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        //public string CustomerName { get; set; }
        public string Email { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
        public string OrderStatus { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public int WarehouseId { get; internal set; }
        public Warehouse? Warehouse { get; set; }
    }
}
