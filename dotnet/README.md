# Clipper dotnet

Created with dotnet cli
## Domain
````
dotnet new sln -n Clipper

dotnet new classlib -n Clipper.Domain
dotnet sln add ./Clipper.Domain/

dotnet new xunit -n Clipper.Domain.Test
dotnet sln add ./Clipper.Domain.Test/

dotnet add Clipper.Domain.Test/ reference Clipper.Domain

dotnet test
dotnet build
````
