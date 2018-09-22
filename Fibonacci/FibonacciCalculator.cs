using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using Fibonacci.Exceptions;

namespace Fibonacci
{
    public class FibonacciCalculator : IFibonacciCalculator
    {
        static private List<BigInteger> calculatedFibonacciNumbers = new List<BigInteger> { 0, 1 };

        public BigInteger GetNextNumber(BigInteger number)
        {
            var isAlreadyCalculated = calculatedFibonacciNumbers.Contains(number);

            var isOne = number == 1;

            if (isAlreadyCalculated)
            {
                if (isOne)
                {
                    return HandleOneCase(number);
                }
                else
                {
                    return GetNextForAlreadyCalculatedNumber(number);
                }
            }
            else
            {
                return CalculateNewNumber(number);
            }
        }

        private BigInteger GetNextForAlreadyCalculatedNumber(BigInteger number)
        {
            if (number == calculatedFibonacciNumbers.Last())
            {
                var sumOfTwoPrecedingNumbers = GetSumOfTwoLastNumbers();
                calculatedFibonacciNumbers.Add(sumOfTwoPrecedingNumbers);
                return sumOfTwoPrecedingNumbers;
            }
            else
            {
                var numberIndex = calculatedFibonacciNumbers.IndexOf(number);
                var nextNumber = numberIndex + 1;
                return calculatedFibonacciNumbers.ElementAt(nextNumber);
            }
        }

        private BigInteger CalculateNewNumber(BigInteger number)
        {
            var sumOfTwoLastNumbers = GetSumOfTwoLastNumbers();

            if (sumOfTwoLastNumbers == number)
            {
                calculatedFibonacciNumbers.Add(number);

                var newNumber = GetSumOfTwoLastNumbers();
                return newNumber;
            }
            else
            {
                throw new OutOfFibonacciSequenceException("The number given is not a part of the Fibonacci sequence!");
            }
        }

        private BigInteger HandleOneCase(BigInteger number)
        {
            var oneCount = calculatedFibonacciNumbers.Count(x => x == 1);
            var isOneSingle = oneCount == 1;

            if (isOneSingle)
            {
                var result = GetSumOfTwoLastNumbers();
                calculatedFibonacciNumbers.Add(number);
                return result;
            }
            else
            {
                return GetSumOfTwoLastNumbers();
            }
        }
        private BigInteger GetSumOfTwoLastNumbers()
        {
            try
            {
                return calculatedFibonacciNumbers.TakeLast(2).BigIntegerSum();
            }
            catch (Exception)
            {
                throw new NotEnougthFibonacciElementsException("There is lesser than 2 elements in prefilled fibonacci list"); ;
            }
            
        }
    }
}
