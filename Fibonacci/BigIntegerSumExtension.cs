using System.Collections.Generic;
using System.Numerics;

namespace Fibonacci
{
    public static class BigIntegerSumExtension
    {
        public static BigInteger BigIntegerSum(this IEnumerable<BigInteger> bigIntegers)
        {
            BigInteger result = 0;

            foreach (var bigInteger in bigIntegers)
            {
                result += bigInteger;
            }

            return result;
        }
    }
}
