# HotelBookingAPI

Hotel Booking API is a simple RESTful web service designed to handle hotel bookings. It provides endpoints for creating, updating, deleting, and retrieving hotel bookings. The API is built using ASP.NET Core and utilizes an in-memory database for storing booking data.

## Usage Instructions:
  - Creating or Editing a Booking:
-Endpoint: /api/HotelBooking/CreateEdit
-Method: POST
-Description: Use this endpoint to create a new booking or edit an existing booking.
-Request Body: Provide a JSON object representing the booking you want to create or edit. Ensure that the Id field is set to 0 for new bookings and to the desired booking ID for editing existing bookings.


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
