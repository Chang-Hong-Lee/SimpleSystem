namespace SimpleSystem.Models;

public class Order
{
    public int OrderId { get; set; }
    public int ClientId { get; set; }
    public string DeliveryAddress { get; set; }
    public decimal TotalPrice { get; set; }
    public int OrderStatus { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime? PaymentDate { get; set; }
    public DateTime? DeliveryDate { get; set; }
}