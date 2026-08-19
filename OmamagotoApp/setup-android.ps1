dotnet build -t:InstallAndroidDependencies `
  -f net10.0-android `
  -p:AndroidSdkDirectory="$env:LOCALAPPDATA\Android\Sdk" `
  -p:JavaSdkDirectory="C:\work\jdk" `
  -p:AcceptAndroidSdkLicenses=True