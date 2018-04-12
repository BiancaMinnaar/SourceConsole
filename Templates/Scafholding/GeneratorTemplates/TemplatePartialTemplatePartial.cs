using System;
using SourceConsole.Templates.PartialClasses;

namespace SourceConsole.Templates.Scafholding.GeneratorTemplates
{
    partial class TemplatePartialTemplatePartial : NormalTemplates.TemplatePartialBase
    {
        public override string FullProjectFileName => throw new NotImplementedException();

        public override SourceEnum TemplateEnum => SourceEnum.Generator;

        public TemplatePartialTemplatePartial(GroupTemplateDataModel model)
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
