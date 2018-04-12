using System;
namespace SourceConsole.Templates.Scafholding.NormalTemplates
{
    public abstract class TemplatePartialBase : ITemplate
    {
        public PartialClasses.TemplateEnum TemplateType => PartialClasses.TemplateEnum.Normal;
        protected GroupTemplateDataModel _DataModel;
        public GroupTemplateDataModel GetDataModel => _DataModel;

        public abstract string FullProjectFileName { get; } //=> throw new NotImplementedException();

        public abstract SourceEnum TemplateEnum { get; }//=> throw new NotImplementedException();

        public TemplatePartialBase(GroupTemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public abstract string TransformText();

        public abstract string GetFileName();
    }
}
