﻿using System;
using Company.Product.CrossCutting.Core;
using Company.Product.CrossCutting.Core.Contract;
using Company.Product.DI.Mappings;
using Company.Product.Logic.PlugInManagement.Contract;
using Ninject;

namespace Company.Product.UI.ConsoleApp
{
    class Program
    {
        internal static IDiContainer DiContainer;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            InitializeDiContainer();

            Console.WriteLine("#### Call message tester ####");

            var messageTester = DiContainer.Get<IMyMessageSubscriptionTester>();

            messageTester.FullTest();
            Console.WriteLine("#### Test finished ####");


            Console.WriteLine("### Program call PlugInLoader.Load ###");
            var plugInLoader = DiContainer.Get<IPlugInLoader>();

            plugInLoader.Load();
            Console.WriteLine("### PlugInLoader.Load Finished ###");


            Console.WriteLine("Call Plugins");

            plugInLoader.RaiseMyPublicEventMessage();
            plugInLoader.RaiseMyPublicEventMessage();
            plugInLoader.RaiseMyPublicEventMessage();


            Console.WriteLine("##################");

            plugInLoader.RaiseMySecondPublicEventMessage();

            Console.WriteLine("########################");

            Console.WriteLine("Done.");
            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
        }

        private static void InitializeDiContainer()
        {
            var kernel = new StandardKernel();

            kernel.Bind<IDiContainer>().To<DiContainer>().InSingletonScope();

            var mapper = new DiMapper();

            DiContainer = kernel.Get<IDiContainer>();

            mapper.Map(DiContainer);
        }
    }
}
