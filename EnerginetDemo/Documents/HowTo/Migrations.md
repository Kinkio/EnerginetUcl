## Migrations

When working with Code First we use migrations to update our database. Read more about migrations [here](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)

When you change your DB model and want to make it work with EF we need to make a migration.

Let's say you have added a property to your model. Run the following

``` dotnet ef migrations add AddedNewPropertyToDbModel```

The command ```dotnet ef migrations add``` tells EF that you have made changes and want to make a new migration.
You can then add your own name to this and when you run the command it will make a new migration in the 'Migrations' folder

Here you can verify that the changes are as just suspected, and if they are fine you can run the command ```dotnet ef database update ```

This will actually push the changes to your local DB and you should be able to see them.
