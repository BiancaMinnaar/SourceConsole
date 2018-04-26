using CorePCL.Generation.Templates;
using CorePCL.Generation.Templates.Extensions;
using CorePCL.Generation.Templates.PartialClasses;
using SourceConsole.Repository.Implementation;
using SourceConsole.Templates.DataModel;

namespace SourceConsole.Templates.Framework
{
    public partial class CheckAndBalanceTemplate : ITemplate<PreSetupTemplateModel>
    {
        public string TemplateResourceKey => "BaseFolderPath";

        public PreSetupTemplateModel DataModel { get; set; }

        public TemplateEnum TemplateType => CorePCL.Generation.Templates.PartialClasses.TemplateEnum.Normal;

        public string FullProjectFileName => this.GetFullProjectFileName<CheckAndBalanceTemplate, PreSetupTemplateModel>();

        public SourceEnum TemplateEnum => SourceEnum.PBContentPage;

        public string GetFileName()
        {
            var readerRepo = new ProjectReaderRepository(new FileService());
            var mapRepo = new SourceFileMapRepository<CheckAndBalanceTemplate, PreSetupTemplateModel>()
            {
                _ReaderRepo = readerRepo
            };
            return this.GetFileName(mapRepo, DataModel.Template);
        }
    }
}
