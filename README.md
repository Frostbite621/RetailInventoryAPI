# 📦 RetailInventoryAPI

## 🚀 Overview

RetailInventoryAPI is a RESTful Web API built with C# and ASP.NET Core (.NET 8) that implements full CRUD functionality for managing product inventory.

This project focuses on backend development fundamentals such as layered architecture, API design, dependency separation, and testable code structure.

---

## 🛠 Tech Stack

- C#
- .NET 8
- ASP.NET Core Web API
- LINQ
- In-Memory Data Store
- Swagger (OpenAPI)
- xUnit (Unit Testing)

---

## 🏗 Architecture

This project follows a layered architecture to promote separation of concerns and maintainability:

Controller → Service → Data (Repository)

- **Controllers** handle HTTP requests and responses  
- **Services** contain business logic  
- **Data/Repository** manages data access  

---

## 📚 Features

- Retrieve all products
- Retrieve product by ID
- Create new product
- Update existing product
- Delete product
- Proper HTTP status codes (200, 201, 204, 404)
- Clean RESTful routing conventions

---

## 🌐 API Endpoints

| Method | Endpoint | Description |
|--------|----------|------------|
| GET | `/api/products` | Retrieve all products |
| GET | `/api/products/{id}` | Retrieve a specific product |
| POST | `/api/products` | Create a new product |
| PUT | `/api/products/{id}` | Update an existing product |
| DELETE | `/api/products/{id}` | Delete a product |

---

## 🧠 Key Backend Concepts Practiced

- RESTful API design
- Dependency separation (Controller → Service → Repository)
- Model binding (JSON → C# objects)
- ActionResult and HTTP status handling
- LINQ querying (FirstOrDefault, Max, Any)
- In-memory persistence simulation
- Clean project structure

---

## 🧪 Testing

Unit tests are implemented using xUnit to validate core service logic, including:

- Product creation behavior
- Retrieval by ID
- Handling of non-existent data

---

## ▶️ How To Run

```bash
dotnet build
dotnet run