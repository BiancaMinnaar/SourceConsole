using System;
using System.Collections.Generic;
using BaseBonsai.DataContracts;
using BaseBonsai.Generation.DataModel;
using BaseBonsai.Generation.Repository;
using GenerationBaseBonsai.Repository;
using TemplaterBonsai.Repository.Implementation.V2;
using TemplaterBonsai.Templates.DataModel;

namespace SourceConsole.Factory
{
    public class SnipetGenerationFactory
    {
        private Dictionary<Type, Func<IProjectReaderRepository, ISnippedDataModel, ISnippedGenerationRepository<ISnippedDataModel>>> supportedInterfaces;
        private static SnipetGenerationFactory _SnipetfactoryInstance;
        public static SnipetGenerationFactory SnipetGenerationFactoryInstance
        {
            get
            {
                if (_SnipetfactoryInstance == null)
                    _SnipetfactoryInstance = new SnipetGenerationFactory();
                return _SnipetfactoryInstance;
            }
        }
        private SnipetGenerationFactory()
        {
            supportedInterfaces = SetViewFactoryMap();
        }

        public Dictionary<Type, Func<IProjectReaderRepository, ISnippedDataModel, ISnippedGenerationRepository<ISnippedDataModel>>> SetViewFactoryMap()
        {
            return new Dictionary<Type, Func<IProjectReaderRepository, ISnippedDataModel, ISnippedGenerationRepository<ISnippedDataModel>>>
            {
                {typeof(TemplaterPartialDataModel), (reader, model) => new BonsaiTemplatePartialTextRepository(reader, model)},
                //BonsaiTileViewMap
            };
        }

        public ISnippedGenerationRepository<ISnippedDataModel> GetGenerationRepo(IProjectReaderRepository reader, ISnippedDataModel model)
        {
            return supportedInterfaces[model.GetType()]?.Invoke(reader, model);
        }
    }
}
