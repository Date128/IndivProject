using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Инд.проект.Models;

namespace Инд.проект.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Private_faceController : ControllerBase
    {
        public индивзадContext Context { get; }

        public Private_faceController(индивзадContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll() // Получение всех записей
        {
            List<PrivateFace> user = Context.PrivateFaces.ToList();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) // Получение одной записи
        {
            PrivateFace? user = Context.PrivateFaces.Where(x => x.PrivateFaceCode == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Add(PrivateFace user) // Создание одной записи
        {
            Context.PrivateFaces.Add(user);
            Context.SaveChanges();
            return Ok(user);
        }

        [HttpPut]
        public IActionResult Update(PrivateFace user) // Изменение существующей записи
        {
            Context.PrivateFaces.Update(user);
            Context.SaveChanges();
            return Ok(user);
        }

        [HttpDelete]
        public IActionResult Delete(int id) // Удаление существующей записи
        {
            PrivateFace? user = Context.PrivateFaces.Where(x => x.PrivateFaceCode == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            Context.PrivateFaces.Remove(user);
            Context.SaveChanges();
            return Ok(user);
        }
    }

}
    