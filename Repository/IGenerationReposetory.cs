using System;
using SourceConsole.Templates;
using SourceConsole.Templates.DataModel;

namespace SourceConsole
{
    public interface IGenerationReposetory
    {
        GroupTemplateDataModel GetDataModel(string screenName, string projectName);
        GroupTemplateDataModel GetDataModel(Func<string> screenName);
        bool WriteTemplateToFile(string fullFilePath, string templateOutput);
        bool WriteTemplateToFile<T, M>(T template) where T : ITemplate<M> where M: TemplateDataModel;
    }
}
