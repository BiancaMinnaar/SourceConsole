using CorePCL.Generation.Templates;
using CorePCL.Generation.Templates.Extensions;
using CorePCL.Generation.Templates.PartialClasses;
using SourceConsole.Repository.Implementation;
using SourceConsole.Templates.DataModel;

namespace SourceConsole.Templates.Scafholding.NormalTemplates
{
    partial class ServiceTemplate : ITemplate<GroupTemplateDataModel>
    {
        public string FullProjectFileName => this.GetFullProjectFileName<ServiceTemplate, GroupTemplateDataModel>();

        public SourceEnum TemplateEnum => SourceEnum.Service;

        public TemplateEnum TemplateType => CorePCL.Generation.Templates.PartialClasses.TemplateEnum.Normal;

        public GroupTemplateDataModel DataModel { get; set; }

        public string TemplateResourceKey => "ServicePath";

        public string GetFileName()
        {
            return this.GetFileName(
                new SourceFileMapRepository<ServiceTemplate, GroupTemplateDataModel>(
                    new ProjectReaderRepository(new FileService())), DataModel.ServiceName);
        }
    }
}
