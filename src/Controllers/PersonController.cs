using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using src.Models;
using src.Repository;


namespace src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private DatabaseContext _context { get; set; }

        public PersonController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Person>> Get()
        {
            var result = _context.People.Include(p => p.Contracts).ToList();
            if (result.Any() is false)
                return NoContent();

            return Ok(result);
        }

        [HttpGet("{id}")]

        public ActionResult<Person> GetById([FromRoute] int id)
        {
            var result = _context.People.SingleOrDefault(p => p.Id == id);
            if (result is null)
            {
                return NotFound(new
                {
                    content = "Content not found, invalid request",
                    status = HttpStatusCode.NotFound
                });
            }

            return Ok(result);
        }


        [HttpPost]
        public ActionResult<Person> Post(Person person)
        {
            var result = _context.People.Find(person.Id);
            if (result is not null)
            {
                return BadRequest(new
                {
                    //Already exists
                    content = "Problems with the post, invalid request",
                    status = HttpStatusCode.BadRequest
                });
            }

            try
            {
                _context.People.Add(person);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {
                return BadRequest(new
                {
                    content = "Problems with the post, invalid request",
                    status = HttpStatusCode.BadRequest
                });
            }

            return Created("Sucess", person);
        }

        [HttpPut("{id}")]
        public ActionResult<Object> Update([FromRoute] int id, [FromBody] Person person)
        {
            var result = _context.People.SingleOrDefault(p => p.Id == id);

            if (result is null)
                return NotFound(new
                {
                    content = "Content not found, invalid request",
                    status = HttpStatusCode.NotFound
                });


            try
            {
                _context.People.Update(person);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {
                return BadRequest(new
                {
                    content = "Problems with the update, invalid request",
                    status = HttpStatusCode.BadRequest
                });
            }

            return Ok(new
            {
                content = $"Updated content {id}",
                status = HttpStatusCode.OK
            });
        }

        [HttpDelete("{id}")]
        public ActionResult<object> Delete([FromRoute] int id)
        {
            var result = _context.People.SingleOrDefault(e => e.Id == id);

            if (result is null)
                return BadRequest(new
                {
                    content = "Content not found, invalid request",
                    status = HttpStatusCode.BadRequest
                });

            _context.People.Remove(result);
            _context.SaveChanges();


            return Ok(new
            {
                content = "Sucess",
                status = HttpStatusCode.OK
            });
        }
    }
}