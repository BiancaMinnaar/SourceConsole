namespace SourceConsole.Templates.NormalTemplates
{
    partial class ViewCodeBehindTemplate : ITemplate
    {
        GroupTemplateDataModel _DataModel;

        public GroupTemplateDataModel GetDataModel => _DataModel;

        public string FullProjectFileName => _DataModel._ViewCodeBehind.FullProjectFileName;

        public PartialClasses.TemplateEnum TemplateType => PartialClasses.TemplateEnum.CodeBehind;

        public ViewCodeBehindTemplate(GroupTemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public SourceEnum TemplateEnum => SourceEnum.ViewCodeBehind;

        public string GetFileName()
        {
            var repo = new SourceFileMapRepository<ViewCodeBehindTemplate>();
            _DataModel._ViewCodeBehind = new DataModel.FileModel()
            {
                CodeName = _DataModel.ViewCodeBehindName,
                Extension = repo.GetSourceExtension(this),
                ProjectFilePath = repo.GetSourcePath(this)
            };
            return _DataModel._ViewCodeBehind.FileName;
        }
    }
}
