using System;
using System.Runtime.Serialization;

namespace Fibonacci.Exceptions
{
    public class OutOfFibonacciSequenceException : ApplicationException
    {
        public OutOfFibonacciSequenceException(){ }

        public OutOfFibonacciSequenceException(string message) : base(message) { }

        public OutOfFibonacciSequenceException(string message, Exception inner) : base(message, inner) { }

        protected OutOfFibonacciSequenceException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
