# Freight Assignment 
A web app made for Cymax Assignment for the purposes of requesting several companies' API for offers and to select the best deal.

## Prerequisites
Install NET Core SDK https://dotnet.microsoft.com/download

Access Locally `https://localhost:5001`

## Testing
### Swagger
View & Test available APIs once project is running `https://localhost:5001/swagger/index.html`

### NUnit
Unit Tests the back end are done with NUnit in 
- [API Integration Tests](https://github.com/BryanMartinez95/FreightAssignment/tree/main/ApiIntegrations/tests)
- [FreightAssignment Tests](https://github.com/BryanMartinez95/FreightAssignment/tree/main/tests/FreightAssignmentTests)

Unit Tests can be done via Visual Studio or with CLI `dotnet test`.


## Core Project Structure
```

├── APIIntegrations                   # Everything related to external API communications live here
│   ├── tests  
│   ├── Base                          # Factories used to implement the API Integrations
│   ├── Shared                        # Shared Interfaces, helpers, classes for API Integrations
├── FreightAssignment                 # Main Backend API for the project
├── test/FreightAssignmentTests       # Unit/Integration tests for FreightAssignmentProject
├── Models                            # Models that are shared throughout the project
```
 
## Built With
- [ASP.NET Core 5.0](https://dotnet.microsoft.com/download/dotnet/5.0) Back End API
- [Swagger](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) API Documentation/Testing

## Additional Libraries/Resources
- [NUnit](https://nunit.org/)

## Roadmap
See the [open issues](https://github.com/BryanMartinez95/FreightAssignment/issues) for a list of proposed features (and known issues).

## Authors
- Bryan Martinez

## License
This project is licensed under the MIT License - see the [LICENSE.MD](https://github.com/BryanMartinez95/FreightAssignment/blob/main/LICENSE) file for details
