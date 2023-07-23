# AsyncInnManagementSystem
The Async Inn Management System is a web application designed to manage hotel data for a hotel chain called "Async Inn." The application allows hotel administrators to manage hotel information, room details, and amenities through a user-friendly interface.

## Entity Relationship Diagram (ERD)

![](./lab12.PNG)

## Overview of Relationships
The Async Inn Management System consists of three main entities: Hotel, Room, and Amenity.
- ### Hotel Entity:

The Hotel entity represents a single hotel location in the Async Inn chain.It has a one-to-many relationship with the Room entity, as each hotel can have multiple rooms.
It also has a many-to-many relationship with the Amenity entity, as each hotel can offer multiple amenities, and each amenity can be available at multiple hotels.
- ### Room Entity:

The Room entity represents an individual hotel room.
It has a many-to-one relationship with the Hotel entity, as each room belongs to a specific hotel.
It also has a many-to-many relationship with the Amenity entity, as each room can have multiple amenities, and each amenity can be available in multiple rooms.
- ### Amenity Entity:

The Amenity entity represents various amenities offered by the hotels, such as Wi-Fi, TV, etc.
It has a many-to-many relationship with both Hotel and Room entities, as explained above
 ## Using :
 To run the Async Inn Management System, follow these steps:

- Clone the repository to your local machine.
- Ensure you have the required dependencies, including .NET Core and SQL Server.
- Set up the database connection string in the appsettings.json file.
- Run the migrations to create the database tables and seed the initial data.
- Build and run the application using dotnet run or using your preferred IDE.



## Technologies Used
- C#
- Entity Framework
- ASP.NET Web API
- SQL Server

## Conroller 
You can check it by using that end point 

     /api/Hotels

 ## Contributions
Contributions to the Async Inn Management System are welcome! If you find any bugs or have ideas for enhancements, feel free to contact me .
