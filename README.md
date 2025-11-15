# 🔐 SafeVault Security Project

This project demonstrates secure coding practices using **Microsoft Copilot**.  
It enhances the security of the *SafeVault* application through improved input validation, SQL injection prevention, authentication, authorization, and vulnerability mitigation.

---

## 🚀 Key Features

### ✔ Secure Coding
- Implemented strong input validation.
- Prevented SQL Injection using EF Core and parameterized operations.

### ✔ Authentication & Authorization
- Implemented **JWT-based Authentication**.
- Role-based Authorization (Admin / User).

### ✔ Security Vulnerability Fixes
- Identified insecure patterns.
- Replaced weak hashing with **SHA-256 hashing**.
- Fixed insecure login logic.

---

## 🧰 Technologies Used
- **C# / ASP.NET Core Web API**
- **Entity Framework Core**
- **Microsoft Copilot**
- **JWT Authentication**
- **Swagger UI**

---

## 📂 Project Structure

```
SafeVaultSecurityProject/
│── Controllers/
│   ├── AuthController.cs
│   └── VaultController.cs
│── Data/
│   └── SafeVaultDbContext.cs
│── Models/
│   └── User.cs
│── Services/
│   └── AuthService.cs
│── Program.cs
│── appsettings.json
│── README.md
```

---

## ▶️ Running the Project

1. Clone the repository:
   ```bash
   git clone https://github.com/YourUserName/SafeVaultSecurityProject.git
   ```

2. Open in Visual Studio or VS Code.

3. Run the API:
   ```bash
   dotnet run
   ```

4. Open Swagger:
   ```
   https://localhost:5001/swagger
   ```

---

## 🔑 Authentication Endpoints

### Register a user
```
POST /api/auth/register
{
  "username": "admin",
  "passwordHash": "123456",
  "role": "Admin"
}
```

### Login
```
POST /api/auth/login
{
  "username": "admin",
  "passwordHash": "123456"
}
```

Returns:
```
{
  "token": "xxxxxxxxx"
}
```

---

## 🔐 Protected Endpoints

### Get secure data (Admin/User)
```
GET /api/vault/secure-data
Authorization: Bearer <token>
```

### Insert data (Admin only)
```
POST /api/vault/insert
Authorization: Bearer <token>
```

---

## 📘 Project Purpose
This repository is created as the final submission for the **Microsoft Copilot Secure Coding Project**, covering:

- Activity 1: Writing Secure Code  
- Activity 2: Implementing Authentication & Authorization  
- Activity 3: Debugging and Security Fixes  

---

## © 2025 SafeVault Security Project
