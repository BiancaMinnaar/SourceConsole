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

        public string GetFileName()
        {
            return this.GetFileName(
                new SourceFileMapRepository<ServiceInterfaceTemplate, GroupTemplateDataModel>(
                    new ProjectReaderRepository(new FileService())));
        }
    }
}
