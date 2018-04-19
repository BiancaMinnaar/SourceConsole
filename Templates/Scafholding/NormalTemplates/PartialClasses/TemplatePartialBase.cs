//using CorePCL.Generation.Templates;
//using CorePCL.Generation.Templates.Extensions;
//using CorePCL.Generation.Templates.PartialClasses;
//using SourceConsole.Repository.Implementation;
//using SourceConsole.Templates.DataModel;

//namespace SourceConsole.Templates.Scafholding.NormalTemplates
//{
//    public abstract class TemplatePartialBase : ITemplate<GroupTemplateDataModel>
//    {
//        public string FullProjectFileName => this.GetFullProjectFileName<TemplatePartialBase, GroupTemplateDataModel>();

//        public SourceEnum TemplateEnum => SourceEnum.Service;

//        public TemplateEnum TemplateType => CorePCL.Generation.Templates.PartialClasses.TemplateEnum.Normal;

//        public GroupTemplateDataModel DataModel { get; set; }

//        public string GetFileName()
//        {
//            return this.GetFileName(
//                new SourceFileMapRepository<ServiceTemplate, GroupTemplateDataModel>(
//                    new ProjectReaderRepository(new FileService())));
//        }

//        public abstract PartialClasses.TemplateEnum TemplateType { get; }
//        public abstract TemplateDataModel DataModel { get; set; }

//        public abstract string FullProjectFileName { get; }

//        public abstract SourceEnum TemplateEnum { get; }

//        public TemplatePartialBase(TemplateDataModel dataModel)
//        {
//            DataModel = dataModel;
//        }

//        public abstract string TransformText();

//        public abstract string GetFileName();
//    }
//}
