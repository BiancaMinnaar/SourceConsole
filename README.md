# SourceConsole
Bonsai

Overview
Bonsai is a set of tools that define a Software development life cycle.
By providing a base framework for software development, Bonsai manages the nitty gritty plumbing and general integration that take up at least 30% of software development time.
By supplying a standardised implementation of the Model View Controller -MVC pattern, Bonsai encourages adherence to the SOLID principles with Test Driven Development as a Focus. 

Requirements
Bonsai's main deployment vector is through the SourceConsole.
You may however decide to write a custom frontend for your templates by adding a reference to the TemplaterBonsai and then executing the appropriate repository RunSteps() functions.

1. Download [.NET Core](https://www.microsoft.com/net/download)
2. You will also need [VisualStudio 2017 Community Edition](https://www.visualstudio.com/downloads/)
3. Follow this [handy installation guid](https://docs.microsoft.com/en-us/xamarin/cross-platform/get-started/installation/windows) to configure the installation for Xamarin. Use this one for [Mac](https://docs.microsoft.com/en-us/visualstudio/mac/installation).
4. Download the [SourceConsole](https://github.com/BiancaMinnaar/SourceConsole) project.
*. Be mindfull where you place the SourceConsole, It will create a new Solution structure around itself to house your new [Xamarin forms](https://www.visualstudio.com/xamarin/) Project.
5. Setup your project name in the SourceConsole/Data/Project.Config file.
6. Run the SourceConsole.
7. The SourceConsole will create a folder and forms project in the same directory as itself. You can open the YourProjectSolution.sln after renaming it as yourown.
8. The SourceConsole will now be in the same solution as the other Xamarin Forms projects required. Open Program.cs in the SourceConsole Project and replace the BonsaiFrameworkRepository with the XamarinFormsScreenGeneratorRepository on line 12 and 13
9. Run the SourceConsole again to create your first screen. Name it Login and use the OnLogin for the event.
10. Open App.Xaml.cs in project with the sam name as you specified in step 5 and add Line 13 telling the navigation stack what the root view is with _MasterRepo.SetRootView(new NavigationPage(new Implementation.View.LoginView()));
11. You can now chose to run the supported platform projects on their respective emulators.
