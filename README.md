\# 📦 RetailInventoryAPI



\## 🚀 Overview



RetailInventoryAPI is a RESTful Web API built with C# and ASP.NET Core (.NET 8) that implements full CRUD functionality for managing product inventory.



This project was built to strengthen backend development fundamentals including routing, model binding, HTTP status handling, and clean API design principles.



---



\## 🛠 Tech Stack



\- C#

\- .NET 8

\- ASP.NET Core Web API

\- LINQ

\- In-Memory Data Store

\- Swagger (OpenAPI)



---



\## 📚 Features



\- Retrieve all products

\- Retrieve product by ID

\- Create new product

\- Update existing product

\- Delete product

\- Proper HTTP status codes (200, 201, 204, 404)

\- Clean RESTful routing conventions



---



\## 🌐 API Endpoints



| Method | Endpoint | Description |

|--------|----------|------------|

| GET | `/api/products` | Retrieve all products |

| GET | `/api/products/{id}` | Retrieve a specific product |

| POST | `/api/products` | Create a new product |

| PUT | `/api/products/{id}` | Update an existing product |

| DELETE | `/api/products/{id}` | Delete a product |



---



\## 🧠 Key Backend Concepts Practiced



\- RESTful API design

\- Controller-based routing

\- Route parameters

\- Model binding (JSON → C# objects)

\- ActionResult and HTTP status codes

\- LINQ querying (FirstOrDefault, Max, Any)

\- In-memory persistence simulation

\- Clean project structure (Controllers / Models)



---



\## ▶️ How To Run



```bash

dotnet build

dotnet run

Then navigate to:



https://localhost:{port}/swagger

to test endpoints via Swagger UI.



🎯 Future Improvements

Input validation with Data Annotations



Service layer abstraction



Database integration (SQL Server or PostgreSQL)



DTO pattern for request/response separation



Unit testing

