using SourceConsole.Templates.DataModel;

namespace SourceConsole.Templates.ReturningServiceTemplates
{
    partial class ViewControllerTemplate : ITemplate<GroupTemplateDataModel>
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

        public TemplateDataModel DataModel { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        GroupTemplateDataModel ITemplate<GroupTemplateDataModel>.DataModel { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public string GetFileName()
        {
            var repo = new SourceFileMapRepository<ViewControllerTemplate,GroupTemplateDataModel>();
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
