using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChitAPI.Models
{
    [Table("Chit_Transaction")]
    public class ChitTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Chit_Transaction_Id",TypeName ="bigint")]
        public long TransactionId { get; set;}
        [Column("Due_Amount", TypeName = "bigint")]
        public long DueAmount {  get; set;}

        [Column("Next_Auction_Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM dd yyyy}")]
        public DateTime NextAuctionDate { get; set;}
        [Column("Duration")]
        public long Duration {  get; set;}

        [ForeignKey("Chit")]
        [Column("Chit_Id_FK")]
        public long ChitId { get; set; }
        public required Chit Chit { get; set; }
    }
}
