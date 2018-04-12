using SourceConsole.Templates.DataModel;

namespace SourceConsole.Templates.NormalTemplates
{
    partial class ViewModelTemplate : ITemplate
    {
        GroupTemplateDataModel _DataModel;

        public GroupTemplateDataModel GetDataModel => _DataModel;

        public string FullProjectFileName => _DataModel._ViewModel.FullProjectFileName;

        public PartialClasses.TemplateEnum TemplateType => PartialClasses.TemplateEnum.Normal;

        public ViewModelTemplate(GroupTemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public SourceEnum TemplateEnum => SourceEnum.ViewModel;

        public TemplateDataModel DataModel { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public string GetFileName()
        {
            var repo = new SourceFileMapRepository<ViewModelTemplate>();
            _DataModel._ViewModel = new DataModel.FileModel()
            {
                CodeName = _DataModel.ViewModelName,
                Extension = repo.GetSourceExtension(this),
                ProjectFilePath = repo.GetSourcePath(this)
            };
            return _DataModel._ViewModel.FileName;
        }
    }
}
