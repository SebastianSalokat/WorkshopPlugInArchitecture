using System;
using Company.Product.Logic.PlugInManagement;

namespace Company.Product.Logic.PlugIn.MySecondPlugIn
{
    internal class NestedSecondLogicClass : INestedSecondLogicClass
    {
        private readonly IMyPublicMessageCaller _myPublicMessageCaller;

        public NestedSecondLogicClass(IMyPublicMessageCaller myPublicMessageCaller)
        {
            _myPublicMessageCaller = myPublicMessageCaller;
        }

        public void DoMagic()
        {
            Console.WriteLine("Magic!");
        }

        public void RaiseMessage()
        {
            Console.WriteLine($"Trigger {nameof(IMyPublicMessageCaller)}.{nameof(IMyPublicMessageCaller.RaiseMessage)} from {nameof(NestedSecondLogicClass)} from SecondPlugIn.");
            _myPublicMessageCaller.RaiseMessage();
        }

    }
}