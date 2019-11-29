using Company.Product.CrossCutting.Core.Contract;
using Company.Product.Logic.PlugInManagement;
using Company.Product.Logic.PlugInManagement.Contract;

namespace Company.Product.DI.Mappings
{
    public class DiMapper
    {
        public void Map(IDiContainer diContainer)
        {
            diContainer.Register<IPlugInLoader, PlugInLoader>();





        }
    }
}
