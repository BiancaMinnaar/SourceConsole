using SourceConsole.Templates.DataModel;
using SourceConsole.Templates.PartialClasses;

namespace SourceConsole.Templates.Scafholding.GeneratorTemplates
{
    public static class Extentions
    {
        public static string GetFileName<T>(this T template) where T:ITemplate
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
    partial class TemplatePartialTemplate : ITemplate
    {
        public string FullProjectFileName => this.GetFullProjectFileName();

        public SourceEnum TemplateEnum => SourceEnum.Generator;

        public TemplateEnum TemplateType => PartialClasses.TemplateEnum.Regenerate;

        public TemplateDataModel DataModel { get; set; }

        public TemplatePartialTemplate(TemplateDataModel dataModel)
        {
            DataModel = dataModel;
        }

        public string GetFileName()
        {
            return this.GetFileName();
        }
    }
}
