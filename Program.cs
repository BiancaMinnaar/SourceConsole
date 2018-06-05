using Templater.Factory;
using Templater.Repository.Implementation;
using Templater.Service.Implementation;
using TemplaterBonsai.Repository.Implementation;

namespace SourceConsole
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var readerRepo = new ProjectReaderRepository(new FileService());
			//var MainRepo = new BonsaiFrameworkRepository(
            //var MainRepo = new XamarinFormsScreenGeneratorRepository(
            var MainRepo = new BonsaiUpgrade1_1_1(
                new FileService(), 
                new SimpleCSharpProjectFactory(readerRepo),
                readerRepo);
            MainRepo.RunSteps();
        }
    }
}
