#!/bin/bash

$containerRegistryName="ContainerRegistry69985"
Test-AzureRmContainerRegistryNameAvailability $containerRegistryName

We can create a new Azure Container Registry using the following commands:
$resourceGroup=New-AzureRmResourceGroup -Location EastUS -Name "ContainerTest01"
$containerRegistryName="4SYSOPSContainerRegistry"

$registry = New-AzureRMContainerRegistry `
-ResourceGroupName $resourceGroup.ResourceGroupName `
-Name $containerRegistryName `
-EnableAdminUser `
-Sku Basic

$creds = Get-AzureRmContainerRegistryCredential -Registry $registry
$creds | fl *
$creds.Password | `
docker login $registry.LoginServer `
-u $creds.Username `
--password-stdin


$imagepath = $registry.LoginServer + "/testimage01"
docker tag $image $imagepath
docker push $imagepath