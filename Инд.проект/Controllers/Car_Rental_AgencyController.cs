using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Инд.проект.Models;

namespace Инд.проект.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Car_Rental_AgencyController : ControllerBase
    {
        public индивзадContext Context { get; }

        public Car_Rental_AgencyController(индивзадContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll() // Получение всех записей
        {
            List<CarRentalAgency> user = Context.CarRentalAgencies.ToList();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) // Получение одной записи
        {
            CarRentalAgency? user = Context.CarRentalAgencies.Where(x => x.AgencyCode == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Add(CarRentalAgency user) // Создание одной записи
        {
            Context.CarRentalAgencies.Add(user);
            Context.SaveChanges();
            return Ok(user);
        }

        [HttpPut]
        public IActionResult Update(CarRentalAgency user) // Изменение существующей записи
        {
            Context.CarRentalAgencies.Update(user);
            Context.SaveChanges();
            return Ok(user);
        }

        [HttpDelete]
        public IActionResult Delete(int id) // Удаление существующей записи
        {
            CarRentalAgency? user = Context.CarRentalAgencies.Where(x => x.AgencyCode == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            Context.CarRentalAgencies.Remove(user);
            Context.SaveChanges();
            return Ok(user);
        }
    }

}
    