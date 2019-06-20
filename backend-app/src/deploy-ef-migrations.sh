#!/bin/bash

set -x

chmod a+x /app/deploy-ef-migrations.sh

EfMigrationsNamespace=$1
EfMigrationsDllName=$1.dll
EfMigrationsDllDepsJson=$1.deps.json
DllDir=$PWD
EfMigrationsDllDepsJsonPath=$PWD/bin/$BuildFlavor/netcoreapp2.0/$EfMigrationsDllDepsJson
PathToNuGetPackages=$HOME/.nuget/packages
PathToEfDll=$PathToNuGetPackages/microsoft.entityframeworkcore.tools.dotnet/1.0.0/tools/netcoreapp1.0/ef.dll

dotnet exec --depsfile ./$EfMigrationsDllDepsJson --additionalprobingpath $PathToNuGetPackages $PathToEfDll database update --assembly ./$EfMigrationsDllName --startup-assembly ./$EfMigrationsDllName --project-dir . --content-root $DllDir --data-dir $DllDir --verbose --root-namespace $EfMigrationsNamespace