using Microsoft.AspNetCore.Mvc;
using person_api.Entities;
using person_api.Persistence;

namespace person_api.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : Controller {
        private readonly PersonDbContext _context;

        public PersonController(PersonDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetAll() { 
        var persons = _context.Persons;
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {
            var person = _context.Persons.SingleOrDefault(p => p.Id == id);
            if(person == null) { NotFound(); }
            return Ok(person);
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            var newPerson = new Person();
            newPerson.Id = Guid.NewGuid();
            newPerson.Name = person.Name;
            newPerson.Age = person.Age;
            newPerson.Gender = person.Gender;

            _context.Persons.Add(newPerson);
            return CreatedAtAction(nameof(GetById), new { id= newPerson.Id.ToString() }, newPerson);
        }
    }
}
