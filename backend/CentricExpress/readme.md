## Database Startup

1. From package manager console run the following command for creating the database: `update-database`
2. After stept 1, on Startup.cs uncomment the line 37 for adding some items into the database. 
3. Run again from package manager console: `update-database`

Note: if update does not work, probably you installted SQL Express differently. Check appsettings.json & update the connection string according to your local settings.

## Swagger
http://localhost:50755/swagger/

## Links

* `.NET Watch` - https://docs.microsoft.com/en-us/aspnet/core/tutorials/dotnet-watch


## Picture Service Request Examples

* Add New Picture : http://localhost:51260/api/Pictures/
```
{
    "description": "Cereals",
    "pictureURL": "https://goo.gl/vb4wWi",qq
}
```
    
* Get Pictures : http://localhost:51260/api/Pictures/
```
[
    {
        "id": "eaed51b6-ce5d-40d4-9265-131fb0268c0f",
        "description": null,
        "pictureURL": null,
        "content": "UGljdHVyZSAx"
    },
    {
        "id": "7d280cf1-3c92-4d0e-80d5-4111acc89d87",
        "description": null,
        "pictureURL": null,
        "content": "UGljdHVyZSAy"
    },
]
```
* Get Picture http://localhost:51260/api/Pictures/pictureId
``` 
   {
        "id": "74aa67b7-f0d8-4bc8-900a-b86631a5db78",
        "description": "Cereals",
        "pictureURL": null,
        "content":"/9j/4AAQSkZJRgABAQAAAQABAAD/2wBDAAUDBAQEAwUEBAQFBQUGBwwIBwcHBw8LCwkMEQ8
   }
```
