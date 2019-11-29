using System;
using Company.Product.CrossCutting.Core.Contract;
using Company.Product.CrossCutting.DataClasses.EventMessages;

namespace Company.Product.Logic.PlugIn.MyFirstPlugIn
{
    public class MyPlugInLogicClass : IMyPlugInLogicClass
    {
        private readonly IEventBroker _eventBroker;

        public MyPlugInLogicClass(IEventBroker eventBroker)
        {
            _eventBroker = eventBroker;
        }

        public void Subscribe()
        {
            _eventBroker.Subscribe<MyPublicEventMessage>(MessageHandler);
        }

        private void MessageHandler(MyPublicEventMessage message)
        {
            Console.WriteLine($"Handle message on: {typeof(MyPlugInLogicClass).FullName}");

            Console.WriteLine($"MessageNumber: {message.MessageNumber} ; Message: {message.Message}");
        }

        public void SayHello()
        {
            var fullName = typeof(MyPlugInLogicClass).FullName;
            Console.WriteLine($"Hello i'm {fullName}!");
        }
    }
}