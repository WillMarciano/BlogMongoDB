using BlogMongoDB.Models;
using System.Collections.Generic;

namespace BlogMongoDB
{
    public class IndexModel
    {
        public IndexModel() { }
        public IndexModel(List<Publicacao> publicacoesRecentes) => PublicacoesRecentes = publicacoesRecentes;

        public List<Publicacao> PublicacoesRecentes { get; private set; }
    }
}
