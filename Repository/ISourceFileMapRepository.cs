using SourceConsole.Templates;
using SourceConsole.Templates.DataModel;

namespace SourceConsole
{
    public interface ISourceFileMapRepository<T,M> 
        where T: ITemplate<M>
        where M: TemplateDataModel
    {
        SourceEnum GetSourceEnumFromTempate(T template);
        string GetSourceExtension(T template);
        string GetSourcePath(T template);
    }
}
