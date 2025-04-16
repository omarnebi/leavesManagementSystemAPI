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
This project follows Clean Architecture. The API project handles HTTP requests and exposes the controllers. The Application project contains the business logic, DTOs, interfaces, and mappings. The Domain project defines core entities and enums with no dependencies. The Infrastructure project implements application interfaces like repositories. The Persistence project manages database access, configurations, and migrations. All tests are placed in a separate Tests project. This structure keeps the code modular, scalable, and easy to maintain.
