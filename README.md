This repository features a professional implementation of a Master-Detail CRUD interface using ASP.NET Core. The project is designed to manage complex relational data structures while focusing on Clean Architecture and a High-Performance User Experience.

🚀 Technical Implementations
The following core functionalities were implemented based on the project requirements:

1. Data Architecture & Persistence
Code First Approach: Utilized Entity Framework Core to architect and manage the database schema directly through C# classes.

Relational Data Management: Engineered seamless One-to-Many relationships, ensuring strict data integrity between Master and Detail records.

Diverse Data Handling: Integrated support for multiple data formats, including Text, Numeric values, Booleans, and Date pickers.

Image Processing: Built a robust file-handling system for uploading and Displaying Images within the application.

2. Advanced Frontend & UX
AJAX Driven UI: Implemented Dynamic CRUD operations via AJAX to ensure a smooth, Zero-Reload user experience.

Modular Design: Leveraged View Components and Partial Views to maintain a DRY (Don't Repeat Yourself) and highly maintainable codebase.

Architectural Decoupling: Used dedicated ViewModels to separate the UI layer from Domain Models, ensuring Secure and Precise data transfer.

3. Security & Application Logic
Model Validation: Applied Comprehensive Data Annotations for strong server-side and client-side validation.

Access Control: Integrated Authentication & Authorization logic to secure sensitive routes and manage user roles.

URL Optimization: Configured Custom Routing to create intuitive, SEO-friendly, and readable URL structures.

🛠 Technology Stack
Backend: ASP.NET Core, EF Core

Database: MS SQL Server

Frontend: Bootstrap, jQuery, AJAX

Design Patterns: MVC, ViewModel, Repository Pattern

📥 Getting Started
Clone the Repository:

Bash
git clone https://github.com/Rion-bhuiyan/Pet_Adoption_System-ASP.NET-Core-
Database Configuration: Update the ConnectionStrings in the appsettings.json file.

Apply Migrations:
Execute the following command in the Package Manager Console:

PowerShell
Update-Database
Run Application: Press F5 in Visual Studio or use dotnet run in your terminal.
