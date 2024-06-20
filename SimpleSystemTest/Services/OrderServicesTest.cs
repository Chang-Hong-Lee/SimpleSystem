using Moq;
using SimpleSystem.Models;
using SimpleSystem.Repository;
using SimpleSystem.Services;

namespace SimpleSystemTest.Services;

public class OrderServicesTest
{
    private readonly OrderService _orderService;
    private readonly Mock<IOrderRepository> _mockOrderRepository;

    public OrderServicesTest()
    {
        _mockOrderRepository = new Mock<IOrderRepository>();
        _orderService = new OrderService(_mockOrderRepository.Object);
    }

    [Fact]
    public void PlaceOrder_OrderIsValid_ShouldReturnTrue()
    {
        // Arrange
        // 創建IOrderRepository的模擬對象
        var mockRepo = new Mock<IOrderRepository>();
        // 設置模擬對象的Save方法，使其對任何Order對象的調用都返回true
        mockRepo.Setup(repo => repo.Save(It.IsAny<Order>())).Returns(true);

        // 使用模擬的存儲庫對象創建OrderService對象
        var service = new OrderService(mockRepo.Object);
        var order = new Order { /* 初始化訂單 */ };

        // Act
        var result = service.PlaceOrder(order);
        
        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void ValidateUserInfo_ShouldThrowException_WhenUserNotExist()
    {
        Assert.Throws<ArgumentException>(() => _orderService.ValidateUserInfo(0));
    }
}