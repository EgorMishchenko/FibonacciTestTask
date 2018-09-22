using System.Numerics;

namespace Fibonacci
{
    public interface IFibonacciCalculator
    {
        BigInteger GetNextNumber(BigInteger number);
    }
}
