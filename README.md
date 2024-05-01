# HotelBookingAPI

Hotel Booking API is a simple RESTful web service designed to handle hotel bookings. It provides endpoints for creating, updating, deleting, and retrieving hotel bookings. The API is built using ASP.NET Core and utilizes an in-memory database for storing booking data.

## Usage Instructions:
  - Use the **CreateEdit** endpoint in order to create or edit a booking. For a new booking, the Id must be 0. If the user enters a different Id than 0, the system will search for a booking with that Id. Therefore, 0 is used to register a new booking, while any other numbers are used for editing, in case the booking already exists in the system

#### Technologies and Tools Used:

  - C#: The primary programming language for developing the API.
    
  - ASP.NET Core: The framework used for building RESTful web services.
    
  - Entity Framework Core: An object-relational mapping (ORM) framework for interacting with databases.

  - Newtonsoft.Json: A library for serializing and deserializing JSON data.

  - Microsoft.EntityFrameworkCore.InMemory: The in-memory database provider used for testing.

  - XUnit: A testing framework for .NET used to create unit tests.

##### Documentation:

   - [ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio)
   - [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli)
