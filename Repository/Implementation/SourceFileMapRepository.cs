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
            switch(template.TemplateEnum)
            {
                case SourceEnum.PBContentPage:
                    return _ReaderRepo.GetBaseFolderPath();
                case SourceEnum.Repository:
                    return _ReaderRepo.GetRepositoryPath();
                case SourceEnum.RepositoryInterface:
                    return _ReaderRepo.GetRepositoryInterfacePath();
                case SourceEnum.Service:
                    return _ReaderRepo.GetServicePath();
                case SourceEnum.ServiceInterface:
                    return _ReaderRepo.GetServiceInterfacePath();
                case SourceEnum.View:
                    return _ReaderRepo.GetViewPath();
                case SourceEnum.ViewCodeBehind:
                    return _ReaderRepo.GetViewCodeBehindPath();
                case SourceEnum.ViewController:
                    return _ReaderRepo.GetViewControllerPath();
                case SourceEnum.ViewControllerInterface:
                    return _ReaderRepo.GetViewControllerInterfacePath();
                case SourceEnum.ViewModel:
                    return _ReaderRepo.GetViewModelPath();
                default:
                    throw new NotSupportedException("Your template isn't supported.");
            }
        }
    }
}
