using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Инд.проект.Models;

namespace Инд.проект.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public индивзадContext Context { get; }

        public CustomersController(индивзадContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll() // Получение всех записей
        {
            List<Customer> user = Context.Customers.ToList();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) // Получение одной записи
        {
            Customer? user = Context.Customers.Where(x => x.CustomersCode == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Add(Customer user) // Создание одной записи
        {
            Context.Customers.Add(user);
            Context.SaveChanges();
            return Ok(user);
        }

        [HttpPut]
        public IActionResult Update(Customer user) // Изменение существующей записи
        {
            Context.Customers.Update(user);
            Context.SaveChanges();
            return Ok(user);
        }

        [HttpDelete]
        public IActionResult Delete(int id) // Удаление существующей записи
        {
            Customer? user = Context.Customers.Where(x => x.CustomersCode == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            Context.Customers.Remove(user);
            Context.SaveChanges();
            return Ok(user);
        }
    }

}
  
