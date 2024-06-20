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
        ValidateUserInfo(userId);

        // 計算總價
        decimal total = CalculateTotal(items);
        
        // 應用折扣
        total = ApplyDiscount(total, discountCode);

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

    /// <summary> 驗證用戶資訊 </summary>
    /// <param name="userId"></param>
    /// <exception cref="ArgumentException"></exception>
    public void ValidateUserInfo(int userId)
    {
        if (userId <= 0)
        {
            throw new ArgumentException("Invalid user information");
        }
    }

    private void SendConfirmationEmail(string email, Order order)
    {
        // 發送郵件實作
        
    }
    
    /// <summary> 計算總價 </summary>
    /// <param name="items">商品</param>
    private decimal CalculateTotal(List<OrderItem> items)
    {
        decimal total = 0;
        // 假設這是從數據庫或其他來源獲取的產品價格
        decimal productPricing = 100; 
        
        foreach (var item in items)
        {
            total += productPricing * item.Quantity;
        }
        return total;
    }
    
    /// <summary> 折扣後的金額 </summary>
    /// <param name="total">總金額</param>
    /// <param name="discountCode">折扣碼</param>
    /// <returns></returns>
    public decimal ApplyDiscount(decimal total, string discountCode)
    {
        if (!string.IsNullOrEmpty(discountCode))
        {
            var discount = GetDiscount(discountCode, total);
            total -= discount;
        }
        return total;
    }

    /// <summary> 取得折扣金額 </summary>
    /// <param name="discountCode">折扣碼</param>
    /// <param name="total">總金額</param>
    public decimal GetDiscount(string discountCode, decimal total)
    {
        if (DiscountCodes.Contains(discountCode))
        {
            return discountCode switch
            {
                "10OFF" => total * 0.1m,
                "20Discount" => 20,
                _ => 0
            };
        }
        return 0;
    }
}