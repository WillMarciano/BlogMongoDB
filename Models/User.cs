using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogMongoDB.Models
{
    public class User
    {
        [Required(ErrorMessage ="Campo {0} obrigatório")]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatório")]
        [DisplayName("Senha")]
        public string Password { get; set; }
    }
}
