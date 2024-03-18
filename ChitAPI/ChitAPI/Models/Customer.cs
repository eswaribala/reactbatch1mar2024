using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChitAPI.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Customer_Id",TypeName ="bigint")]
        public long Id { get; set; }    
        public required FullName Name { get; set; }
        [Column("Email", TypeName = "varchar(200)")]

        public required string Email { get; set; }
        [Column("Password", TypeName = "varchar(10)")]
        public required string Password { get; set; }
        [Column("Phone", TypeName = "bigint")]
        public long Phone { get; set; }
    }
}
