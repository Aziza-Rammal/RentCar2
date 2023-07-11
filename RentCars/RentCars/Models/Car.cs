using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCars.Models
{
    [Table("Car", Schema = "dbo")]
    public class Car
    {
        [Key]
        [Display(Name = "Car ID")]
        public int CarId { get; set; }


        [Column(TypeName = "varchar(30)")]
        [Display(Name = "Type car")]
        public string Type { get; set; }


        [Column(TypeName = "varchar(20)")]
        [Display(Name = "Engine Capacity")]
        public string EngCapacity { get; set; }


        [Column(TypeName = "varchar(10)")]
        [Display(Name = "Color")]
        public string Color { get; set; }


        [Column(TypeName = "int")]
        [Display(Name = "Daily Rent")]

        public int Price { get; set; }


        [Column(TypeName = "varchar(20)")]
        [Display(Name = "Driver")]
        public string DriveStatus { get; set; }


    }


}
