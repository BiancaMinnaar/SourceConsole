using System;
using CorePCL.Generation.Factory;
using CorePCL.Generation.Repository;
using CorePCL.Generation.Service;
using CorePCL.Generation.Templates;
using MobileBonsai.Generation.Repository.Implementation;
using SourceConsole.Factory;
using SourceConsole.Templates.DataModel;

namespace SourceConsole.Repository.Implementation
{
    public class XamarinFormsScreenGeneratorRepository : GeneratorStepsRepository<GroupTemplateDataModel>
    {
        IProjectReaderRepository readerRepository;
        protected TemplateInstanceFactory<GroupTemplateDataModel> instanceFactory;
        GroupTemplateDataModel model;

        public XamarinFormsScreenGeneratorRepository(
            IFileService fileService, IProjectFactory projectFactory, IProjectReaderRepository readerRepo)
            :base(fileService, projectFactory)
        {
            readerRepository = readerRepo;
        }

        public override GroupTemplateDataModel SetupModel(string templateName)
        {
            Func<string> getScreenName = () =>
            {
                Console.Write("Screen Name:");
                return Console.ReadLine();
            };
            var screenData = GetDataModel(getScreenName());
            screenData.ProjectName = readerRepository.GetProjectName();
            Func<string> getEventName = () =>
            {
                Console.Write("Event Name:");
                return Console.ReadLine();
            };
            screenData.EventName = getEventName();

            return screenData;
        }

        protected override void SetupSteps()
        {
            model = SetupModel("");
            instanceFactory = new TemplateInstanceFactory<GroupTemplateDataModel>(
                model, readerRepository);
            instanceFactory.Add<Templates.Scafholding.NormalTemplates.ViewModelTemplate>();
            instanceFactory.Add<Templates.Scafholding.NormalTemplates.ViewTemplate>();
            instanceFactory.Add<Templates.Scafholding.NormalTemplates.ViewCodeBehindTemplate>();
            instanceFactory.Add<Templates.Scafholding.NormalTemplates.ViewControllerInterfaceTemplate>();
            instanceFactory.Add<Templates.Scafholding.ReturningServiceTemplates.ViewControllerTemplate>();
            instanceFactory.Add<Templates.Scafholding.ReturningServiceTemplates.RepositoryInterfaceTemplate>();
            instanceFactory.Add<Templates.Scafholding.ReturningServiceTemplates.RepositoryTemplate>();
            instanceFactory.Add<Templates.Scafholding.ReturningServiceTemplates.ServiceInterfaceTemplate>();
            instanceFactory.Add<Templates.Scafholding.ReturningServiceTemplates.ServiceTemplate>();
        }

        public override void RunSteps()
        {
            SetupSteps();
            foreach(var template in instanceFactory.ToList())
            {
                var temp = new SourceFileMapRepository<ITemplate<GroupTemplateDataModel>, GroupTemplateDataModel>()
                {
                    _ReaderRepo = readerRepository
                };
                WriteTemplateWithModelInjection(template, temp);
            }
        }
    }
}
