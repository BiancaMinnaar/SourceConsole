using CorePCL.Generation.Templates;
using CorePCL.Generation.Templates.Extensions;
using CorePCL.Generation.Templates.PartialClasses;
using SourceConsole.Repository.Implementation;
using SourceConsole.Templates.DataModel;

namespace SourceConsole.Templates.Scafholding.ReturningServiceTemplates
{
    partial class RepositoryTemplate : ITemplate<GroupTemplateDataModel>
    {
        public string FullProjectFileName => this.GetFullProjectFileName<RepositoryTemplate, GroupTemplateDataModel>();

        public SourceEnum TemplateEnum => SourceEnum.Repository;

        public TemplateEnum TemplateType => CorePCL.Generation.Templates.PartialClasses.TemplateEnum.Normal;

        public GroupTemplateDataModel DataModel { get; set; }

        public string TemplateResourceKey => "RepositoryPath";

        public string GetFileName()
        {
            return this.GetFileName(
                new SourceFileMapRepository<RepositoryTemplate, GroupTemplateDataModel>(
                    new ProjectReaderRepository(new FileService())), DataModel.RepositoryName);
        }
    }
}
