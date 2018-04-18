using SourceConsole.Templates;
using SourceConsole.Templates.DataModel;

namespace SourceConsole.Factory
{
    public interface IProjectFactory
    {
        void UpdateProjectFileWithFileReference<M>(ITemplate<M> template) where M : TemplateDataModel;
    }
}
