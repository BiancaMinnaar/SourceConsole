using SourceConsole.Templates.DataModel;

namespace SourceConsole.Templates.Scafholding.NormalTemplates
{
    public abstract class TemplatePartialBase : ITemplate
    {
        public abstract PartialClasses.TemplateEnum TemplateType { get; }
        public abstract TemplateDataModel DataModel { get; set; }

        public abstract string FullProjectFileName { get; }

        public abstract SourceEnum TemplateEnum { get; }

        public TemplatePartialBase(TemplateDataModel dataModel)
        {
            DataModel = dataModel;
        }

        public abstract string TransformText();

        public abstract string GetFileName();
    }
}
