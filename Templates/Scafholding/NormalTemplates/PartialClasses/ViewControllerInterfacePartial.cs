using CorePCL.Generation.Templates;
using CorePCL.Generation.Templates.Extensions;
using CorePCL.Generation.Templates.PartialClasses;
using SourceConsole.Repository.Implementation;
using SourceConsole.Templates.DataModel;

namespace SourceConsole.Templates.Scafholding.NormalTemplates
{
    partial class ViewControllerInterfaceTemplate : ITemplate<GroupTemplateDataModel>
    {
        public string FullProjectFileName => this.GetFullProjectFileName<ViewControllerInterfaceTemplate, GroupTemplateDataModel>();

        public SourceEnum TemplateEnum => SourceEnum.ViewControllerInterface;

        public TemplateEnum TemplateType => CorePCL.Generation.Templates.PartialClasses.TemplateEnum.Normal;

        public GroupTemplateDataModel DataModel { get; set; }

        public string TemplateResourceKey => "ViewControllerInterfacePath";

        public string GetFileName()
        {
            var readerRepo = new ProjectReaderRepository(new FileService());
            var mapRepo = new SourceFileMapRepository<ViewControllerInterfaceTemplate, GroupTemplateDataModel>()
            {
                _ReaderRepo = readerRepo
            };
            return this.GetFileName(mapRepo, DataModel.ViewControllerInterfaceName);
        }
    }
}
