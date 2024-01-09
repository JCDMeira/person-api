using person_api.Controllers;
using person_api.Entities;

namespace person_api.Persistence
{
    public class PersonDbContext
    {
        public List<Person> Persons { get; set; }

        public PersonDbContext()
        {
            Persons = new List<Person>();
        }
    }
}
