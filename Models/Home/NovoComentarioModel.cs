using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BlogMongoDB.Models
{
    public class NovoComentarioModel
    {
        [HiddenInput(DisplayValue = false)]
        public string PublicacaoId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Comentário")]
        public string Conteudo { get; set; }
    }
}
