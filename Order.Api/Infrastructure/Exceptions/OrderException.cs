using System;

namespace Order.Api.Infrastructure.Exceptions
{
    public class OrderException : Exception
    {
        public OrderException()
        {

        }

        public OrderException(string message) : base(message)
        {

        }

        public OrderException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
