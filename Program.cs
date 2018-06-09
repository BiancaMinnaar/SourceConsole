using Templater.Factory;
using Templater.Repository.Implementation;
using Templater.Service.Implementation;

namespace SourceConsole
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var readerRepo = new ProjectReaderRepository(new FileService());
			var MainRepo = new BonsaiFrameworkRepository(
            //var MainRepo = new XamarinFormsScreenGeneratorRepository(
                new FileService(), 
                new SimpleCSharpProjectFactory(readerRepo),
                readerRepo);
            MainRepo.RunSteps();
        }
    }
}
