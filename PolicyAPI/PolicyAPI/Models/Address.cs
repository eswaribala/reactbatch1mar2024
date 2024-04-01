using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PolicyAPI.Models
{
    [Table("Address")]
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Address_Id")]
        public long AddressId {  get; set; }
        [Column("Door_No")]
        public string DoorNo { get; set; }
        [Column("Street_Name")]
        public string StreetName {  get; set; }
        [Column("City")]
        public string City { get; set; }
        [Column("State")]
        public string State { get; set; }
        [Column("Country")]
        public string Country { get; set; }
        [Column("Postal_Code")]
        public long PostalCode { get; set; }


        [ForeignKey("PolicyHolder")]
        [Column("AdharCard_No_FK")]
        public string AdharCardNo {  get; set; }

        public PolicyHolder PolicyHolder { get; set; }



    }
}
