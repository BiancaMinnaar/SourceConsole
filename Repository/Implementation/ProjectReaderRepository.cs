using System;
using System.Xml;
using CorePCL.Generation.Data;
using CorePCL.Generation.Repository;
using CorePCL.Generation.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SourceConsole.Repository.Implementation;

namespace SourceConsole
{
    public class ProjectReaderRepository : IProjectReaderRepository
    {
		IFileService _FileService;
        ProjectModel _Model;
        XmlDocument _ProjectFile;
        string configJson;
        string namespaceURI = "http://schemas.microsoft.com/developer/msbuild/2003";
        XmlNamespaceManager xnManager;


        public ProjectReaderRepository(IFileService fileService)
        {
			_FileService = fileService;
            configJson = _FileService.ReadFromFile("Data/Project.Config");
            _Model = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType<ProjectModel>(configJson, _Model);
        }

        private XmlNode SetDocument()
        {
            _ProjectFile = new XmlDocument();
            _ProjectFile.Load(_Model.ProjectFileLocation);

            xnManager =
                new XmlNamespaceManager(_ProjectFile.NameTable);
            xnManager.AddNamespace("pr", namespaceURI);
            return _ProjectFile.DocumentElement;
        }

        private void AddNodeToNode(ItemGroupEnum groupToNode, string elementName, Action<XmlElement> createElement)
        {
            var xnRoot = SetDocument();
            var allGroups = xnRoot.SelectNodes("//pr:ItemGroup", xnManager);
            var element = _ProjectFile.CreateElement(elementName, namespaceURI);
            createElement(element);
            allGroups[(int)groupToNode].AppendChild(element);
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
            AddNodeToNode(ItemGroupEnum.Compile, "Compile", (compile) => 
            {
                compile.SetAttribute("Include", "$(MSBuildThisFileDirectory)"+classPath);
            });
            _ProjectFile.Save(_Model.ProjectFileLocation);

            return false;
        }

        public bool InsertXamlFileReferenceInProjectFile(string classPath, string codeBehindFileName)
        {
            AddNodeToNode(ItemGroupEnum.Compile, "Compile", (compile) => 
            {
                compile.SetAttribute("Include", "$(MSBuildThisFileDirectory)"+classPath);
                var xamlElement = _ProjectFile.CreateElement("DependentUpon", namespaceURI);
                xamlElement.InnerText = codeBehindFileName;
                compile.AppendChild(xamlElement);
            });
            _ProjectFile.Save(_Model.ProjectFileLocation);

            return false;
        }

        public bool InsertXamlEmbededResourceInProjectFile(string classPath)
        {
            AddNodeToNode(ItemGroupEnum.EmbeddedResource, "EmbeddedResource", (embededResource) => 
            {
                embededResource.SetAttribute("Include", "$(MSBuildThisFileDirectory)"+classPath);
                var subType = _ProjectFile.CreateElement("SubType", namespaceURI);
                subType.InnerText = "Designer";
                var generator = _ProjectFile.CreateElement("Generator", namespaceURI);
                generator.InnerText = "Generator";
                embededResource.AppendChild(subType);
                embededResource.AppendChild(generator);
            });
            _ProjectFile.Save(_Model.ProjectFileLocation);

            return false;
        }
    }
}
