using System.ComponentModel.DataAnnotations;

namespace BlogMongoDB.Models
{
    public class NovaPublicacaoModel
    {
        public NovaPublicacaoModel() { }
        public NovaPublicacaoModel(string titulo, string conteudo, string tags)
        {
            Titulo = titulo;
            Conteudo = conteudo;
            Tags = tags;
        }

        [Required(ErrorMessage = "* Campo {0} obrigatório")]
        [DataType(DataType.Text)]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage ="* Campo {0} obrigatório")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Conteúdo")]
        public string Conteudo { get; set; }

        [Required(ErrorMessage = "* Campo {0} obrigatório")]
        [DataType(DataType.Text)]
        [Display(Name = "Tag")]
        public string Tags { get; set; }
    }
}
