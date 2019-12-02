namespace Company.Product.Logic.PlugInManagement.Contract
{
    public interface IPlugInLoader
    {
        void Load();
        void RaiseMyPublicEventMessage();
        void RaiseMySecondPublicEventMessage();
    }
}
