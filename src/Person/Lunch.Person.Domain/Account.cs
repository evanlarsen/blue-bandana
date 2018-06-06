using System;

namespace Lunch.Person.Domain
{
    public class Account
    {
        public string Password { get; set; }

        public bool Signin(string guess)
        {
            return string.Equals(Password, guess);
        }
    }
}
