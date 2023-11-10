using Microsoft.EntityFrameworkCore;
using YempoRespiriExam.Data;
using APIModels;

namespace YempoRespiriExam.Services
{
    public class PersonServices : IPersonServices
    {
        private readonly DataContext dataContext;

        public PersonServices(DataContext dataContext )
        {
            this.dataContext = dataContext;
        }

        public Task<List<Person>> Get()
        {
            return dataContext.Person.ToListAsync();
        }
        public Task<Person> GetPerson(string id)
        {
            var person = dataContext.Person.FirstAsync(s => s.Id == Guid.Parse(id));
            return person;
        }
    }
}
