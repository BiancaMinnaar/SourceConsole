using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SourceConsole.Model;
using SourceConsole.Repository.Implementation;
using Templater.Repository.Implementation;
using Templater.Service.Implementation;
using TemplaterBonsai.Templates.DataModel.Authoring;

namespace SourceConsole.Data
{
    public class UpgradeViewCommand : BonsaiCommand
    {
        public override string GetCommandString()
        {
            return $"-{this.Command} {Component.ComponentName} {LayoutName} {ComponentLayoutDataModel.SerializeObject()}";
        }
    }

    public class Builder
    {
        static BonsaiCommandRepository commsRepo = new BonsaiCommandRepository();
        private static BonsaiCommandList<T> YourBonsaiCommand<T>()
            where T:BonsaiCommand, new()
        {
            return new BonsaiCommandList<T>
            {
                Commands = new List<T>
                {
                    new T()
                    {
                        Command = "viewLayoutUpgrade",
                        Component = new BonsaiComponent { ComponentName = "System" },
                        //Component = commsRepo.GetBonsaiComponent("System",
                        //                    commsRepo.GetModelModel(new List<ModelModel>
                        //                    {
                        //                        new ModelModel
                        //                        {
                        //                            PropertyName = "UserName",
                        //                            PropertyType = "InputTextBox"
                        //                        },
                        //                        new ModelModel
                        //                        {
                        //                            PropertyName = "Password",
                        //                            PropertyType = "InputTextBox"
                        //                        }
                        //                    }),
                        //                    new List<BonsaiComponent>
                        //                    {
                        //                        commsRepo.GetBonsaiComponent("InputTextBox",
                        //            commsRepo.GetModelModel(new List<ModelModel>
                        //            {
                        //                new ModelModel
                        //                {
                        //                    PropertyName = "Text",
                        //                    PropertyType = "string"
                        //                },
                        //                new ModelModel
                        //                {
                        //                    PropertyName = "HasUnderline",
                        //                    PropertyType = "bool"
                        //                }
                        //            }), null)
                        //                    }),
                        ComponentLayoutDataModel = new CollectionModelModel
                        {
                            ModelList = new List<ModelModel>
                            {
                                new ModelModel
                                {
                                    PropertyName = "Layout",
                                    PropertyType = "ProjectBaseViewModel"
                                }
                            },
                        },
                        LayoutName = "Authorization"
                    }
                }
            };
        }

        public static BonsaiCommandList<T> GetBonsiaCommandList<T>()
            where T : BonsaiCommand, new()
        {
            var commandList = YourBonsaiCommand<T>();
            var filer = new FileService();
            var projectName = new ProjectReaderRepository(new FileService()).GetProjectName();
            filer.WriteFileToDisk($"../{projectName}/Command.json", commandList.SerializeObject());
            return commandList;
        }

        public static BonsaiCommandList<T> ReadBonsaiCommands<T>()
            where T : BonsaiCommand, new()
        {
            var filer = new FileService();
            var projectName = new ProjectReaderRepository(new FileService()).GetProjectName();
            var commandString = filer.ReadFromFile($"../{projectName}/Command.json");
            var fileCommand = JsonConvert.DeserializeObject<BonsaiCommandList<T>>(commandString);
            return fileCommand;
        }

        public static BonsaiCommandList<T> GetBonsiaCommandListFromjson<T>()
            where T : BonsaiCommand, new()
        {
            return ReadBonsaiCommands<T>();
        }
    }
}
