# Setup localPath environment variable
[Environment]::SetEnvironmentVariable("localPath", ".\student.", "User")

## Visual Studio Extensions
# SpecFlow Extension
$SpecFlowPath = "$($env:TEMP)\$([guid]::NewGuid()).vsix"
Write-Host "Downloading Specflow VSIX extension..."
# Download and output file to disk
Invoke-WebRequest "https://techtalkspecflowteam.gallerycdn.vsassets.io/extensions/techtalkspecflowteam/specflowforvisualstudio2017/2017.2.7/1534927727895/TechTalk.SpecFlow.VsIntegration.2017-2017.2.7.vsix" -OutFile $SpecFlowPath
Write-Host "Download finished succesfully. Opening..."

## SonarQube Extension
$SonarLitePath = "$($env:TEMP)\$([guid]::NewGuid()).vsix"
Write-Host "Downloading SonarQube extension..."
Invoke-WebRequest "https://sonarsource.gallerycdn.vsassets.io/extensions/sonarsource/sonarlintforvisualstudio2017/4.8.0.4040/1548077537880/SonarLint.VSIX-4.8.0.4040-2017.vsix" -OutFile $SonarLitePath

# Open vsix file to prompt user install
& $SpecFlowPath
& $SonarLitePath

# todo remove file after installation