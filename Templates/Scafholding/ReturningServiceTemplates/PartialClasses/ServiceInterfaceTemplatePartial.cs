using SourceConsole.Templates.DataModel;

namespace SourceConsole.Templates.ReturningServiceTemplates
{
    partial class ServiceInterfaceTemplate : ITemplate<GroupTemplateDataModel>
    {
        GroupTemplateDataModel _DataModel;

        public GroupTemplateDataModel GetDataModel => _DataModel;

        public string FullProjectFileName => _DataModel._ServiceInterface.FullProjectFileName;

        public PartialClasses.TemplateEnum TemplateType => PartialClasses.TemplateEnum.Normal;

        public ServiceInterfaceTemplate(GroupTemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public SourceEnum TemplateEnum => SourceEnum.ServiceInterface;

        GroupTemplateDataModel ITemplate<GroupTemplateDataModel>.DataModel { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public string GetFileName()
        {
            var repo = new SourceFileMapRepository<ServiceInterfaceTemplate,GroupTemplateDataModel>();
            _DataModel._ServiceInterface = new DataModel.FileModel()
            {
                CodeName = _DataModel.ServiceInterfaceName,
                Extension = repo.GetSourceExtension(this),
                ProjectFilePath = repo.GetSourcePath(this)
            };
            return _DataModel._ServiceInterface.FileName;
        }
    }
}
