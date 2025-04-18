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
- ✅ Docker
---
## 🧱 Project Architecture (Clean Architecture)

This project follows the Clean Architecture pattern with clearly separated layers:

- **API**: Handles HTTP requests and exposes the controllers.
- **Application**: Contains business logic, DTOs, interfaces, mappings, and services.
- **Domain**: Defines the core entities and enums, with no external dependencies.
- **Infrastructure**: Implements interfaces from the Application layer (e.g., repositories, services).
- **Persistence**: Manages database access, configurations, seeding, and EF Core migrations.
- **Tests**: Contains unit and integration tests in a separate project.

This structure ensures the codebase remains modular, scalable, testable, and easy to maintain.

---
## Goals

The `LeaveRequestsController` is designed to handle all operations related to leave requests in the system. Below are the primary goals and functionalities of this controller:

1. **List All Leave Requests**  
   - **Route**: `GET /api/LeaveRequests`  
   - Retrieves all leave requests in the system.

2. **Get a Specific Leave Request**  
   - **Route**: `GET /api/LeaveRequests/{id}`  
   - Fetches the details of a specific leave request by its ID.

3. **Create a New Leave Request**  
   - **Route**: `POST /api/LeaveRequests`  
   - Allows employees to submit a new leave request after validation.

4. **Update an Existing Leave Request**  
   - **Route**: `PUT /api/LeaveRequests/{id}`  
   - Updates the details of an existing leave request.

5. **Filter Leave Requests**  
   - **Route**: `GET /api/LeaveRequests/filter`  
   - Filters leave requests based on criteria such as employee, type, status, etc.

6. **Generate Leave Reports**  
   - **Route**: `GET /api/LeaveRequests/report`  
   - Generates reports for leave requests over a specific period or department.

7. **Approve a Leave Request**  
   - **Route**: `POST /api/LeaveRequests/{id}/approve`  
   - Approves a leave request.

8. **Delete a Leave Request**  
   - **Route**: `DELETE /api/LeaveRequests/{id}`  
   - Deletes a leave request by its ID.

This controller ensures that all leave-related operations are handled efficiently and provides endpoints for both employees and managers to interact with the system.

---
## 🛠️ Prerequisites

Make sure the following are installed on your system:

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- Git CLI
---

## 🚀 Local Setup Instructions
```shell
git clone https://github.com/omarnebi/leavesManagementSystemAPI.git
cd leavesManagementSystemAPI
dotnet run
http://localhost:5087
```








