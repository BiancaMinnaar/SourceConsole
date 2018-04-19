using System;
using CorePCL.Generation.Repository;
using CorePCL.Generation.Repository.Implementation;
using SourceConsole.Factory;
using SourceConsole.Templates.DataModel;
using SourceConsole.Templates.Scafholding.NormalTemplates;

namespace SourceConsole.Repository.Implementation
{
    public class XamarinFormsRepository
    {
        public XamarinFormsRepository()
        {
        }

        public void GenerateXamarinScreen()
        {
            IProjectReaderRepository readerRepo = new ProjectReaderRepository(new FileService());
            IGenerationReposetory<GroupTemplateDataModel> repo =
                new GenerationReposetory<GroupTemplateDataModel>(new FileService(), new SimpleCSharpProjectFactory(readerRepo));
            var screenData = repo.GetBaseDataModel(() =>
            {
                Console.Write("Template Name:");
                return Console.ReadLine();
            });
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<ViewModelTemplate, GroupTemplateDataModel>(readerRepo));
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<ViewTemplate, GroupTemplateDataModel>(readerRepo));
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<ViewCodeBehindTemplate, GroupTemplateDataModel>(readerRepo));
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<ViewControllerInterfaceTemplate, GroupTemplateDataModel>(readerRepo));
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<ViewControllerTemplate, GroupTemplateDataModel>(readerRepo));
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<RepositoryInterfaceTemplate, GroupTemplateDataModel>(readerRepo));
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<RepositoryTemplate, GroupTemplateDataModel>(readerRepo));
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<ServiceInterfaceTemplate, GroupTemplateDataModel>(readerRepo));
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<ServiceTemplate, GroupTemplateDataModel>(readerRepo));
        }
    }
}
