$chocoUrl = "https://chocolatey.org/install.ps1"
iex((New-Object System.Net.Webclient).DownloadString("chocoUrl"))

choco install git -y