// include Fake lib
#r @".tools\FAKE\tools\FakeLib.dll"

open Fake

RestorePackages()

// Directories
let buildDir  = @".\.build\"
let testDir   = @".\.test\"
let deployDir = @".\.deploy\"
let packagesDir = @".\packages"

// tools
//let nunitVersion = GetPackageVersion packagesDir "NUnit.Runners"
let nunitPath = @".tools\NUnit.Runners\"
let fxCopRoot = @".\Tools\FxCop\FxCopCmd.exe"
    
// version info
let version = "0.2"  // or retrieve from CI server

// Targets
Target "Clean" (fun _ -> 
    CleanDirs [buildDir; testDir; deployDir]
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
                   OutputFile = testDir + @"TestResults.xml"})
)

Target "FxCop" (fun _ ->
    !+ (buildDir + @"\**\*.dll") 
      ++ (buildDir + @"\**\*.exe") 
        |> Scan  
        |> FxCop (fun p -> 
            {p with                     
                ReportFileName = testDir + "FXCopResults.xml";
                ToolPath = fxCopRoot})
)

Target "Zip" (fun _ ->
    !+ (buildDir + "\**\*.*") 
        -- "*.zip" 
        |> Scan
        |> Zip buildDir (deployDir + "Calculator." + version + ".zip")
)

Target "Default" (fun _ ->
    trace "Built!"
)

// Dependencies
"Clean"
  ==> "CompileApp" 
  ==> "CompileTest"
  //==> "FxCop"
  ==> "NUnitTest"  
  //==> "Zip"
  ==> "Default"
 
// start build
RunTargetOrDefault "Default"