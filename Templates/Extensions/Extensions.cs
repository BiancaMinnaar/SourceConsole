using System;
using SourceConsole.Templates.DataModel;

namespace SourceConsole.Templates.Extensions
{
    public static class Extentions
    {
        public static string GetFileName<T,M>(this T template) where T : ITemplate<M> where M:TemplateDataModel
        {
            var repo = new SourceFileMapRepository<T,M>();
            template.DataModel._Template = new FileModel()
            {
                CodeName = template.DataModel.Template,
                Extension = repo.GetSourceExtension(template),
                ProjectFilePath = repo.GetSourcePath(template)
            };
            return template.DataModel._Template.FileName;
        }

        public static string GetFullProjectFileName<T, M>(this T template) where T : ITemplate<M> where M : TemplateDataModel
        {
            return template.DataModel._Template.FullProjectFileName;
        }
    }
}
