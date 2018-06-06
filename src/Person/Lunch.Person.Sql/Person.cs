using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lunch.Person.Sql
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PersonId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public Account Account { get; set; }
    }
}
