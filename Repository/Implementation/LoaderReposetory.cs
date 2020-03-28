using System;
using System.IO;

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
                File.Move("Data/ProjectSeed.Config", $"../{projectName}/ProjectSeed.config");
            }
            if (!File.Exists($"../{projectName}/Inputs.json"))
            {
                File.Move("Data/Inputs.json", $"../{projectName}/Inputs.json");
            }
        }
    }
}
