using System;
using Company.Product.CrossCutting.Core.Contract;
using Company.Product.CrossCutting.Core.Contract.DataClasses;
using Ninject;

namespace Company.Product.CrossCutting.Core
{
    public class DiContainer : IDiContainer
    {
        private readonly IKernel _kernel;

        public DiContainer(IKernel kernel)
        {
            _kernel = kernel;
        }

        public void Register<TContract, TImplementation>(Scope scope = Scope.Transient) where TImplementation : TContract
        {
            var binding = _kernel.Bind<TContract>().To<TImplementation>();
            
            switch (scope)
            {
                case Scope.Singleton:
                    binding.InSingletonScope();
                    break;
                case Scope.Transient:
                    binding.InTransientScope();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(scope), scope, null);
            }
            
        }

        public TContract Get<TContract>()
        { 
            var instance = _kernel.Get<TContract>();
            return instance;
        }
    }
}
