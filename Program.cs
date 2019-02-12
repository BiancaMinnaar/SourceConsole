using System;
using System.Configuration;
using System.Linq;
using Templater.Repository.Implementation;
using Templater.Service.Implementation;
using TemplaterBonsai.Factory;

namespace SourceConsole
{
    class MainClass
    {
        private static bool GetConfirmation(out string[] args)
        {
            Console.Write("Enter Bonsai Command. <1> Init Bonsai <2> Create View\r\n<h>elp <q>uit :");
            var command = Console.ReadLine();
            if (command != "" && command.ToUpper() != "Q")
            {
                switch(command)
                {
                    case "1":
                        args = "-init -view System".Split(" ");
                        return true;
                    case "2":
                        Console.WriteLine("Please indicate your View name eg. Login :");
                        var viewname = Console.ReadLine();
                        args = ("-view " + viewname).Split(" ");
                        return true;
                    default:
                        Console.WriteLine("Only use available Commans");
                        return GetConfirmation(out args);
                }
            }
            args = null;
            return false;
        }

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
            while(GetConfirmation(out args))
            {
                var map = new CommandParameterFunctionMapManager(
                    new ProjectReaderRepository(new FileService()), args.ToList()
                    //You need a licence to call the paid functions.
                    //Please email me @ bianca@bonsaisoft.co.za
                    //,"","");
                    , ConfigurationManager.AppSettings["LicenceKey"], ConfigurationManager.AppSettings["LicenceValue"]);
                var commandMapKeys =map.GetCommandMap(args);
                foreach(var command in commandMapKeys)
                {
                    Console.WriteLine(command.Value);
                    Console.ReadLine();
                }
            }
        }
    }
}
