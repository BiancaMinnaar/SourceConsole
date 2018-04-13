using SourceConsole.Templates.DataModel;
using SourceConsole.Templates.PartialClasses;

namespace SourceConsole.Templates.Framework
{
    partial class ProjectBaseContentPageTemplate : ITemplate<GroupTemplateDataModel>
    {
        GroupTemplateDataModel _DataModel;
		public GroupTemplateDataModel GetDataModel => _DataModel;
        public TemplateEnum TemplateType => PartialClasses.TemplateEnum.Normal;
        public SourceEnum TemplateEnum => SourceEnum.PBContentPage;
        public string FullProjectFileName => _DataModel._RepositoryInterface.FullProjectFileName;

        GroupTemplateDataModel ITemplate<GroupTemplateDataModel>.DataModel { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public ProjectBaseContentPageTemplate(GroupTemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public string GetFileName()
        {
            var repo = new SourceFileMapRepository<ProjectBaseContentPageTemplate,GroupTemplateDataModel>();
            _DataModel._ProjectBaseContentPage = new DataModel.FileModel()
            {
                CodeName = _DataModel.ProjectBaseContentPageName,
                Extension = repo.GetSourceExtension(this),
                ProjectFilePath = repo.GetSourcePath(this)
            };
            return _DataModel._ProjectBaseContentPage.FileName;
        }
    }
}
