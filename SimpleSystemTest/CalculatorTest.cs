using SimpleSystem;

namespace SimpleSystemTest
{
    public class CalculatorTests
    {
        
        #region 基本測試
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
        #endregion

        #region 邊界測試
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
        #endregion
        
        #region 簡化多筆測試
        
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(-1, -1, -2)]
        [InlineData(100, 200, 300)]
        public void Add_VariousNumbers_ShouldReturnCorrectSum(int a, int b, int expected)
        {
            // Arrange
            var calculator = new Calculator();
            // Act
            var result = calculator.Add(a, b);
            // Assert
            Assert.Equal(expected, result);
        }

        #endregion
    }

}