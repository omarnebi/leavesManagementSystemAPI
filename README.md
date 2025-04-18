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
cd LeaveManagementSystem.API
dotnet ef migrations add IEmploye --project ../LeaveManagementSystem.Persistence --startup-project .
dotnet ef database update



