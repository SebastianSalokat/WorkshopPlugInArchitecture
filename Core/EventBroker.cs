using System;
using System.Collections.Generic;
using Company.Product.CrossCutting.Core.Contract;
using Company.Product.CrossCutting.Core.Contract.DataClasses;

namespace Company.Product.CrossCutting.Core
{
    public class EventBroker : IEventBroker
    {
        private readonly Dictionary<Type, List<Subscription>> _messageSubscriptions = new Dictionary<Type, List<Subscription>>();

        public void Raise<TMessage>(TMessage message) where TMessage : EventBrokerMessage
        {
            var messageType = typeof(TMessage);

            if(_messageSubscriptions.ContainsKey(messageType))
            {
                var subscriptions = _messageSubscriptions[messageType];

                foreach (var subscription in subscriptions)
                {
                    if (subscription.Filter != null)
                    {
                        var result = subscription.Filter.DynamicInvoke(message);

                        bool shouldTriggerHandler = (bool) result;

                        if (!shouldTriggerHandler)
                        {
                            continue;
                        }
                    }

                    subscription.Handler.DynamicInvoke(message);
                }
            }
        }

        public void Subscribe<TMessage>(Action<TMessage> handler) where TMessage : EventBrokerMessage
        {
            var subscription = new Subscription(handler);
            AddSubscription<TMessage>(subscription);
        }

        public void Subscribe<TMessage>(Func<TMessage, bool> condition, Action<TMessage> handler) where TMessage : EventBrokerMessage
        {
            var subscription = new Subscription(condition, handler);
            AddSubscription<TMessage>(subscription);
        }

        private void AddSubscription<TMessage>(Subscription subscription) where TMessage : EventBrokerMessage
        {
            var messageType = typeof(TMessage);
            if (_messageSubscriptions.ContainsKey(messageType))
            {
                _messageSubscriptions[messageType].Add(subscription);
            }
            else
            {
                _messageSubscriptions.Add(messageType, new List<Subscription>() { subscription });
            }
        }
    }
}
