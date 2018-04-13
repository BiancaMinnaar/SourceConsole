using System;
using SourceConsole.Templates;
using SourceConsole.Templates.DataModel;

namespace SourceConsole
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            IProjectReaderRepository readerRepo = new ProjectReaderRepository(new FileService());
            IGenerationReposetory repo = new GenerationReposetory(readerRepo, new FileService());
            var screenData = repo.GetBaseDataModel<TemplateDataModel>(() =>
                {
                    Console.Write("Template Name:");
                    return Console.ReadLine();
            });
            //repo.WriteTemplateToFile(new SourceConsole.Templates.NormalTemplates.ViewModelTemplate(screenData));
            //repo.WriteTemplateToFile(new SourceConsole.Templates.NormalTemplates.ViewTemplate(screenData));
            //repo.WriteTemplateToFile(new SourceConsole.Templates.NormalTemplates.ViewCodeBehindTemplate(screenData));
            //repo.WriteTemplateToFile(new SourceConsole.Templates.NormalTemplates.ViewControllerInterfaceTemplate(screenData));
            //repo.WriteTemplateToFile(new SourceConsole.Templates.NormalTemplates.ViewControllerTemplate(screenData));
            //repo.WriteTemplateToFile(new SourceConsole.Templates.NormalTemplates.RepositoryInterfaceTemplate(screenData));
            //repo.WriteTemplateToFile(new SourceConsole.Templates.NormalTemplates.RepositoryTemplate(screenData));
            //repo.WriteTemplateToFile(new SourceConsole.Templates.NormalTemplates.ServiceInterfaceTemplate(screenData));
            //repo.WriteTemplateToFile(new SourceConsole.Templates.NormalTemplates.ServiceTemplate(screenData));

            //repo.WriteTemplateToFile<SourceConsole.Templates.Framework.ProjectBaseContentPageTemplate,GroupTemplateDataModel>(new SourceConsole.Templates.Framework.ProjectBaseContentPageTemplate(screenData));
            //var screenData = new TemplateDataModel()
            //{
            //    ProjectName = ""
            //};
            repo.WriteTemplateToFile(new Templates.Swift.Swift_RepositoryTemplate(screenData), screenData);
        }
    }
}
