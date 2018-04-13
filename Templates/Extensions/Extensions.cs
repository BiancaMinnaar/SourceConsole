using System;
using SourceConsole.Templates.DataModel;

namespace SourceConsole.Templates.Extensions
{
    public static class Extentions
    {
        public static string GetFileName<T>(this T template) where T : ITemplate
        {
            var repo = new SourceFileMapRepository<T>();
            template.DataModel._Template = new FileModel()
            {
                CodeName = template.DataModel.Template,
                Extension = repo.GetSourceExtension(template),
                ProjectFilePath = repo.GetSourcePath(template)
            };
            return template.DataModel._Template.FileName;
        }

        public static string GetFullProjectFileName<T>(this T template) where T : ITemplate
        {
            return template.DataModel._Template.FullProjectFileName;
        }
    }
}
