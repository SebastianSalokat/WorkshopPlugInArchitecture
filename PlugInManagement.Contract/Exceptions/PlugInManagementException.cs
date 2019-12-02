using System;
using System.Runtime.Serialization;

namespace Company.Product.Logic.PlugInManagement.Contract.Exceptions
{
    public class PlugInManagementException : Exception
    {
        public PlugInManagementException()
        {
        }

        public PlugInManagementException(string message) : base(message)
        {
        }

        public PlugInManagementException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PlugInManagementException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
