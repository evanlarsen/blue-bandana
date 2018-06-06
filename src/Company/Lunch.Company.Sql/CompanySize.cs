using System.ComponentModel.DataAnnotations.Schema;

namespace Lunch.Company.Sql
{
    public class CompanySize
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanySizeId { get; set; }
        public int From { get; set; }
        public int To { get; set; }
    }
}
