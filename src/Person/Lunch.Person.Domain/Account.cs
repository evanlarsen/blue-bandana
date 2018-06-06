using System;

namespace Lunch.Person.Domain
{
    public class Account
    {
        public Guid AccountId { get; set; }
        public string Password { get; set; }

        public bool Signin(string guess)
        {
            return string.Equals(Password, guess);
        }
    }
}
