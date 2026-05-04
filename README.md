Master-Detail CRUD Application | ASP.NET Core 
This repository contains a robust implementation of a Master-Detail CRUD interface developed with ASP.NET Core MVC. The project focuses on handling complex relational data while maintaining a clean architecture and smooth user experience.

Technical Implementations
Based on the project requirements outlined in image_55893c.png, the following features were implemented:

1. Data Architecture & Persistence
Code First Approach: Utilized Entity Framework Core to design and manage the database schema directly through C# classes.

Relational Data Management: Seamlessly handled One-to-Many relationships, ensuring data integrity across Master and Detail records.

Diverse Data Types: Integrated support for various data formats, including text, numeric values, booleans, and date pickers.

Image Uploading: Implemented file handling for storing and displaying images within the application.

2. Frontend & User Experience
AJAX Integration: Dynamic CRUD operations are performed via AJAX to provide a seamless, no-reload experience for the user.

View Components & Partial Views: Leveraged modular UI components to keep the code DRY (Don't Repeat Yourself) and maintainable.

View Models: Used dedicated ViewModels to decouple the domain models from the UI layer, ensuring secure and precise data transfer.

3. Security & Logic
Data Annotations: Applied comprehensive validation logic at the model level to ensure data quality and provide instant feedback to users.

Authentication & Authorization: Integrated identity management to control access and secure sensitive routes.

Custom Routing: Configured specialized routing paths to make URLs more intuitive and SEO-friendly.

Technology Stack
Backend: ASP.NET Core, EF Core

Database: MS SQL Server

Frontend: Bootstrap, jQuery, AJAX

Patterns: MVC, ViewModel, Repository Pattern

Getting Started
Clone the Repo:
git clone [https://github.com/yourusername/your-repo-name.git](https://github.com/yourusername/your-repo-name.git)

Database Setup: Update the ConnectionStrings in appsettings.json.

Run Migrations:
Open Package Manager Console and run Update-Database.

Launch: Press F5 or use dotnet run to start the application.
