using System.ComponentModel.DataAnnotations;

namespace Rifa_On.Data.Dtos
{
    public class LoginUsuario
    {
        [Required]
        public string UserName { get; set; }
        [Required] 
        public string Password { get; set; }
    }
}
