using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCars.Models
{

    [Table("Rent", Schema = "dbo")]
    public class Rent
    {
        [Key]
        [Display(Name = "Rent Id")]
        public int RentId { get; set; }



        [ForeignKey("Client")]
        
        public int Phone { get; set; }


        [ForeignKey("Car")]
        public int CarId { get; set; }




        public virtual Client Client { get; set; }
        public virtual Car Car { get; set; }

    }
}
