# HotelBookingAPI

The Hotel Booking API is a RESTful web service designed to manage hotel bookings, providing endpoints for creating, reading, updating, and deleting reservations. The API is built using ASP.NET Core and utilizes an in-memory database for storing booking data.

## Usage Instructions:
  - Use the **CreateEdit** endpoint in order to create or edit a booking. For a new booking, the Id must be 0. If the user enters a different Id than 0, the system will search for a booking with that Id. Therefore, 0 is used to register a new booking, while any other numbers are used for editing, in case the booking already exists in the system

  - Use the **Get** endpoint to retrieve information about a specific booking. You need to enter the ID of the booking you're looking for. If there is a booking, the information will be displayed. If the booking does not exist, **NotFound** message will be displayed.

  - Use the **Delete** endpoint in order to delete a booking from database. If the booking is succesfully deleted, **NoContent** message wil be displayed. If the booking is not found in database, **NotFound** message will be displayed.

  - Use the **GetAll** endpoint in order to receive all bookings registred in database.

#### Technologies and Tools Used:

  - **C#**: The primary programming language for developing the API.
    
  - **ASP.NET Core**: The framework used for building RESTful web services.
    
  - **Entity Framework Core**: An object-relational mapping (ORM) framework for interacting with databases.

  - **Newtonsoft.Json**: A library for serializing and deserializing JSON data.

  - **Microsoft.EntityFrameworkCore.InMemory**: The in-memory database provider used for testing.

  - **XUnit**: A testing framework for .NET used to create unit tests.

##### Screenshots:

  - [Booking is created](Screenshots/CreateBooking.jpg)

##### Documentation:

   - [ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio)
   - [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli)
