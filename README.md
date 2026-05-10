<p align="center">
  <img src="https://github.com/Yrish-1/BarangayManagementSystem/blob/main/EJC_Logo.png" alt="Every Juan Counts Logo" width="300"/>
</p>

<h1 align="center" >  🏠 Every Juan Counts </h1>
<p align="center" >A Barangay-Level Census Data Collection and Management System</p>
<p align="center"> "You Count. We Count. Everyone Counts."</p>

---
## 📋 Table of Contents

- About the Project
- Features
  Tech Stack
- OOP Design Principle
- System Architecture
- Forms and UI
- Getting Started
- Database Setup
- User Roles
- Development Timeline
- Team
- Acknowledgement

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
├── Barangay Staff
└── Admin

EventReport (Base Class)
├── BirthReport
├── DeathReport
├── MoveInReport
└── MoveOutReport
```

### 🔁 Polymorphism
Both `Resident`, `Barangay Staff` and `Admin` users can call a `Submit()` method — but the behavior differs. A resident submits a population update report, while an admin submits an approval or rejection decision. The same method name is used, but the implementation changes depending on who is performing the action.

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
EveryJuanCount/
│
├── bin/
├── obj/
├── Properties/
├── Resources/
│
├── Forms/
│   │
│   ├── [Admin - F5]
│   │   ├── AdminForm5.cs
│   │   ├── AdminForm5.Designer.cs
│   │   ├── AdminForm5.resx
│   │   ├── AnnouncementsAdF5.cs
│   │   ├── AnnouncementsAdF5.Designer.cs
│   │   ├── AnnouncementsAdF5.resx
│   │   ├── DashboardAdF5.cs
│   │   ├── DashboardAdF5.Designer.cs
│   │   ├── DashboardAdF5.resx
│   │   ├── ManageStaffAdF5.cs
│   │   ├── ManageStaffAdF5.Designer.cs
│   │   ├── ManageStaffAdF5.resx
│   │   ├── PopulationReportAdF5.cs
│   │   ├── PopulationReportAdF5.Designer.cs
│   │   ├── PopulationReportAdF5.resx
│   │   ├── ReportApprovalAdF5.cs
│   │   ├── ReportApprovalAdF5.Designer.cs
│   │   ├── ReportApprovalAdF5.resx
│   │   ├── ResidentsAdF5.cs
│   │   ├── ResidentsAdF5.Designer.cs
│   │   ├── ResidentsAdF5.resx
│   │   ├── SettingsAdF5.cs
│   │   ├── SettingsAdF5.Designer.cs
│   │   └── SettingsAdF5.resx
│   │
│   ├── [Barangay Staff - F4]
│   │   ├── AnnouncementsBrgyStffF4.cs
│   │   ├── AnnouncementsBrgyStffF4.Designer.cs
│   │   ├── AnnouncementsBrgyStffF4.resx
│   │   ├── BarangayStaffForm4.cs
│   │   ├── BarangayStaffForm4.Designer.cs
│   │   ├── BarangayStaffForm4.resx
│   │   ├── DashboardBrgyStffF4.cs
│   │   ├── DashboardBrgyStffF4.Designer.cs
│   │   ├── DashboardBrgyStffF4.resx
│   │   ├── EncodeResidentBrgyStffF4.cs
│   │   ├── EncodeResidentBrgyStffF4.Designer.cs
│   │   ├── EncodeResidentBrgyStffF4.resx
│   │   ├── ReportsQueueBrgyStffF4.cs
│   │   ├── ReportsQueueBrgyStffF4.Designer.cs
│   │   ├── ReportsQueueBrgyStffF4.resx
│   │   ├── ResidentsBrgyStffF4.cs
│   │   ├── ResidentsBrgyStffF4.Designer.cs
│   │   ├── ResidentsBrgyStffF4.resx
│   │   ├── SettingsBrgyStffF4.cs
│   │   ├── SettingsBrgyStffF4.Designer.cs
│   │   ├── SettingsBrgyStffF4.resx
│   │   ├── SubmitReportBrgyStffF4.cs
│   │   ├── SubmitReportBrgyStffF4.Designer.cs
│   │   └── SubmitReportBrgyStffF4.resx
│   │
│   └── [Resident - F3]
│       ├── DashboardResF3.cs
│       ├── DashboardResF3.Designer.cs
│       ├── DashboardResF3.resx
│       ├── ReportHistoryResF3.cs
│       ├── ReportHistoryResF3.Designer.cs
│       ├── ReportHistoryResF3.resx
│       ├── ResidentForm3.cs
│       ├── ResidentForm3.Designer.cs
│       ├── ResidentForm3.resx
│       ├── SettingsResF3.cs
│       ├── SettingsResF3.Designer.cs
│       ├── SettingsResF3.resx
│       ├── SubmitReportResF3.cs
│       ├── SubmitReportResF3.Designer.cs
│       └── SubmitReportResF3.resx
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
├── Form1.cs                        ← Login Form
├── Form1.Designer.cs
├── Form1.resx
├── Form2.cs                        ← Registration/ Sign Up
├── Form2.Designer.cs
├── Form2.resx
├── Program.cs
├── EveryJuanCount.csproj
├── EveryJuanCount.csproj.user
├── EveryJuanCount.slnx
└── README.md
```

---

## 🖥 Forms and UI

The system is composed of **six interconnected Windows Forms**:

| Form | Purpose | Key Controls |
|---|---|---|
| **Form1** *(Login)* | Secure entry point for all user roles | `TextBox`, `Button`, `PictureBox` |
| **Form2** *(Main Entry / Splash)* | Initial landing or role-selection screen | `Panel`, `Label`, `Button`, `PictureBox` |
| **DashboardAdF5** *(Admin Dashboard)* | Admin control center with navigation and stats | `Panel`, `GroupBox`, `Label`, `MenuStrip`, `Button` |
| **DashboardBrgyStffF4** *(Barangay Staff Dashboard)* | Staff control center with navigation | `Panel`, `GroupBox`, `Label`, `MenuStrip`, `Button` |
| **DashboardResF3** *(Resident Dashboard)* | Resident portal with available actions | `Panel`, `Label`, `Button`, `PictureBox` |
| **BarangayStaffForm4** | Staff account management and registration | `TextBox`, `ComboBox`, `Button`, `DateTimePicker` |
| **ResidentForm3** | Create and update resident records | `TextBox`, `DateTimePicker`, `ComboBox`, `Button` |
| **EncodeResidentBrgyStffF4** | Staff-side resident data encoding | `TextBox`, `ComboBox`, `DateTimePicker`, `Button` |
| **ResidentsAdF5** | Admin view of all registered residents | `DataGridView`, `TextBox` *(search)*, `Button` |
| **ResidentsBrgyStffF4** | Staff view of all registered residents | `DataGridView`, `TextBox` *(search)*, `Button` |
| **SubmitReportResF3** | Resident submits vital event reports | `RadioButton`, `TextBox`, `DateTimePicker`, `OpenFileDialog`, `Button` |
| **SubmitReportBrgyStffF4** | Staff submits vital event reports | `RadioButton`, `TextBox`, `DateTimePicker`, `OpenFileDialog`, `Button` |
| **ReportApprovalAdF5** | Admin reviews and acts on submitted reports | `DataGridView`, `RichTextBox`, `ComboBox`, `Button` |
| **ReportsQueueBrgyStffF4** | Staff views queue of pending reports | `DataGridView`, `Label`, `Button` |
| **ReportHistoryResF3** | Resident views their past submitted reports | `DataGridView`, `Label`, `Button` |
| **PopulationReportAdF5** | Admin views population statistics and trends | `DataGridView`, `Chart`, `Label`, `DateTimePicker` |
| **AnnouncementsAdF5** | Admin creates and manages announcements | `RichTextBox`, `TextBox`, `Button`, `DateTimePicker` |
| **AnnouncementsBrgyStffF4** | Staff views barangay announcements | `Label`, `RichTextBox`, `Panel` |
| **ManageStaffAdF5** | Admin manages barangay staff accounts | `DataGridView`, `TextBox`, `ComboBox`, `Button` |
| **AdminForm5** | Admin profile and account settings | `TextBox`, `Button`, `PictureBox` |
| **SettingsAdF5** | Admin system settings and preferences | `CheckBox`, `ComboBox`, `TextBox`, `Button` |
| **SettingsBrgyStffF4** | Staff account settings | `CheckBox`, `ComboBox`, `TextBox`, `Button` |
| **SettingsResF3** | Resident account settings | `CheckBox`, `ComboBox`, `TextBox`, `Button` |
---

## 🚀 Getting Started

### Prerequisites

- Windows 10 or later
- [Visual Studio 2022](https://visualstudio.microsoft.com/) with **.NET Desktop Development** workload installed
- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) or later
- SQL Server Express or SQLite
- Pichon - A vast collection of 1.5 MILLION pixel-perfect icons and curated graphics in one tiny desktop app
- Lunacy - a free, next-gen vector graphic design app for Windows, macOS, and Linux, primarily used for UI/UX and web design

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

### 🏘 Resident *(ResF3)*
- Register an account and log in via **Form1/Form2**
- View personal dashboard via **DashboardResF3**
- View and manage own resident profile via **ResidentForm3**
- Submit vital event reports via **SubmitReportResF3**
- Track the status of submitted reports via **ReportHistoryResF3**
- View barangay announcements
- Manage account settings via **SettingsResF3**

### 🏛 Barangay Staff *(BrgyStffF4)*
- Log in with staff credentials via **Form1/Form2**
- View staff dashboard via **DashboardBrgyStffF4**
- Encode and manage resident records via **EncodeResidentBrgyStffF4**
- Browse the full resident list via **ResidentsBrgyStffF4**
- Submit vital event reports on behalf of residents via **SubmitReportBrgyStffF4**
- Monitor the reports queue via **ReportsQueueBrgyStffF4**
- View barangay announcements via **AnnouncementsBrgyStffF4**
- Manage account settings via **SettingsBrgyStffF4**

### 👑 Admin *(AdF5)*
- Log in with admin credentials via **Form1/Form2**
- View the real-time population dashboard via **DashboardAdF5**
- Review and act on submitted reports via **ReportApprovalAdF5**
- Monitor population statistics via **PopulationReportAdF5**
- Manage barangay staff accounts via **ManageStaffAdF5**
- Browse and manage all resident records via **ResidentsAdF5**
- Post and manage announcements via **AnnouncementsAdF5**
- Manage admin profile via **AdminForm5**
- Configure system settings via **SettingsAdF5**

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
