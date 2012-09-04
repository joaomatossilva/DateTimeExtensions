properties { 
  $base_dir = resolve-path .
  $build_dir = "$base_dir\build"
  $packageinfo_dir = "$base_dir\packaging"
  $40_build_dir = "$build_dir\4.0\"
  $35_build_dir = "$build_dir\3.5\"
  $lib_dir = "$base_dir\SharedLibs"
  $release_dir = "$base_dir\Release"
  $sln_file = "$base_dir\DateTimeExtensions.sln"
  $tools_dir = "$base_dir\.tools"
  $config = "Release"
  $run_tests = $true

  $testMessage = 'Executed Test!'
  $compileMessage = 'Executed Compile!'
  $cleanMessage = 'Executed Clean!'
}
Include .\teamcity.psm1
TaskSetup {
    TeamCity-ReportBuildProgress "Running task $($psake.context.Peek().currentTaskName)"
}

$framework = '4.0'

task default -depends Test

task Test -depends Compile, Clean { 
  $old = pwd
  cd $build_dir
  & $tools_dir\NUnit.Runners\nunit-console.exe "$build_dir\3.5\DateTimeExtensions.Tests.dll" /noshadow
  & $tools_dir\NUnit.Runners\nunit-console.exe "$build_dir\4.0\DateTimeExtensions.Tests.dll" /noshadow
  cd $old
}

task Compile -depends Clean { 
	new-item $release_dir -itemType directory
	new-item $build_dir -itemType directory 
	
  msbuild $sln_file /p:"OutDir=$35_build_dir;Configuration=$config;TargetFrameworkVersion=V3.5"
  msbuild $sln_file /target:Rebuild /p:"OutDir=$40_build_dir;Configuration=$config;TargetFrameworkVersion=V4.0"
}

task Clean { 
  remove-item -force -recurse $build_dir -ErrorAction SilentlyContinue
  remove-item -force -recurse $release_dir -ErrorAction SilentlyContinue
}

task ? -Description "Helper to display task info" {
	Write-Documentation
}