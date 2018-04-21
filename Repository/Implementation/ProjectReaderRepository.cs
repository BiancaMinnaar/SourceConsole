using System.Xml;
using CorePCL.Generation.Data;
using CorePCL.Generation.Repository;
using CorePCL.Generation.Service;
using Newtonsoft.Json.Linq;

namespace SourceConsole
{
    public class ProjectReaderRepository : IProjectReaderRepository
    {
		IFileService _FileService;
        ProjectModel _Model;
        XmlDocument _ProjectFile;
        string configJson;

        public ProjectReaderRepository(IFileService fileService)
        {
			_FileService = fileService;
            configJson = _FileService.ReadFromFile("../../Data/Project.Config");
            _Model = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType<ProjectModel>(configJson, _Model);
            _ProjectFile = new XmlDocument();
            _ProjectFile.Load(_Model.ProjectFileLocation);
            XmlNamespaceManager xnManager =
                new XmlNamespaceManager(_ProjectFile.NameTable);
            xnManager.AddNamespace("tu", "http://schemas.microsoft.com/developer/msbuild/2003");
        }

        public string GetProjectFileLocation()
        {
            return _Model.ProjectFileLocation;
        }

        public string GetProjectName()
        {
            return _Model.ProjectName;
        }

        public string GetTemplatePath(string templateName)
        {
            var configData = JObject.Parse(configJson);
            return configData[templateName].ToString();
        }

        public bool InsertFileReferenceInProjectFile(string classPath)
        {
            var namespaceURI = "http://schemas.microsoft.com/developer/msbuild/2003";
            XmlNamespaceManager xnManager =
                new XmlNamespaceManager(_ProjectFile.NameTable);
            xnManager.AddNamespace("tu", namespaceURI);
            XmlNode xnRoot = _ProjectFile.DocumentElement;
            var allGroups = xnRoot.SelectNodes("//tu:ItemGroup", xnManager);
            var mainGroupNode = allGroups[0];
            var embededGroupNodel = allGroups[1];
            var viewElement = _ProjectFile.CreateElement("Compile", namespaceURI);
            viewElement.SetAttribute("Include", classPath);
            mainGroupNode.AppendChild(viewElement);
            _ProjectFile.Save(_Model.ProjectFileLocation);

            return false;
        }

        public bool InsertXamlFileReferenceInProjectFile(string classPath, string codeBehindFileName)
        {
            var namespaceURI = "http://schemas.microsoft.com/developer/msbuild/2003";
            XmlNamespaceManager xnManager =
                new XmlNamespaceManager(_ProjectFile.NameTable);
            xnManager.AddNamespace("tu", namespaceURI);
            XmlNode xnRoot = _ProjectFile.DocumentElement;
            var allGroups = xnRoot.SelectNodes("//tu:ItemGroup", xnManager);
            var mainGroupNode = allGroups[0];
            var embededGroupNodel = allGroups[1];
            var viewElement = _ProjectFile.CreateElement("Compile", namespaceURI);
            viewElement.SetAttribute("Include", classPath);
            var xamlElement = _ProjectFile.CreateElement("DependentUpon", namespaceURI);
            xamlElement.InnerText = codeBehindFileName;
            viewElement.AppendChild(xamlElement);
            mainGroupNode.AppendChild(viewElement);
            _ProjectFile.Save(_Model.ProjectFileLocation);

            return false;
        }

        public bool InsertXamlEmbededResourceInProjectFile(string classPath)
        {
            var namespaceURI = "http://schemas.microsoft.com/developer/msbuild/2003";
            XmlNamespaceManager xnManager =
                new XmlNamespaceManager(_ProjectFile.NameTable);
            xnManager.AddNamespace("tu", namespaceURI);
            XmlNode xnRoot = _ProjectFile.DocumentElement;
            var allGroups = xnRoot.SelectNodes("//tu:ItemGroup", xnManager);
            var embededGroupNodel = allGroups[1];
            var embededResource = _ProjectFile.CreateElement("EmbeddedResource", namespaceURI);
            embededResource.SetAttribute("Include", classPath);
            embededGroupNodel.AppendChild(embededResource);
            _ProjectFile.Save(_Model.ProjectFileLocation);

            return false;
        }
    }
}
