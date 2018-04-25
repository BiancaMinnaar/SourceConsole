using CorePCL.Generation.Templates;
using CorePCL.Generation.Templates.Extensions;
using CorePCL.Generation.Templates.PartialClasses;
using SourceConsole.Repository.Implementation;
using SourceConsole.Templates.DataModel;

namespace SourceConsole.Templates.Framework
{
    public partial class ProjectBaseContentViewTemplate : ITemplate<PreSetupTemplateModel>
    {
        public string TemplateResourceKey => "BaseFolderPath";

        public PreSetupTemplateModel DataModel { get; set; }

        public TemplateEnum TemplateType => CorePCL.Generation.Templates.PartialClasses.TemplateEnum.Normal;

        public string FullProjectFileName => this.GetFullProjectFileName<ProjectBaseContentViewTemplate, PreSetupTemplateModel>();

        public SourceEnum TemplateEnum => SourceEnum.PBContentPage;

        public string GetFileName()
        {
            return this.GetFileName(
                new SourceFileMapRepository<ProjectBaseContentViewTemplate, PreSetupTemplateModel>(
                    new ProjectReaderRepository(new FileService())), DataModel.Template);
        }
    }
}
