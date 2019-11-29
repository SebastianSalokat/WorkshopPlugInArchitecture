namespace Company.Product.CrossCutting.Core.Contract
{
    public interface IPlugIn
    {
        void AddMapping(IDiContainer diContainer);

        void AddMessageSubscription(IDiContainer diContainer, IEventBroker eventBroker);
    }
}
