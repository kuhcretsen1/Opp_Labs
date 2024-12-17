using System.Numerics;

namespace Calculator
{
    public class Calculator<T> where T : struct, INumber<T>
    { 
        public T Add(T a, T b)
        {
            return a + b;
        }

        public T Subtract(T a, T b)
        {
            return a - b;
        }

        public T Multiply(T a, T b)
        {
            return a * b;
        }

        public T Divide(T a, T b)
        {
            if (b.Equals(default(T)))
                throw new DivideByZeroException();
            return a / b;
        }

        public T Power(T a, int exponent)
        {
            T result = a;
            for (int i = 1; i < exponent; i++)
            {
                result = result * a;
            }
            return result;
        }
    }
}
