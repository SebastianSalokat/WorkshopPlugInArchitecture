using Company.Product.CrossCutting.Core.Contract;
using Company.Product.CrossCutting.DataClasses.EventMessages;

namespace Company.Product.Logic.PlugInManagement
{
    public class MyPublicMessageCaller : IMyPublicMessageCaller
    {
        private readonly IEventBroker _eventBroker;
        private int _messageCount = 0;

        public MyPublicMessageCaller(IEventBroker eventBroker)
        {
            _eventBroker = eventBroker;
        }

        public void RaiseMessage()
        {
            var myPublicEventMessage = new MyPublicEventMessage()
            {
                Message = $"{nameof(MyPublicMessageCaller)} calls PlugIns!!!!",
                MessageNumber = _messageCount
            };
            _eventBroker.Raise(myPublicEventMessage);

            _messageCount++;
        }
    }
}