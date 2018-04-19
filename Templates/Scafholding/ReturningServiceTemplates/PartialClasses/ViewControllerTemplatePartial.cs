using CorePCL.Generation.Templates;
using CorePCL.Generation.Templates.Extensions;
using CorePCL.Generation.Templates.PartialClasses;
using SourceConsole.Repository.Implementation;
using SourceConsole.Templates.DataModel;

namespace SourceConsole.Templates.ReturningServiceTemplates
{
    partial class ViewControllerTemplate : ITemplate<GroupTemplateDataModel>
    {
        public string FullProjectFileName => this.GetFullProjectFileName<ViewControllerTemplate, GroupTemplateDataModel>();

        public SourceEnum TemplateEnum => SourceEnum.ViewController;

        public TemplateEnum TemplateType => CorePCL.Generation.Templates.PartialClasses.TemplateEnum.Normal;

        public GroupTemplateDataModel DataModel { get; set; }

        public string GetFileName()
        {
            return this.GetFileName(
                new SourceFileMapRepository<ViewControllerTemplate, GroupTemplateDataModel>(
                    new ProjectReaderRepository(new FileService())));
        }
    }
}
