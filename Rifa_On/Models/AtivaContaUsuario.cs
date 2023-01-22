using System.ComponentModel.DataAnnotations;

namespace Rifa_On.Models
{
    public class AtivaContaUsuario
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CodigoAtivacao { get; set; }
    }
}
