using Company.Product.CrossCutting.Core.Contract.DataClasses;

namespace Company.Product.Logic.PlugInManagement.Contract.DataClasses
{
    public class MyEventMessage : EventBrokerMessage
    {
        public string Message { get; set; }

    }
}