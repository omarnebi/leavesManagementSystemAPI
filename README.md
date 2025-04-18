# Leave Management System API

A backend Web API built with **ASP.NET Core 9**, using **Clean Architecture**, Entity Framework Core with SQLite, and AutoMapper.
This project simulates a leave management system where employees can request leaves, and admins can manage them.
---
## 📦 Technologies Used

- ✅ ASP.NET Core 9 Web API
- ✅ Entity Framework Core + SQLite
- ✅ Clean Architecture
- ✅ AutoMapper (for mapping DTOs)
- ✅ RESTful design
- ✅ Repository Pattern

---

## 🚀 Local Setup Instructions

### 1. Clone the repository

```bash
git clone https://github.com/omarnebi/leavesManagementSystemAPI.git
cd leavesManagementSystemAPI


## 🗂️ Project Structure
This project follows the Clean Architecture pattern with clearly separated layers:

- **API**: Handles HTTP requests and exposes the controllers.
- **Application**: Contains business logic, DTOs, interfaces, mappings, and services.
- **Domain**: Defines the core entities and enums, with no external dependencies.
- **Infrastructure**: Implements interfaces from the Application layer (e.g., repositories, services).
- **Persistence**: Manages database access, configurations, seeding, and EF Core migrations.

