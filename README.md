# Student Fees Tracker 📚💰

This project contains a sample ASP.NET Core app. This app is an example of the article I produced for the Telerik Blog (telerik.com/blogs).

Welcome to the **Student Fees Tracker** repository! 

This ASP.NET Core Minimal API application helps you keep track of student fees using MySQL as the database, Dapper as the Micro ORM, and follows the Abstract Factory design pattern. 🎓💻

## Features 🌟

- Easily manage student fee records.
- Store data in a MySQL database.
- Efficient data access with Dapper.
- Maintainable codebase using the Abstract Factory design pattern.

## Prerequisites 📋

Before you begin, ensure you have met the following requirements:

- .NET 6 SDK installed.
- MySQL server up and running.
- Knowledge of the Abstract Factory design pattern.

## Getting Started 🚀

1. Clone this repository:

   ```shell
   git clone https://github.com/zangassis/student-fees-tracker.git
   ```

2. Navigate to the project directory:

   ```shell
   cd student-fees-tracker
   ```

3. Configure your MySQL connection in the `appsettings.json` file:

   ```json
   "ConnectionStrings": {
    "ProjectConnection": "host=localhost; port=port_number; database=student_fee_management; user=root; password=password;"
    }
   ```

4. Run the application:

   ```shell
   dotnet run
   ```

5. Access the API at `https://localhost:port` using your favorite API client (e.g., Fiddler, curl).

## Database Setup 🗃️

Make sure you have created a MySQL database named `student_fee_management` with the required tables for this application. You can find the SQL script in the `Database` folder.

## Abstract Factory Design Pattern 🏭

This project implements the Abstract Factory design pattern to provide an abstract interface for creating related objects without specifying their concrete classes. It promotes loose coupling and supports the creation of families of related objects.

## Contribution Guidelines 🤝

Feel free to contribute to this project! You can:

- Report issues.
- Submit feature requests.
- Open pull requests for bug fixes or new features.

## License 📝

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

Happy coding! 🚀📚💻
