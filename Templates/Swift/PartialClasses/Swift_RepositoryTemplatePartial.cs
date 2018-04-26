using CorePCL.Generation.DataModel;
using CorePCL.Generation.Templates;
using CorePCL.Generation.Templates.Extensions;
using CorePCL.Generation.Templates.PartialClasses;
using SourceConsole.Repository.Implementation;

namespace SourceConsole.Templates.Swift
{
    partial class Swift_RepositoryTemplate : ITemplate<TemplateDataModel>
    {
        public string FullProjectFileName => this.GetFullProjectFileName<Swift_RepositoryTemplate,TemplateDataModel>();

        public SourceEnum TemplateEnum => SourceEnum.Generator;

        public TemplateEnum TemplateType => CorePCL.Generation.Templates.PartialClasses.TemplateEnum.Regenerate;

        public TemplateDataModel DataModel { get; set; }

        public string TemplateResourceKey => throw new System.NotImplementedException();

        public string GetFileName()
        {
            var readerRepo = new ProjectReaderRepository(new FileService());
            var mapRepo = new SourceFileMapRepository<Swift_RepositoryTemplate, TemplateDataModel>()
            {
                _ReaderRepo = readerRepo
            };
            return this.GetFileName(mapRepo, DataModel.Template);
        }
    }
}
