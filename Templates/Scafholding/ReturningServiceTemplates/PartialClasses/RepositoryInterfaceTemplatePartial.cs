using SourceConsole.Templates.DataModel;

namespace SourceConsole.Templates.ReturningServiceTemplates
{
    partial class RepositoryInterfaceTemplate : ITemplate
    {
        GroupTemplateDataModel _DataModel;
        public GroupTemplateDataModel GetDataModel => _DataModel;
        public string FullProjectFileName => _DataModel._RepositoryInterface.FullProjectFileName;
        public PartialClasses.TemplateEnum TemplateType => PartialClasses.TemplateEnum.Normal;

        public RepositoryInterfaceTemplate(GroupTemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public SourceEnum TemplateEnum => SourceEnum.RepositoryInterface;

        public TemplateDataModel DataModel { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public string GetFileName()
        {
            var repo = new SourceFileMapRepository<RepositoryInterfaceTemplate,TemplateDataModel>();
            _DataModel._RepositoryInterface = new DataModel.FileModel()
            {
                CodeName = _DataModel.RepositoryInterfaceName,
                Extension = repo.GetSourceExtension(this),
                ProjectFilePath = repo.GetSourcePath(this)
            };
            return _DataModel._RepositoryInterface.FileName;
        }

    }
}
