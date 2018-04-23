using CorePCL.Generation.Templates;
using CorePCL.Generation.Templates.Extensions;
using CorePCL.Generation.Templates.PartialClasses;
using CorePCL.Generation.DataModel;
using SourceConsole.Repository.Implementation;
using SourceConsole.Templates.DataModel;
using System;

namespace SourceConsole.Templates.Framework
{
    public partial class AppCodeBehindTemplate : ITemplate<TemplateDataModel>
    {
        public string FullProjectFileName => this.GetFullProjectFileName<AppCodeBehindTemplate, TemplateDataModel>();

        public SourceEnum TemplateEnum => SourceEnum.Generator;

        public TemplateEnum TemplateType => CorePCL.Generation.Templates.PartialClasses.TemplateEnum.CodeBehind;

        public TemplateDataModel DataModel { get; set; }

        public string TemplateResourceKey => "RootPath";

        public string GetFileName()
        {
            return this.GetFileName(
                new SourceFileMapRepository<AppCodeBehindTemplate, TemplateDataModel>(
                    new ProjectReaderRepository(new FileService())), DataModel.Template);
        }
    }
}
