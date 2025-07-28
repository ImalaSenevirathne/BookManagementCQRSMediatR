# Book Management API with CQRS and MediatR (.NET 8)

## Overview

This is a sample ASP.NET Core 8 Web API demonstrating the implementation of the **CQRS (Command Query Responsibility Segregation)** pattern using **MediatR** as the mediator library. The project manages a simple book catalog with operations split between commands (writes) and queries (reads), showcasing a clean and maintainable architecture.

The data is stored using Entity Framework Core's in-memory database provider for simplicity. This example can be extended to use persistent storage.

---

## Features

- Add a new book (Create)
- Retrieve a book by ID (Read)
- Retrieve all books (Read)
- Update a book's title (Update)
- Delete a book by ID (Delete)

Each action is handled via dedicated commands or queries processed by MediatR handlers, demonstrating the full CQRS approach.

---

## Technologies Used

- [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- ASP.NET Core 8 Minimal APIs
- [MediatR](https://github.com/jbogard/MediatR) (Mediator pattern implementation)
- Entity Framework Core InMemory provider (for demo purposes)
- C# 11

---

## Project Structure

- `Models/` - Domain entities (e.g., `Book`)
- `Data/` - EF Core `DbContext`
- `Features/Books/Commands` - Write operations (Add, Update, Delete)
- `Features/Books/Queries` - Read operations (Get by ID, Get all)
- `Features/Books/Handlers` - Request handlers for commands and queries
- `Program.cs` - Application entry point and API endpoint mappings

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) installed
- A tool like [Postman](https://www.postman.com/) or `curl` to test HTTP endpoints

### Running the Application

1. Clone the repository:

https://github.com/ImalaSenevirathne/BookManagementCQRSMediatR.git
