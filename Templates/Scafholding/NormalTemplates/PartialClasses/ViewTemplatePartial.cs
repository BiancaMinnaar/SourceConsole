using CorePCL.Generation.Templates;
using CorePCL.Generation.Templates.Extensions;
using CorePCL.Generation.Templates.PartialClasses;
using SourceConsole.Repository.Implementation;
using SourceConsole.Templates.DataModel;

namespace SourceConsole.Templates.Scafholding.NormalTemplates
{
    partial class ViewTemplate : ITemplate<GroupTemplateDataModel>
    {
        public string FullProjectFileName => this.GetFullProjectFileName<ViewTemplate, GroupTemplateDataModel>();

        public SourceEnum TemplateEnum => SourceEnum.View;

        public TemplateEnum TemplateType => CorePCL.Generation.Templates.PartialClasses.TemplateEnum.Xaml;

        public GroupTemplateDataModel DataModel { get; set; }

        public string TemplateResourceKey => "ViewPath";

        public string GetFileName()
        {
            var readerRepo = new ProjectReaderRepository(new FileService());
            var mapRepo = new SourceFileMapRepository<ViewTemplate, GroupTemplateDataModel>()
            {
                _ReaderRepo = readerRepo
            };
            return this.GetFileName(mapRepo, DataModel.ViewName);
        }
    }
}
