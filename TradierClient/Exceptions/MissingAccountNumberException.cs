using System;

namespace Tradier.Client.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when the account number is missing.
    /// </summary>
    public class MissingAccountNumberException : Exception
    {
        /// <summary>
        /// Represents an exception thrown when an account number is missing.
        /// </summary>
        public MissingAccountNumberException()
        {
        }

        /// <summary>
        /// Represents an exception that is thrown when an account number is missing.
        /// </summary>
        /// <seealso cref="System.Exception" />
        public MissingAccountNumberException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Represents an exception that is thrown when an account number is missing.
        /// </summary>
        /// <remarks>
        /// This exception is thrown when an account number is expected but not provided.
        /// </remarks>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public MissingAccountNumberException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}