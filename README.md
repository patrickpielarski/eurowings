# Eurowings Coding Challenge
## Restful API Service to query flights
---
ASP.NET Web API project using .NET 8 and Swagger UI

### Setup
- Specify your database connection string in the appsettings.json file
- Open the solution in Visual Studio 2022 and start the debugger on the Eurowings project to launch into swagger UI
- To run specs, richtclick the Eurowings.Specs project in Visual Studio an choose 'Run Tests'

### How to improve with more time / current trade-offs
- extend unit tests to test also the FlightDbContext
- seperate model classes for API and DB context
- add logging functionality
- add caching functionality
