using System;
using Company.Product.CrossCutting.Core.Contract;
using Company.Product.CrossCutting.DataClasses.EventMessages;

namespace Company.Product.Logic.PlugIn.MySecondPlugIn
{
    internal class SecondLogicClass : ISecondLogicClass
    {
        private readonly IEventBroker _eventBroker;
        private readonly INestedSecondLogicClass _nestedSecondLogicClass;

        public SecondLogicClass(IEventBroker eventBroker, INestedSecondLogicClass nestedSecondLogicClass)
        {
            _eventBroker = eventBroker;
            _nestedSecondLogicClass = nestedSecondLogicClass;
        }

        public void Subscribe()
        {
            _eventBroker.Subscribe<MyPublicEventMessage>(HandleMessage);
            _eventBroker.Subscribe<MySecondPublicEventMessage>(HandleMessage);
        }

        private void HandleMessage(MySecondPublicEventMessage message)
        {
            Console.WriteLine($"Handle message on: {typeof(SecondLogicClass).FullName}");

            Console.WriteLine($"MessageNumber: {message.MessageNumber} ; Message: {message.Message}");

            _nestedSecondLogicClass.RaiseMessage();
        }

        private void HandleMessage(MyPublicEventMessage message)
        {
            Console.WriteLine($"Handle message on: {typeof(SecondLogicClass).FullName}");

            Console.WriteLine($"MessageNumber: {message.MessageNumber} ; Message: {message.Message}");

            _nestedSecondLogicClass.DoMagic();
        }
    }
}