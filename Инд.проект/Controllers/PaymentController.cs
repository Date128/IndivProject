using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Инд.проект.Models;

namespace Инд.проект.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        public индивзадContext Context { get; }

        public PaymentController(индивзадContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll() // Получение всех записей
        {
            List<Payment> user = Context.Payments.ToList();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) // Получение одной записи
        {
            Payment? user = Context.Payments.Where(x => x.PaymentCode == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Add(Payment user) // Создание одной записи
        {
            Context.Payments.Add(user);
            Context.SaveChanges();
            return Ok(user);
        }

        [HttpPut]
        public IActionResult Update(Payment user) // Изменение существующей записи
        {
            Context.Payments.Update(user);
            Context.SaveChanges();
            return Ok(user);
        }

        [HttpDelete]
        public IActionResult Delete(int id) // Удаление существующей записи
        {
            Payment? user = Context.Payments.Where(x => x.PaymentCode == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            Context.Payments.Remove(user);
            Context.SaveChanges();
            return Ok(user);
        }
    }

}
    
