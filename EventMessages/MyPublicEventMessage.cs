using Company.Product.CrossCutting.Core.Contract.DataClasses;

namespace Company.Product.CrossCutting.DataClasses.EventMessages
{
    public class MyPublicEventMessage : EventBrokerMessage
    {
        public string Message { get; set; }

        public int MessageNumber { get; set; }

    }
}
