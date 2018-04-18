using System;
using SourceConsole.Templates;
using SourceConsole.Templates.DataModel;

namespace SourceConsole
{
    public interface IGenerationReposetory
    {
        GroupTemplateDataModel GetDataModel(string screenName, string projectName);
        GroupTemplateDataModel GetDataModel(Func<string> screenName);
        M GetBaseDataModel<M>(Func<string> templateName) where M : TemplateDataModel, new();
        bool WriteTemplateToFile(string fullFilePath, string templateOutput);
        bool WriteTemplateToFile<T, M>(M model) where T : ITemplate<M>, new() where M: TemplateDataModel;
    }
}
