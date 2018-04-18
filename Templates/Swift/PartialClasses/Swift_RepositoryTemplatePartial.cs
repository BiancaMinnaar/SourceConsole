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

        public string GetFileName()
        {
            return this.GetFileName();
        }
    }
}
