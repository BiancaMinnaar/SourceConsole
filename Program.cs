using System;
using CorePCL.Generation.Repository;
using CorePCL.Generation.Repository.Implementation;
using SourceConsole.Factory;
using SourceConsole.Repository.Implementation;
using SourceConsole.Templates.DataModel;

namespace SourceConsole
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var readerRepo = new ProjectReaderRepository(new FileService());
            var MainRepo = new XamarinFormsScreenGeneratorRepository(
            //var MainRepo = new BonsaiFrameworkRepository(
                new FileService(), 
                new SimpleCSharpProjectFactory(readerRepo),
                readerRepo);
            //MainRepo.GenerateXamarinScreen();
            MainRepo.RunSteps();
        }
    }
}
