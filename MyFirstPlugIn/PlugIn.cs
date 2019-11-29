using System;
using Company.Product.CrossCutting.Core.Contract;

namespace Company.Product.Logic.PlugIn.MyFirstPlugIn
{
    public class PlugIn : IPlugIn
    {
        public void AddMapping(IDiContainer diContainer)
        {
            Console.WriteLine($"Register mappings of {typeof(PlugIn).FullName}");

            diContainer.Register<IMyPlugInLogicClass, MyPlugInLogicClass>();

            Console.WriteLine("MappingsRegistered");
        }

        public void AddMessageSubscription(IDiContainer diContainer, IEventBroker eventBroker)
        {
            Console.WriteLine($"Subscribe. {typeof(PlugIn).FullName}");


            var logicClass = diContainer.Get<IMyPlugInLogicClass>();

            logicClass.Subscribe();


            Console.WriteLine("Subscribed");
        }


    }
}
