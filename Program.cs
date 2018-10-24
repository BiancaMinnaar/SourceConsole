using System;
using System.Linq;
using Templater.Repository.Implementation;
using Templater.Service.Implementation;
using TemplaterBonsai.Factory;

namespace SourceConsole
{
    class MainClass
    {
        //-init
        //-view
        //-call
        //-return
        //-viewname <>
        public static void Main(string[] args)
        {
            var map = new CommandParameterFunctionMapManager(new ProjectReaderRepository(new FileService()), args.ToList());
            var commandMapKeys =map.GetCommandMap(args);
            foreach(var command in commandMapKeys)
            {
                Console.WriteLine(command.Value);
                Console.ReadLine();
            }
        }
    }
}
