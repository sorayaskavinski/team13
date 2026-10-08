# Task Forge — Team 13

A modern, responsive task management application built with **.NET Blazor**, designed to help users streamline their workflow, organize daily tasks, and boost productivity efficiently.

---

## 🎥 Video Demonstration & Project Links

- **Video Demo:** [Watch on YouTube](https://youtube.com) *(Substitua pelo link do seu vídeo)*
- **GitHub Repository:** [https://github.com/sorayaskavinski/team13](https://github.com/sorayaskavinski/team13)

---

## 👥 Team Members & Contributions

- **Soraya Skavinski & Eyob Daniel Teffera** — *Task Operations*
  - Task creation, assignment, priority settings, status tracking, and deletion (CRUD).
  - Post-merge integration, branch conflict resolution, and core user documentation.
- **Eyob Daniel Teffera** — *Project Management*
  - Project creation, viewing, updating, and deletion workflow.
  - Organization and linking of tasks to specific user projects.
- **Tomas Fontes** — *Authentication & Security*
  - User registration, login, and Two-Factor Authentication (2FA).
  - Account deletion workflow and authentication security handling.
- **Wisdom Samuel Etim** — *Dashboard & UI/UX*
  - Interactive Dashboard design and data overview.
  - State management and responsive UI components for dynamic feedback.

---

## 🚀 Key Features

- **User Authentication & Security:** Secure login, user registration, 2FA support, and account isolation for private workspaces.
- **Project Workspaces:** Create, structure, and manage independent project workspaces.
- **Task Operations (CRUD):** Full task lifecycle management — create, assign, set priorities, update statuses, edit details, and delete with safety confirmation.
- **Interactive Dashboard:** Clean, intuitive interface presenting real-time status, project progress bars, overview statistics, and instant task status toggles.
- **Responsive & Accessible Design:** Optimized layout for desktop, tablet, and mobile browsers following WCAG AA guidelines.

---

## 🛠️ Tech Stack & Tools

- **Programming Languages:** C#, HTML5, CSS3, JavaScript
- **Framework & Libraries:** .NET 8.0 / ASP.NET Core, Blazor Server (Interactive Server Mode), Entity Framework Core
- **Database:** SQLite / LocalDB with EF Core Migrations
- **Version Control & Management:** Git, GitHub, Trello

---

## 📋 Prerequisites

Before running this project, make sure you have the following installed on your local machine:
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (or latest LTS version)
- **IDE:** Visual Studio 2022 (with *ASP.NET and web development* workload) or Visual Studio Code (with *C# Dev Kit* extension)

---

## 🏃 How to Run the Application

1. **Clone the Repository:**
   ```bash
   git clone [https://github.com/sorayaskavinski/team13.git](https://github.com/sorayaskavinski/team13.git)
   cd team13

2. **Launch the Application:**
    dotnet run

3. **Apply Database Migrations:**
    dotnet ef database update

4. **Access in Browser:**
  Open your browser and navigate to https://localhost:5087 (or the URL specified in your terminal output).