using BlogMongoDB.Models;
using MongoDB.Driver;

namespace BlogMongoDB.Data
{
    public class AcessoMongoDB
    {
        public const string StringConnection = "mongodb://localhost:27017";
        public const string NomeDatabase = "Blog";

        private static readonly IMongoClient _cliente;
        private static readonly IMongoDatabase _BaseDeDados;

        static AcessoMongoDB()
        {
            _cliente = new MongoClient(StringConnection);
            _BaseDeDados = _cliente.GetDatabase(NomeDatabase);
        }

        public IMongoClient Cliente => _cliente;
        public IMongoCollection<User> Usuarios => _BaseDeDados.GetCollection<User>("Users");
        public IMongoCollection<Publicacao> Publicacoes => _BaseDeDados.GetCollection<Publicacao>("Publicacoes");

    }
}
