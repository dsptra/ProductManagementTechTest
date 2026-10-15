# AXA Mandiri Technical Test — Local Setup

## Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/)
- [PostgreSQL](https://www.postgresql.org/download/) running on port `5432`

---

## Steps

**1. Clone the repository**
```
git clone <repository-url>
```

**2. Configure the database connection**

Open `AXA.Mandiri.Technical.Test.API/appsettings.json` and update the connection string to match your PostgreSQL credentials:
```json
"ConnectionStrings": {
  "PostgresConnection": "Host=localhost;Port=5432;Database=axa_technical_test;Username=<your_username>;Password=<your_password>"
}
```

**3. Apply database migrations**

Open the Package Manager Console in Visual Studio (`Tools > NuGet Package Manager > Package Manager Console`), set the default project to `AXA.Mandiri.Technical.Test.Infrastructure`, and run:
```
Update-Database
```

**4. Set the startup project**

Right-click `AXA.Mandiri.Technical.Test.API` in Solution Explorer and select **Set as Startup Project**.

**5. Run the application**

Press `F5` or click the **Run** button. Swagger UI will open automatically at:
```
https://localhost:<port>/swagger
```

> To access protected endpoints, call `POST /api/Auth/login` first to obtain a JWT token, then click **Authorize** in Swagger and enter `Bearer <token>`.
