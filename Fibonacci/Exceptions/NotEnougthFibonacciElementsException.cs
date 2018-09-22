using System;
using System.Runtime.Serialization;

namespace Fibonacci.Exceptions
{
    public class NotEnougthFibonacciElementsException : ApplicationException
    {
        public NotEnougthFibonacciElementsException() { }

        public NotEnougthFibonacciElementsException(string message) : base(message) { }

        public NotEnougthFibonacciElementsException(string message, Exception inner) : base(message, inner) { }

        protected NotEnougthFibonacciElementsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
