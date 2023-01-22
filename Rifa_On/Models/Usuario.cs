using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rifa_On.Models
{
    public class Usuario
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Username")]
        [Required]
        [MaxLength(150)]
        public string Username { get; set; } = string.Empty;
        [Column("Email")]
        [Required]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;
        [Column("PhoneNumber")]
        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
