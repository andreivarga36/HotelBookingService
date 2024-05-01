# HotelBookingAPI

Hotel Booking API is a simple RESTful web service designed to handle hotel bookings. It provides endpoints for creating, updating, deleting, and retrieving hotel bookings. The API is built using ASP.NET Core and utilizes an in-memory database for storing booking data.

## Usage Instructions:
  - To add a new booking, make sure the Id field in the JSON object is always set to 0. This indicates that it is a new booking.  

### Endpoints:
    - POST /api/HotelBooking/CreateEdit: Creates a new booking or updates an existing one.
        Request Body: JSON object representing the booking details.
        Response: JSON object indicating the success or failure of the operation.

    - GET /api/HotelBooking/Get/{id}: Retrieves the details of a specific booking by its ID.
        Path Parameter: Booking ID.
        Response: JSON object containing the booking details if found, or an error message if not found.

    - DELETE /api/HotelBooking/Delete/{id}: Deletes a booking by its ID.
        Path Parameter: Booking ID.
        Response: JSON object indicating the success or failure of the operation.

    - GET /api/HotelBooking/GetAll: Retrieves all bookings stored in the database.
        Response: JSON array containing all booking objects.


#### Technologies and Tools Used:

    - C#: The primary programming language for developing the API.

    - ASP.NET Core: The framework used for building RESTful web services.

    - Entity Framework Core: An object-relational mapping (ORM) framework for interacting with databases.

    - Newtonsoft.Json: A library for serializing and deserializing JSON data.

    - Microsoft.EntityFrameworkCore.InMemory: The in-memory database provider used for testing.

    - XUnit: A testing framework for .NET used to create unit tests.

#####Documentation:

    ASP.NET Core Documentation
    Entity Framework Core Documentation
    XUnit Documentation
