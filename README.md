# Order API
[![Build Status](https://travis-ci.org/Lidiadev/OrderApi.png?branch=master)](https://travis-ci.org/Lidiadev/OrderApi)

OrderAPI is a RESTful API with the following feature:
- create orders for products like website and paid search campaings.

## Prerequirements

* Visual Studio 2017 
* .NET Core 2.1 SDK 

## Frameworks Used

* .NET Core 2.1
* Entity Framework Core 2.1
* XUnit 2.3.1

## Architecture Overview

The architecture patterns used for this application are based on DDD (Domain-Driven Design) approach.

## Solution Overview

### Order.Domain
- POCO entity classes
- DTOs
- Repository interfaces

### Order.Infrastructure
- data persistance infrastructure: repository implementations
- ORM: Entity Framework Core

### Order.Api
- ASP.NET Core Web API
- Application contracts and implementation
- MVC filters

### Order.UnitTests
- Unit tests for all layers

### Order.IntegrationsTests
- Integration tests for creating an Order scenarios

## How to create the database

* Open solution in Visual Studio 2017
* Open the **appsettings.json**  file from **Order.Infrastructure**
* Add the **connectionstring** for the SQL Server where the database will be created
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\;Database=OrderDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```
* From cmd run:
```sh
OrderApi\Order.Infrastructure> dotnet run
```

## Continuous Integration

**Travis CI** has been used to run the tests.
Each pushed commit runs the unit tests.

## How To Run Unit Tests

* Open solution in Visual Studio 2017
* Build the project
* Open **Test Explorer** 
* Run the **Order.UnitTests** tests.

## How To Run Integration Tests

* Open solution in Visual Studio 2017
* Open the *Startup.cs* file from Order.Api
* Uncomment the following code:
```csharp
 services.AddDbContext<OrderContext>(options =>
       //options.UseSqlServer("Server=.\\;Database=OrderTestDb;Trusted_Connection=True;MultipleActiveResultSets=true"));
```
(ToDo: fix the integration tests configuration to use the connection string from the appsettings.json file from the test project)
* Build the project
* Open **Test Explorer** 
* Run the **Order.IntegrationTests** tests.

## Libraries Used for Testing

* Moq - mocking framewework used to mimic the behavior of classes and interfaces
* AutoFixture - used to generate test data

## Documentation
* Swagger has been used to provide documentation for the object model.

## ToDos
- improve the logical data model
- add more validation
- abstract the products
- use AutoMapper for object-to-object mapping.
