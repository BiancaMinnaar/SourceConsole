using System;
using System.Collections.Generic;
using System.Linq;
using BaseBonsai.DataContracts;
using BaseBonsai.Generation.DataModel;
using BaseBonsai.Generation.Repository;
using SourceConsole.Factory;
using Templater.Factory;
using Templater.Repository.Implementation;
using Templater.Service.Implementation;
using TemplaterBonsai.Repository;
using TemplaterBonsai.Repository.Implementation;
using TemplaterBonsai.Repository.Implementation.V2;
using TemplaterBonsai.Templates.DataModel;

namespace SourceConsole
{
    class MainClass
    {
        private IProjectReaderRepository readerRepo;
        private List<string> commandList;
        private MainClass(IProjectReaderRepository reader, List<string> commands)
        {
            readerRepo = reader;
            commandList = commands;
        }
        private Dictionary<string, Func< string[], string>> MapCommandParametersToTemplaterRepos()
        {
            var mapFunctions = new Dictionary<string, Func<string[], string>>
            {
                { "-init", (parm) => 
                    {
                        var MainRepo = new BonsaiFrameworkRepository(
                        new FileService(), new SimpleCSharpProjectFactory(readerRepo), readerRepo);
                        MainRepo.RunSteps();
                        return "Bonsai Did init"; 
                        } },
                { "-view", (parm) => 
                    {
                        var MainRepo = new BonsaiViewControlStructureRepository(
                        new FileService(), new SimpleCSharpProjectFactory(readerRepo), readerRepo, parm[0]);
                        MainRepo.RunSteps();
                        return "Your view: " + parm[0] + " was Created";
                    } },
                { "-partial", (parm) => 
                    {
                        var snippedModel = new TemplaterPartialDataModel
                        {
                            ProjectName = readerRepo.GetProjectName(),
                            Template = parm[0],
                            NameSpace = parm[1],
                            DataModelName = parm[2]
                        };
                        var snippedRepo = SnipetGenerationFactory.SnipetGenerationFactoryInstance.GetGenerationRepo(
                            readerRepo, snippedModel);
                        return snippedRepo.ReturnSnipped(); 
                    }}
            };
            return mapFunctions;
        }
        private Dictionary<string, string> GetCommandMap(string[] commands)
        {
            var executionMap = MapCommandParametersToTemplaterRepos();
            var map = new Dictionary<string, string>();

            string command = string.Empty;
            List<string> parms = new List<string>();
            for(var count=0; count < commands.Count(); count++)
            {
                var argument = commands[count];
                if (argument.StartsWith('-'))
                {
                    if (count <= commands.Count() - 1 && commands[count+1].StartsWith('-'))
                    {
                        map.Add(command, executionMap[command]?.Invoke(parms.ToArray()));
                        parms = new List<string>();
                    }
                    command = argument;
                }
                else
                {

                    parms.Add(argument);
                }
            }
            map.Add(command, executionMap[command]?.Invoke(parms.ToArray()));
            return map;
        }

        //-init
        //-view
        //-call
        //-return
        //-viewname <>
        public static void Main(string[] args)
        {
            IBonsaiStructureRepository MainRepo = null;
            var map = new MainClass(new ProjectReaderRepository(new FileService()), args.ToList());
            var commandMapKeys =map.GetCommandMap(args);
            foreach(var command in commandMapKeys)
            {
                Console.WriteLine(command.Value);
                Console.ReadLine();
            }




            //var commandParameters = from arg in args
            //                        where arg.StartsWith('-')
            //                        select arg;
            //List<string> commandList = commandParameters.ToList();
            //var argument = "-viewname";
            //var functionParamaters = from arg in args
            //                         where !arg.StartsWith('-')
            //                         select new { argument, arg  };
            //var str = functionParamaters.ToDictionary(key => key.argument, value => value.arg);

            //foreach (var arg in commandParameters)
            //{
            //    if (arg.Equals("-init", System.StringComparison.OrdinalIgnoreCase))
            //    {
            //        MainRepo = new BonsaiFrameworkRepository(
            //            new FileService(), new SimpleCSharpProjectFactory(readerRepo), readerRepo);
            //    }
            //    if (arg.Equals("-view", System.StringComparison.OrdinalIgnoreCase))
            //    {
            //        MainRepo = new BonsaiViewControlStructureRepository(
            //            new FileService(), new SimpleCSharpProjectFactory(readerRepo), readerRepo, str["-viewname"]);
            //    }
            //    if (arg.Equals("-call", System.StringComparison.OrdinalIgnoreCase))
            //    {
            //        MainRepo = new BonsaiCallingStructureRepository(
            //            new FileService(), new SimpleCSharpProjectFactory(readerRepo), readerRepo, str["-viewname"]);
            //    }
            //    if (arg.Equals("-return", System.StringComparison.OrdinalIgnoreCase))
            //    {
            //        MainRepo = new BonsaiReturnCallingStructureRepository(
            //            new FileService(), new SimpleCSharpProjectFactory(readerRepo), readerRepo, str["-viewname"]);
            //    }
            //}
            //if (MainRepo != null)
                //MainRepo.RunSteps();
        }
    }
}
