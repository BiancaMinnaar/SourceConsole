using SourceConsole.Templates.DataModel;

namespace SourceConsole.Templates
{
    public interface ITemplate
    {
        TemplateDataModel DataModel { get; set; }
        PartialClasses.TemplateEnum TemplateType { get; }
		string FullProjectFileName { get; }
        string TransformText();
        SourceEnum TemplateEnum { get; }
        string GetFileName();
    }
}
