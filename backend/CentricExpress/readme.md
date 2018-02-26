## Database Startup

1. From package manager console run the following command for creating the database: `update-database`
2. After stept 1, on Startup.cs uncomment the line 37 for adding some items into the database. 
3. Run again from package manager console: `update-database`

Note: if update does not work, probably you installted SQL Express differently. Check appsettings.json & update the connection string according to your local settings.

## Swagger
http://localhost:50755/swagger/

## Links

* `.NET Watch` - https://docs.microsoft.com/en-us/aspnet/core/tutorials/dotnet-watch

