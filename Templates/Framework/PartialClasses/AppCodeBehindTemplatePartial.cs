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

        public SourceEnum TemplateEnum => SourceEnum.ViewCodeBehind;

        public TemplateEnum TemplateType => CorePCL.Generation.Templates.PartialClasses.TemplateEnum.CodeBehind;

        public PreSetupTemplateModel DataModel { get; set; }

        public string TemplateResourceKey => "RootPath";

        public string GetFileName()
        {
            var readerRepo = new ProjectReaderRepository(new FileService());
            var mapRepo = new SourceFileMapRepository<AppCodeBehindTemplate, PreSetupTemplateModel>()
            {
                _ReaderRepo = readerRepo
            };
            return this.GetFileName(mapRepo, DataModel.Template);
        }
    }
}
