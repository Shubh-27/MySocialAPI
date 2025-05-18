# MySocialAppAPI

A robust social networking API built with ASP.NET Core 5.0, providing a scalable and secure backend for social media applications.

## 🚀 Features

- RESTful API architecture
- Entity Framework Core for data access
- SQL Server database integration
- Swagger/OpenAPI documentation
- CORS support
- Multi-tenant database architecture
- Business Logic Layer (BAL) implementation
- Request/Response model validation

## 🛠️ Technology Stack

- ASP.NET Core 5.0
- Entity Framework Core 5.0.17
- SQL Server
- Swashbuckle.AspNetCore 5.6.3
- Microsoft.AspNetCore.Cors 2.2.0

## 📋 Prerequisites

- .NET 5.0 SDK
- SQL Server
- Visual Studio 2019/2022 or Visual Studio Code
- Git

## 🔧 Setup and Installation

1. Clone the repository:
   ```bash
   git clone [your-repository-url]
   ```

2. Navigate to the project directory:
   ```bash
   cd MySocialAppAPI
   ```

3. Restore the NuGet packages:
   ```bash
   dotnet restore
   ```

4. Set up the database:
   - Run the SQL script in `DataBase.txt` to create the database and tables
   - The script will create a database named `MySocialDB` with the following tables:
     - `MySocial`: User accounts
     - `Friend`: Friend relationships
     - `Post`: User posts

5. Generate Entity Framework models:
   ```bash
   dotnet ef dbcontext scaffold "Server=localhost;Database=MySocialDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o TenantDB -c MySocialAppDBContext --force
   ```

6. Update the database connection string in `appsettings.json`

7. Run the application:
   ```bash
   dotnet run
   ```

8. Access the Swagger documentation at:
   ```
   https://localhost:5001/swagger
   ```

## 📁 Project Structure

- `Controllers/` - API endpoints and request handling
- `BAL/` - Business Logic Layer
- `RequestModel/` - Request DTOs and validation
- `ResponnceModel/` - Response DTOs
- `TenantDB/` - Multi-tenant database context and models
- `Properties/` - Project properties and launch settings

## 💾 Database Schema

### MySocial Table
- `Id` (int, PK) - Auto-incrementing primary key
- `Name` (nvarchar(100)) - User's full name
- `Username` (nvarchar(100)) - User's username
- `Password` (nvarchar(100)) - User's password
- `AccountCreated` (datetime) - Account creation timestamp (UTC)

### Friend Table
- `FriendID` (int, PK) - Auto-incrementing primary key
- `FromUserID` (int, FK) - Reference to sender's MySocial.Id
- `ToUserID` (int, FK) - Reference to receiver's MySocial.Id
- `Status` (bit) - Friend request status

### Post Table
- `PostID` (int, PK) - Auto-incrementing primary key
- `UserID` (int, FK) - Reference to MySocial.Id
- `PostText` (nvarchar(500)) - Content of the post
- `CreatedDateTime` (datetime) - Post creation timestamp (UTC)
- `ModifiedDateTime` (datetime) - Last modification timestamp (UTC)

## 🔐 Configuration

The application uses the following configuration files:
- `appsettings.json` - Main configuration file
- `appsettings.Development.json` - Development-specific settings

## 📝 API Documentation

API documentation is available through Swagger UI when running the application. Navigate to `/swagger` endpoint to view the complete API documentation.