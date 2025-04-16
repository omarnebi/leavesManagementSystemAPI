# Leave Management System API

A backend Web API built with **ASP.NET Core 9**, using **Clean Architecture**, Entity Framework Core with SQLite, and AutoMapper.
This project simulates a leave management system where employees can request leaves, and admins can manage them.
---
## 📦 Technologies Used

- ✅ ASP.NET Core 9 Web API
- ✅ Entity Framework Core + SQLite
- ✅ Clean Architecture
- ✅ AutoMapper (for mapping DTOs)
- ✅ Swagger (for API documentation)
- ✅ RESTful design
- ✅ Repository Pattern

---

## 🗂️ Project Structure
LeaveManagementSystem/
├── src/
│   ├── API/                            → Presentation layer (Controllers, Program.cs, Swagger)
│   ├── Application/                   → DTOs, Interfaces, Services, Mappings, Use Cases
│   ├── Domain/                        → Business entities, enums (no dependencies)
│   ├── Infrastructure/               → Implementation of interfaces (Repositories, External services)
│   └── Persistence/                  → EF Core DbContext, Configurations, Seeding, Migrations

├── tests/
│   └── LeaveManagementSystem.Tests/   → Unit tests and integration tests

├── .gitignore                         → Ignore build artifacts, user settings, etc.
├── README.md                          → Project documentation and usage guide
├── LeaveManagementSystem.sln         → Visual Studio solution file
