using Company.Product.CrossCutting.Core.Contract.DataClasses;

namespace Company.Product.CrossCutting.Core.Contract
{
    public interface IDiContainer
    {
        void Register<TContract, TImplementation>(Scope scope = Scope.Transient) where TImplementation : TContract;

        TContract Get<TContract>();
    }
}
