curl -sL https://aka.ms/InstallAzureCLIDeb | sudo bash
az login -u "naman786sinha@gmail.com" -p "thinkMS123"
az apim api import -g aspdotnetswagger --service-name aspdotnetswagger --path itisfromapim --specification-url "https://aspdotnetswagger.azurewebsites.net/azure_swagger_dotnet/swagger/v1/swagger.json" --specification-format OpenApiJson --api-id "DotnetSwagger" --display-name "DotnetSwagger"
