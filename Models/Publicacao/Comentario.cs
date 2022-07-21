using System;

namespace BlogMongoDB.Models
{
    public class Comentario
    {
        public string Autor { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
