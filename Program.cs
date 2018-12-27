using System;
using System.Linq;
using Templater.Repository.Implementation;
using Templater.Service.Implementation;
using TemplaterBonsai.Factory;

namespace SourceConsole
{
    class MainClass
    {
        //free calls:
        //-init
        //-view
        //Licenced calls:
        //-viewWithModel
        //-control
        //-callingStructure
        //-initServicedRepo
        //-viewControllerMethodCall
        //-controlBindableProperty
        //-modelProperty
        //proprietary calls:
        // -partial
        public static void Main(string[] args)
        {
            var map = new CommandParameterFunctionMapManager(
            new ProjectReaderRepository(new FileService()), args.ToList()
                //You need a licence to call the paid functions.
                //Please email me @ bianca@bonsaisoft.co.za
                ,"","");
            var commandMapKeys =map.GetCommandMap(args);
            foreach(var command in commandMapKeys)
            {
                Console.WriteLine(command.Value);
                Console.ReadLine();
            }
        }
    }
}
