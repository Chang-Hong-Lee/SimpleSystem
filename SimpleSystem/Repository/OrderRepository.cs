using SimpleSystem.Models;

namespace SimpleSystem.Repository;

public interface IOrderRepository
{
    bool Save(Order order);
}

