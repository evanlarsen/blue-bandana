using System;

namespace Lunch.Person.Sql
{
    public class PhoneNumber
    {
        public Guid PhoneNumberId { get; set; }
        public string Number { get; set; }
        public bool IsVerified { get; set; }
        public int VerificationCode { get; set; }
    }
}
