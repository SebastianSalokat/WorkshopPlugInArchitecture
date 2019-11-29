using System;

namespace Company.Product.CrossCutting.Core
{
    internal class Subscription
    {
        public Subscription(Delegate handler)
        {
            Handler = handler;
        }

        public Subscription(Delegate filter, Delegate handler)
        {
            Filter = filter;
            Handler = handler;
        }

        public Delegate Handler { get; private set; }

        public Delegate Filter { get; private set; }
    }
}