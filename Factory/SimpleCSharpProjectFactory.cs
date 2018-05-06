using CorePCL.Generation.DataModel;
using CorePCL.Generation.Factory;
using CorePCL.Generation.Repository;
using CorePCL.Generation.Templates;

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
            switch (template.TemplateType)
            {
                case CorePCL.Generation.Templates.PartialClasses.TemplateEnum.Normal:
                    _ProjectReader.InsertFileReferenceInProjectFile(template.FullProjectFileName);
                    break;
                case CorePCL.Generation.Templates.PartialClasses.TemplateEnum.Xaml:
                    var noExtension = template.FullProjectFileName.Substring(0, template.FullProjectFileName.LastIndexOf('.'));
                    _ProjectReader.InsertXamlFileReferenceInProjectFile(
                        noExtension + ".xaml.cs",
                        template.GetFileName());
                    _ProjectReader.InsertXamlEmbededResourceInProjectFile(template.FullProjectFileName);
                    break;
            }
        }
    }
}
