# WebShopApp

Welcome to the WebShopApp, a sample project demonstrating how to structure a Web API using .NET. This project showcases the architecture of a typical web application, including API, Business Logic Layer (BLL), and Data Access Layer (DAL).

## Table of Contents

- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [Technologies Used](#technologies-used)
- [Features](#features)
- [Contributing](#contributing)
- [License](#license)

## Project Structure

The solution is divided into several projects, each responsible for a different aspect of the application:

WebShopApp
├── WebShopApp.API
│ ├── Controllers
│ ├── appsettings.json
│ └── Program.cs
├── WebShopApp.BLL
│ ├── Interfaces
│ └── Services
├── WebShopApp.DAL
│ ├── Data
│ │ └── WebShopDbContext.cs
│ ├── DTOs
│ ├── Interfaces
│ │ ├── ICategoryRepository.cs
│ │ ├── ICustomerRepository.cs
│ │ ├── IOrderRepository.cs
│ │ ├── IProductRepository.cs
│ │ └── IRepository.cs
│ ├── Models
│ │ ├── Category.cs
│ │ ├── Customer.cs
│ │ ├── Order.cs
│ │ ├── Product.cs
│ │ ├── ProductCategory.cs
│ │ └── ProductOrder.cs
│ ├── Profiles
│ │ └── AutoMapperProfile.cs
│ └── Repositories
└── WebShopApp.Utilities


### WebShopApp.API

This project contains the API controllers and the configuration for the web application.

- **Controllers**
  - `ProductsController.cs`: Handles the HTTP requests for product-related operations.
- **Configuration**
  - `appsettings.json`: Configuration file for the application settings.
  - `Program.cs`: The entry point of the application.

### WebShopApp.BLL

The Business Logic Layer handles the core functionality and business rules of the application.

- **Interfaces**
  - `IProductService.cs`: Interface for the product service.
- **Services**
  - `ProductService.cs`: Implementation of the product service interface.

### WebShopApp.DAL

The Data Access Layer manages the database interactions.

- **Data**
  - `WebShopDbContext.cs`: The database context class.
- **DTOs**
  - `ProductDto.cs`: Data Transfer Object for products.
- **Interfaces**
  - Various repository interfaces for managing data operations.
- **Models**
  - Entity classes such as `Category.cs`, `Customer.cs`, `Order.cs`, `Product.cs`, `ProductCategory.cs`, and `ProductOrder.cs`.
- **Profiles**
  - `AutoMapperProfile.cs`: Configuration for mapping between models and DTOs.
- **Repositories**
  - Implementation of repository interfaces.

## Getting Started

### Prerequisites

- .NET 8
- SQL Server

## Technologies Used
- .NET Core
- Entity Framework Core
- AutoMapper

## Features
- Basic CRUD operations for products.
- Layered architecture with separation of concerns.
- DTOs for data transfer.
- Repository pattern for data access.
- AutoMapper for object-object mapping.