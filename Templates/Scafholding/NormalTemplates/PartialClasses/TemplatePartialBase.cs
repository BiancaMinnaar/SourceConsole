using SourceConsole.Templates.DataModel;

namespace SourceConsole.Templates.Scafholding.NormalTemplates
{
    public abstract class TemplatePartialBase : ITemplate
    {
        public abstract PartialClasses.TemplateEnum TemplateType { get; }
        protected TemplateDataModel _DataModel;

        public abstract string FullProjectFileName { get; }

        public abstract SourceEnum TemplateEnum { get; }

        public TemplatePartialBase(TemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public abstract string TransformText();

        public abstract string GetFileName();
    }
}
