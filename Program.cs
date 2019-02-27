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
            Console.Write("Enter Bonsai Command.\r\n" +
                "<1> Init Bonsai\r\n" +
                "<2> Create View\r\n" +
                "<3> BindableProperty <4> ModelProperty\r\n" +
                "<5> Add Business Logic Unit\r\n" +
                "<6> Add Serviced Repository Method Call \r\n" +
            	"\r\n<h>elp <q>uit :");
            var command = Console.ReadLine();
            if (command != "" && command.ToUpper() != "Q")
            {
                switch(command)
                {
                    case "1":
                        args = "-init -view System".Split(" ");
                        return true;
                    case "2":
                        Console.Write("Please indicate your View name eg. Login :");
                        var viewname = Console.ReadLine();
                        args = ("-view " + viewname).Split(" ");
                        return true;
                    case "3":
                        Console.WriteLine("Please indicate your ControlName name eg. SearchTileView :");
                        var controlTile = Console.ReadLine();
                        Console.Write("Please indicate your Property Name name eg. Telephone :");
                        var propertyName = Console.ReadLine();
                        Console.Write("Please indicate your Property Type name eg. string :");
                        var propertyType = Console.ReadLine();
                        args = ("-controlBindableProperty " + controlTile + " " + propertyName + " " + propertyType).Split(" ");
                        return true;
                    case "4":
                        Console.Write("Please indicate your Property Name eg. Telephone :");
                        var modelPropertyName = Console.ReadLine();
                        Console.Write("Please indicate your Property Type eg. string :");
                        var modelPropertyType = Console.ReadLine();
                        args = ("-modelProperty " + modelPropertyName + " " + modelPropertyType).Split(" ");
                        return true;
                    case "5":
                        Console.Write("Please indicate your ViewController name eg. Dashboard :");
                        var viewControllername = Console.ReadLine();
                        args = ("-initServicedRepo " + viewControllername).Split(" ");
                        return true;
                    case "6":
                        Console.Write("Please indicate your Repository name eg. Dashboard :");
                        var repoName = Console.ReadLine();
                        Console.Write("Please indicate your MethodName name eg. GetAllocations :");
                        var methodName = Console.ReadLine();
                        args = ("-viewControllerMethodCall " + repoName + " " + methodName).Split(" ");
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
