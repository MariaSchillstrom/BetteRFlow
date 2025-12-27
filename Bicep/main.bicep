@description('Location for all resources')
param location string = resourceGroup().location

@description('SQL Admin Username')
param sqlAdminUsername string

@secure()
@description('SQL Admin Password')
param sqlAdminPassword string

// SQL Server
resource sqlServer 'Microsoft.Sql/servers@2022-05-01-preview' = {
  name: 'betterflow-sql-${uniqueString(resourceGroup().id)}'
  location: location
  properties: {
    administratorLogin: sqlAdminUsername
    administratorLoginPassword: sqlAdminPassword
  }
}

// SQL Database
resource sqlDatabase 'Microsoft.Sql/servers/databases@2022-05-01-preview' = {
  parent: sqlServer
  name: 'BetteRFlowDB'
  location: location
  sku: {
    name: 'Basic'
    tier: 'Basic'
  }
}

// App Service Plan
resource appServicePlan 'Microsoft.Web/serverfarms@2022-03-01' = {
  name: 'betterflow-plan'
  location: location
  sku: {
    name: 'B1'
    tier: 'Basic'
  }
}

// Web App
resource webApp 'Microsoft.Web/sites@2022-03-01' = {
  name: 'betterflow-app-${uniqueString(resourceGroup().id)}'
  location: location
  properties: {
    serverFarmId: appServicePlan.id
    httpsOnly: true
  }
}