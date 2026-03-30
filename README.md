# RetailInventoryAPI

A RESTful backend API built with ASP.NET Core (.NET 8) for managing retail inventory data. This project demonstrates clean architecture principles, database integration using Entity Framework Core, and automated testing with xUnit.

---

## 🚀 Features

- Full CRUD operations for products  
- PostgreSQL database integration using Entity Framework Core  
- Clean layered architecture (Controller → Service → DbContext)  
- Swagger/OpenAPI for API testing and documentation  
- Unit tests using xUnit with in-memory database  

---

## 🛠️ Tech Stack

- C#  
- ASP.NET Core (.NET 8)  
- Entity Framework Core  
- PostgreSQL (Npgsql)  
- xUnit (Testing)  
- Swagger (Swashbuckle)  

---

## 📁 Project Structure

```
RetailInventoryAPI/
│
├── Controllers/        # API endpoints
├── Services/           # Business logic
├── Data/               # DbContext and database setup
├── Models/             # Domain models
├── DTOs/               # Data transfer objects (in progress)
├── Migrations/         # EF Core migrations
│
RetailInventoryAPI.Tests/
├── Unit tests for ProductService using in-memory database
```

---

## 📌 API Endpoints

| Method | Endpoint            | Description                 |
|--------|--------------------|-----------------------------|
| GET    | /api/products      | Get all products            |
| GET    | /api/products/{id} | Get product by ID           |
| POST   | /api/products      | Create a new product        |
| PUT    | /api/products/{id} | Update an existing product  |
| DELETE | /api/products/{id} | Delete a product            |

---

## 🧪 Testing

Unit tests are implemented using xUnit and EF Core’s in-memory database provider.

To run tests:

```
dotnet test
```

---

## ⚙️ Running the Project

1. Update your connection string in `appsettings.json`:

```
"ConnectionStrings": {
  "DefaultConnect": "Host=localhost;Port=5432;Database=RetailInventoryDb;Username=postgres;Password=YOURPASSWORD"
}
```

2. Apply migrations:

```
dotnet ef database update
```

3. Run the API:

```
dotnet run --project RetailInventoryAPI
```

4. Open Swagger:

```
http://localhost:5000/swagger
```

---

## 📈 Future Improvements

- Implement DTO mapping across all endpoints  
- Add input validation (FluentValidation or Data Annotations)  
- Introduce repository pattern  
- Add authentication (JWT)  
- Improve error handling and logging  

---

## 👨‍💻 Author

Tyler Kelley  
Aspiring Backend Developer  