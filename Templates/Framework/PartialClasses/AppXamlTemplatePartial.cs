using CorePCL.Generation.Templates;
using CorePCL.Generation.Templates.Extensions;
using CorePCL.Generation.Templates.PartialClasses;
using SourceConsole.Repository.Implementation;
using SourceConsole.Templates.DataModel;

namespace SourceConsole.Templates.Framework
{
    public partial class AppXamlTemplate : ITemplate<PreSetupTemplateModel>
    {
        public string FullProjectFileName => this.GetFullProjectFileName<AppXamlTemplate, PreSetupTemplateModel>();

        public SourceEnum TemplateEnum => SourceEnum.View;

        public TemplateEnum TemplateType => CorePCL.Generation.Templates.PartialClasses.TemplateEnum.Xaml;

        public PreSetupTemplateModel DataModel { get; set; }

        public string TemplateResourceKey => "RootPath";

        public string GetFileName()
        {
            return this.GetFileName(
                new SourceFileMapRepository<AppXamlTemplate, PreSetupTemplateModel>(
                    new ProjectReaderRepository(new FileService())), DataModel.Template);
        }
    }
}
