<p align="center">
  <img src="https://github.com/Yrish-1/BarangayManagementSystem/blob/main/EJC_Logo.png" alt="Every Juan Counts Logo" width="300"/>
</p>

# 🏠 Every Juan Counts
### A Barangay-Level Census Data Collection and Management System

> *"You Count. We Count. Everyone Counts."*
---

## 📋 Table of Contents

- [About the Project](#about-the-project)
- [Features](#features)
  [Tech Stack](#tech-stack)
- [OOP Design Principle](#oop-design-principle)
- [System Architecture](#system-architecture)
- [Forms and UI](#forms-and-ui)
- [Getting Started](#getting-started)
- [Database Setup](#database-setup)
- [User Roles](#user-roles)
- [Development Timeline](#development-timeline)
- [Team](#teaam) 
- [Acknowledgement](#acknowledgement)

---

## 📖 About the Project

Managing and maintaining an accurate population count in a barangay has always been a challenge for local government units. Traditional census methods rely heavily on scheduled house-to-house visits conducted by barangay officials — which are costly, time-consuming, and often result in outdated records.

**Every Juan Counts** is a community-driven barangay population update system that empowers residents to report changes in their households directly through the system. Residents can submit reports for vital events such as births, deaths, and transfers, along with supporting documents for verification. These reports are reviewed and approved by barangay officials before the population count is updated — ensuring data that is always accurate and verified.

---

## ✨ Features

| Feature | Description |
|---|---|
| 🔐 **User Registration & Login** | Residents and barangay admins can create accounts and securely log in using their credentials |
| 👤 **Resident Profile Management** | Residents can view and manage their household profile, including personal details and current status |
| 📝 **Population Update Reporting** | Residents can submit reports for births, deaths, move-ins, and move-outs within their household |
| 📊 **Report Status Tracking** | Residents can monitor their submitted reports — Pending, Approved, or Rejected |
| ✅ **Admin and Staff Review & Approval** | Barangay administrators and employees or staff can review, approve, or reject submitted reports with written remarks |
| 🔄 **Automated Population Count Update** | Once a report is approved, the system automatically updates the total population count |
| 📈 **Population Dashboard** | Real-time dashboard displaying current population count, recent updates, and vital event statistics |

---

## 🛠 Tech Stack

- **Language:** C# (.NET 6 or later)
- **UI Framework:** Windows Forms (WinForms)
- **IDE:** Visual Studio Community
- **Database:** SQL Server / SQLite
- **Version Control:** Git & GitHub

---

## 🧩 OOP Design Principles

This project strictly follows all four core Object-Oriented Programming principles:

### 🔒 Encapsulation
Each data entity in the system is bundled and protected within its own class. The `Resident` class holds personal details like name, age, and status as **private fields**, accessible only through controlled public properties and methods — preventing unauthorized or accidental changes to population data.

### 🧬 Inheritance
A general `User` base class contains shared attributes like name, email, and password. Both `Resident` and `Admin` classes **inherit** from this base class, avoiding data repetition while allowing each class to define its own unique behaviors and properties.

```
User (Base Class)
├── Resident
└── Admin

EventReport (Base Class)
├── BirthReport
├── DeathReport
├── MoveInReport
└── MoveOutReport
```

### 🔁 Polymorphism
Both `Resident` and `Admin` users can call a `Submit()` method — but the behavior differs. A resident submits a population update report, while an admin submits an approval or rejection decision. The same method name is used, but the implementation changes depending on who is performing the action.

### 🎭 Abstraction
Complex backend processes — such as document verification, population count updates, and status notifications — are hidden from the user. Residents simply fill out a form and submit; the system handles all processing behind the scenes through abstract interfaces and base classes.

---

## 🏗 System Architecture

The project follows a **3-layer architecture**:

```
┌─────────────────────────────┐
│         UI Layer            │  ← Windows Forms (.cs forms)
│   (Presentation / Views)   │
├─────────────────────────────┤
│      Business Logic Layer   │  ← Classes, OOP Logic, Validation
│   (Models / Services)      │
├─────────────────────────────┤
│      Data Access Layer      │  ← SQL queries, DB connection
│   (Repository / DAL)       │
└─────────────────────────────┘
```

### 📁 Folder Structure

```
EveryJuanCounts/
│
├── Forms/
│   ├── LoginForm.cs
│   ├── DashboardForm.cs
│   ├── ResidentInfoForm.cs
│   ├── ResidentListForm.cs
│   ├── ReportUpdateForm.cs
│   └── AdminApprovalForm.cs
│
├── Models/
│   ├── User.cs
│   ├── Resident.cs
│   ├── Admin.cs
│   ├── EventReport.cs
│   ├── BirthReport.cs
│   ├── DeathReport.cs
│   ├── MoveInReport.cs
│   └── MoveOutReport.cs
│
├── DataAccess/
│   ├── DatabaseConnection.cs
│   ├── ResidentRepository.cs
│   └── ReportRepository.cs
│
├── Services/
│   ├── AuthService.cs
│   ├── PopulationService.cs
│   └── ReportService.cs
│
├── Documentation/
│   ├── UseCaseDiagram.png
│   ├── ClassDiagram.png
│   ├── SequenceDiagram.png
│   └── ERDiagram.png
│
├── README.md
└── EveryJuanCounts.sln
```

---

## 🖥 Forms and UI

The system is composed of **six interconnected Windows Forms**:

| Form | Purpose | Key Controls |
|---|---|---|
| **Login Form** | Secure entry point for both user roles | `TextBox`, `Button`, `CheckBox`, `LinkLabel`, `PictureBox` |
| **Population Dashboard** | Main control center with real-time stats | `Panel`, `GroupBox`, `Label`, `MenuStrip`, `DateTimePicker` |
| **Resident Information Form** | Create and update resident records | `TextBox`, `DateTimePicker`, `ComboBox`, `Button` |
| **Resident List View** | Searchable table of all registered residents | `DataGridView`, `TextBox` (search), `Button` |
| **Report & Update Form** | Submit vital event reports | `RadioButton`, `TextBox`, `DateTimePicker`, `OpenFileDialog` |
| **Admin Approval Form** | Review and act on submitted reports | `DataGridView`, `RichTextBox`, `ComboBox`, `Button` |

---

## 🚀 Getting Started

### Prerequisites

- Windows 10 or later
- [Visual Studio 2022](https://visualstudio.microsoft.com/) with **.NET Desktop Development** workload installed
- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) or later
- SQL Server Express or SQLite

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/PowerpuffGurls/EveryJuanCounts.git
   cd EveryJuanCounts
   ```

2. **Open the solution in Visual Studio 2022**
   ```
   File → Open → Project/Solution → EveryJuanCounts.sln
   ```

3. **Restore NuGet packages**
   ```
   Tools → NuGet Package Manager → Restore Packages
   ```

4. **Set up the database** *(see Database Setup below)*

5. **Build and run**
   ```
   Press F5 or click the ▶ Run button
   ```

---

## 🗄 Database Setup

1. Open **SQL Server Management Studio** or use the built-in SQLite option
2. Run the schema script located at:
   ```
   DataAccess/schema.sql
   ```
3. Update the connection string in `DatabaseConnection.cs`:
   ```csharp
   private static string connectionString = 
       "Server=YOUR_SERVER;Database=EveryJuanCountsDB;Trusted_Connection=True;";
   ```

---

## 👥 User Roles

### 🏘 Resident
- Register an account and log in
- View and manage household profile
- Submit reports for births, deaths, move-ins, and move-outs
- Attach supporting documents (birth certificate, death certificate, etc.)
- Track the status of submitted reports

### 🏛 Barangay Administrator
- Log in with admin credentials
- View the real-time population dashboard
- Review all pending reports in the approval queue
- Approve, reject, or return reports for revision with remarks
- Monitor population statistics by event type and date range

---

## 📅 Development Timeline

| Week | Milestone |
|---|---|
| **Week 1** | Project planning, requirements analysis, GitHub setup, role assignment |
| **Week 2** | System design — ERD, Use Case Diagram, Class Diagram, Sequence Diagrams, UI layout plan |
| **Week 3** | Environment setup, database creation, data access layer, CRUD operations |
| **Week 4** | Login Form and authentication module with role-based access control |
| **Week 5** | Resident Information Form, List View, age auto-computation, search and filter |
| **Week 6** | Report & Update Form, dynamic fields, file attachment, input validation |
| **Week 7** | Admin Approval Form, Population Dashboard, OOP refactoring, testing, documentation, submission |

---

## ⚠️ Known Challenges

- **Digital literacy gap** — Not all barangay residents, especially senior citizens, are tech-savvy. The UI is designed to be as simple and intuitive as possible to address this.
- **Connectivity limitations** — Some barangay areas may have poor internet access. The system uses a local database to function offline where possible.
- **Document verification** — Residents are required to upload supporting documents. Admins must carefully review submissions to prevent fake or tampered documents from being approved.

---

## 👩‍💻 Team — Powerpuff Gurls

| # | Name | Role | Responsibilities |
|---|---|---|---|
| 1 | **Deduque, Julianne Antoinette** | Lead Developer | Responsible for coding and the logic behind the project |
| 2 | **Espartinez, Elaiza** | GUI Lead | Design plan and project interface |
| 3 | **Pine, Yrish** | Project Manager | Oversees project progress and supports all roles |

**Section:** CS 2201 — CS 222 Advanced Object-Oriented Programming, 2nd Semester AY 2025–2026

**Instructor:** Ms. Fatima Marie P. Agdon

---

## 📄 Acknowledgement 

This project was developed as an academic requirement for **CS 222 – Advanced Object-Oriented Programming**, Computer Science Department, 2nd Semester AY 2025–2026. All rights reserved by the Powerpuff Gurls team.

---

<div align="center">
  <strong>Every Juan Counts</strong> · Powerpuff Gurls · CS 2201 · 2026
  <br/>
  <em>"You Count. We Count. Everyone Counts."</em>
</div>
