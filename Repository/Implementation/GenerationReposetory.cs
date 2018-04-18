using System;
using SourceConsole.Factory;
using SourceConsole.Templates;
using SourceConsole.Templates.DataModel;

namespace SourceConsole
{
    public class GenerationReposetory : IGenerationReposetory
    {
        IFileService _FileService;
        IProjectReaderRepository _ProjectReader;
        IProjectFactory _ProjectFactory;
        GroupTemplateDataModel _Model;

        public GenerationReposetory(IProjectReaderRepository projectReader, IFileService fileService, IProjectFactory projectPactory)
        {
            _FileService = fileService;
            _ProjectReader = projectReader;
            _ProjectFactory = projectPactory;
        }

        public M GetBaseDataModel<M>(Func<string> templateName) where M : TemplateDataModel, new()
        {
            return new M()
            {
                Template = templateName()
            };
        }

        public GroupTemplateDataModel GetDataModel(string screenName, string projectName)
        {
            _Model = new GroupTemplateDataModel(screenName, projectName);
            return _Model;
        }

        public GroupTemplateDataModel GetDataModel(Func<string> screenName)
        {
            _Model = new GroupTemplateDataModel(screenName(), _ProjectReader.GetProjectName());
            return _Model;
        }

        public bool WriteTemplateToFile(string fullFilePath, string templateOutput)
        {
            return _FileService.WriteFileToDisk(fullFilePath, templateOutput);
        }

        public bool WriteTemplateToFile<T, M>(M model)
            where T : ITemplate<M>, new()
            where M : TemplateDataModel
        {
            var template = new T
            {
                DataModel = model
            };
            var templateOutput = template.TransformText();
            var fullName = new SourceFileMapRepository<T, M>().GetSourcePath(template) + template.GetFileName();
            var hasWritten = _FileService.WriteFileToDisk(fullName, templateOutput);
            _ProjectFactory.UpdateProjectFileWithFileReference<M>(template);

            return true;
        }
    }
}
