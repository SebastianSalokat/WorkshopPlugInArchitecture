﻿using System;
using Company.Product.CrossCutting.Core.Contract;

namespace Company.Product.Logic.PlugIn.MyFirstPlugIn
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

            diContainer.Register<IMyPlugInLogicClass, MyPlugInLogicClass>();
        }

        public void AddMessageSubscription(IDiContainer diContainer, IEventBroker eventBroker)
        {
            Console.WriteLine(nameof(PlugIn.AddMessageSubscription));

            var logicClass = diContainer.Get<IMyPlugInLogicClass>();

            logicClass.Subscribe();
        }


    }
}
