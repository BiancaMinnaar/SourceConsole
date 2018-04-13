using System;
using SourceConsole.Templates;
using SourceConsole.Templates.DataModel;

namespace SourceConsole
{
    public class GenerationReposetory : IGenerationReposetory
    {
        IFileService _FileService;
        IProjectReaderRepository _ProjectReader;
        GroupTemplateDataModel _Model;

        public GenerationReposetory(IProjectReaderRepository projectReader, IFileService fileService)
        {
            _FileService = fileService;
            _ProjectReader = projectReader;
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

        public bool WriteTemplateToFile<T,M>(T template) where T : ITemplate<M> where M : TemplateDataModel
        {
            var templateOutput = template.TransformText();
            var templateEnum = template.TemplateEnum;
            var fullName = new SourceFileMapRepository<T,M>().GetSourcePath(template) + template.GetFileName();
            var hasWritten = _FileService.WriteFileToDisk(fullName, templateOutput);
            switch((int)template.TemplateType)
            {
                case 0:
					_ProjectReader.InsertFileReferenceInProjectFile(template.FullProjectFileName);
                    break;
                case 1:
                    var noExtension = template.FullProjectFileName.Substring(0, template.FullProjectFileName.LastIndexOf('.'));
					_ProjectReader.InsertXamlFileReferenceInProjectFile(
                        noExtension + ".cs", 
                        template.GetFileName());
					_ProjectReader.InsertXamlEmbededResourceInProjectFile(template.FullProjectFileName);
                    break;
                default:
                    break;
            }

            if (template.TemplateType == 0)
            {
            }
            else
            {
            }

            return true;
        }
    }
}
