# Orders API

This project provides a RESTful API for managing orders in an e-commerce application. It includes features such as creating, updating, deleting, and fetching orders with pagination.

## Table of Contents
- [Setup Instructions](#setup-instructions)
- [Architecture Choices](#architecture-choices)
- [Technologies Used](#technologies-used)
- [API Endpoints](#api-endpoints)

## Setup Instructions

To set up the project locally, follow the steps below:

### Prerequisites
Ensure you have the following installed on your machine:
- .NET 6.0 (or higher) SDK: [Install .NET SDK](https://dotnet.microsoft.com/download)
- SQL Server (or any relational database of your choice)
- Visual Studio or any other code editor (VS Code, JetBrains Rider)

### Step-by-step Setup:

1. **Clone the repository:**
   ```bash
   git clone https://github.com/your-repo/orders-api.git
   cd orders-api
2. Restore the dependencies:
Run the following command to restore the necessary NuGet packages:
dotnet restore

3. Set up the database:

Make sure you have SQL Server installed and running locally.

Update the connection string in appsettings.json to match your database configuration:
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=OrdersDb;Trusted_Connection=True;"
}

4.Apply database migrations:
If you are using Entity Framework Core for database access, apply the migrations to set up the database:
dotnet ef database update

5.Run the application:
Start the application by running the following command:
dotnet run
By default, the API will be available at https://localhost:5001 or http://localhost:5000.


Architecture Choices
This project follows a clean architecture approach, where responsibilities are separated into layers to enhance maintainability, scalability, and testability.

Layers:
1. API Layer (Presentation Layer):

       This layer contains the controllers that handle incoming HTTP requests. Each controller method processes the incoming request, uses MediatR to send commands/queries, and returns responses (DTOs).

2. Application Layer:

       This layer contains the business logic of the application and is responsible for orchestrating the behavior of the system through commands, queries, and handlers.

       Commands like CreateOrderCommand, UpdateOrderCommand, and DeleteOrderCommand represent requests to modify the state of the system.

       Query handlers like GetOrdersQueryHandler fetch the requested data, while the handler processes the data and returns it to the client (in the form of DTOs).

3. Domain Layer:

       This layer contains the core business domain models and the rules that govern their behavior. It includes entities like Order, OrderDetail, and repositories like IOrderRepository.

       Repositories are used to interact with the database.

4. Infrastructure Layer:

       This layer contains the data access logic (e.g., Entity Framework Core implementations of repositories) and external services.

Why Clean Architecture?

             1.Separation of Concerns: Each layer is responsible for specific tasks, reducing interdependencies and making the code more maintainable.

             2.Testability: By separating business logic into the Application Layer, you can easily mock dependencies and write unit tests for your handlers and services.

              3.Flexibility: This architecture allows you to replace or update specific components (e.g., swapping the database or changing how commands are processed) without affecting the entire application.

             4.Dependency Injection (DI)
               The application uses Dependency Injection (provided by ASP.NET Core) to inject dependencies such as services and repositories into the controllers and handlers.

MediatR
MediatR is used to handle commands and queries in a decoupled way. Commands like CreateOrderCommand, UpdateOrderCommand, and DeleteOrderCommand are sent through MediatR to their respective handlers, making the code more modular and easier to maintain.

DTOs (Data Transfer Objects)
DTOs are used to transfer data between layers. The API layer returns DTOs instead of domain entities to avoid exposing unnecessary or sensitive information and to provide a cleaner response to the client.

Repository Pattern
The Repository Pattern is used to abstract data access logic from the rest of the application. The IOrderRepository and its implementation provide methods for interacting with the database without exposing database-specific logic to the rest of the application.

Technologies Used
.NET 6.0: The backend framework for building the RESTful API.

Entity Framework Core: ORM used for database access.

MediatR: A library used to implement the Mediator pattern, which helps decouple the logic between controllers and handlers.

Swagger: Used for API documentation and testing.

JWT Authentication: Secures the API endpoints using JSON Web Tokens (JWT).

SQL Server: Relational database used for persistence.

AutoMapper: Used for mapping between entities and DTOs.

API Endpoints
Create an Order
POST /api/orders

Creates a new order.

Request Body: A CreateOrderDto object with order details.

Response: A 201 Created status with the created order's ID.

Update an Order
PUT /api/orders/{id}

Updates an existing order.

Request Body: A UpdateOrderCommand object with updated order details.

Response: A 200 OK status with the updated order's ID.

Delete an Order
DELETE /api/orders/{id}

Deletes an order by ID.

Response: A 204 No Content status if the order is successfully deleted.

Get Orders
GET /api/orders

Retrieves a list of orders with optional pagination.

Query Parameters: page, pageSize for pagination.

Response: A list of OrderDto objects.
