# Fictional Civilization Simulator

Fictional Civilization Simulator is a personal project for exploring and managing fictional civilizations. It consists of a React-based user interface and an ASP.NET Core API with database support, providing a full-stack simulation experience.

## 🌍 Project Overview

This simulator allows users to:

- View a list of fictional civilizations
- Add new civilizations with name, description, population, and territory
- Edit or delete existing civilizations
- Interact through a clean and responsive frontend
- Fetch and update data through a RESTful API

---

## 🧱 Technologies Used

### 🔹 Frontend (UI)

- **Framework**: [React](https://reactjs.org/)
- **Language**: JavaScript
- **Styling**: CSS
- **Deployment**: [Netlify](https://netlify.com)

### 🔹 Backend (API)

- **Framework**: ASP.NET Core Web API
- **Language**: C#
- **Database**: SQLite (lightweight file-based relational database)
- **ORM**: Entity Framework Core
- **Deployment**: [Render](https://render.com)

---

## 🚀 Live Demo

- **UI**: [fictional-civ-sim-ui.netlify.app](https://fictional-civ-sim-ui.netlify.app)
- **API**: [https://fictional-civ-sim-api.onrender.com/api/civilization/getallcivilizations](https://fictional-civ-sim-api.onrender.com/api/civilization/getallcivilizations)

---

## 🛠️ Getting Started

### 📁 Clone the Repository

```bash
git clone https://github.com/NickLimnios/fictional-civ-sim.git
cd fictional-civ-sim
```

### 🖼️ UI Setup (React)
🔧 Prerequisites
- Node.js (v18 or later recommended)
- npm

### 📦 Install Dependencies
```bash
cd fcs.ui
npm install
```

### 🌐 Configure API URL
In src/api.js, set your API base URL:
```bash
export const API_URL = "https://fictional-civ-sim-api.onrender.com/api";
```

To run against a local backend instead:

```bash
export const API_URL = "https://localhost:5001/api";
```

### ▶️ Run the App
```bash
npm start
```

App will run at http://localhost:3000.

### 🔧 API Setup (ASP.NET Core)
📋 Prerequisites
- .NET 7 SDK or later

### 📂 Navigate to API folder
```bash
cd fcs.api
```

### 📦 Restore Dependencies
```bash
dotnet restore
```

### 💾 Database Setup
The API uses SQLite. The database file will be automatically created when you run the app.

To apply the latest Entity Framework migrations (if needed):

```bash
dotnet ef database update
```

(EF tools must be installed: dotnet tool install --global dotnet-ef)

### ▶️ Run the API

```bash
dotnet run
```

The API will be accessible at https://localhost:5001.

### 🐳 Docker Support (Optional)
You can containerize the full app using Docker (if configured):

```bash
docker-compose up --build
```

### 📄 License
This project is licensed under the MIT License. See the LICENSE file for details.
