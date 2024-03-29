﻿using System;
using System.Linq.Expressions;
using Company.Product.CrossCutting.Core.Contract.DataClasses;

namespace Company.Product.CrossCutting.Core.Contract
{
    public interface IEventBroker
    {
        void Raise<TMessage>(TMessage message) where TMessage : EventBrokerMessage;
        void Subscribe<TMessage>(Action<TMessage> handler) where TMessage : EventBrokerMessage;
        void Subscribe<TMessage>(Func<TMessage,bool> condition, Action<TMessage> handler) where TMessage : EventBrokerMessage;
    }
}
