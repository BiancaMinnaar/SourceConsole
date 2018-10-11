using System.Collections.Generic;
using System.Linq;
using Templater.Factory;
using Templater.Repository.Implementation;
using Templater.Service.Implementation;
using TemplaterBonsai.Repository;
using TemplaterBonsai.Repository.Implementation;
using TemplaterBonsai.Repository.Implementation.V2;

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
            IBonsaiStructureRepository MainRepo = null;
            var readerRepo = new ProjectReaderRepository(new FileService());
            var commandParameters = from arg in args
                                    where arg.StartsWith('-')
                                    select arg;
            List<string> commandList = commandParameters.ToList();
            var argument = "-viewname";
            var functionParamaters = from arg in args
                                     where !arg.StartsWith('-')
                                     select new { argument, arg  };
            var str = functionParamaters.ToDictionary(key => key.argument, value => value.arg);

            foreach (var arg in commandParameters)
            {
                if (arg.Equals("-init", System.StringComparison.OrdinalIgnoreCase))
                {
                    MainRepo = new BonsaiFrameworkRepository(
                        new FileService(), new SimpleCSharpProjectFactory(readerRepo), readerRepo);
                }
                if (arg.Equals("-view", System.StringComparison.OrdinalIgnoreCase))
                {
                    MainRepo = new BonsaiViewControlStructureRepository(
                        new FileService(), new SimpleCSharpProjectFactory(readerRepo), readerRepo, str["-viewname"]);
                }
                if (arg.Equals("-call", System.StringComparison.OrdinalIgnoreCase))
                {
                    MainRepo = new BonsaiCallingStructureRepository(
                        new FileService(), new SimpleCSharpProjectFactory(readerRepo), readerRepo, str["-viewname"]);
                }
                if (arg.Equals("-return", System.StringComparison.OrdinalIgnoreCase))
                {
                    MainRepo = new BonsaiReturnCallingStructureRepository(
                        new FileService(), new SimpleCSharpProjectFactory(readerRepo), readerRepo, str["-viewname"]);
                }
            }
            if (MainRepo != null)
                MainRepo.RunSteps();
        }
    }
}
