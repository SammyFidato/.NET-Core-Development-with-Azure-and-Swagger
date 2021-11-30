$ProgressPreference = 'SilentlyContinue'; Invoke-WebRequest -Uri https://aka.ms/installazurecliwindows -OutFile .\AzureCLI.msi; Start-Process msiexec.exe -Wait -ArgumentList '/I AzureCLI.msi /quiet'; rm .\AzureCLI.msi
az login -u "naman786sinha@gmail.com" -p "thinkMS123"
az apim api import -g aspdotnetswagger --service-name aspdotnetswagger --path itisfromapim --specification-url "https://aspdotnetswagger.azurewebsites.net/azure_swagger_dotnet/swagger/v1/swagger.json" --specification-format OpenApiJson --api-id "DotnetSwagger" --display-name "DotnetSwagger"
