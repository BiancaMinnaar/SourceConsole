using System;
using CorePCL.Generation.Repository;
using CorePCL.Generation.Repository.Implementation;
using SourceConsole.Factory;
using SourceConsole.Templates.DataModel;

namespace SourceConsole.Repository.Implementation
{
    public class XamarinFormsRepository
    {
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
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<Templates.Scafholding.NormalTemplates.ViewModelTemplate, GroupTemplateDataModel>(readerRepo));
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<Templates.Scafholding.NormalTemplates.ViewTemplate, GroupTemplateDataModel>(readerRepo));
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<Templates.Scafholding.NormalTemplates.ViewCodeBehindTemplate, GroupTemplateDataModel>(readerRepo));
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<Templates.Scafholding.NormalTemplates.ViewControllerInterfaceTemplate, GroupTemplateDataModel>(readerRepo));
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<Templates.Scafholding.ReturningServiceTemplates.ViewControllerTemplate, GroupTemplateDataModel>(readerRepo));
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<Templates.Scafholding.ReturningServiceTemplates.RepositoryInterfaceTemplate, GroupTemplateDataModel>(readerRepo));
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<Templates.Scafholding.ReturningServiceTemplates.RepositoryTemplate, GroupTemplateDataModel>(readerRepo));
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<Templates.Scafholding.ReturningServiceTemplates.ServiceInterfaceTemplate, GroupTemplateDataModel>(readerRepo));
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<Templates.Scafholding.ReturningServiceTemplates.ServiceTemplate, GroupTemplateDataModel>(readerRepo));
        }
    }
}
