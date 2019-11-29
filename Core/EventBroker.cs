using System;
using Company.Product.CrossCutting.Core.Contract;
using Company.Product.CrossCutting.Core.Contract.DataClasses;

namespace Company.Product.CrossCutting.Core
{
    public class EventBroker : IEventBroker
    {
        public void Raise<TMessage>(TMessage message) where TMessage : EventBrokerMessage
        {
            //TODO : HUhu
        }

        public void Subscribe<TMessage>() where TMessage : EventBrokerMessage
        {
        }

        public void Subscribe<TMessage>(Func<TMessage, bool> condition) where TMessage : EventBrokerMessage
        {
        }
    }
}
