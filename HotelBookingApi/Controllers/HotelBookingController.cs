using HotelBookingApi.Data;
using HotelBookingApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {
        private readonly ApiContext context;

        public HotelBookingController(ApiContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public JsonResult CreateEdit(HotelBooking booking)
        {
            if (booking.Id == 0)
            {
                context.Bookings.Add(booking);
            }
            else
            {
                var bookingInDb = context.Bookings.Find(booking.Id);

                if (bookingInDb == null)
                {
                    return new JsonResult(NotFound());
                }

                EditBooking(booking, bookingInDb);
            }

            context.SaveChanges();

            return new JsonResult(Ok(booking));
        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = context.Bookings.Find(id);

            if (result is null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = context.Bookings.Find(id);

            if (result is null)
            {
                return new JsonResult(NotFound());
            }

            context.Bookings.Remove(result);
            context.SaveChanges();

            return new JsonResult(NoContent());
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var result = context.Bookings.ToList();

            return new JsonResult(Ok(result));
        }

        private static void EditBooking(HotelBooking booking, HotelBooking bookingInDb)
        {
            bookingInDb.RoomNumber = booking.RoomNumber;
            bookingInDb.ClientName = booking.ClientName;
        }
    }
}
