namespace Lunch.Company.Domain.Dtos
{
    public class CreateNewCompanyDto
    {
        public string Name { get; set; }
        public int CompanySizeId { get; set; }
        public AddressDto Address { get; set; }
    }
}
