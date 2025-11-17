# 🏁 Driving License Issuance Management System

![C#](https://img.shields.io/badge/Language-C%23-blue) 
![WinForms](https://img.shields.io/badge/Framework-WinForms-orange)
![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-red)

A **desktop-based system** built using **C# (WinForms), .NET Framework, and SQL Server**, designed to manage the full workflow of issuing **local and international driving licenses** efficiently and securely.

---

## 🚦 Overview

The **Driving License Issuance Management System** streamlines and controls all operations related to driver licensing.  
Structured using a **3-Tier Architecture** for enhanced maintainability, scalability, and secure data handling.  

It ensures a **controlled, traceable, and rule-based environment** for managing license procedures from registration to issuance.

---

## ✨ Key Features

> 💡 **User & Driver Management**
- Register and manage system users.  
- Maintain complete driver profiles.  
- Store and manage license-related information.

> 💡 **License Processing**
- Handle **new license applications**.  
- Manage **replacement for lost/damaged licenses**.  
- Issue **international driving licenses**.  
- Manage **license renewals**.

> 💡 **Suspensions & Reactivations**
- Apply license suspension rules.  
- Reactivate suspended licenses according to regulations.

> 💡 **Examination Workflow**
- Manage exam types:  
  ✔ Vision Test  
  ✔ Written Test  
  ✔ Practical Driving Test  
- Enforce **sequential exam rules** (cannot skip stages).  
- Track exam results and eligibility.

> 💡 **Security & Logging**
- Log all sensitive actions with:  
  - User ID  
  - Timestamp  
  - Action details  
- Ensures traceability and accountability.

---

## 🏗 Architecture

Presentation Layer (WinForms UI)
│
▼
Business Logic Layer (BLL)
│
▼
Data Access Layer (DAL) + SQL Server


**3-Tier Architecture** ensures maintainability, modularity, and secure data management.

---

## 🛠 Technologies Used

| Layer | Technology |
|-------|-----------|
| UI / Presentation | WinForms |
| Logic / Business | C# – .NET Framework |
| Data / Storage | SQL Server + ADO.NET |
| Architecture | 3-Tier |

---

## 📥 Installation & Setup

1️⃣ **Open Project**  
Open the `.sln` solution file in **Visual Studio**.

2️⃣ **Restore Dependencies**  
Restore **NuGet packages** if needed.

3️⃣ **Prepare the Database**  
Open **SQL Server Management Studio (SSMS)** and run the included `.sql` script to create tables, stored procedures, and initial data.

4️⃣ **Update Configuration**  
Set your SQL Server connection string in: DataAccessLayer\clsDataAccessSettings.cs

5️⃣ **Run Application**  
Press **F5** in Visual Studio to launch the system.

