using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Инд.проект.Models;

namespace Инд.проект.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        public индивзадContext Context { get; }

        public AmenitiesController(индивзадContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll() // Получение всех записей
        {
            List<Amenity> user = Context.Amenities.ToList();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) // Получение одной записи
        {
            Amenity? user = Context.Amenities.Where(x => x.AmenitiesCode == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Add(Amenity user) // Создание одной записи
        {
            Context.Amenities.Add(user);
            Context.SaveChanges();
            return Ok(user);
        }

        [HttpPut]
        public IActionResult Update(Amenity user) // Изменение существующей записи
        {
            Context.Amenities.Update(user);
            Context.SaveChanges();
            return Ok(user);
        }

        [HttpDelete]
        public IActionResult Delete(int id) // Удаление существующей записи
        {
            Amenity? user = Context.Amenities.Where(x => x.AmenitiesCode == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            Context.Amenities.Remove(user);
            Context.SaveChanges();
            return Ok(user);
        }
    }

}
   
