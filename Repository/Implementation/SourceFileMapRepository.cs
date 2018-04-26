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
        public IProjectReaderRepository _ReaderRepo { get; set; }

        public SourceFileMapRepository()
        {
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
                case SourceEnum.ViewCodeBehind:
                    return "xaml.cs";
                default:
                    return "cs";
            }
        }

        public string GetSourcePath(T template)
        {
            if (_ReaderRepo != null)
                return _ReaderRepo.GetTemplatePath(template.TemplateResourceKey);
            else throw new NullReferenceException("Set ReaderRepo");
        }
    }
}
