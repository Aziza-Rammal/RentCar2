using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCars.Models
{
    [Table("Client", Schema = "dbo")]
    public class Client
    {
        [Key]
        [Display(Name = "Phone Number")]
        public int Phone { get; set; }


        [Column(TypeName = "varchar(40)")]
        [Display(Name = "FullName")]
        public string FullName { get; set; }


        [Column(TypeName = "varchar(40)")]
        [Display(Name = "Addrees")]
        public string Addrees { get; set; }

    }
}
