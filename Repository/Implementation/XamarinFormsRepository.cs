using System;
using CorePCL.Generation.Repository;
using CorePCL.Generation.Repository.Implementation;
using SourceConsole.Factory;
using SourceConsole.Templates.DataModel;
using CorePCL.Generation.DataModel;
using CorePCL.Generation.Templates;

namespace SourceConsole.Repository.Implementation
{
    public class XamarinFormsRepository
    {
        public void GenerateXamarinScreen()
        {
            IProjectReaderRepository readerRepo = new ProjectReaderRepository(new FileService());
            IGenerationReposetory<GroupTemplateDataModel> repo =
                new GenerationReposetory<GroupTemplateDataModel>(new FileService(), new SimpleCSharpProjectFactory(readerRepo));
            Func<string> getScreenName = () =>
            {
                Console.Write("Screen Name:");
                return Console.ReadLine();
            };
            var screenData = repo.GetBaseDataModel(getScreenName());
            screenData.ProjectName = readerRepo.GetProjectName();
            Func<string> getEventName = () =>
            {
                Console.Write("Event Name:");
                return Console.ReadLine();
            };
            screenData.EventName = getEventName();
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

        public Action WriteTemplateWithModelInjection<M, I>(IProjectReaderRepository readerRepo, string templateName, Action<M> inject) 
            where M : TemplateDataModel, new()
            where I : ITemplate<M>, new()
        {
            IGenerationReposetory<M> repo =
                new GenerationReposetory<M>(new FileService(), new SimpleCSharpProjectFactory(readerRepo));
            var model = repo.GetBaseDataModel(templateName);
            inject(model);

            return () =>
            {
                repo.WriteTemplateToFile(
                    model,
                    new SourceFileMapRepository<I, M>(readerRepo));
            };   
        }

        public void GenerateXamarinPreSetup()
        {
            IProjectReaderRepository readerRepo = new ProjectReaderRepository(new FileService());

            WriteTemplateWithModelInjection<PreSetupTemplateModel, Templates.Framework.AppXamlTemplate>(
                readerRepo, "App",(obj) => 
            {
                obj.ProjectName = readerRepo.GetProjectName();
            })();
            WriteTemplateWithModelInjection<PreSetupTemplateModel, Templates.Framework.AppCodeBehindTemplate>(
                readerRepo, "App", (obj) =>
                {
                    obj.ProjectName = readerRepo.GetProjectName();
                })();
            WriteTemplateWithModelInjection<PreSetupTemplateModel, Templates.Framework.CheckAndBalanceTemplate>(
                readerRepo, "CheckAndBalance", (obj) =>
                {
                    obj.ProjectName = readerRepo.GetProjectName();
                })();
            WriteTemplateWithModelInjection<PreSetupTemplateModel, Templates.Framework.MasterModelTemplate>(
                readerRepo, "MasterModel", (obj) =>
                {
                    obj.ProjectName = readerRepo.GetProjectName();
                })();
            WriteTemplateWithModelInjection<PreSetupTemplateModel, Templates.Framework.ProjectBaseContentPageTemplate>(
                readerRepo, "ProjectBaseContentPage", (obj) =>
                {
                    obj.ProjectName = readerRepo.GetProjectName();
                })();
            WriteTemplateWithModelInjection<PreSetupTemplateModel, Templates.Framework.ProjectBaseContentScrollViewTemplate>(
                readerRepo, "ProjectBaseContentScrollView", (obj) =>
                {
                    obj.ProjectName = readerRepo.GetProjectName();
                })();
            WriteTemplateWithModelInjection<PreSetupTemplateModel, Templates.Framework.ProjectBaseContentViewTemplate>(
                readerRepo, "ProjectBaseContentView", (obj) =>
                {
                    obj.ProjectName = readerRepo.GetProjectName();
                })();
            WriteTemplateWithModelInjection<PreSetupTemplateModel, Templates.Framework.ProjectBaseRepositoryTemplate>(
                readerRepo, "ProjectBaseRepository", (obj) =>
                {
                    obj.ProjectName = readerRepo.GetProjectName();
                })();
            WriteTemplateWithModelInjection<PreSetupTemplateModel, Templates.Framework.ProjectBaseStackContentViewTemplate>(
                readerRepo, "ProjectBaseStackContentView", (obj) =>
                {
                    obj.ProjectName = readerRepo.GetProjectName();
                })();
            WriteTemplateWithModelInjection<PreSetupTemplateModel, Templates.Framework.ProjectBaseViewControllerTemplate>(
                readerRepo, "ProjectBaseViewController", (obj) =>
                {
                    obj.ProjectName = readerRepo.GetProjectName();
                })();
            WriteTemplateWithModelInjection<PreSetupTemplateModel, Templates.Framework.ProjectBaseViewModelTemplate>(
                readerRepo, "ProjectBaseViewModel", (obj) =>
                {
                    obj.ProjectName = readerRepo.GetProjectName();
                })();
            WriteTemplateWithModelInjection<PreSetupTemplateModel, Templates.Framework.SVGBindingPropertyTemplate>(
                readerRepo, "SVGBindingProperty", (obj) =>
                {
                    obj.ProjectName = readerRepo.GetProjectName();
                })();
        }
    }
}
