using System;
using System.IO;
using System.Text;

namespace SourceConsole.Repository.Implementation
{
    public class LoaderReposetory
    {
        public LoaderReposetory()
        {
        }

        public static void TestForDataFiles(string projectName)
        {
            if (!File.Exists($"../{projectName}/ProjectSeed.Config"))
            {
                if (!Directory.Exists($"../{projectName}"))
                    Directory.CreateDirectory($"../{projectName}");
                var projectSeed = $"../{projectName}/ProjectSeed.config";
                var stringToWrite = $"{{\n\r\t\"ProjectName\": \"{projectName}\"\n\r}}";
                File.Move("Data/ProjectSeed.Config", projectSeed);
                File.WriteAllText(projectSeed, stringToWrite);
            }
            if (!File.Exists($"../{projectName}/Inputs.json"))
            {
                File.Move("Data/Inputs.json", $"../{projectName}/Inputs.json");
            }
            if (!File.Exists($"../{projectName}/Command.json"))
            {
                File.Move("Data/Command.json", $"../{projectName}/Command.json");
            }
        }
    }
}
