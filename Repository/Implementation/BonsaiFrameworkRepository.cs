using CorePCL.Generation.Factory;
using CorePCL.Generation.Repository;
using CorePCL.Generation.Service;
using CorePCL.Generation.Templates;
using MobileBonsai.Generation.Repository.Implementation;
using SourceConsole.Factory;
using SourceConsole.Templates.DataModel;

namespace SourceConsole.Repository.Implementation
{
    public class BonsaiFrameworkRepository : GeneratorStepsRepository<PreSetupTemplateModel>
    {
        IProjectReaderRepository readerRepository;
        protected TemplateInstanceFactory<PreSetupTemplateModel> instanceFactory;
        PreSetupTemplateModel model;

        public BonsaiFrameworkRepository(IFileService fileService, IProjectFactory projectFactory, IProjectReaderRepository readerRepo) : base(fileService, projectFactory)
        {
            readerRepository = readerRepo;
        }

        public override void RunSteps()
        {
            SetupSteps();
            foreach (var template in instanceFactory.ToList())
            {
                var temp = new SourceFileMapRepository<ITemplate<PreSetupTemplateModel>, PreSetupTemplateModel>()
                {
                    _ReaderRepo = readerRepository
                };
                WriteTemplateWithModelInjection(template, temp);
            }
        }

        public override PreSetupTemplateModel SetupModel(string templateName)
        {
            model = GetDataModel(templateName);
            model.ProjectName = readerRepository.GetProjectName();

            return model;
        }

        protected override void SetupSteps()
        {
            instanceFactory = new TemplateInstanceFactory<PreSetupTemplateModel>(
                model, readerRepository);
            instanceFactory.Add<Templates.Framework.CheckAndBalanceTemplate>(SetupModel("CheckAndBalance"));
            instanceFactory.Add<Templates.Framework.MasterModelTemplate>(SetupModel("MasterModel"));
            instanceFactory.Add<Templates.Framework.ProjectBaseContentPageTemplate>(SetupModel("ProjectBaseContentPage"));
            instanceFactory.Add<Templates.Framework.ProjectBaseContentScrollViewTemplate>(SetupModel("ProjectBaseContentScrollView"));
            instanceFactory.Add<Templates.Framework.ProjectBaseContentViewTemplate>(SetupModel("ProjectBaseContentView"));
            instanceFactory.Add<Templates.Framework.ProjectBaseRepositoryTemplate>(SetupModel("ProjectBaseRepository"));
            instanceFactory.Add<Templates.Framework.ProjectBaseStackContentViewTemplate>(SetupModel("ProjectBaseStackContentView"));
            instanceFactory.Add<Templates.Framework.ProjectBaseViewControllerTemplate>(SetupModel("ProjectBaseViewController"));
            instanceFactory.Add<Templates.Framework.ProjectBaseViewModelTemplate>(SetupModel("ProjectBaseViewModel"));
            instanceFactory.Add<Templates.Framework.SVGBindingPropertyTemplate>(SetupModel("SVGBindingProperty"));
        }
    }
}
