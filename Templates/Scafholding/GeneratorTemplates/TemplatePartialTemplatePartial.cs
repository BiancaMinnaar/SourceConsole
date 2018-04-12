using System;
using SourceConsole.Templates.DataModel;
using SourceConsole.Templates.PartialClasses;

namespace SourceConsole.Templates.Scafholding.GeneratorTemplates
{
    partial class TemplatePartialTemplate : ITemplate
    {
        public string FullProjectFileName => DataModel._Template.FullProjectFileName;

        public SourceEnum TemplateEnum => SourceEnum.Generator;

        public TemplateEnum TemplateType => PartialClasses.TemplateEnum.Regenerate;

        public TemplateDataModel DataModel { get; set; }

        public string GetFileName()
        {
            var repo = new SourceFileMapRepository<TemplatePartialTemplate>();
            DataModel._Template = new FileModel()
            {
                CodeName = DataModel.Template,
                Extension = repo.GetSourceExtension(this),
                ProjectFilePath = repo.GetSourcePath(this)
            };
            return DataModel._Template.FileName;
        }
    }
}
