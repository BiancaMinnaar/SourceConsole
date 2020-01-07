using System;
using System.Threading.Tasks;
using Templater.Service.Implementation;

namespace SourceConsole.Repository.Implementation
{
    public class InputReaderRepository : IInputReaderRepository
    {
        public static string ReadInputJson()
        {
            var filer = new FileService();
            return filer.ReadFromFile($"Data/Inputs.json");
        }
    }
}
