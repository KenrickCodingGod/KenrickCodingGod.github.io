# WPFW Deliverable 3 – Portfolio API

Deze backend is gemaakt met ASP.NET Core Web API (.NET 10).
Ik heb gekozen voor controllers met aparte services en een EF Core-datalaag.

## Codestructuur

- Controllers: verwerken HTTP-requests en geven responses terug.
- Services: voeren CRUD-bewerkingen uit en zetten gegevens om naar DTO's.
- Models: bevatten de Project- en Blogpost-entiteiten.
- DTOs: aparte Create-, Update- en Response-objecten.
- Data: bevat PortfolioDbContext voor de databaseverbinding.
- Program.cs: registreert Swagger, services en DbContext via dependency injection.

## Endpoints

Voor Projects en Blogposts zijn vijf endpoints beschikbaar:
GET alle, GET op ID, POST, PUT op ID en DELETE op ID.

## Database

De API gebruikt Azure SQL Server met Entity Framework Core.
De connectionstring heet ConnectionStrings:PortfolioDatabase.
Deze wordt lokaal ingesteld via .NET User Secrets en staat niet met een wachtwoord in GitHub.

De database en tabellen worden bij een nieuwe, lege database aangemaakt met EnsureCreatedAsync in Program.cs.

## Applicatie starten

Open de backendmap:

cd backend

Stel eerst de SQL Server-connectionstring in via:

dotnet user-secrets set "ConnectionStrings:PortfolioDatabase" "JOUW_CONNECTIONSTRING"

Start de API:

ASPNETCORE_ENVIRONMENT=Development dotnet run --urls http://localhost:5050

Open Swagger UI:

http://localhost:5050/swagger
