# Setup

Make sure you have installed the [.NET cli](https://learn.microsoft.com/en-us/dotnet/core/tools/) - You should have this if you are using VS

- Install the [Entity Framework CLI](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)
- Navigate to the project root (EnerginetDemo) - Run this command ``` dotnet ef database update ```
  - This will publish the migration to your local DB instance

## Call your API for the first time
- Run your Azure Function
- Start Postman and call the endpoint (Check out the HowToCallApiFromPostman.PNG image for details about this)
- Check your data in LocalDatabase (Servername: (LocalDB)\MSSQLLocalDB)
- After you have done this and validated that it works it is time for the [assignment](Assignment.md)
