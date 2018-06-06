using System;

namespace Lunch.Person.Sql
{
    public class PhoneNumber
    {
        public Guid PersonId { get; set; }
        public string Number { get; set; }
        public bool IsVerified { get; set; }
        public int VerificationCode { get; set; }
        public DateTime VerificationCodeCreatedDate { get; set; }
    }
}
