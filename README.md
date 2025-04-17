# LeaveManagementSystem.API

## 🧱 Project Architecture (Clean Architecture)

This project follows the Clean Architecture pattern with clearly separated layers:

- **API**: Handles HTTP requests and exposes the controllers.
- **Application**: Contains business logic, DTOs, interfaces, mappings, and services.
- **Domain**: Defines the core entities and enums, with no external dependencies.
- **Infrastructure**: Implements interfaces from the Application layer (e.g., repositories, services).
- **Persistence**: Manages database access, configurations, seeding, and EF Core migrations.
- **Tests**: Contains unit and integration tests in a separate project.

This structure ensures the codebase remains modular, scalable, testable, and easy to maintain.

## 📁 Project Structure

```
LeaveManagementSystem/
├── src/
│   ├── LeaveManagementSystem.API/              → Presentation Layer
│   ├── LeaveManagementSystem.Application/      → Business Logic, DTOs, Interfaces
│   ├── LeaveManagementSystem.Domain/           → Core Domain Entities
│   ├── LeaveManagementSystem.Infrastructure/   → Repositories, Services
│   └── LeaveManagementSystem.Persistence/      → EF Core, Migrations, DbContext

├── tests/
│   └── LeaveManagementSystem.Tests/            → Unit & Integration Tests

├── docker-compose.yml
├── .gitignore
├── README.md
```

## 🚀 Local Setup with Docker

### 1. Build the image

```bash
docker-compose build
```

### 2. Run the container

```bash
docker-compose up
```

### 3. Access the API

```
http://localhost:8080
```

## 🧪 CLI Tips

- Full rebuild:
  ```bash
  docker-compose build --no-cache
  docker-compose up --force-recreate
  ```

- Stop containers:
  ```bash
  docker-compose down
  ```
