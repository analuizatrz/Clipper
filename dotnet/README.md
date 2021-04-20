# Clipper dotnet

to run unit tests
````sh
dotnet test
````

to build 
````sh
dotnet build
````

to run mvc application
````sh
dotnet run --project Clipper.Mvc/
````

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
## Services

````
dotnet new classlib -n Clipper.Services
dotnet sln add ./Clipper.Services/
dotnet add Clipper.Services/ reference Clipper.Domain

dotnet new xunit -n Clipper.Services.Test
dotnet sln add ./Clipper.Services.Test/
dotnet add Clipper.Services.Test/ reference Clipper.Services
dotnet add Clipper.Services.Test/ reference Clipper.Domain.Test
dotnet add Clipper.Services.Test/ package moq
````

## Web Mvc
Create apsnet mvc project, with razor pages, authentication and entity framework configured to sql server connection

````
dotnet new mvc -n Clipper.Mvc -au Individual -uld
dotnet sln add Clipper.Mvc/
````

````
dotnet ef database update --project Clipper.Mvc
````

To run the mvc application:

````
dotnet run --project Clipper.Mvc/
````