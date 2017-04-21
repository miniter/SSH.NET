#addin nuget:https://ci.appveyor.com/nuget/cake-utility-4ufl9hamniq3/?package=Cake.Utility
#addin nuget:?package=Cake.Git

var configuration = EnvironmentVariable("CONFIGURATION") ?? Argument("configuration", "Release");

var buildHelper = GetVersionHelper();
if (!buildHelper.IsAppVeyor){
	buildHelper.Branch = Argument("branch", GitBranchCurrent(".").FriendlyName);
	buildHelper.CommitMessageShort = GitLogTip(".").MessageShort;  //https://github.com/WCOMAB/Cake_Git
}

var verInfo = buildHelper.GetNextVersion("1.0.0");
buildHelper.SetNextVersion(verInfo);
var solutionInfo = buildHelper.GetSolutionToBuild();


Task("Patch-Assembly-Info")
    .WithCriteria(() => buildHelper.IsCiBuildEnvironment)
    .Does(() =>
{
	//buildHelper.PatchAllAssemblyInfo(verInfo, "");
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
	var msBuildSettings = new MSBuildSettings {
		Verbosity = Verbosity.Minimal, //http://cakebuild.net/api/Cake.Core.Diagnostics/Verbosity/
		Configuration = configuration,
		//ToolVersion = MSBuildToolVersion.VS2015,
		//PlatformTarget = PlatformTarget.MSIL
	};
	MSBuild(solutionInfo.SolutionFileAndPath, msBuildSettings); 
});


Task("Pack")
    .IsDependentOn("Build")
    .Does(() =>
{
    var nuspecFiles = GetFiles("./**/*.nuspec");
    foreach (var nuspec in nuspecFiles){
		Information(nuspec.FullPath);
	    var csproj = nuspec.ChangeExtension(".csproj");
		Information(csproj.FullPath);
        var output = Directory("./Artifacts"); 
        CreateDirectory(output); 
		NuGetPack(csproj.FullPath,  new NuGetPackSettings { 
			Version = verInfo.FullVersion,
			OutputDirectory = output.Path.FullPath,
			IncludeReferencedProjects = true,
			Properties = new Dictionary<string, string> { {"Configuration", configuration} },
		});
	}
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Patch-Assembly-Info")
    .Does(() =>
{
    NuGetRestore(solutionInfo.SolutionFileAndPath);
});

Task("Default")
    .IsDependentOn("Pack")
    .Does(() =>
{
});

RunTarget("Default");
