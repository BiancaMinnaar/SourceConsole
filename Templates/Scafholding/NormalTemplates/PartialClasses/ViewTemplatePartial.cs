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

        public TemplateEnum TemplateType => CorePCL.Generation.Templates.PartialClasses.TemplateEnum.Normal;

        public GroupTemplateDataModel DataModel { get; set; }

        public string TemplateResourceKey => "ViewPath";

        public string GetFileName()
        {
            return this.GetFileName(
                new SourceFileMapRepository<ViewTemplate, GroupTemplateDataModel>(
                    new ProjectReaderRepository(new FileService())), DataModel.ViewName);
        }
    }
}
