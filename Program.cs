using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using SourceConsole.Repository.Implementation;
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
                "<3> BindableProperty\r\n" +
                "<4> ModelProperty\r\n" +
                "<5> ViewModel\r\n" +
                "<6> Add Business Logic Unit\r\n" +
                "<7> Add Serviced Repository Method Call \r\n" +
                "<8> Add Control \r\n" +
                "<9> AddPopup \r\n" +
                "<10> Partial \r\n" +
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
                        Console.Write("Please past your json to file \n\r Hit enter to continue :");
                        Console.ReadLine();
                        var model2Json = InputReaderRepository.ReadInputJson();
                        Console.Write("Please indicate your View name eg. Login :");
                        var viewname = Console.ReadLine();
                        var args2 = new List<string>($"-viewWithModel {viewname}".Split(" "));
                        args2.Add(model2Json);
                        args = args2.ToArray();
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
                        Console.Write("Please past your json to file \n\r Hit enter to continue :");
                        Console.ReadLine();
                        var model1Json = InputReaderRepository.ReadInputJson();
                        Console.Write("Please indicate your ViewModel name eg. Details :");
                        var viewModelName = Console.ReadLine();
                        var args5 = new List<string>($"-viewModel {viewModelName}".Split(" "));
                        args5.Add(model1Json);
                        args = args5.ToArray();
                        return true;
                    case "6":
                        Console.Write("Please indicate your ViewController name eg. Dashboard :");
                        var viewControllername = Console.ReadLine();
                        args = ("-initServicedRepo " + viewControllername).Split(" ");
                        return true;
                    case "7":
                        Console.Write("Please indicate your Repository name eg. Dashboard :");
                        var repoName = Console.ReadLine();
                        Console.Write("Please indicate your MethodName name eg. GetAllocations :");
                        var methodName = Console.ReadLine();
                        args = ("-viewControllerMethodCall " + repoName + " " + methodName).Split(" ");
                        return true;
                    case "8":
                        Console.Write("Please past your json to file \n\r Hit enter to continue :");
                        Console.ReadLine();
                        var modelJson = InputReaderRepository.ReadInputJson();
                        Console.Write("Please indicate your Control name :");
                        var controlName = Console.ReadLine();
                        var args8 = new List<string>($"-control {controlName}".Split(" "));
                        args8.Add(modelJson);
                        args = args8.ToArray();
                        return true;
                    case "9":
                        Console.Write("Please past your json to file \n\r Hit enter to continue :");
                        Console.ReadLine();
                        var popupModelJson = InputReaderRepository.ReadInputJson();
                        Console.Write("Please indicate your Control name :");
                        var popupName = Console.ReadLine();
                        var args1 = new List<string>($"-popup {popupName}".Split(" "));
                        args1.Add(popupModelJson);
                        args = args1.ToArray();
                        return true;
                    case "10":
                        Console.Write("Template please? :");
                        var template = Console.ReadLine();
                        
                        Console.Write("NameSpace please :");
                        var NameSpace = Console.ReadLine();

                        Console.Write("DataModel please :");
                        var Datamodel = Console.ReadLine();
                        args = $"-partial {template} {NameSpace} {Datamodel}".Split(" ");
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
                    //Please email me @ bminnaar@gmail.com
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
