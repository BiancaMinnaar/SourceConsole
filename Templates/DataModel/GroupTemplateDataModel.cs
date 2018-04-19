using CorePCL.Generation.DataModel;

namespace SourceConsole.Templates.DataModel
{
    public class GroupTemplateDataModel : TemplateDataModel
    {
		public string EventName { get; set; }
        public string ProjectName { get; set; }

        public FileModel _ViewModel { get; set; }
		public string ViewModelName
        {
            get => _ViewModel.CodeName;
            set => _ViewModel = new FileModel() { CodeName = value };
        }
        public FileModel _View { get; set; }
        public string ViewName
        {
            get => _View.CodeName;
            set => _View = new FileModel() { CodeName = value };
        }
        public FileModel _ViewCodeBehind { get; set; }
        public string ViewCodeBehindName
        {
            get => _View.CodeName;
            set => _View = new FileModel() { CodeName = value };
        }
        public FileModel _ViewController { get; set; }
        public string ViewControllerName
        {
            get => _ViewController.CodeName;
            set => _ViewController = new FileModel() { CodeName = value };
        }
        public FileModel _ViewControllerInterface { get; set; }
        public string ViewControllerInterfaceName
        {
            get => _ViewControllerInterface.CodeName;
            set => _ViewControllerInterface = new FileModel() { CodeName = value };
        }
        public FileModel _Repository { get; set; }
        public string RepositoryName
        {
            get => _Repository.CodeName;
            set => _Repository = new FileModel() { CodeName = value };
        }
        public FileModel _RepositoryInterface { get; set; }
        public string RepositoryInterfaceName
        {
            get => _RepositoryInterface.CodeName;
            set => _RepositoryInterface = new FileModel() { CodeName = value };
        }
        public FileModel _Service { get; set; }
        public string ServiceName
        {
            get => _Service.CodeName;
            set => _Service = new FileModel() { CodeName = value };
        }
        public FileModel _ServiceInterface { get; set; }
        public string ServiceInterfaceName
        {
            get => _ServiceInterface.CodeName;
            set => _ServiceInterface = new FileModel() { CodeName = value };
        }

        public FileModel _ProjectBaseContentPage { get; set; }
        public string ProjectBaseContentPageName
        {
            get => _ProjectBaseContentPage.CodeName;
            set => _ProjectBaseContentPage = new FileModel() { CodeName = value };
        }

        public override void SetData()
        {
            ViewModelName = Template + "ViewModel";
            ViewName = Template + "View";
            ViewControllerName = Template + "ViewController";
            ViewControllerInterfaceName = "I" + ViewControllerName;
            RepositoryName = Template + "Repository";
            RepositoryInterfaceName = "I" + RepositoryName;
            ServiceName = Template + "Service";
            ServiceInterfaceName = "I" + ServiceName;

            ProjectBaseContentPageName = "ProjectBaseContentPage";
        }
    }
}
