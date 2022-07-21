using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace BlogMongoDB.Models
{
    public class Publicacao
    {
        public Publicacao()
        {
            Tags = new List<string>();
            DataCriacao = DateTime.UtcNow;
            Comentarios = new List<Comentario>();
        }

        public Publicacao(string autor, string titulo, string conteudo, string tags)
        {
            Autor = autor;
            Titulo = titulo;
            Conteudo = conteudo;

            string[] vet = tags.Split(',', ';');
            Tags = new List<string>();
            foreach (string tag in vet)
                Tags.Add(tag);

            DataCriacao = DateTime.UtcNow;
            Comentarios = new List<Comentario>();
        }


        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Autor { get; private set; }
        public string Titulo { get; private set; }
        public string Conteudo { get; private set; }
        public List<string> Tags { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public List<Comentario> Comentarios { get; private set; }
    }
}
