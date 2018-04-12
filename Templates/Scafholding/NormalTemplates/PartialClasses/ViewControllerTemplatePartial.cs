using SourceConsole.Templates.DataModel;

namespace SourceConsole.Templates.NormalTemplates
{
    partial class ViewControllerTemplate : ITemplate
    {
        GroupTemplateDataModel _DataModel;

        public GroupTemplateDataModel GetDataModel => _DataModel;

        public PartialClasses.TemplateEnum TemplateType => PartialClasses.TemplateEnum.Normal;

        public string FullProjectFileName => _DataModel._ViewController.FullProjectFileName;

        public ViewControllerTemplate(GroupTemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public SourceEnum TemplateEnum => SourceEnum.ViewController;

        public string GetFileName()
        {
            var repo = new SourceFileMapRepository<ViewControllerTemplate>();
            _DataModel._ViewController = new DataModel.FileModel()
            {
                CodeName = _DataModel.ViewControllerName,
                Extension = repo.GetSourceExtension(this),
                ProjectFilePath = repo.GetSourcePath(this)
            };
            return _DataModel._ViewController.FileName;
        }
    }
}
