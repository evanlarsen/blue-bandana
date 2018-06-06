using Domain = Lunch.Person.Domain;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lunch.Person.Sql
{
    public class PersonRepository : Domain.IPersonRepository
    {
        private readonly PersonContext personContext;
        private readonly PersonMapper personMapper;

        public PersonRepository(PersonContext personContext)
        {
            this.personContext = personContext;
            personMapper = new PersonMapper();
        }

        public Task Add(Domain.Person dPers)
        {
            Person person = personMapper.MapToEntity(dPers);
            personContext.People.Add(person);
            return personContext.SaveChangesAsync();
        }

        public async Task<Domain.Person> Get(Guid id)
        {
            var person = await personContext.People
                .Include(c => c.Account)
                .Include(c => c.PhoneNumber)
                .AsNoTracking()
                .SingleOrDefaultAsync(c => c.PersonId == id);
            var dPers = personMapper.MapFromEntity(person);
            return dPers;
        }

        public async Task Update(Domain.Person dPers)
        {
            var person = await personContext.People
                .Include(c => c.Account)
                .Include(c => c.PhoneNumber)
                .SingleOrDefaultAsync();

            personMapper.MapToEntity(ref person, dPers);
            await personContext.SaveChangesAsync();
        }
    }
}
