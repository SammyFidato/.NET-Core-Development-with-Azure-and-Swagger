az login --service-principal -u "f7d4aa74-439d-4e5b-a1e3-aea0d83ac987" -p "sBIa.zKN.sXYInDbIE0xGdmWzMJNR36-QI" --tenant "0c88fa98-b222-4fd8-9414-559fa424ce64"
az  account set --subscription "faab79a5-d424-4699-b3ff-b0cf94ea9f90"
az apim api import -g aspdotnetswagger --service-name aspdotnetswagger --path itisfromapim --specification-url "https://aspdotnetswagger.azurewebsites.net/azure_swagger_dotnet/swagger/v1/swagger.json" --specification-format OpenApiJson --api-id "DotnetSwagger" --display-name "DotnetSwagger"
