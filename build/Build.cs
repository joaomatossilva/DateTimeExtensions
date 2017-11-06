using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Git;
using Nuke.Common.Tools.GitVersion;
using Nuke.Core;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Core.IO.FileSystemTasks;
using static Nuke.Core.IO.PathConstruction;
using static Nuke.Core.EnvironmentInfo;
using System.IO;
using Nuke.Common.Tools.DotNet;
using Nuke.Core.BuildServers;

class Build : NukeBuild
{
    // Console application entry. Also defines the default target.
    public static int Main () => Execute<Build>(x => x.Compile);

    // Auto-injection fields:
    // [GitVersion] readonly GitVersion GitVersion;
    //  - Semantic versioning. Must have 'GitVersion.CommandLine' referenced.
    // [GitRepository] readonly GitRepository GitRepository;
    //  - Parses origin, branch name and head from git config.
    // [Parameter] readonly string MyGetApiKey;
    //  - Returns command-line arguments and environment variables.

    public override AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";

    int Revision => AppVeyor.Instance?.BuildNumber ?? 1;

    Target Clean => _ => _
            .Executes(() =>
            {
                EnsureCleanDirectory(OutputDirectory);
                EnsureCleanDirectory(ArtifactsDirectory);
            });

    Target Restore => _ => _
            .DependsOn(Clean)
            .Executes(() =>
            {
                DotNetRestore(s => DefaultDotNetRestore);
            });

    Target Compile => _ => _
            .DependsOn(Clean, Restore)
            .Executes(() =>
            {
                DotNetBuild(s => s
                    .SetVersionSuffix($"rev{Revision:D4}")
                    .SetConfiguration(Configuration));
            });

    Target Pack => _ => _
        .DependsOn(Compile, Test)
        .Executes(() =>
        {
            DotNetPack(s => s
                .SetOutputDirectory(ArtifactsDirectory)
                .SetProject(RootDirectory / "src" / "DateTimeExtensions")
                .SetNoBuild(true)
                .SetVersionSuffix($"rev{Revision:D4}")
                .SetConfiguration(Configuration));
        });

    Target Test => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            DotNetTest(s => s
                .SetProjectFile(RootDirectory / "tests" / "DateTimeExtensions.Tests")
                .SetConfiguration(Configuration));
        });
}
