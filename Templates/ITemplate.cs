namespace SourceConsole.Templates
{
    public interface ITemplate
    {
        PartialClasses.TemplateEnum TemplateType { get; }
        GroupTemplateDataModel GetDataModel { get; }
		string FullProjectFileName { get; }
        string TransformText();
        SourceEnum TemplateEnum { get; }
        string GetFileName();
    }
}
