using System;

namespace Lunch.Person.Domain
{
    public class Person
    {
        public Guid PersonId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public Account Account { get; set; }
    }
}
