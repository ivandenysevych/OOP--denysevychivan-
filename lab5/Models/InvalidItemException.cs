using System;

namespace lab5.Models
{
    public class InvalidItemException : Exception
    {
        public InvalidItemException(string message) : base(message)
        {
        }
    }
}
