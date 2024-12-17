using Calculator;

namespace TestCalculator
{
    public class TestCalculator
    {
        [Fact]
        public void TestAddInt()
        {
            // Arrange
            Calculator<int> calculator = new Calculator<int>();

            // Act
            int result = calculator.Add(2, 3);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void TestAddDouble()
        {
            // Arrange
            Calculator<double> calculator = new Calculator<double>();

            // Act
            double result = calculator.Add(2.5, 3.7);

            // Assert
            Assert.Equal(6.2, result);
        }

        [Fact]
        public void TestSubtractInt()
        {
            // Arrange
            Calculator<int> calculator = new Calculator<int>();

            // Act
            int result = calculator.Subtract(5, 3);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void TestSubtractDouble()
        {
            // Arrange
            Calculator<double> calculator = new Calculator<double>();

            // Act
            double result = calculator.Subtract(5.5, 3.2);

            // Assert
            Assert.Equal(2.3, result);
        }

        [Fact]
        public void TestMultiplyInt()
        {
            // Arrange
            Calculator<int> calculator = new Calculator<int>();

            // Act
            int result = calculator.Multiply(4, 5);

            // Assert
            Assert.Equal(20, result);
        }

        [Fact]
        public void TestMultiplyDouble()
        {
            // Arrange
            Calculator<double> calculator = new Calculator<double>();
            double a = 4.5;
            double b = 5.2;

            // Act
            double result = calculator.Multiply(a, b);

            // Assert
            Assert.Equal(a * b, result);
        }

        [Fact]
        public void TestDivideInt()
        {
            // Arrange
            Calculator<int> calculator = new Calculator<int>();

            // Act
            int result = calculator.Divide(10, 2);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void TestDivideDouble()
        {
            // Arrange
            Calculator<double> calculator = new Calculator<double>();

            // Act
            double result = calculator.Divide(10.5, 2.1);

            // Assert
            Assert.Equal(5.0, result);
        }

        [Fact]
        public void TestPowerInt()
        {
            // Arrange
            Calculator<int> calculator = new Calculator<int>();
            int a = 4;
            int b = 2;
            // Act
            int result = calculator.Power(4, 2);

            // Assert
            Assert.Equal(Math.Pow(a, b), result);
        }

        [Fact]
        public void TestPowerDouble()
        {
            // Arrange
            Calculator<double> calculator = new Calculator<double>();
            double a = 4.5;
            int b = 2;

            // Act
            double result = calculator.Power(a, b);

            // Assert
            Assert.Equal(Math.Pow(a, b), result);
        }

        [Fact]
        public void TestDivideByZero()
        {
            // Arrange
            Calculator<int> calculator = new Calculator<int>();

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
        }
    }
}