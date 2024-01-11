using person_api.Controllers;
using person_api.Entities;

namespace person_api.Persistence
{
    public class PersonDbContext
    {
        public List<Person> Persons { get; set; }

        public PersonDbContext()
        {
            Persons = new List<Person>()  {
        new Person() { Gender="male", Id= new Guid("de70438d-a47e-414c-8641-618d9b88447a"), Name = "John Doe", Age = 42 },
        new Person() { Gender="male", Id=  new Guid("ab9fe789-5d03-4b60-81c1-70db7eb2dde3"), Name = "Joseph Alan", Age = 30 },
        new Person() { Gender="female", Id=  new Guid("19726897-79bd-4c7c-9737-8721ed035f7d"), Name = "Stella Dolle", Age = 29 },
        new Person() { Gender="male", Id= new Guid("c960e0ac-8a9d-400e-8947-72786ddbaac5"), Name = "Charles Anthony", Age = 35 },
        }; ;
        }
    }
}
