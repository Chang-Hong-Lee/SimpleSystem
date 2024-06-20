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
        
        [Fact]
        public void Add_MaxIntAndZero_ShouldReturnMaxInt()
        {
            // Arrange
            var calculator = new Calculator();
            // Act
            var result = calculator.Add(int.MaxValue, 0);
            // Assert
            Assert.Equal(int.MaxValue, result);
        }

        [Fact]
        public void Add_MaxIntAndOne_ShouldThrowOverflowException()
        {
            // Arrange
            var calculator = new Calculator();
            // Act & Assert
            Assert.Throws<OverflowException>(() => calculator.Add(int.MaxValue, 1));
        }
    }

}