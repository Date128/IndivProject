using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Инд.проект.Models;

namespace Инд.проект.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        public индивзадContext Context { get; }

        public BookingController(индивзадContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll() // Получение всех записей
        {
            List<Booking> user = Context.Bookings.ToList();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) // Получение одной записи
        {
            Booking? user = Context.Bookings.Where(x => x.BookingCode == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Add(Booking user) // Создание одной записи
        {
            Context.Bookings.Add(user);
            Context.SaveChanges();
            return Ok(user);
        }

        [HttpPut]
        public IActionResult Update(Booking user) // Изменение существующей записи
        {
            Context.Bookings.Update(user);
            Context.SaveChanges();
            return Ok(user);
        }

        [HttpDelete]
        public IActionResult Delete(int id) // Удаление существующей записи
        {
            Booking? user = Context.Bookings.Where(x => x.BookingCode == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            Context.Bookings.Remove(user);
            Context.SaveChanges();
            return Ok(user);
        }
    }

}
     