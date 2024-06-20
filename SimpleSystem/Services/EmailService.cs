using SimpleSystem.Models;

namespace SimpleSystem.Services;

public interface IEmailService
{
    void SendConfirmationEmail(string email, Order order);
}

public class EmailService
{
    public void SendConfirmationEmail(string email, Order order)
    {
        // 發送確認郵件
    }
}