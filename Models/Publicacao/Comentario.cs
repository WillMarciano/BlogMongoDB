using System;

namespace BlogMongoDB.Models
{
    public class Comentario
    {
        public Comentario(string autor, string conteudo)
        {
            Autor = autor;
            Conteudo = conteudo;
            DataCriacao = DateTime.UtcNow;
        }

        public string Autor { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
