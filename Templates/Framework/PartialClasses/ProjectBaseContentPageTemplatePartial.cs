using CorePCL.Generation.Templates;
using CorePCL.Generation.Templates.Extensions;
using CorePCL.Generation.Templates.PartialClasses;
using SourceConsole.Repository.Implementation;
using SourceConsole.Templates.DataModel;

namespace SourceConsole.Templates.Framework
{
    partial class ProjectBaseContentPageTemplate : ITemplate<PreSetupTemplateModel>
    {
        public string FullProjectFileName => this.GetFullProjectFileName<ProjectBaseContentPageTemplate, PreSetupTemplateModel>();

        public SourceEnum TemplateEnum => SourceEnum.PBContentPage;

        public TemplateEnum TemplateType => CorePCL.Generation.Templates.PartialClasses.TemplateEnum.Normal;

        public PreSetupTemplateModel DataModel { get; set; }

        public string TemplateResourceKey => "BaseFolderPath";

        public string GetFileName()
        {
            return this.GetFileName(
                new SourceFileMapRepository<ProjectBaseContentPageTemplate, PreSetupTemplateModel>(
                    new ProjectReaderRepository(new FileService())), DataModel.Template);
        }
    }
}
