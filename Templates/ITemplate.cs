using SourceConsole.Templates.DataModel;

namespace SourceConsole.Templates
{
    /// <summary>
    /// Template. Depricated Use ITemplate<M>
    /// </summary>
    public interface ITemplate : ITemplate<TemplateDataModel>
    {
    }

    public interface ITemplate<M> where M : TemplateDataModel
    {
        M DataModel { get; set; }
        PartialClasses.TemplateEnum TemplateType { get; }
        string FullProjectFileName { get; }
        string TransformText();
        SourceEnum TemplateEnum { get; }
        string GetFileName();
    }
}
