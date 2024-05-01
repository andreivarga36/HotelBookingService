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
                .UseInMemoryDatabase(databaseName: "First")
                .Options;

            using var context = new ApiContext(options);
            var controller = new HotelBookingController(context);
            var newBooking = new HotelBooking { Id = 0, RoomNumber = 5, ClientName = "John" };

            controller.CreateEdit(newBooking);

            Assert.Single(context.Bookings);
            Assert.True(context.Bookings.Any(b => b.ClientName == "John"));
        }

        [Fact]
        public void CreateEdit_BookingIsEdited_ShouldReturnExpectedResult()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
             .UseInMemoryDatabase(databaseName: "Second")
             .Options;

            using var context = new ApiContext(options);
            var controller = new HotelBookingController(context);

            var newBooking = new HotelBooking { Id = 0, RoomNumber = 42, ClientName = "Paul" };
            controller.CreateEdit(newBooking);

            Assert.True(context.Bookings.Any(b => b.Id == 1));
            Assert.True(context.Bookings.Any(b => b.RoomNumber == 42));
            Assert.True(context.Bookings.Any(b => b.ClientName == "Paul"));

            var editedBooking = new HotelBooking { Id = 1, RoomNumber = 33, ClientName = "Paul" };
            controller.CreateEdit(editedBooking);

            // same client, so id isn't changed
            Assert.True(context.Bookings.Any(b => b.Id == 1));
            Assert.True(context.Bookings.Any(b => b.RoomNumber == 33));
            Assert.True(context.Bookings.Any(b => b.ClientName == "Paul"));
        }

        [Fact]
        public void CreateEdit_BookingIsNotFound_ShouldReturnExpectedResult()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
             .UseInMemoryDatabase(databaseName: "Third")
             .Options;

            using var context = new ApiContext(options);
            var controller = new HotelBookingController(context);

            var firstBooking = new HotelBooking { Id = 6, RoomNumber = 11, ClientName = "Mary" };
            var result = controller.CreateEdit(firstBooking);

            Assert.IsType<NotFoundResult>(result.Value);
        }

        [Fact]
        public void Get_BookingIsFound_ShouldReturnExpectedResult()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
             .UseInMemoryDatabase(databaseName: "Fourth")
             .Options;

            using var context = new ApiContext(options);
            var controller = new HotelBookingController(context);

            var firstBooking = new HotelBooking { Id = 0, RoomNumber = 1, ClientName = "Mary" };
            controller.CreateEdit(firstBooking);

            Assert.IsType<OkObjectResult>(controller.Get(1).Value);
        }

        [Fact]
        public void Get_BookingIsNotFound_ShouldReturnExpectedResult()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
             .UseInMemoryDatabase(databaseName: "Fifth")
             .Options;

            using var context = new ApiContext(options);
            var controller = new HotelBookingController(context);

            var firstBooking = new HotelBooking { Id = 0, RoomNumber = 5, ClientName = "Mary" };
            controller.CreateEdit(firstBooking);

            Assert.IsType<NotFoundResult>(controller.Get(8).Value);
        }

        [Fact]
        public void Delete_BookingIsFound_ShouldReturnExpectedResult()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
            .UseInMemoryDatabase(databaseName: "Sixth")
            .Options;

            using var context = new ApiContext(options);
            var controller = new HotelBookingController(context);

            var firstBooking = new HotelBooking { Id = 0, RoomNumber = 10, ClientName = "Kimberly" };
            controller.CreateEdit(firstBooking);

            Assert.IsType<NoContentResult>(controller.Delete(1).Value);
        }

        [Fact]
        public void Delete_BookingIsNotFound_ShouldReturnExpectedResult()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
            .UseInMemoryDatabase(databaseName: "Seventh")
            .Options;

            using var context = new ApiContext(options);
            var controller = new HotelBookingController(context);

            var firstBooking = new HotelBooking { Id = 0, RoomNumber = 10, ClientName = "Kimberly" };
            controller.CreateEdit(firstBooking);

            Assert.IsType<NotFoundResult>(controller.Delete(2).Value);
        }

        [Fact]
        public void GetAll_AllBokingsAreReturned_ShouldReturnExpectedResult()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
           .UseInMemoryDatabase(databaseName: "Eighth")
           .Options;

            using var context = new ApiContext(options);
            var controller = new HotelBookingController(context);

            var firstBooking = new HotelBooking { Id = 0, RoomNumber = 4, ClientName = "Marcus" };
            var secondBooking = new HotelBooking { Id = 0, RoomNumber = 2, ClientName = "Carlo" };
            var thirdBooking = new HotelBooking { Id = 0, RoomNumber = 55, ClientName = "Joshua" };

            controller.CreateEdit(firstBooking);
            controller.CreateEdit(secondBooking);
            controller.CreateEdit(thirdBooking);

            Assert.Equal(3, context.Bookings.Count());
            Assert.True(context.Bookings.Any(b => b.ClientName == "Marcus"));
            Assert.True(context.Bookings.Any(b => b.ClientName == "Carlo"));
            Assert.True(context.Bookings.Any(b => b.ClientName == "Joshua"));
        }

        [Fact]
        public void GetAll_NoBookingsAvailable_ShouldReturnExpectedResult()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
           .UseInMemoryDatabase(databaseName: "Nineth")
           .Options;

            using var context = new ApiContext(options);
            var controller = new HotelBookingController(context);

            var result = controller.GetAll();

            Assert.Empty(context.Bookings);
            Assert.IsType<OkObjectResult>(result.Value);
        }
    }
}