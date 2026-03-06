using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIsNET.Domain.Model.CompanyAggregate
{
    [Table("company", Schema = "lavajato")]
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
