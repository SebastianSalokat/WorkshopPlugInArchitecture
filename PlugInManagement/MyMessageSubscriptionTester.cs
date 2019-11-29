using System;
using Company.Product.CrossCutting.Core.Contract;
using Company.Product.Logic.PlugInManagement.Contract;
using Company.Product.Logic.PlugInManagement.Contract.DataClasses;

namespace Company.Product.Logic.PlugInManagement
{
    public class MyMessageSubscriptionTester : IMyMessageSubscriptionTester
    {
        private readonly IEventBroker _eventBroker;

        public MyMessageSubscriptionTester(IEventBroker eventBroker)
        {
            _eventBroker = eventBroker;
        }

        public void FullTest()
        {
            AddSubscription();

            RaiseMessage();
        }

        public void AddSubscription()
        {
            Console.WriteLine($"Subscribe to message on: {typeof(MyMessageSubscriptionTester).FullName}");

            _eventBroker.Subscribe<MyEventMessage>(MyMessageHandler);
        }

        public void MyMessageHandler(MyEventMessage message)
        {
            Console.WriteLine("Message is raised.");
            Console.WriteLine($"Message tells us: {message.Message}");
        }


        public void RaiseMessage()
        {
            Console.WriteLine($"Raising message on: {typeof(MyMessageSubscriptionTester).FullName}");
            var message = new MyEventMessage(){
                Message = "MyTestEventMessage says hello!"    
            };

            _eventBroker.Raise(message);
        }

    }
}
