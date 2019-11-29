using Company.Product.Logic.PlugInManagement.Contract.DataClasses;

namespace Company.Product.Logic.PlugInManagement.Contract
{
    public interface IMyMessageSubscriptionTester
    {
        void FullTest();
        void AddSubscription();
        void MyMessageHandler(MyEventMessage message);
        void RaiseMessage();
    }
}