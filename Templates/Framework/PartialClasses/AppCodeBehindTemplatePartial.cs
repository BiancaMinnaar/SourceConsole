using CorePCL.Generation.Templates;
using CorePCL.Generation.Templates.Extensions;
using CorePCL.Generation.Templates.PartialClasses;
using SourceConsole.Repository.Implementation;
using SourceConsole.Templates.DataModel;

namespace SourceConsole.Templates.Framework
{
    public partial class AppCodeBehindTemplate : ITemplate<PreSetupTemplateModel>
    {
        public string FullProjectFileName => this.GetFullProjectFileName<AppCodeBehindTemplate, PreSetupTemplateModel>();

        public SourceEnum TemplateEnum => SourceEnum.Generator;

        public TemplateEnum TemplateType => CorePCL.Generation.Templates.PartialClasses.TemplateEnum.CodeBehind;

        public PreSetupTemplateModel DataModel { get; set; }

        public string TemplateResourceKey => "RootPath";

        public string GetFileName()
        {
            return this.GetFileName(
                new SourceFileMapRepository<AppCodeBehindTemplate, PreSetupTemplateModel>(
                    new ProjectReaderRepository(new FileService())), DataModel.Template);
        }
    }
}
