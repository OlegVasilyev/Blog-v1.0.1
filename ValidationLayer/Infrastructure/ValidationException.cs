using System;

namespace ValidationLayer.Infrastructure
{
    /// <summary>
    /// Exception that can be used for data validation
    /// </summary>
    public class ValidationException : Exception
    {
        public string Property { get; protected set; }

        public ValidationException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
