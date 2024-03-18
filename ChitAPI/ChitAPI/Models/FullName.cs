using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChitAPI.Models
{
    [Owned]
    public class FullName
    {
        [Column("FirstName",TypeName ="varchar(100)")]
        [Required]
        [RegularExpression("^[a-zA-Z]{5,25}$", ErrorMessage = "First Name Should be in alphabets within the range of 5,25")]

        public required string FirstName { get; set; }
        [Column("LastName", TypeName = "varchar(100)")]
        [Required]
        [RegularExpression("^[a-zA-Z]{5,25}$", ErrorMessage = "Last Name Should be in alphabets within the range of 5,25")]

        public required string LastName { get; set; }
        [Column("MiddleName", TypeName = "varchar(100)")]
        [RegularExpression("^[a-zA-Z]{5,25}$", ErrorMessage = "Last Name Should be in alphabets within the range of 5,25")]

        public required string MiddleName  { get; set; }
    }
}
