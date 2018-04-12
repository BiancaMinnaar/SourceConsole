using SourceConsole.Templates.DataModel;

namespace SourceConsole.Templates
{
    public interface ITemplate
    {
        PartialClasses.TemplateEnum TemplateType { get; }
		string FullProjectFileName { get; }
        string TransformText();
        SourceEnum TemplateEnum { get; }
        string GetFileName();
    }
}
