using System;
using System.Configuration;
using Templater.Repository.Implementation;
using Templater.Service.Implementation;
using TemplaterBonsai.Factory;

namespace SourceConsole.Repository.Implementation
{
    public class InteractionRepository : IInteractionRepository
    {
        private readonly ProjectReaderRepository ProjectReader;

        public InteractionRepository()
        {
            ProjectReader = new ProjectReaderRepository(new FileService(), ConfigurationManager.AppSettings["AppName"]);
        }

        public string[] GetAvailableCommands()
        {
            var map = new TemplaterBonsai.Factory.Version6.CommandParameterFunctionMapManager(
                    ProjectReader,
                    ConfigurationManager.AppSettings["LicenceKey"],
                    ConfigurationManager.AppSettings["LicenceValue"],
                    ConfigurationManager.AppSettings["AppName"]);
            return map.ReturnAvailableCommands();
        }
    }
}
