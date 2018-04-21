using System;
using CorePCL.Generation.DataModel;
using CorePCL.Generation.Repository;
using CorePCL.Generation.Templates;

namespace SourceConsole.Repository.Implementation
{   
    public class SourceFileMapRepository<T, M> : ISourceFileMapRepository<T, M>
        where T : ITemplate<M>
        where M : TemplateDataModel
    {
        IProjectReaderRepository _ReaderRepo;// = new ProjectReaderRepository(new FileService());

        public SourceFileMapRepository(IProjectReaderRepository readerRepo)
        {
            _ReaderRepo = readerRepo;
        }

        public SourceEnum GetSourceEnumFromTempate(T template)
        {
            return template.TemplateEnum;
        }

        public string GetSourceExtension(T template)
        {
            switch(template.TemplateEnum)
            {
                case SourceEnum.View:
                               return "xaml";
                default:
                    return "cs";
            }
        }

        public string GetSourcePath(T template)
        {
            return _ReaderRepo.GetTemplatePath(template.TemplateResourceKey);
        }
    }
}
