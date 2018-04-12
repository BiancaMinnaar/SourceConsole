﻿namespace SourceConsole.Templates.Scafholding.ReturningServiceTemplates
{
    partial class ServiceTemplate : ITemplate
    {
        GroupTemplateDataModel _DataModel;

        public GroupTemplateDataModel GetDataModel => _DataModel;

        public string FullProjectFileName => _DataModel._Service.FullProjectFileName;

        public PartialClasses.TemplateEnum TemplateType => PartialClasses.TemplateEnum.Normal;

        public ServiceTemplate(GroupTemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public SourceEnum TemplateEnum => SourceEnum.Service;

        public string GetFileName()
        {
            var repo = new SourceFileMapRepository<ServiceTemplate>();
            _DataModel._Service = new DataModel.FileModel()
            {
                CodeName = _DataModel.ServiceName,
                Extension = repo.GetSourceExtension(this),
                ProjectFilePath = repo.GetSourcePath(this)
            };
            return _DataModel._Service.FileName;
        }
    }
}
