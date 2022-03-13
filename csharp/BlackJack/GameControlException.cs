using System;
using System.Runtime.Serialization;

namespace BlackJack
{
    [Serializable]
    internal class GameControlException : Exception
    {
        public GameControlException()
        {
        }

        public GameControlException(string message) : base(message)
        {
        }

        public GameControlException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GameControlException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}