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
}