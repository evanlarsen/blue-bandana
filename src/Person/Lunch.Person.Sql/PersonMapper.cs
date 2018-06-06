using System;

namespace Lunch.Person.Sql
{
    public class PersonMapper
    {
        public Person MapToEntity(Domain.Person dPers)
        {
            var person = new Person();
            MapToEntity(ref person, dPers);
            return person;
        }

        public void MapToEntity(ref Person person, Domain.Person dPers)
        {
            person.Account = MapAccount(dPers.Account, dPers.PersonId);
            person.PersonId = dPers.PersonId;
            person.Email = dPers.Email;
            person.Name = dPers.Name;
            person.PhoneNumber = MapPhoneNumber(dPers.PhoneNumber, dPers.PersonId);
        }

        private Account MapAccount(Domain.Account dAcct, Guid personId)
        {
            var account = new Account();
            account.PersonId = personId;
            account.Password = dAcct.Password;
            return account;
        }

        private PhoneNumber MapPhoneNumber(Domain.PhoneNumber dPn, Guid personId)
        {
            var phoneNumber = new PhoneNumber();
            phoneNumber.PersonId = personId;
            phoneNumber.Number = dPn.Number;
            phoneNumber.IsVerified = dPn.IsVerified;
            phoneNumber.VerificationCode = dPn.VerificationCode;
            phoneNumber.VerificationCodeCreatedDate = dPn.VerificationCodeCreatedDate;
            return phoneNumber;
        }

        public Domain.Person MapFromEntity(Person person)
        {
            var dPers = new Domain.Person();
            dPers.PersonId = person.PersonId;
            dPers.Email = person.Email;
            dPers.Name = person.Name;
            dPers.PhoneNumber = MapPhoneNumber(person.PhoneNumber);
            dPers.Account = MapAccount(person.Account);
            return dPers;
        }

        private Domain.PhoneNumber MapPhoneNumber(PhoneNumber phoneNumber)
        {
            var dPn = new Domain.PhoneNumber();
            dPn.Number = phoneNumber.Number;
            dPn.IsVerified = phoneNumber.IsVerified;
            dPn.VerificationCode = phoneNumber.VerificationCode;
            dPn.VerificationCodeCreatedDate = phoneNumber.VerificationCodeCreatedDate;
            return dPn;
        }

        private Domain.Account MapAccount(Account account)
        {
            var dAcct = new Domain.Account();
            dAcct.Password = account.Password;
            return dAcct;
        }
    }
}
