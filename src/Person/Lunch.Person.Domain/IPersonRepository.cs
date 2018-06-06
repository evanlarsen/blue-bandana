using System;
using System.Threading.Tasks;

namespace Lunch.Person.Domain
{
    public interface IPersonRepository
    {
        Task<Person> Get(Guid id);
        Task Add(Person person);
        Task Update(Person person);
    }
}
