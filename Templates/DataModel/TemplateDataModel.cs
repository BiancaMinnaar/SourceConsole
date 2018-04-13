namespace SourceConsole.Templates.DataModel
{
    public class TemplateDataModel : CorePCL.BaseViewModel
    {
        public FileModel _Template { get; set; }
        public string Template
        {
            get => _Template.CodeName;
            set => _Template = new FileModel() { CodeName = value };
        }

        public TemplateDataModel()
        {}
    }
}
