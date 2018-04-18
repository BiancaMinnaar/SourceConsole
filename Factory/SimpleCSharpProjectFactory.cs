using SourceConsole.Templates;
using SourceConsole.Templates.DataModel;

namespace SourceConsole.Factory
{
    public class SimpleCSharpProjectFactory : IProjectFactory
    {
        IProjectReaderRepository _ProjectReader;

        public SimpleCSharpProjectFactory(IProjectReaderRepository projectReader)
        {
            _ProjectReader = projectReader;
        }

        public void UpdateProjectFileWithFileReference<M>(ITemplate<M> template) where M : TemplateDataModel
        {
            switch ((int)template.TemplateType)
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
            }
        }
    }
}
