using SimpleSystem;

namespace SimpleSystemTest
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_TwoNumbers_ShouldReturnSum()
        {
            // Arrange
            var calculator = new Calculator();
            // Act
            var result = calculator.Add(2, 3);
            // Assert
            Assert.Equal(5, result);
        }
    }

}