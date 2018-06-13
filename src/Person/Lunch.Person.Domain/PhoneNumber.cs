using System;

namespace Lunch.Person.Domain
{
    public class PhoneNumber
    {
        public string Number { get; set; }
        public bool IsVerified { get; set; }
        public int? VerificationCode { get; set; }
        public DateTime? VerificationCodeCreatedDate { get; set; }

    }
}
