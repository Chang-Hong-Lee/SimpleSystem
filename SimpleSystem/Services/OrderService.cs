using SimpleSystem.Models;
using SimpleSystem.Repository;

namespace SimpleSystem.Services;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    /// <summary> 下訂單 </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    public bool PlaceOrder(Order order)
    {
        if (order == null)
        {
            throw new ArgumentNullException(nameof(order));
        }
        // 一些業務邏輯
        return _orderRepository.Save(order);
    }
    
    public List<string> DiscountCodes = new List<string> { "10OFF", "20Discount" };
    public enum OrderStatus
    {
        Pending,
        Paid,
        Delivered
    }
    
    public void ProcessUserOrder(int userId, string email, string address, List<OrderItem> items, string discountCode)
    {
        // 驗證用戶信息
        if (userId <= 0)
        {
            throw new ArgumentException("Invalid user information");
        }

        // 計算總價
        decimal total = 0;
        foreach (var item in items)
        {
            total += item.Price * item.Quantity;
        }

        // 應用折扣
        if (!string.IsNullOrEmpty(discountCode))
        {
            decimal discount = 0;
            if (discountCode == "10OFF")
            {
                discount = total * 0.1m;
            }
            else if (discountCode == "200Discount")
            {
                discount = 200;
            }
            total -= discount;
        }

        // 保存訂單
        var order = new Order
        {
            ClientId = userId,
            DeliveryAddress = address,
            TotalPrice = total,
            OrderStatus = (int)OrderStatus.Pending,
            OrderDate = DateTime.Now,
        };
        _orderRepository.Save(order);

        // 發送確認郵件
        SendConfirmationEmail(email, order);
    }

    private void SendConfirmationEmail(string email, Order order)
    {
        // 發送郵件實作
        
    }
}