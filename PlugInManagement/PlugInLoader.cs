using System;
using System.IO;
using System.Reflection;
using Company.Product.CrossCutting.Core.Contract;
using Company.Product.CrossCutting.DataClasses.EventMessages;
using Company.Product.Logic.PlugInManagement.Contract;

namespace Company.Product.Logic.PlugInManagement
{
    public class PlugInLoader : IPlugInLoader
    {
        private readonly IEventBroker _eventBroker;
        private int _messageCount = 1;

        public PlugInLoader(IEventBroker eventBroker)
        {
            _eventBroker = eventBroker;
        }

        public void Load()
        {

            //TODO: DO Reflection Magic
            

            var currentDirectory = Environment.CurrentDirectory;

            var files = Directory.GetFiles(currentDirectory, "*.dll");

            foreach (var file in files)
            {
                var assembly = Assembly.LoadFile(file);

                var types = assembly.GetTypes();

                foreach (var type in types)
                {
                    if (type.GetInterface(nameof(IPlugIn))) 


                }

            }

        }

        public void RaiseMessage()
        {

            var myPublicEventMessage = new MyPublicEventMessage()
            {
                Message = "PlugInLoader calls PlugIns!!!!",
                MessageNumber = _messageCount
            };
            _eventBroker.Raise(myPublicEventMessage);

            _messageCount++;
        }
    }
}
