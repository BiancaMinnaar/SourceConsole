using SourceConsole.Templates.DataModel;

namespace SourceConsole.Templates.NormalTemplates
{
    partial class ViewControllerInterfaceTemplate : ITemplate
    {
        GroupTemplateDataModel _DataModel;

        public GroupTemplateDataModel GetDataModel => _DataModel;

        public string FullProjectFileName => _DataModel._ViewControllerInterface.FullProjectFileName;

        public PartialClasses.TemplateEnum TemplateType => PartialClasses.TemplateEnum.Normal;

        public ViewControllerInterfaceTemplate(GroupTemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public SourceEnum TemplateEnum => SourceEnum.ViewControllerInterface;

        public string GetFileName()
        {
            var repo = new SourceFileMapRepository<ViewControllerInterfaceTemplate>();
            _DataModel._ViewControllerInterface = new DataModel.FileModel()
            {
                CodeName = _DataModel.ViewControllerInterfaceName,
                Extension = repo.GetSourceExtension(this),
                ProjectFilePath = repo.GetSourcePath(this)
            };
            return _DataModel._ViewControllerInterface.FileName;
        }
    }
}
