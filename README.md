# Driving License Issuance Management System

A desktop-based system built using **C# (WinForms)**, **.NET Framework**, and **SQL Server**, designed to manage the complete workflow of issuing **local and international driving licenses** efficiently and securely.

---

## 🚦 Overview

The **Driving License Issuance Management System** streamlines and controls all operations related to driver licensing.  
It is structured using a **3-Tier Architecture**, enhancing maintainability, scalability, and secure data interaction.

This system ensures a controlled, traceable, and rule-based environment for managing license procedures from registration to issuance.

---

## 🧩 Core Features

### 👤 User & Driver Management
- Register and manage system users.
- Register drivers and maintain complete driver profiles.
- Store and manage license-related information.

### 📄 License Processing
- Handle **new license applications**.
- Manage **replacement for lost/damaged licenses**.
- Issue **international driving licenses**.
- Manage **license renewals**.

### 🚫 Suspensions & Reactivations
- Apply license suspension rules.
- Reactivate suspended licenses according to regulations.

### 📝 Examination Workflow
- Manage exam types:  
  ✔ Vision Test  
  ✔ Written Test  
  ✔ Practical Driving Test  
- Enforce **sequential exam rules** (cannot skip stages).
- Track exam results and eligibility.

### 🔐 Security & Logging
- Log all sensitive actions with:
  - User ID  
  - Timestamp  
  - Action details  
- Ensures traceability and accountability.

### 🏗 Architecture
- **3-Tier Architecture**  
  - Presentation Layer (WinForms UI)  
  - Business Logic Layer (BLL)  
  - Data Access Layer (DAL) with SQL Server  

---

## 🛠 Technologies Used
- C# – .NET Framework  
- WinForms  
- SQL Server  
- ADO.NET  
- 3-Tier Architecture Design  

---

## 📥 Installation & Setup

### 1️⃣ Open the Project
- Open the solution file (`.sln`) using **Visual Studio**.

### 2️⃣ Restore Dependencies
- Restore **NuGet packages** (Visual Studio will prompt you automatically if needed).

### 3️⃣ Prepare the Database
- Open **SQL Server Management Studio (SSMS)**.
- Run the included `.sql` script to create all required tables and stored procedures.

### 4️⃣ Update Configuration
- Set your connection string in: DAL/clsDataAccessSettings.cs

