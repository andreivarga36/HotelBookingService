using HotelBookingApi.Controllers;
using HotelBookingApi.Data;
using HotelBookingApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingsApiFacts
{
    public class HotelBookingControllerFacts
    {
        [Fact]
        public void CreateEdit_NewBookingIsAdded_ShouldReturnExpectedResult()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using var context = new ApiContext(options);
            var controller = new HotelBookingController(context);
            var newBooking = new HotelBooking { Id = 0, RoomNumber = 5, ClientName = "John" };

            var result = controller.CreateEdit(newBooking);

            Assert.NotNull(result);
            Assert.Single(context.Bookings);
            Assert.True(context.Bookings.Any(b => b.ClientName == "John"));
        }

        [Fact]
        public void CreateEdit_BookingIsEdited_ShouldReturnExpectedResult()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
             .UseInMemoryDatabase(databaseName: "Test_Database")
             .Options;

            using var context = new ApiContext(options);
            var controller = new HotelBookingController(context);

            var newBooking = new HotelBooking { Id = 0, RoomNumber = 42, ClientName = "Paul" };
            var firstBooking = controller.CreateEdit(newBooking);

            Assert.True(context.Bookings.Any(b => b.Id == 1));
            Assert.True(context.Bookings.Any(b => b.RoomNumber == 42));
            Assert.True(context.Bookings.Any(b => b.ClientName == "Paul"));

            var editedBooking = new HotelBooking { Id = 1, RoomNumber = 33, ClientName = "Paul" };
            var secondBooking = controller.CreateEdit(editedBooking);

            // same client, so id isn't changed
            Assert.True(context.Bookings.Any(b => b.Id == 1));
            Assert.True(context.Bookings.Any(b => b.RoomNumber == 33));
            Assert.True(context.Bookings.Any(b => b.ClientName == "Paul"));
        }

        [Fact]
        public void CreateEdit_BookingIsNotFound_ShouldReturnExpectedResult()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
             .UseInMemoryDatabase(databaseName: "Test_Database")
             .Options;

            using var context = new ApiContext(options);
            var controller = new HotelBookingController(context);

            var firstBooking = new HotelBooking { Id = 6, RoomNumber = 11, ClientName = "Mary" };
            var result = controller.CreateEdit(firstBooking);

            Assert.IsType<NotFoundResult>(result.Value);     
        }
    }
}