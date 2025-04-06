# Crayon CloudSales

Crayon CloudSales is a sample api-based application designed to demonstrate cloud service ordering and purchasing flow. It is built using the **Clean Architecture** approach and incorporates technologies such as ASP.NET Core, MediatR, FluentValidation, and Entity Framework Core. The solution simulates integration with external cloud platforms like CCP (Crayon Cloud Platform) and handles user account management, software ordering, and purchase tracking.

---

## 🧭 Overview

The project consists of the following layers:

- **Application Layer**: Contains business logic, command/query handlers, validation, and service interfaces.
- **Infrastructure Layer**: Includes integrations with external services (e.g., CCP)
- **Persistence Layer**: Manages database-related concerns like migrations and entity configurations, data access via Entity Framework Core.
- **Web API Layer**: The entry point for the application, exposing endpoints for account operations and software purchasing.

---

## ✅ Features

- Retrieve and display available cloud software from external APIs.
- Validate and process software orders.
- Store purchased software data in a local database.
- Unit testing support using NUnit, FakeItEasy, and Shouldly.

---

## 🧱 Design Principles

This project is built following the **Clean Architecture** and **SOLID principles**, specifically embracing the **Dependency Inversion Principle**. The goal is to achieve a system with:

<p align="center">
  <img src="https://jkphl.is/fileadmin/images/blog/clear-architecture/clear-architecture-domain-application-client-tiers.svg" alt="Onion Architecture Diagram" />
</p>

- **High maintainability**: Business rules are isolated from external concerns.
- **Testability**: Core logic is free of infrastructure dependencies.
- **Flexibility**: External systems (like databases or APIs) can be swapped or modified with minimal changes.

The separation of concerns is achieved through:
- Interfaces and abstractions in the Application layer.
- Dependency Injection to wire up implementations at runtime.
- Inversion of Control to make high-level modules independent of low-level modules.

This design is inspired by:
- [Uncle Bob’s Clean Architecture](https://blog.cleancoder.com/uncle-bob/2011/11/22/Clean-Architecture.html)
- [Clear Architecture in PHP by jkphl](https://jkphl.is/articles/clear-architecture-php/)
- [Screaming Architecture](https://blog.cleancoder.com/uncle-bob/2011/09/30/Screaming-Architecture.html)
- [CQRS](https://martinfowler.com/bliki/CQRS.html)


---

## 🛠️ Technologies

- [.NET 8 / .NET Core](https://dotnet.microsoft.com/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [MediatR](https://github.com/jbogard/MediatR)
- [FluentValidation](https://docs.fluentvalidation.net/)
- [NUnit](https://nunit.org/)
- [FakeItEasy](https://fakeiteasy.github.io/)
- [Shouldly](https://shouldly.readthedocs.io/)

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [SQL Server or localdb] (for EF Core)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Rider](https://www.jetbrains.com/rider/)

### Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/your-org/crayon-cloudsales.git

