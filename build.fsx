// include Fake lib
#r @".tools\FAKE\tools\FakeLib.dll"

open Fake
open Fake.AssemblyInfoFile

RestorePackages()

let authors = ["kappy"]

// project name and description
let projectName = "DateTimeExtensions"
let projectDescription = "Merge of extensions for System.DateTime like localized working days with holidays calculations and natural time date difference"
let projectSummary = projectDescription // TODO: write a summary

// Directories
let buildDir  = @".\.build\"
let testDir   = @".\.test\"
let deployDir = @".\.deploy\"

// tools
//let nunitVersion = GetPackageVersion packagesDir "NUnit.Runners"
let nunitPath = @".tools\NUnit.Runners\"
let fxCopRoot = @".\Tools\FxCop\FxCopCmd.exe"
    
let buildMode = getBuildParamOrDefault "buildMode" "Release"

// version info
let buildNumber =
  match buildServer with
  | TeamCity -> buildVersion
  | _ -> "0"

let version = "3.9.0." + buildNumber

// Targets
Target "Clean" (fun _ -> 
    CleanDirs [buildDir; testDir; deployDir;]
)

Target "WriteAssemblyInfo" (fun _ ->
    CreateCSharpAssemblyInfo "./DateTimeExtensions/Properties/AssemblyInfo.cs"
        [Attribute.Title projectName
         Attribute.Description projectDescription
         Attribute.Product projectName
         Attribute.Version version
         Attribute.FileVersion version]
)

Target "CompileApp" (fun _ ->    
    !! @"DateTimeExtensions\**\*.csproj" 
      |> MSBuildRelease buildDir "Build" 
      |> Log "AppBuild-Output: "
)

Target "CompileTest" (fun _ ->
    !! @"DateTimeExtensions.Tests\**\*.csproj"
      |> MSBuildDebug testDir "Build"
      |> Log "TestBuild-Output: "
)

Target "NUnitTest" (fun _ ->  
    !! (testDir + @"\**\*Tests.dll") 
      |> NUnit (fun p -> 
                 {p with 
                   ToolPath = nunitPath; 
                   DisableShadowCopy = false; 
                   WorkingDir = testDir;
                   OutputFile = @"TestResults.xml"})
)

Target "FxCopReport" (fun _ ->
    sendTeamCityFXCopImport (buildDir + "\DateTimeExtensions.dll.CodeAnalysisLog.xml")
)

Target "FxCop" (fun _ ->
    !! (buildDir + @"\**\*.dll") 
      ++ (buildDir + @"\**\*.exe") 
        |> Scan  
        |> FxCop (fun p -> 
            {p with                     
                ReportFileName = testDir + "FXCopResults.xml";
                ToolPath = fxCopRoot})
)

Target "Zip" (fun _ ->
    !! (buildDir + "\**\*.*") 
        -- "*.zip" 
        |> Scan
        |> Zip buildDir (deployDir + "Calculator." + version + ".zip")
)

Target "CreatePackage" (fun _ ->
    //CopyDir deployDir buildDir allFiles

    NuGet (fun p -> 
        {p with
            Authors = authors
            Project = projectName
            Description = projectDescription                               
            OutputPath = deployDir
            Summary = projectSummary
            WorkingDir = buildDir
            Version = version
            AccessKey = getBuildParamOrDefault "nugetkey" ""
            Publish = hasBuildParam "nugetkey" }) "./DateTimeExtensions\DateTimeExtensions.nuspec"
)

Target "Default" (fun _ ->
    trace "Built!"
)

Target "Release" (fun _ ->
    trace "Release Target! You've nailed it"
)


// Dependencies
"Clean"
  ==> "WriteAssemblyInfo"
  ==> "CompileApp" 
  ==> "FxCopReport"
  ==> "CompileTest"
  //==> "FxCop"
  ==> "NUnitTest"  
  ==> "Default"
  ==> "CreatePackage"
  ==> "Release"
 
// start build
RunTargetOrDefault "Default"