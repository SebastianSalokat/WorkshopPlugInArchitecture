using System;
using Company.Product.CrossCutting.Core.Contract;

namespace Company.Product.Logic.PlugIn.MySecondPlugIn
{
    public class PlugIn : IPlugIn
    {
        public PlugIn()
        {
            Console.WriteLine(typeof(PlugIn).FullName + " is called!");
        }

        public void AddMapping(IDiContainer diContainer)
        {
            Console.WriteLine(nameof(PlugIn.AddMapping));
            diContainer.Register<ISecondLogicClass, SecondLogicClass>();
            diContainer.Register<INestedSecondLogicClass, NestedSecondLogicClass>();
        }

        public void AddMessageSubscription(IDiContainer diContainer, IEventBroker eventBroker)
        {
            Console.WriteLine(nameof(PlugIn.AddMessageSubscription));
            var logicClass = diContainer.Get<ISecondLogicClass>();

            logicClass.Subscribe();

        }
    }
}
