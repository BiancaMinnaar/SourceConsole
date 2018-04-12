using System;
using SourceConsole.Templates.DataModel;
using SourceConsole.Templates.PartialClasses;

namespace SourceConsole.Templates.Scafholding.GeneratorTemplates
{
    partial class TemplatePartialTemplatePartial : NormalTemplates.TemplatePartialBase
    {
        public override string FullProjectFileName => throw new NotImplementedException();

        public override SourceEnum TemplateEnum => SourceEnum.Generator;

        public override TemplateEnum TemplateType => throw new NotImplementedException();

        public TemplatePartialTemplatePartial(TemplateDataModel model)
            : base(model)
        {
        }

        public override string GetFileName()
        {
            throw new NotImplementedException();
        }

        public override string TransformText()
        {
            throw new NotImplementedException();
        }
    }
}
