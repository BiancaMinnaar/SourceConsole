using SourceConsole.Templates.DataModel;
using SourceConsole.Templates.Extensions;
using SourceConsole.Templates.PartialClasses;

namespace SourceConsole.Templates.Swift
{
    partial class Swift_RepositoryTemplate : ITemplate<TemplateDataModel>
    {
        public string FullProjectFileName => this.GetFullProjectFileName<Swift_RepositoryTemplate,TemplateDataModel>();

        public SourceEnum TemplateEnum => SourceEnum.Generator;

        public TemplateEnum TemplateType => PartialClasses.TemplateEnum.Regenerate;

        public TemplateDataModel DataModel { get; set; }

        public Swift_RepositoryTemplate(TemplateDataModel dataModel)
        {
            DataModel = dataModel;
        }

        public string GetFileName()
        {
            return this.GetFileName();
        }
    }
}
