if(Test-Path .\artifacts) { Remove-Item .\artifacts -Force -Recurse }

$revision = @{ $true = $env:APPVEYOR_BUILD_NUMBER; $false = 1 }[$env:APPVEYOR_BUILD_NUMBER -ne $NULL];
$revision = "rev{0:D4}" -f [convert]::ToInt32($revision, 10)

# Remove revision suffix if the build was triggered by a tag
$revision = @{ $true = $NULL; $false = $revision }[$env:APPVEYOR_REPO_TAG -e $true]


# Restore packages and build product
Write-Host "Restoring..." -ForegroundColor "Green"
& dotnet restore -v Minimal # Restore all packages
if ($LASTEXITCODE -ne 0)
{
    throw "dotnet restore failed with exit code $LASTEXITCODE"
}

# Build all
Write-Host "Building..." -ForegroundColor "Green"
Get-ChildItem "DateTimeExtensions*.csproj" -Recurse |
ForEach-Object {
    if ($revision) {
        & dotnet build "$_" --version-suffix "$revision"
    } else {
        & dotnet build "$_"
    }
}

# Run tests
Write-Host "Running Tests..." -ForegroundColor "Green"
Get-ChildItem "DateTimeExtensions.Test*.csproj" -Recurse |
ForEach-Object {
    & dotnet test "$_"
}

# Package all
Write-Host "Packaging..." -ForegroundColor "Green"
Get-ChildItem "DateTimeExtensions*.csproj" -Recurse | Where-Object { $_.Name -NotLike "*.Tests*" } |
ForEach-Object {
    if ($revision) {
        & dotnet pack "$_" -c Release -o .\artifacts --version-suffix "$revision"   
    } else {
        & dotnet pack "$_" -c Release -o .\artifacts
    }
}