using System.Collections.Generic;
using System.Linq;
using CorePCL.Generation.DataModel;
using CorePCL.Generation.Repository;
using CorePCL.Generation.Templates;

namespace SourceConsole.Factory
{
    public class MapRepoCollection<T, M> : List<T>
        where M : TemplateDataModel, new()
    {
        public List<C> ToList<C>()
            where C : ITemplate<M>, new()
        {
            return this.ToList<C>();
        }
    }

    public class TemplateInstanceFactory<M> : MobileBonsai.Generation.Factory.ITemplateInstanceFactoy<M>
        where M : TemplateDataModel, new()
        
    {
        M _model;
        IProjectReaderRepository _projectReaderRepository;
        MapRepoCollection<ITemplate<M>, M> templateList;

        public TemplateInstanceFactory(M model, IProjectReaderRepository readerRepository)
        {
            _model = model;
            _projectReaderRepository = readerRepository;
            templateList = new MapRepoCollection<ITemplate<M>, M>();
        }

        public void Add<T>()
            where T:ITemplate<M>, new()
        {
            templateList.Add(new T() {DataModel=_model});
        }

        public void Add<T>(M model)
            where T : ITemplate<M>, new()
        {
            templateList.Add(new T() { DataModel = model });
        }

        public List<ITemplate<M>> ToList()
        {
            return templateList.ToList();
        }
    }
}
