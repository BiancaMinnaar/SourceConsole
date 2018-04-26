using CorePCL.Generation.Templates;
using CorePCL.Generation.Templates.Extensions;
using CorePCL.Generation.Templates.PartialClasses;
using SourceConsole.Repository.Implementation;
using SourceConsole.Templates.DataModel;

namespace SourceConsole.Templates.Scafholding.ReturningServiceTemplates
{
    partial class ServiceInterfaceTemplate : ITemplate<GroupTemplateDataModel>
    {
        public string FullProjectFileName => this.GetFullProjectFileName<ServiceInterfaceTemplate, GroupTemplateDataModel>();

        public SourceEnum TemplateEnum => SourceEnum.ServiceInterface;

        public TemplateEnum TemplateType => CorePCL.Generation.Templates.PartialClasses.TemplateEnum.Normal;

        public GroupTemplateDataModel DataModel { get; set; }

        public string TemplateResourceKey => "ServiceInterfacePath";

        public string GetFileName()
        {
            var readerRepo = new ProjectReaderRepository(new FileService());
            var mapRepo = new SourceFileMapRepository<ServiceInterfaceTemplate, GroupTemplateDataModel>()
            {
                _ReaderRepo = readerRepo
            };
            return this.GetFileName(mapRepo, DataModel.Template);
        }
    }
}
