using System;
using System.Threading.Tasks;
using Templater.Repository.Implementation;
using Templater.Service.Implementation;

namespace SourceConsole.Repository.Implementation
{
    public class InputReaderRepository : IInputReaderRepository
    {
        public static string ReadInputJson()
        {
            var filer = new FileService();
            var projectName = new ProjectReaderRepository(new FileService()).GetProjectName();
            return filer.ReadFromFile($"../{projectName}/Inputs.json");
        }
    }
}
