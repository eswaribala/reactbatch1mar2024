using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChitAPI.Models
{
    [Table("Chit")]
    public class Chit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Chit_Id",TypeName ="bigint")]
        public long ChitId { get; set; }
        [Column("Chit_Value", TypeName = "bigint")]
        public long ChitValue { get; set; }
        [Column("Total_Duration")]
        public int TotalDuration { get; set; }
        [Column("Installment_Amount", TypeName = "bigint")]
        public long InstallmentAmount {  get; set; }

        [ForeignKey("Customer")]
        [Column("Customer_Id_FK")]
        public long CustomerId { get; set; }
        public required Customer Customer { get; set; }
       


    }
}
