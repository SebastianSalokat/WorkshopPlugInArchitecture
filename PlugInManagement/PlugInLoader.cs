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
        private readonly IDiContainer _diContainer;
        private int _messageCount = 1;

        private const string Plugins = "PlugIns";
        private const string SearchPattern = "*.dll";

        public PlugInLoader(IEventBroker eventBroker, IDiContainer diContainer)
        {
            _eventBroker = eventBroker;
            _diContainer = diContainer;
        }

        public void Load()
        {

            var currentDirectory = Path.Combine(Environment.CurrentDirectory, Plugins);

            var files = Directory.GetFiles(currentDirectory, SearchPattern, SearchOption.AllDirectories);

            foreach (var file in files)
            {
                var assembly = Assembly.LoadFile(file);

                var types = assembly.GetTypes();

                foreach (var type in types)
                {
                    var plugInInterfaces = type.GetInterface(nameof(IPlugIn));
                    if (plugInInterfaces != null)
                    {
                        var instance = Activator.CreateInstance(type);

                        if (!(instance is IPlugIn plugIn))
                        {
                            throw new Exception("Could not create instance of plugIn!");
                        }

                        plugIn.AddMapping(_diContainer);
                        plugIn.AddMessageSubscription(_diContainer, _eventBroker);
                    }
                }
            }
        }

        public void RaiseMyPublicEventMessage()
        {
            var myPublicEventMessage = new MyPublicEventMessage()
            {
                Message = $"{nameof(PlugInLoader)} calls PlugIns with {nameof(MyPublicEventMessage)}!!!!",
                MessageNumber = _messageCount
            };
            _eventBroker.Raise(myPublicEventMessage);

            _messageCount++;
        }

        public void RaiseMySecondPublicEventMessage()
        {
            var mySecondPublicEventMessage = new MySecondPublicEventMessage()
            {
                Message = $"{nameof(PlugInLoader)} calls {nameof(MySecondPublicEventMessage)}!!!!",
                MessageNumber = _messageCount
            };
            _eventBroker.Raise(mySecondPublicEventMessage);

            _messageCount++;
        }
    }
}
