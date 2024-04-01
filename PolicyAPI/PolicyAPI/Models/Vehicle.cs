using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PolicyAPI.Models
{
    public enum FuelType
    {
        PETROL,DIESEL,ELECTRIC,GAS
    }

    [Table("Vehicle")]
    public class Vehicle
    {
        [Key]
        [Column("Registration_No")]
        public string RegistrationNo {  get; set; }
        [Column("Maker")]
        public string Maker {  get; set; }
        [Column("DOR")]
        [DataType(DataType.Date)]
        public DateTime DOR {  get; set; }
        [Column("Engine_No")]
        public string EngineNo {  get; set; }
        [Column("Chasis_No")]
        public string ChasisNo {  get; set; }
        [Column("Color")]
        public string Color {  get; set; }
        [Column("Fuel_Type")]
        public FuelType FuelType { get; set;}

    }
}
