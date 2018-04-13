using SourceConsole.Templates.DataModel;
using SourceConsole.Templates.Extensions;
using SourceConsole.Templates.PartialClasses;

namespace SourceConsole.Templates.Scafholding.GeneratorTemplates
{
    partial class TemplatePartialTemplate : ITemplate
    {
        public string FullProjectFileName => this.GetFullProjectFileName();

        public SourceEnum TemplateEnum => SourceEnum.Generator;

        public TemplateEnum TemplateType => PartialClasses.TemplateEnum.Regenerate;

        public TemplateDataModel DataModel { get; set; }

        public TemplatePartialTemplate(TemplateDataModel dataModel)
        {
            DataModel = dataModel;
        }

        public string GetFileName()
        {
            return this.GetFileName();
        }
    }
}
