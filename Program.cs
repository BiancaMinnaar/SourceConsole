using System;
using CorePCL.Generation.Repository;
using CorePCL.Generation.Repository.Implementation;
using SourceConsole.Factory;
using SourceConsole.Repository.Implementation;
using SourceConsole.Templates.DataModel;

namespace SourceConsole
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var MainRepo = new XamarinFormsRepository();
            MainRepo.GenerateXamarinScreen();
        }
    }
}
