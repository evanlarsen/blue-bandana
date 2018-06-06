using Domain = Lunch.Person.Domain;

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
            person.Account = MapAccount(dPers.Account);
            person.AccountId = person.Account.AccountId;
            person.CompanyLocationId = dPers.CompanyLocationId;
            person.PersonId = dPers.PersonId;
            person.Email = dPers.Email;
            person.IsOfficeManager = dPers.IsOfficeManager;
            person.Name = dPers.Name;
            person.PhoneNumber = MapPhoneNumber(dPers.PhoneNumber);
            person.PhoneNumberId = person.PhoneNumber.PhoneNumberId;
        }

        private Account MapAccount(Domain.Account dAcct)
        {
            var account = new Account();
            account.AccountId = dAcct.AccountId;
            account.Password = dAcct.Password;
            return account;
        }

        private PhoneNumber MapPhoneNumber(Domain.PhoneNumber dPn)
        {
            var phoneNumber = new PhoneNumber();
            phoneNumber.Number = dPn.Number;
            phoneNumber.IsVerified = dPn.IsVerified;
            phoneNumber.PhoneNumberId = dPn.PhoneNumberId;
            phoneNumber.VerificationCode = dPn.VerificationCode;
            return phoneNumber;
        }

        public Domain.Person MapFromEntity(Person person)
        {
            var dPers = new Domain.Person();
            dPers.Account = MapAccount(person.Account);
            dPers.CompanyLocationId = person.CompanyLocationId;
            dPers.PersonId = person.PersonId;
            dPers.Email = person.Email;
            dPers.IsOfficeManager = person.IsOfficeManager;
            dPers.Name = person.Name;
            dPers.PhoneNumber = MapPhoneNumber(person.PhoneNumber);

            return dPers;
        }

        private Domain.PhoneNumber MapPhoneNumber(PhoneNumber phoneNumber)
        {
            var dPn = new Domain.PhoneNumber();
            dPn.Number = phoneNumber.Number;
            dPn.IsVerified = phoneNumber.IsVerified;
            dPn.PhoneNumberId = phoneNumber.PhoneNumberId;
            dPn.VerificationCode = phoneNumber.VerificationCode;
            return dPn;
        }

        private Domain.Account MapAccount(Account account)
        {
            var dAcct = new Domain.Account();
            dAcct.AccountId = account.AccountId;
            dAcct.Password = account.Password;
            return dAcct;
        }
    }
}
